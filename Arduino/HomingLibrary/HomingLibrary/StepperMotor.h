// StepperMotor.h

#ifndef _NEWSTEPPERMOTOR_h
#define _NEWSTEPPERMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include <LimitSwitch.h>
#include <Component.h>

#define STEPPER_STEPS_PER_REVOLUTION 200

#define STEPPER_FORWARD HIGH
#define STEPPER_BACKWARD LOW

#define PULSE_DELAY 1000
#define STOP_DELAY 500
#define WAKE_DELAY 10

#define MANUAL_STEPS 100


class StepperMotor : public Component
{

public:
	StepperMotor(int stepPin, int directionPin, int limitPin, int sleepPin, int resetPin);


	void moveManual();

	void moveIncremental();


private:

	int stepPin, directionPin;

	int sleepPin, resetPin;

	int currentPosition;

	LimitSwitch* limitSwitch;

	void home();
	void move();

	void step(int direction);


};

#endif

