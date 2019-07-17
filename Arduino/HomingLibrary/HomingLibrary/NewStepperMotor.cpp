// 
// 
// 

#include "NewStepperMotor.h"


NewStepperMotor::NewStepperMotor(int stepPin, int directionPin, int limitPin)
{
	this->stepPin = stepPin;
	this->directionPin = directionPin;

	pinMode(stepPin, OUTPUT);
	pinMode(directionPin, OUTPUT);

	digitalWrite(stepPin, LOW);
	digitalWrite(directionPin, LOW);

	limitSwitch = new LimitSwitch(limitPin);

	targetPosition = 0;
}

void NewStepperMotor::moveManual()
{
	if (Serial.available())
	{
		char input = Serial.read();
		if (input == 'f')
		{
			Serial.println("Moving forward");
		}
		else if (input == 'b')
		{
			Serial.println("Moving Backward");
		}

		for (int i = 0; i <= MANUAL_STEPS; i++)
		{
			if (input == 'f')
			{
				step(STEPPER_FORWARD);
			}
			else if (input == 'b')
			{
				step(STEPPER_BACKWARD);
			}

		}
		delay(500);
		Serial.println("Done");
	}
}

void NewStepperMotor::moveIncremental()
{
	digitalWrite(directionPin, HIGH);
	for (int x = 0; x < 200; x++) {
		noInterrupts();
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
		interrupts();
	}
	delay(5000);
	digitalWrite(directionPin, LOW);
	for (int x = 0; x < 200; x++) {
		noInterrupts();
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
		interrupts();
	}
	delay(5000);
}

void NewStepperMotor::home()
{
	setState(STOP);
}

void NewStepperMotor::move()
{
	if (targetPosition == currentPosition)
	{
		setState(STOP);
	}
	else
	{
		int direction = targetPosition > currentPosition ? STEPPER_FORWARD : STEPPER_BACKWARD;
		step(direction);
	}

}

void NewStepperMotor::step(int direction)
{
	noInterrupts();
	digitalWrite(directionPin, direction);

	digitalWrite(stepPin, HIGH);
	delayMicroseconds(PULSE_DELAY);
	digitalWrite(stepPin, LOW);
	delayMicroseconds(PULSE_DELAY);
	interrupts();
	if (direction == HIGH)
	{
		currentPosition++;
	}
	else
	{
		currentPosition--;
	}
}
