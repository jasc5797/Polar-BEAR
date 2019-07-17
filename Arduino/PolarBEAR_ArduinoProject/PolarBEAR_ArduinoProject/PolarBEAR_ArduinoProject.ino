/*
 Name:		PolarBEAR_ArduinoProject.ino
 Created:	6/10/2019 10:03:23 PM
 Author:	stinsoncerraj
*/

// the setup function runs once when you press reset or power the board
#include <Bounce2.h>
#include "DebounceLimitSwitch.h"
#include <Encoder.h>
#include <CytronMotorDriver.h>
#include "LimitSwitch.h"
#include "PolarBEAR.h"

#define LIMIT_SWITCH_PIN 7
#define PWM_PIN 5
#define DIR_PIN 6
#define ENCODER_PIN_A 2
#define ENCODER_PIN_B 3

PolarBear* polarBear;

LimitSwitch* limitSwitch;
DebounceLimitSwitch* debounceLimitSwitch;

QuadratureMotor* quadratureMotor;

Bounce bounce = Bounce();
bool state;

int count = 0;

void setup() {
	//limitSwitch = new LimitSwitch(LIMIT_SWITCH_PIN);
	debounceLimitSwitch = new DebounceLimitSwitch(LIMIT_SWITCH_PIN);
	quadratureMotor = new QuadratureMotor(PWM_PIN, DIR_PIN, ENCODER_PIN_A, ENCODER_PIN_B, debounceLimitSwitch);
	Serial.begin(115200);
	Serial.println("Polar BEAR is ready");

	//delay(1000);
	//Serial.println("Homing Motor");
	//HomeTest();
	//Serial.println("Homing Complete");

	/*

	bounce.attach(LIMIT_SWITCH_PIN, INPUT);
	bounce.interval(20);

	bounce.update();
	state = bounce.read();
	*/


	//quadratureMotor->home();
	//quadratureMotor->setSpeed(100);
}

// the loop function runs over and over again until power down or reset
void loop() {
	//quadratureMotor->home();
	//DebounceLimitSwitchTest();
	//quadratureMotor->limitSwitch1->Test();
	//(*quadratureMotor).home();
	//debounceLimitSwitch->Test();
	quadratureMotor->limitSwitch1->bounce.update();
	//debounceLimitSwitch->Test();
	Serial.println(quadratureMotor->limitSwitch1->bounce.fell());
}


void BounceTest()
{

}

PolarBear* initialize()
{
	
}

void HomeTest()
{
	quadratureMotor->home();
}

void DebounceLimitSwitchTest()
{
	debounceLimitSwitch->update();
	if (debounceLimitSwitch->hasStateChanged())
	{
		if (debounceLimitSwitch->isPressed())
		{
			Serial.println("Pressed");
		}
		else
		{
			Serial.println("Released");
		}
	}
	
}

void LimitSwitchTriggerTest()
{
	if (limitSwitch->isTriggered())
	{
		count++;
		Serial.print("Limit Switch was triggered ");
		Serial.print(count);
		Serial.println(" times");
	}
}

void DebounceTest()
{
	//LimitSwitchTriggerTest();
	bool changed = false;
	bounce.update();

	if (bounce.fell())
	{
		Serial.println("Fell");
		Serial.println(bounce.read());
		changed = true;
	}
	if (bounce.rose())
	{
		Serial.println("Rose");
		Serial.println(bounce.read());
		changed = true;
	}
	if (bounce.rose())
	{
		Serial.println("Rose");
		Serial.println(bounce.read());
		changed = true;
	}
	if (changed)
	{
		int val = bounce.read();
		if (val != 0)
		{
			//Serial.println("Pressed");
		}
	}
	//Serial.println(bounce.read());
}
