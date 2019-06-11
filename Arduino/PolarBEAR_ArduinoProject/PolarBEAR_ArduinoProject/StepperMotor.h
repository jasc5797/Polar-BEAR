// StepperMotor.h

#ifndef _STEPPERMOTOR_h
#define _STEPPERMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define TOTAL_STEPS 300

class StepperMotor
{
public:

	StepperMotor(int stepPin, int directionPin);
	~StepperMotor();

	void step(int degrees);

private:

	int stepPin, directionPin;
};

#endif

