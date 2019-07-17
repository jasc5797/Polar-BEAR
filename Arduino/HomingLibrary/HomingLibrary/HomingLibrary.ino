/*
 Name:		HomingLibrary.ino
 Created:	6/29/2019 2:39:08 PM
 Author:	stinsoncerraj
*/

// the setup function runs once when you press reset or power the board

#include "NewQuadratureMotor.h"
#include "NewStepperMotor.h"
#include "Component.h"
#include <AccelStepper.h>

#include "StepperMotor.h"
#include <Encoder.h>
#include <Bounce2.h>
#include <CytronMotorDriver.h>


#include "LimitSwitch.h"
#include "QuadratureMotor.h"

#define TILT_LIMIT_PIN1 12
#define TILT_LIMIT_PIN2 13
#define TILT_PWM_PIN 6
#define TILT_DIR_PIN 5
#define TILT_ENCODER_PIN_A 40
#define TILT_ENCODER_PIN_B 38

#define ROTATION_LIMIT_PIN 7
#define ROTATION_PWM_PIN 10
#define ROTATION_DIR_PIN 9
#define ROTATION_ENCODER_PIN_A 36
#define ROTATION_ENCODER_PIN_B 34

#define STEPPER_DIR_PIN 22
#define STEPPER_STEP_PIN 24
#define STEPPER_LIMIT_PIN 26

//#define DEBUG true




NewQuadratureMotor* tiltMotor;
NewQuadratureMotor* rotationMotor;

NewStepperMotor* newStepperMotor;


//QuadratureMotor* quadratureMotor;
//StepperMotor* stepperMotor;

LimitSwitch* limitSwitchA = new LimitSwitch(TILT_LIMIT_PIN1);
LimitSwitch* limitSwitchB = new LimitSwitch(TILT_LIMIT_PIN2);
LimitSwitch* limitSwitchC = new LimitSwitch(ROTATION_LIMIT_PIN);



void setup() 
{
	Serial.begin(9600);

	tiltMotor = new NewQuadratureMotor(TILT_PWM_PIN, TILT_DIR_PIN, TILT_ENCODER_PIN_A, TILT_ENCODER_PIN_B, TILT_LIMIT_PIN1, TILT_LIMIT_PIN2);
	rotationMotor = new NewQuadratureMotor(ROTATION_PWM_PIN, ROTATION_DIR_PIN, ROTATION_ENCODER_PIN_A, ROTATION_ENCODER_PIN_B, ROTATION_LIMIT_PIN);
	newStepperMotor = new NewStepperMotor(STEPPER_STEP_PIN, STEPPER_DIR_PIN, STEPPER_LIMIT_PIN);

	Serial.println("Setup Complete");


	//newQuadratureMotor = new NewQuadratureMotor(PWM_PIN, DIR_PIN, ENCODER_PIN_A, ENCODER_PIN_B, LIMIT_PIN1);

	//quadratureMotor = new QuadratureMotor(PWM_PIN, DIR_PIN, ENCODER_PIN_A, ENCODER_PIN_B, LIMIT_PIN1, LIMIT_PIN2);
	//stepperMotor = new StepperMotor(STEPPER_STEP_PIN, STEPPER_DIR_PIN, STEPPER_LIMIT_PIN);

	//delay(2000);
	//quadratureMotor->home();
	//quadratureMotor->testTravelDistance();

	//stepperMotor->home();
	//quadratureMotor->testMove();
	//newQuadratureMotor->testTravelDistance(50);
}

// the loop function runs over and over again until power down or reset
void loop() 
{
	/*
	tiltMotor->moveManual(true);
	rotationMotor->moveManual(false);
	newStepperMotor->moveManual();
	*/

	limitSwitchA->test("Tilt Forward");
	limitSwitchB->test("Tilt Backward");
	limitSwitchC->test("Rotation");


	//stepperMotor->testIncremental();
	//stepperMotor->testLimitSwitch();
	//stepperMotor->testLimitSwitch();
	//quadratureMotor->Test();
	//quadratureMotor->home();

	//SstepperMotor->test();
	//stepperMotor->home();
	

	

	//quadratureMotor->testLimitSwitch1();
	//quadratureMotor->testLimitSwitch2();
	//newStepperMotor->moveManual();
	//newStepperMotor->moveIncremental();
	
}
