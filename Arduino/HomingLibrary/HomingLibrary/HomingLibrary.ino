/*
 Name:		HomingLibrary.ino
 Created:	6/29/2019 2:39:08 PM
 Author:	stinsoncerraj
*/

// *** Include Statements ***


// Third-Party Libraries
#include <ArduinoJson.hpp> // Allows for reading JSON data from a serial connection
#include <ArduinoJson.h>
#include <Encoder.h> // Allows reading from and writing to the Encoders on Quadrature Motors
#include <Bounce2.h> // Debounces signal from Limit Switches
#include <CytronMotorDriver.h> // Controls Quadrature Motors using MD20A

// First-Party Libraries
#include "LimitSwitch.h"
#include "QuadratureMotor.h"
#include "StepperMotor.h"
#include "Motor.h"
#include "PolarBear.h"
#include "Component.h"

// *** Macro Definitions ***


// Tilt Motor Arduino Pin Definitions
#define TILT_LIMIT_PIN1 12
#define TILT_LIMIT_PIN2 13
#define TILT_PWM_PIN 6
#define TILT_DIR_PIN 5
#define TILT_ENCODER_PIN_A 40
#define TILT_ENCODER_PIN_B 38

// Rotation Motor Arduino Pin Definitions
#define ROTATION_LIMIT_PIN 7
#define ROTATION_PWM_PIN 10
#define ROTATION_DIR_PIN 9
#define ROTATION_ENCODER_PIN_A 36
#define ROTATION_ENCODER_PIN_B 34

// Extension Motor Arduino Pin Definitions
#define EXTENSION_DIR_PIN 22
#define EXTENSION_STEP_PIN 24
#define EXTENSION_LIMIT_PIN 26
#define EXTENSION_SLEEP_PIN 46
#define EXTENSION_RESET_PIN 44

//  *** Object Definitions ***
QuadratureMotor* tiltMotor;
QuadratureMotor* rotationMotor;
StepperMotor* extensionMotor;

PolarBear* polarBear;

// the setup function runs once when you press reset or power the board
void setup()
{
	Serial.begin(9600); // Open a serial connection

	tiltMotor = new QuadratureMotor(TILT_PWM_PIN, TILT_DIR_PIN, TILT_ENCODER_PIN_A, TILT_ENCODER_PIN_B, TILT_LIMIT_PIN1, TILT_LIMIT_PIN2);
	rotationMotor = new QuadratureMotor(ROTATION_PWM_PIN, ROTATION_DIR_PIN, ROTATION_ENCODER_PIN_A, ROTATION_ENCODER_PIN_B, ROTATION_LIMIT_PIN);
	extensionMotor = new StepperMotor(EXTENSION_STEP_PIN, EXTENSION_DIR_PIN, EXTENSION_LIMIT_PIN, EXTENSION_SLEEP_PIN, EXTENSION_RESET_PIN);

	polarBear = new PolarBear(tiltMotor, rotationMotor, extensionMotor);

	Serial.println("Setup Complete");
}

// the loop function runs over and over again until power down or reset
void loop() 
{
	//polarBear->update();
	extensionMotor->moveManual();
}