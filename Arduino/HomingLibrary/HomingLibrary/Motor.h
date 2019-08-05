// Motor.h

#ifndef _MOTOR_h
#define _MOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "Component.h"

// If the motor is +/- X steps then the arm is in the right position
// This is to reduce bouncing if the encoder does not perfectly line up
#define MOTOR_ROUGHLY_EQUAL_STEPS 100

class Motor : public Component
{
public:

	enum STATE { 
		HOME, 
		MOVE, 
		STOP,
		ERROR
	};

	Motor(char* name);

	STATE getState();

	virtual void setState(STATE state);

	//virtual void update() = 0;
	void update();
	
	int getTargetPosition();
	void setTargetPosition(int targetPosition);
	void setTargetPositionRelative(int offset);

	void setTargetPositionRelativeDegrees(double offsetDegrees);

	bool isHoming();
	bool isMoving();
	bool isStopped();

	bool hasError();

	virtual int degreesToSteps(double degrees) = 0;


protected:

	STATE state = STOP;

	int targetPosition;
	int currentPosition;


	virtual void move() = 0;
	virtual void home() = 0;

	bool isRoughlyEqual(int value1, int value2);

};

#endif

