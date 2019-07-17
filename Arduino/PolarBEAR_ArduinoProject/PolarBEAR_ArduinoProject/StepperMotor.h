// StepperMotor.h

#ifndef _STEPPERMOTOR_h
#define _STEPPERMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define TOTAL_STEPS 200
#define DELAY 200


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

	int getClosestDegree(int degrees);
	int getCurrentDegree();

private:

	Mode mode = CONTINUOUS;

	int stepPin, directionPin;
	int currentDegree;

	void setDirection(int degrees);

	void stepContinuous(int degrees);
	void stepBatch(int degrees);

	
};

#endif

