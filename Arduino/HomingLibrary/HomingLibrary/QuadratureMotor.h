// QuadratureMotor.h

#ifndef _QUADRATUREMOTOR_h
#define _QUADRATUREMOTOR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include <CytronMotorDriver.h>
#include <Encoder.h>

#include "LimitSwitch.h"
#include "Motor.h"

#define DISCONNECTED -1

#define QUADRATURE_MOTOR_STEPS_PER_REVOLUTION 12658.944

#define ONE_LIMIT_STEPS -11920.20 // 10 tests (~ -338.99 degrees)

/*
Average Steps: -11930.00
Average Degrees: -339.27
*/

#define TWO_LIMIT_STEPS

#define HOMING_SPEED 25
#define RELEASE_SPEED 25

#define MOTOR_FORWARD 1
#define MOTOR_BACKWARD -1

#define ROTATION_MINIMUM 1000
#define ROTATION_MAXIMUM QUADRATURE_MOTOR_STEPS_PER_REVOLUTION - 1000

#define TILT_MINIMUM 1000
#define TILT_MAXIMUM 1000


class QuadratureMotor : public Motor
{
	
public:

	enum LIMIT_MODE {
		ONE,
		TWO
	};


	enum HOME_STATE
	{
		START,
		PRESSED,
		RELEASED,
		COMPLETED
	};


	QuadratureMotor(int pwmPin, int dirPin, int encoderPinA, int encoderPinB, int limitPin1, int limitPin2 = DISCONNECTED, char* name = "Quadrature Motor");
	//~QuadratureMotor();


	void setTargetPosition(int targetPostion) { this->targetPosition = targetPosition; }
	int getTargetPosition() { return targetPosition; }

	void testTravelDistance(int count = 10);

	void moveToTarget(int steps);
	void moveToTargetDegrees(double degrees);

	virtual void setState(STATE state);

	virtual int degreesToSteps(double degrees);

	virtual void stop();

	void homeBasic();

private:
	int getTravelDistance();
	int getTravelDistanceOneLimit();
	int getTravelDistanceTwoLimit();

	int16_t speed;
	//int targetPosition;

	LIMIT_MODE limitMode = ONE;


	//LIMIT_STATE limitState = LIMIT_STATE::NONE;
	HOME_STATE homeState = START;

	CytronMD* motor;
	Encoder* encoder;
	LimitSwitch* limitSwitch1;
	LimitSwitch* limitSwitch2;

	virtual void move();
	virtual void home();

	void moveOneLimit();
	void moveTwoLimit();

	void moveHelper(LimitSwitch* limitSwitch);

	//void homeOneLimit();
	//void homeTwoLimit();

	void setSpeed(int16_t speed);

	// Could be one function if another parameter is added
	bool moveUntilPressed(LimitSwitch* limitSwitch, int16_t speed, int direction);
	bool moveUntilReleased(LimitSwitch* limitSwitch, int16_t speed, int direction);

};

#endif

