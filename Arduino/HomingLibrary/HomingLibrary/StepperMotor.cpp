// 
// 
// 

#include "StepperMotor.h"


StepperMotor::StepperMotor(int stepPin, int directionPin, int limitPin, int sleepPin, int resetPin, char* name) : Motor(name)
{
	this->stepPin = stepPin;
	this->directionPin = directionPin;
	this->sleepPin = sleepPin;
	this->resetPin = resetPin;

	pinMode(stepPin, OUTPUT);
	pinMode(directionPin, OUTPUT);
	pinMode(sleepPin, OUTPUT);
	pinMode(resetPin, OUTPUT);

	digitalWrite(stepPin, LOW);
	digitalWrite(directionPin, LOW);
	digitalWrite(sleepPin, LOW);
	digitalWrite(resetPin, HIGH);

	limitSwitch = new LimitSwitch(limitPin);

	targetPosition = 0;
}

void StepperMotor::moveManual()
{
	if (Serial.available())
	{
		char input = Serial.read();
		Serial.print("Manual Moving ");
		Serial.println(name);
		if (input == 'f')
		{
			Serial.println("Moving Forward");
		}
		else if (input == 'b')
		{
			Serial.println("Moving Backward");
		}
		else
		{
			Serial.println("Unknown Command");
			return;
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

// Do not use
void StepperMotor::moveIncremental()
{
	digitalWrite(directionPin, HIGH);
	digitalWrite(sleepPin, HIGH);
	delay(WAKE_DELAY);
	for (int x = 0; x < 200; x++) {
		noInterrupts();
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
		interrupts();
	}
	digitalWrite(sleepPin, LOW);
	delay(5000);
	digitalWrite(directionPin, LOW);
	digitalWrite(sleepPin, HIGH);
	delay(WAKE_DELAY);
	for (int x = 0; x < 200; x++) {
		noInterrupts();
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
		interrupts();
	}
	digitalWrite(sleepPin, LOW);
	delay(5000);
}

void StepperMotor::home()
{
	setState(STOP);
}

void StepperMotor::move()
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

void StepperMotor::step(int direction)
{

	noInterrupts();
	digitalWrite(sleepPin, HIGH);
	delay(WAKE_DELAY);

	digitalWrite(directionPin, direction);

	digitalWrite(stepPin, HIGH);
	delayMicroseconds(PULSE_DELAY);
	digitalWrite(stepPin, LOW);
	delayMicroseconds(PULSE_DELAY);
	digitalWrite(sleepPin, LOW);

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
