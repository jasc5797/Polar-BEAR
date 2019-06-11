// 
// 
// 

#include "QuadratureMotor.h"


QuadratureMotor::QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1)
{
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
}

// int between -255 and 255
void QuadratureMotor::setSpeed(int speed)
{
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

void QuadratureMotor::limit1Interrupt()
{

}

void QuadratureMotor::limit2Interrupt()
{

}