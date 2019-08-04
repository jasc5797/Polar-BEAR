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
	handleCommand();
	//updateComponents();
	
}

void PolarBear::updateComponents()
{
	tiltMotor->update();
	rotationMotor->update();
	extensionMotor->update();
}


void PolarBear::handleCommand()
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
			JsonObject docStep = commandJSON["Step"];
			serializeJsonPretty(docStep, Serial);
			Serial.println(";");
			delay(2000);
			serialJSON->sendStatus(STATUS_WAITING);
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
			serialJSON->sendStatus(STATUS_CLOSED);
		}
	}
}
