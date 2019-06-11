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
	PolarBear(QuadratureMotor* quadratureMotor1, QuadratureMotor* quadratureMotor2, StepperMotor* stepperMotors);
	~PolarBear();

private:
	QuadratureMotor* quadratureMotor1;
	QuadratureMotor* quadratureMotor2;

	StepperMotor* stepperMotor;
};


#endif

