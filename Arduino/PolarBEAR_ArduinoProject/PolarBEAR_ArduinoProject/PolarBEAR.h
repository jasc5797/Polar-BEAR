// PolarBEAR.h

#ifndef _POLARBEAR_h
#define _POLARBEAR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "QuadratureMotor.h"
#include "StepperMotor.h"

class PolarBear
{

public:
	PolarBear();
	PolarBear(QuadratureMotor* quadratureMotor1, QuadratureMotor* quadratureMotor2, StepperMotor* stepperMotors);
	~PolarBear();

	QuadratureMotor* getQuadratureMotor1();
	void setQuadratureMotor1(QuadratureMotor* quadratureMotor1);
	void setQuadratureMotor1(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1);


	QuadratureMotor* getQuadratureMotor2();
	void setQuadratureMotor2(QuadratureMotor* quadratureMotor2);
	void setQuadratureMotor2(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1);

	StepperMotor* getStepperMotor();
	void setStepperMotor(StepperMotor* stepperMotor);
	void setStepperMotor(int stepPin, int directionPin);

private:
	QuadratureMotor* quadratureMotor1;
	QuadratureMotor* quadratureMotor2;

	StepperMotor* stepperMotor;
};


#endif

