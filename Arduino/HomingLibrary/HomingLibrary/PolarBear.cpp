// 
// 
// 

#include "PolarBear.h"

PolarBear::PolarBear(QuadratureMotor* tiltMotor, QuadratureMotor* rotationMotor, StepperMotor* extensionMotor, EndEffector* endEffector)
{
	this->tiltMotor = tiltMotor;
	this->rotationMotor = rotationMotor;
	this->extensionMotor = extensionMotor;
	this->endEffector = endEffector;

	serialJSON = new SerialJSON();
}

void PolarBear::update()
{
	handleNewCommand();
	updateComponents();
	//handleRunningCommand();
	
}

void PolarBear::updateComponents()
{
	tiltMotor->update();
	rotationMotor->update();
	extensionMotor->update();
}

void PolarBear::handleRunningCommand()
{
	if (isRunning)
	{
		if (serialJSON->isEqual(runType, TYPE_TILT))
		{
			if (tiltMotor->isStopped())
			{
				stopRunning();
			}
		}
		else if (serialJSON->isEqual(runType, TYPE_ROTATION))
		{
			if (rotationMotor->isStopped())
			{
				stopRunning();
			}
		}
		else if (serialJSON->isEqual(runType, TYPE_EXTENSION))
		{
			if (extensionMotor->isStopped())
			{
				stopRunning();
			}
		}
		else if (serialJSON->isEqual(runType, TYPE_HOME))
		{
			if (serialJSON->isEqual(homeComponentType, TYPE_TILT) && tiltMotor->isStopped())
			{
				stopRunning();
			}
			else if (serialJSON->isEqual(homeComponentType, TYPE_ROTATION) && rotationMotor->isStopped())
			{
				stopRunning();
			}
			else if (serialJSON->isEqual(homeComponentType, TYPE_EXTENSION) && extensionMotor->isStopped())
			{
				stopRunning();
			}
		}
	}
}


void PolarBear::handleNewCommand()
{
	DynamicJsonDocument commandJSON = serialJSON->readCommand();

	if (!commandJSON.isNull())
	{
		char* command = commandJSON[COMMAND];
		if (serialJSON->isEqual(command, COMMAND_OPEN))
		{
			serialJSON->sendStatus(STATUS_OPENED);
		}
		else if (serialJSON->isEqual(command, COMMAND_RUN))
		{
			handleRun(commandJSON);
		}
		else if (serialJSON->isEqual(command, COMMAND_FINISHED))
		{
			serialJSON->sendStatus(STATUS_READY);
		}
		else if (serialJSON->isEqual(command, COMMAND_STOP))
		{
			serialJSON->sendStatus(STATUS_STOPPED);
		}
		else if (serialJSON->isEqual(command, COMMAND_CLOSE))
		{
			tiltMotor->stop();
			rotationMotor->stop();
			/*
			tiltMotor->setState(Motor::STATE::STOP);
			rotationMotor->setState(Motor::STATE::STOP);
			extensionMotor->setState(Motor::STATE::STOP);
			*/
			serialJSON->sendStatus(STATUS_CLOSED);
		}
	}
}

void PolarBear::handleRun(DynamicJsonDocument commandJSON)
{


	JsonObject stepJSON = commandJSON["Step"];
	runType = stepJSON["Type"];

	/*
	serializeJsonPretty(stepJSON, Serial);
	Serial.println(";");
	*/
	isRunning = true;
	if (serialJSON->isEqual(runType, TYPE_TILT))
	{
		handleTiltRun(stepJSON);
	}
	else if (serialJSON->isEqual(runType, TYPE_DELAY))
	{
		handleDelayRun(stepJSON);
	}
	else if (serialJSON->isEqual(runType, TYPE_HOME))
	{
		handleHomeRun(stepJSON);
	}
	else if (serialJSON->isEqual(runType, TYPE_ROTATION))
	{
		handleRotationRun(stepJSON);
	}
	else if (serialJSON->isEqual(runType, TYPE_EXTENSION))
	{
		handleExtensionRun(stepJSON);
	}
	else if (serialJSON->isEqual(runType, TYPE_END_EFFECTOR))
	{
		handleEndEffectorRun(stepJSON);
	}
	else
	{
		Serial.println("Unknown Step Type;");
		stopRunning();
	}

	/*
	serializeJsonPretty(docStep, Serial);
	Serial.println(";");
	delay(2000);
	serialJSON->sendStatus(STATUS_WAITING);
	*/
}

void PolarBear::handleTiltRun(JsonObject stepJSON)
{
	/*
	char* degreesString = stepJSON[VALUE_DEGREES];
	double degrees = atof(degreesString);
	*/
	double degrees = stepJSON[VALUE_DEGREES];
	//tiltMotor->setTargetPositionRelativeDegrees(degrees);
	//tiltMotor->setState(Motor::STATE::MOVE);
	tiltMotor->moveToTargetDegrees(degrees);
	stopRunning();
}

void PolarBear::handleRotationRun(JsonObject stepJSON)
{

	/*
	char* degreesString = stepJSON[VALUE_DEGREES];
	double degrees = atof(degreesString);
	*/
	double degrees = stepJSON[VALUE_DEGREES];
	//rotationMotor->setTargetPositionRelativeDegrees(degrees);
	//rotationMotor->setState(Motor::STATE::MOVE);
	rotationMotor->moveToTargetDegrees(degrees);
	stopRunning();
}

void PolarBear::handleExtensionRun(JsonObject stepJSON)
{
	/*
	char* distanceString = stepJSON[VALUE_DISTANCE];
	double distance = atof(distanceString);
	*/
	double distance = stepJSON[VALUE_DISTANCE];
	extensionMotor->setTargetPositionRelativeDegrees(distance);
	extensionMotor->setState(Motor::STATE::MOVE);
}

void PolarBear::handleHomeRun(JsonObject stepJSON)
{
	homeComponentType = stepJSON[VALUE_COMPONENT];
	if (serialJSON->isEqual(homeComponentType, TYPE_TILT))
	{
		//tiltMotor->setState(Motor::STATE::HOME);
		tiltMotor->homeBasic();
	}
	else if (serialJSON->isEqual(homeComponentType, TYPE_ROTATION))
	{
		//rotationMotor->setState(Motor::STATE::HOME);
		rotationMotor->homeBasic();
	}
	else if (serialJSON->isEqual(homeComponentType, TYPE_EXTENSION))
	{
		//extensionMotor->setState(Motor::STATE::HOME);
	}
	else
	{	
		Serial.println("Unknown Home Component;");
	}
	stopRunning();
}

void PolarBear::handleDelayRun(JsonObject stepJSON)
{
	int length = stepJSON[VALUE_LENGTH];
	delay(length);
	stopRunning();
}

void PolarBear::handleEndEffectorRun(JsonObject stepJSON)
{
	/*
	char* tiltDegreesString = stepJSON[VALUE_TILT_DEGREES];
	char* rotationDegreesString = stepJSON[VALUE_ROTATION_DEGREES];
	double tiltDegrees = atof(tiltDegreesString);
	double rotationDegrees = atof(rotationDegreesString);
	*/
	double tiltDegrees = stepJSON[VALUE_TILT_DEGREES];
	double rotationDegrees = stepJSON[VALUE_ROTATION_DEGREES];
	endEffector->move(tiltDegrees, rotationDegrees);
	stopRunning();
}

void PolarBear::handleStop()
{
	tiltMotor->setState(Motor::STATE::STOP);
	rotationMotor->setState(Motor::STATE::STOP);
	extensionMotor->setState(Motor::STATE::STOP);
}

void PolarBear::stopRunning()
{
	isRunning = false;
	serialJSON->sendStatus(STATUS_WAITING);
}
