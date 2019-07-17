// 
// 
// 

#include "StepperMotor.h"


StepperMotor::StepperMotor(int stepPin, int directionPin, int limitPin)
{
	this->stepPin = stepPin;
	this->directionPin = directionPin;

	pinMode(stepPin, OUTPUT);
	pinMode(directionPin, OUTPUT);

	digitalWrite(stepPin, LOW);
	digitalWrite(directionPin, LOW);

	limitSwitch = new LimitSwitch(limitPin);
	
	position = 0;
}



void StepperMotor::step(int direction)
{
	digitalWrite(directionPin, direction);
	for (int i = 0; i < 1; i++) 
	{
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(FUCKED_PULSE_DELAY);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(FUCKED_PULSE_DELAY);
		if (direction == HIGH)
		{
			position++;
		}
		else
		{
			position--;
		}
	}

}

void StepperMotor::home()
{
	Serial.println("Homing Stepper");
	Serial.println("Moving Forward");

	Serial.println("Waiting on press");
	bool isPressed;
	do
	{
		step(FUCKED_FORWARD);
		limitSwitch->update();
		isPressed = limitSwitch->pressed();
	} while (!isPressed);
	Serial.println("Pressed");
	delay(FUCKED_STOP_DELAY);
	Serial.println("Moving Backward");

	Serial.println("Waiting on release");
	bool isReleased;
	do
	{
		step(FUCKED_BACKWARD);
		limitSwitch->update();
		isReleased = limitSwitch->released();
	} while (!isReleased);
	Serial.println("Released");
	Serial.println("Stopping");
	position = 0;
	
}

void StepperMotor::testLimitSwitch()
{
	limitSwitch->test("Test");
}

void StepperMotor::test()
{
	digitalWrite(directionPin, HIGH);
	for (int x = 0; x < 200; x++) {
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
	}
	delay(200);
	digitalWrite(directionPin, LOW);
	for (int x = 0; x < 200; x++) {
		digitalWrite(stepPin, HIGH);
		delayMicroseconds(1000);
		digitalWrite(stepPin, LOW);
		delayMicroseconds(1000);
	}
	delay(200);
}

void StepperMotor::testTravelDistance(int count, int steps)
{
	int* distances = new int[count];
	for (int i = 0; i < count; i++)
	{
		Serial.print("Test ");
		Serial.print(i + 1);
		Serial.print(" of ");
		Serial.println(count);
		distances[i] = getTravelDistance(steps);
	}

	float sum;
	for (int i = 0; i < count; i++)
	{
		Serial.print("Test #");
		Serial.print(i + 1);
		Serial.print(": ");
		Serial.println(distances[i]);
		sum += distances[i];
	}

	float average = sum / count;
	Serial.print("Average: ");
	Serial.println(average);
}

int StepperMotor::getTravelDistance(int steps)
{
	bool isPressed;
	do
	{
		step(FUCKED_FORWARD);
		limitSwitch->update();
		isPressed = limitSwitch->pressed();
	} while (!isPressed);
	delay(FUCKED_STOP_DELAY);
	bool isReleased;
	do
	{
		step(FUCKED_BACKWARD);
		limitSwitch->update();
		isReleased = limitSwitch->released();
	} while (!isReleased);
	position = 0;
	do
	{
		step(FUCKED_BACKWARD);
	} while (abs(position) < steps);
	delay(FUCKED_STOP_DELAY);
	do
	{
		step(FUCKED_FORWARD);
		limitSwitch->update();
		isPressed = limitSwitch->pressed();
	} while (!isPressed);
	return steps - abs(position);

}

void StepperMotor::testIncremental(int steps)
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

		for (int i = 0; i <= steps; i++)
		{
			if (input == 'f')
			{
				step(HIGH);
			}
			else if (input == 'b')
			{
				step(LOW);
			}
			
		}
		delay(500);
		Serial.println("Done");
	}
}

