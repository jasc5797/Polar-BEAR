// 
// 
// 

#include "QuadratureMotor.h"

QuadratureMotor::QuadratureMotor(int pwmPin, int dirPin, int encoderPinA, int encoderPinB, int limitPin1, int limitPin2)
{
	motor = new CytronMD(PWM_DIR, pwmPin, dirPin);
	encoder = new Encoder(encoderPinA, encoderPinB);
	limitSwitch1 = new LimitSwitch(limitPin1);
	limitSwitch2 = new LimitSwitch(limitPin2);
}

void QuadratureMotor::home()
{
	Serial.println("Homing");
	Serial.println("Moving Forward");
	motor->setSpeed(HOMING_SPEED);
	Serial.println("Waiting on Press");
	bool isPressed;
	do
	{	
		limitSwitch1->update();
		isPressed = limitSwitch1->pressed();
	} while (!isPressed);
	Serial.println("Pressed");
	Serial.println("Moving Backward");
	motor->setSpeed(HOMING_SPEED * -1);
	Serial.println("Waiting on Release");
	bool isReleased;
	do
	{
		limitSwitch1->update();
		isReleased = limitSwitch1->released();
	} while (!isReleased);
	Serial.println("Released");
	Serial.println("Stopping");
	motor->setSpeed(0);
	encoder->write(0);


	Serial.println("Testing second limit");
	Serial.println("Moving Backward");
	motor->setSpeed(HOMING_SPEED * -1);
	Serial.println("Waiting on Press");
	do
	{
		limitSwitch2->update();
		isPressed = limitSwitch2->pressed();
	} while (!isPressed);
	Serial.println("Pressed");
	Serial.println("Moving Forward");
	motor->setSpeed(HOMING_SPEED);
	Serial.println("Waiting on release");
	do
	{
		limitSwitch2->update();
		isReleased = limitSwitch2->released();
	} while (!isReleased);
	Serial.println("Released");
	Serial.println("Stopping");
	motor->setSpeed(0);
	Serial.println("Complete");


}

void QuadratureMotor::testLimitSwitch1()
{
	limitSwitch1->test("Test");
}

void QuadratureMotor::testLimitSwitch2()
{
	limitSwitch2->test("Test");
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
		Serial.println(distances[i]);
		sum += distances[i];
	}

	float average = sum / count;
	Serial.print("Average: ");
	Serial.println(average);
	Serial.print("Average Degrees: ");
	Serial.println((average / STEPS_PER_REVOLUTION) * 360);

	delete [] distances;
	distances = NULL;
}

int QuadratureMotor::getTravelDistance()
{
	motor->setSpeed(HOMING_SPEED);
	bool isPressed;
	do
	{
		limitSwitch1->update();
		isPressed = limitSwitch1->pressed();
	} while (!isPressed);
	motor->setSpeed(HOMING_SPEED * -1);
	bool isReleased;
	do
	{
		limitSwitch1->update();
		isReleased = limitSwitch1->released();
	} while (!isReleased);
	motor->setSpeed(0);
	encoder->write(0);

	motor->setSpeed(HOMING_SPEED * -1);
	do
	{
		limitSwitch2->update();
		isPressed = limitSwitch2->pressed();
	} while (!isPressed);
	motor->setSpeed(HOMING_SPEED);
	do
	{
		limitSwitch2->update();
		isReleased = limitSwitch2->released();
	} while (!isReleased);
	motor->setSpeed(0);
	return encoder->read();
}


void QuadratureMotor::testMove()
{
	int targetPos = 1000;
	encoder->write(0);
	motor->setSpeed(HOMING_SPEED);
	while (encoder->read() < targetPos);
	motor->setSpeed(0);
	delay(100);
	motor->setSpeed(-1 * HOMING_SPEED);
	while (encoder->read() > 0);
	motor->setSpeed(0);
}