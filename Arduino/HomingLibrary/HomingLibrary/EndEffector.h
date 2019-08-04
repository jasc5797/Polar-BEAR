// EndEffector.h

#ifndef _ENDEFFECTOR_h
#define _ENDEFFECTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include <Servo.h>

#define END_EFFECTOR_TILT_MINIMUM 55
#define END_EFFECTOR_TILT_MAXIMUM 155

#define END_EFFECTOR_ROTATION_MINIMUM 0
#define END_EFFECTOR_ROTATION_MAXIMUM 180

class EndEffector : Component
{
public:
	EndEffector(int tiltPin, int rotationPin, char* name = "End Effector");

	void move(int tiltDegrees, int rotationDegrees);

private:
	Servo tiltServo;
	Servo rotationServo;
};

#endif

