// PolarBear.h

#ifndef _POLARBEAR_h
#define _POLARBEAR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "QuadratureMotor.h"
#include "StepperMotor.h"
#include "Motor.h"
#include "Component.h"

class PolarBear
{
public:
	PolarBear(QuadratureMotor* tiltMotor, QuadratureMotor* rotationMotor, StepperMotor* extensionMotor);

	void update();

};
#endif

