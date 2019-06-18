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

	QuadratureMotor(int pwmPin, int directionPin, int encoderPinA, int encoderPinB, int limitPin1 = -1, int limitPin2 = -1);
	~QuadratureMotor();

	// CytronMD wrapper functions
	void setSpeed(int speed);

	// Encoder wrapper functions
	void write(int32_t newPosition);
	int32_t read();

	bool getIsLimit1Pressed();
	bool getIsLimit2Pressed();

private:

	CytronMD* motor;
	Encoder* encoder;

	int limitPin1, limitPin2;

	LimitMode limitMode;

	bool isLimit1Pressed = false, isLimit2Pressed = false;

	static void limit1Interrupt();
	static void limit2Interrupt();


};

#endif

