// 
// 
// 

#include "QuadratureMotor.h"

QuadratureMotor::QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, DebounceLimitSwitch* limitSwitch)
{
	limitMode = ONE;
	this->limitSwitch1 = limitSwitch1;

	motor = new CytronMD(PWM_DIR, pwmPin, directionPin);
	encoder = new Encoder(encoderPinA, encoderPinB);
}

QuadratureMotor::QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1)
{
	/*
	if (limitPin1 < 0 && limitPin2 < 0)
	{
		limitMode = NONE;
	}
	else if (limitPin1 >= 0 && limitPin2 < 0)
	{
		limitMode = ONE;
		this->limitPin1 = limitPin1;
		pinMode(limitPin1, INPUT);
		attachInterrupt(digitalPinToInterrupt(limitPin1), QuadratureMotor::limit1Interrupt, CHANGE);
	}
	else if (limitPin1 >= 0 && limitPin2 >= 0)
	{
		limitMode = TWO;
		this->limitPin1 = limitPin1;
		this->limitPin2 = limitPin2; 
		pinMode(limitPin1, INPUT);
		pinMode(limitPin2, INPUT);
		attachInterrupt(digitalPinToInterrupt(limitPin1), QuadratureMotor::limit1Interrupt, CHANGE);
		attachInterrupt(digitalPinToInterrupt(limitPin2), QuadratureMotor::limit2Interrupt, CHANGE);
	}
	motor = new CytronMD(PWM_DIR, pwmPin, directionPin);
	encoder = new Encoder(encoderPinA, encoderPinB);
	*/
}

// int between -255 and 255
void QuadratureMotor::setSpeed(int speed)
{
	this->speed = speed;
	motor->setSpeed(speed);
}

void QuadratureMotor::write(int32_t newPosition)
{
	encoder->write(newPosition);
}

int32_t QuadratureMotor::read()
{
	return encoder->read();
}

bool QuadratureMotor::getIsLimit1Pressed()
{
	return isLimit1Pressed;
}

bool QuadratureMotor::getIsLimit2Pressed()
{
	return isLimit2Pressed;
}

void QuadratureMotor::limit1Interrupt()
{

}

void QuadratureMotor::limit2Interrupt()
{

}

bool QuadratureMotor::isMoving()
{
	return speed != 0;
}

void QuadratureMotor::home()
{
	limitSwitch1->Test();
	//Serial.println("Moving Forward");
	//setSpeed(100);
	//Serial.println(limitSwitch1->bounce.rose());
	//setSpeed(0);

	/*
	Serial.println("Moving forward");
	setSpeed(100);
	bool isPressed;
	do
	{
		delay(100);
		limitSwitch1->update();
		isPressed = limitSwitch1->bounce.rose();//isPressed();
		//Serial.println(limitSwitch1->bounce.read());
	} while (!isPressed);
	Serial.println("Limit Switch Pressed");
	setSpeed(-25);
	Serial.println("Moving Backward");
	do
	{
		delay(100);
		limitSwitch1->update();
		isPressed = limitSwitch1->bounce.fell();//isPressed();
		
	} while (!isPressed);
	Serial.println("Limit Switch Released");
	setSpeed(0);
	write(0);
	*/
}