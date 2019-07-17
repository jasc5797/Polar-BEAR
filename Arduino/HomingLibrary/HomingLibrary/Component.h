// Component.h

#ifndef _COMPONENT_h
#define _COMPONENT_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

// If the motor is +/- X steps then the arm is in the right position
// This is to reduce bouncing if the encoder does not perfectly line up
#define MOTOR_ROUGHLY_EQUAL_STEPS 10

class Component
{
public:

	enum STATE { 
		HOME, 
		MOVE, 
		STOP,
		ERROR
	};


	STATE getState();

	virtual void setState(STATE state);

	//virtual void update() = 0;
	void update();
	
	int getTargetPosition();
	void setTargetPosition(int targetPosition);

	bool isHoming();
	bool isMoving();
	bool isStopped();

	bool hasError();


protected:

	STATE state = STOP;

	int targetPosition;


	virtual void move() = 0;
	virtual void home() = 0;

	bool isRoughlyEqual(int value1, int value2);

};

#endif

