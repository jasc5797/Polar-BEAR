// QuadratureMotor.h

#ifndef _QUADRATUREMOTOR_h
#define _QUADRATUREMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

//#include <Cytron_Motor_Drivers_Library/CytronMotorDriver.h>
//#include <Encoder/Encoder.h>

#include <CytronMotorDriver.h>
#include <Encoder.h>

#include <LimitSwitch.h>


#define STEPS_PER_REVOLUTION 12658.944

#define HOMING_SPEED 15

class QuadratureMotor
{

public:
	QuadratureMotor(int pwmPin, int dirPin, int encoderPinA, int encoderPinB, int limitPin1, int limitPin2);
	~QuadratureMotor();


	void home();

	void testLimitSwitch1();
	void testLimitSwitch2();

	void testTravelDistance(int count = 10);

	void testMove();



private:
	
	CytronMD* motor;
	Encoder* encoder;
	LimitSwitch* limitSwitch1;
	LimitSwitch* limitSwitch2;

	int getTravelDistance();

};

#endif

