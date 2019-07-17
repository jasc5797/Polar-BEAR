// QuadratureMotor.h

#ifndef _QUADRATUREMOTOR_h
#define _QUADRATUREMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "Encoder/Encoder.h"
#include "Cytron_Motor_Drivers_Library/CytronMotorDriver.h"
#include "LimitSwitch.h"
#include "DebounceLimitSwitch.h"

class QuadratureMotor
{
public:

	// Designates how many limit switches are attached
	enum LimitMode
	{
		NONE,
		ONE,
		TWO
	};

	QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, DebounceLimitSwitch* limitSwitch1);
	QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1);
	~QuadratureMotor();

	// CytronMD wrapper functions
	void setSpeed(int speed);

	// Movement Control
	bool isMoving();

	void moveDegrees();
	
	void home();


	// Limit Switch Test functions (may not be used)
	bool getIsLimit1Pressed();
	bool getIsLimit2Pressed();
	DebounceLimitSwitch* limitSwitch1;

private:

	CytronMD* motor;
	Encoder* encoder;




	int speed = 0;

	// Encoder wrapper functions
	void write(int32_t newPosition);
	int32_t read();


	// Limit Switch Test Stuff (Interrupts) (Not used)

	int limitPin1, limitPin2;

	LimitMode limitMode;

	bool isLimit1Pressed = false, isLimit2Pressed = false;

	static void limit1Interrupt();
	static void limit2Interrupt();


};

#endif

