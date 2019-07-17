/*
 Name:		HomingLibrary.ino
 Created:	6/29/2019 2:39:08 PM
 Author:	stinsoncerraj
*/

// *** Include Statements ***

// Third-Party Libraries
#include <Encoder.h> // Allows reading from and writing to the Encoders on Quadrature Motors
#include <Bounce2.h> // Debounces signal from Limit Switches
#include <CytronMotorDriver.h> // Controls Quadrature Motors using MD20A

// First-Party Libraries
#include "LimitSwitch.h"
#include "QuadratureMotor.h"
#include "StepperMotor.h"
#include "Component.h"

// *** Macro Definitions ***

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
#define STEPPER_SLEEP_PIN 46
#define STEPPER_RESET_PIN 44

//#define DEBUG true

QuadratureMotor* tiltMotor;
QuadratureMotor* rotationMotor;

StepperMotor* extensionMotor;

LimitSwitch* limitSwitchA;
LimitSwitch* limitSwitchB;
LimitSwitch* limitSwitchC;


// the setup function runs once when you press reset or power the board
void setup() 
{
	Serial.begin(9600);

	tiltMotor = new QuadratureMotor(TILT_PWM_PIN, TILT_DIR_PIN, TILT_ENCODER_PIN_A, TILT_ENCODER_PIN_B, TILT_LIMIT_PIN1, TILT_LIMIT_PIN2);
	rotationMotor = new QuadratureMotor(ROTATION_PWM_PIN, ROTATION_DIR_PIN, ROTATION_ENCODER_PIN_A, ROTATION_ENCODER_PIN_B, ROTATION_LIMIT_PIN);
	extensionMotor = new StepperMotor(STEPPER_STEP_PIN, STEPPER_DIR_PIN, STEPPER_LIMIT_PIN, STEPPER_SLEEP_PIN, STEPPER_RESET_PIN);

	/*
	limitSwitchA = new LimitSwitch(TILT_LIMIT_PIN1);
	limitSwitchB = new LimitSwitch(TILT_LIMIT_PIN2);
	limitSwitchC = new LimitSwitch(ROTATION_LIMIT_PIN);
	*/

	Serial.println("Setup Complete");

	// Homing Tests
	tiltMotor->testTravelDistance(1);
	rotationMotor->testTravelDistance(1);
}

// the loop function runs over and over again until power down or reset
void loop() 
{
	// Manual Movement Tests
	//tiltMotor->moveManual(true);
	//rotationMotor->moveManual(false);
	//extensionMotor->moveManual();
	

	

	// Test the limit switches
	// Make sure to run if the arm has been rewired
	/*
	limitSwitchA->test("Tilt Forward");
	limitSwitchB->test("Tilt Backward");
	limitSwitchC->test("Rotation");
	*/
}
