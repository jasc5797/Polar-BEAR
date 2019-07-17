// StepperMotor.h

#ifndef _STEPPERMOTOR_h
#define _STEPPERMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include <LimitSwitch.h>
#include <Component.h>

#define FUCKED_STEPS_PER_REVOLUTION 200

#define FUCKED_FORWARD HIGH
#define FUCKED_BACKWARD LOW

#define FUCKED_PULSE_DELAY 3000
#define FUCKED_STOP_DELAY 500


class StepperMotor //: public Component
{

public:
	StepperMotor(int stepPin, int directionPin, int limitPin);

	//virtual void update();

	void home();

	void testLimitSwitch();

	void test();

	void step(int direction);

	void testTravelDistance(int count = 10, int steps = 100);

	void testIncremental(int steps = 100);

	int getTravelDistance(int steps);

private:
	
	int stepPin, directionPin;

	int position;

	LimitSwitch* limitSwitch;




};

#endif

