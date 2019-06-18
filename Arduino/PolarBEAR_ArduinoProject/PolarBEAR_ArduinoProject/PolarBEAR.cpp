// 
// 
// 

#include "PolarBEAR.h"


PolarBear::PolarBear(QuadratureMotor* quadratureMotor1, QuadratureMotor* quadratureMotor2, StepperMotor* stepperMotr)
{
	this->quadratureMotor1 = quadratureMotor1;
	this->quadratureMotor2 = quadratureMotor2;

	this->stepperMotor = stepperMotor;
}

// Maybe move gets/sets to header to declutter this file
QuadratureMotor* PolarBear::getQuadratureMotor1()
{
	return quadratureMotor1;
}

void PolarBear::setQuadratureMotor1(QuadratureMotor* quadraturMotor1)
{
	this->quadratureMotor1 = quadratureMotor1;
}

void PolarBear::setQuadratureMotor1(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1)
{
	quadratureMotor1 = new QuadratureMotor(pwmPin, directionPin, encoderPinA, encoderPinB, limitPin1, limitPin2);
}

QuadratureMotor* PolarBear::getQuadratureMotor2()
{
	return quadratureMotor2;
}

void PolarBear::setQuadratureMotor2(QuadratureMotor* quadraturMotor2)
{
	this->quadratureMotor2 = quadratureMotor2;
}

void PolarBear::setQuadratureMotor2(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1)
{
	quadratureMotor2 = new QuadratureMotor(pwmPin, directionPin, encoderPinA, encoderPinB, limitPin1, limitPin2);
}

StepperMotor* PolarBear::getStepperMotor()
{
	return stepperMotor;
}

void PolarBear::setStepperMotor(StepperMotor* stepperMotor)
{
	this->stepperMotor = stepperMotor;
}

void PolarBear::setStepperMotor(int stepPin, int directionPin)
{
	stepperMotor = new StepperMotor(stepPin, directionPin);
}

