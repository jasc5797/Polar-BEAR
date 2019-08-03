// 
// 
// 

#include "QuadratureMotor.h"

QuadratureMotor::QuadratureMotor(int pwmPin, int dirPin, int encoderPinA, int encoderPinB, int limitPin1, int limitPin2, char* name) : Motor(name)
{
	motor = new CytronMD(PWM_DIR, pwmPin, dirPin);
	encoder = new Encoder(encoderPinA, encoderPinB);
	limitSwitch1 = new LimitSwitch(limitPin1);
	if (limitPin2 != DISCONNECTED)
	{
		limitSwitch2 = new LimitSwitch(limitPin2);
		limitMode = TWO;
	}
	else
	{
		limitMode = ONE;
	}
}


void QuadratureMotor::setState(STATE state)
{
	Motor::setState(state);
	switch (state)
	{
		case HOME:
			homeState = START;
			break;
		case ERROR:
			break;
		default:
			break;
	}
}

void QuadratureMotor::home()
{
	switch (homeState)
	{
		case START:
			bool isPressed = moveUntilPressed(limitSwitch1, HOMING_SPEED, MOTOR_FORWARD);
			if (isPressed)
			{
				homeState = PRESSED;
			}
			break;
		case PRESSED:
			bool isReleased = moveUntilReleased(limitSwitch1, RELEASE_SPEED, MOTOR_BACKWARD);
			if (isReleased)
			{
				homeState = RELEASED;
			}
			break;
		case RELEASED:
			encoder->write(0);
			homeState = COMPLETED;
			break;
		case COMPLETED:
			setState(STOP);
			break;
		default:
			setSpeed(0);
			break;
	}
}

void QuadratureMotor::move()
{
	switch (limitMode)
	{
		case ONE:
			moveOneLimit();
			break;
		case TWO:
			moveTwoLimit();
			break;
		default:
			break;
	}
}

void QuadratureMotor::moveOneLimit()
{
	moveHelper(limitSwitch1);
}

void QuadratureMotor::moveTwoLimit()
{
	int currentPosition = encoder->read();
	LimitSwitch* limitSwitch = targetPosition > currentPosition ? limitSwitch1 : limitSwitch2;
	moveHelper(limitSwitch);
}

void QuadratureMotor::moveHelper(LimitSwitch* limitSwitch)
{
	int currentPosition = encoder->read();

	// Check if the motor is rougly in the right position
	if (isRoughlyEqual(currentPosition, targetPosition))
	{
		// Stop the motor if it is positioned right
		setState(STOP);

	}
	else
	{
		// Find which direction the motor has to move to get to the target position
		int direction = targetPosition > currentPosition ? MOTOR_FORWARD : MOTOR_BACKWARD;

		// Make sure the limitswitch is not pressed 
		limitSwitch->update();
		bool isPressed = limitSwitch->pressed();
		bool isReleased = true;
		if (isPressed)
		{
			// If the limit switch is pressed then back up the motor
			int releaseDirection = direction == MOTOR_FORWARD ? MOTOR_BACKWARD : MOTOR_FORWARD;
			isReleased = moveUntilReleased(limitSwitch, RELEASE_SPEED, releaseDirection);
		}
		if (isReleased)
		{
			// If the limit switch is released then move forward
			isPressed = moveUntilPressed(limitSwitch, HOMING_SPEED, direction);
		}
	}
}

void QuadratureMotor::setSpeed(int16_t speed)
{
	this->speed = speed;
	motor->setSpeed(speed);
}

bool QuadratureMotor::moveUntilPressed(LimitSwitch* limitSwitch, int16_t speed, int direction)
{
	limitSwitch->update();
	bool isPressed = limitSwitch->pressed();
	if (!isPressed)
	{
		setSpeed(speed * direction);
	}
	else
	{
		setSpeed(0);
	}
	return isPressed;
}

bool QuadratureMotor::moveUntilReleased(LimitSwitch* limitSwitch, int16_t speed, int direction)
{	
	limitSwitch->update();
	bool isReleased = limitSwitch->released();
	if (!isReleased)
	{
		setSpeed(speed * direction);
	}
	else
	{
		setSpeed(0);
	}
	return isReleased;
}

void QuadratureMotor::testTravelDistance(int count)
{
	int* distances = new int[count];
	for (int i = 0; i < count; i++)
	{
		Serial.print("Test ");
		Serial.print(i + 1);
		Serial.print(" of ");
		Serial.println(count);
		distances[i] = getTravelDistance();
	}

	float sum;
	for (int i = 0; i < count; i++)
	{
		Serial.print("Test #");
		Serial.print(i + 1);
		Serial.print(": ");
		Serial.print(distances[i]);
		Serial.print(" steps, ");
		Serial.print((distances[i] / MOTOR_STEPS_PER_REVOLUTION) * 360);
		Serial.println(" degrees");
		sum += distances[i];
	}

	float average = sum / count;
	float variance = 0;
	for (int i = 0; i < count; i++)
	{
		variance += ((distances[i] - average) * (distances[i] - average));
	}
	variance /= count;
	float standardDeviation = sqrt(variance);
	Serial.print("Average Steps: ");
	Serial.println(average);
	Serial.print("Average Degrees: ");
	Serial.println((average / MOTOR_STEPS_PER_REVOLUTION) * 360);
	Serial.print("Variance: ");
	Serial.println(variance);
	Serial.print("Standard Deviation: ");
	Serial.println(standardDeviation);

	delete[] distances;
	distances = NULL;
}

void QuadratureMotor::moveManual(char* name, char forward, char backward, int steps)
{

	if (Serial.available())
	{
		//char forward = !alternate ? 'l' : 'u';
		//char backward = !alternate ? 'r' : 'd';

		char input = Serial.read();
		int direction;
		LimitSwitch* limitSwitch;
		Serial.print(name);
		if (input == forward)
		{
			
			Serial.println(" moving forward");
			direction = MOTOR_FORWARD;
			limitSwitch = limitSwitch1;
		}
		else if (input == backward)
		{
			Serial.println(" moving Backward");
			direction = MOTOR_BACKWARD;
			if (limitMode == ONE)
			{
				limitSwitch = limitSwitch1;
			}
			else
			{
				limitSwitch = limitSwitch2;
			}
		}
		int startPos = encoder->read();
		bool isPressed;
		do
		{
			isPressed = moveUntilPressed(limitSwitch, HOMING_SPEED, direction);
		} while (abs(startPos - encoder->read()) < 200 && !isPressed);

		if (isPressed)
		{

			bool isReleased;
			do
			{
				int releaseDirection = direction == MOTOR_FORWARD ? MOTOR_BACKWARD : MOTOR_FORWARD;
				isReleased = moveUntilReleased(limitSwitch, RELEASE_SPEED, releaseDirection);
			} while (!isReleased);
		}
		setSpeed(0);

		Serial.println("Done");
	}
}

int QuadratureMotor::getTravelDistance()
{
	switch (limitMode)
	{
		case ONE:
			return getTravelDistanceOneLimit();
		case TWO:
			return getTravelDistanceTwoLimit();
		default:
			return 0;
	}
}

int QuadratureMotor::getTravelDistanceOneLimit()
{
	bool isLimitPressed;
	do
	{
		isLimitPressed = moveUntilPressed(limitSwitch1, HOMING_SPEED, MOTOR_FORWARD);
	} while (!isLimitPressed);

	bool isLimitReleased;
	do
	{
		isLimitReleased = moveUntilReleased(limitSwitch1, RELEASE_SPEED, MOTOR_BACKWARD);
	} while (!isLimitReleased);

	encoder->write(0);

	do
	{
		isLimitPressed = moveUntilPressed(limitSwitch1, HOMING_SPEED, MOTOR_BACKWARD);
	} while (!isLimitPressed);

	do
	{
		isLimitReleased = moveUntilReleased(limitSwitch1, RELEASE_SPEED, MOTOR_FORWARD);
	} while (!isLimitReleased);

	return encoder->read();
}

int QuadratureMotor::getTravelDistanceTwoLimit()
{
	// Move towards first limit switch
	bool isLimit1Pressed;
	do
	{
		isLimit1Pressed = moveUntilPressed(limitSwitch1, HOMING_SPEED, MOTOR_FORWARD);
	} while (!isLimit1Pressed);

	// 
	bool isLimit1Released;
	do
	{
		isLimit1Released = moveUntilReleased(limitSwitch1, RELEASE_SPEED, MOTOR_BACKWARD);
	} while (!isLimit1Released);

	encoder->write(0);

	bool isLimit2Pressed;
	do {
		isLimit2Pressed = moveUntilPressed(limitSwitch2, HOMING_SPEED, MOTOR_BACKWARD);
	} while (!isLimit2Pressed);

	bool isLimit2Released;
	do
	{
		isLimit2Released = moveUntilReleased(limitSwitch2, HOMING_SPEED, MOTOR_FORWARD);
	} while (!isLimit2Released);
	return encoder->read();
}
