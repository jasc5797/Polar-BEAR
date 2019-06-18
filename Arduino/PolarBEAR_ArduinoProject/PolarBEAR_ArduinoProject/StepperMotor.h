// StepperMotor.h

#ifndef _STEPPERMOTOR_h
#define _STEPPERMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define TOTAL_STEPS 300
#define BATCH_STEPS 100

class StepperMotor
{
public:

	enum Mode
	{
		CONTINUOUS, 
		BATCH
	};

	StepperMotor(int stepPin, int directionPin);
	~StepperMotor();

	void step(int degrees);

private:

	Mode mode = CONTINUOUS;

	int stepPin, directionPin;

	void setDirection(int degrees);

	void stepContinuous(int degrees);
	void stepBatch(int degrees);

	int degreesToMicroSeconds(int degrees);
};

#endif

