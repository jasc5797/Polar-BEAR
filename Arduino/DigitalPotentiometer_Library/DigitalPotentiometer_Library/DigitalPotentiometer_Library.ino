/*
 Name:		DigitalPotentiometer_Library.ino
 Created:	5/22/2019 7:35:28 PM
 Author:	stinsoncerraj
*/

#include "X9C104.h"
#include "DigitalPotentiometer.h"

#define BAUD 115200
#define DELAY 100

const int pinUD = 29;
const int pinINC = 25;
const int pinCS = 27;
const int pinRW = A15;

//DigitalPotentiometer* digitalPot;
X9C104* digPot;

// the setup function runs once when you press reset or power the board
void setup() {
	Serial.begin(115200);
	digPot = new X9C104(pinCS, pinUD, pinINC, pinRW);

	runTest();

	
	//currentStep = digPot->getStep();
	//Serial.println(currentStep);

	//digitalPot = new DigitalPotentiometer(pinUD, pinINC, pinCS, pinRW);
	//digitalPot->toggleIsIncreasing();
	//int wiperValue = digitalPot->getWiperValue();
	//Serial.println("Wiper Value: " + wiperValue);
	//digitalPot->toggleIsIncreasing();
	//Serial.println("Wiper Value: " + wiperValue);
	/*int i = 0;
	do
	{
		delay(500);
		int wiperValue = digitalPot->getWiperValue();
		digitalPot->increment();
		Serial.println(wiperValue);
		i++;
	} while (i < 100);*/
	/*Serial.println(wiperValue);
	digitalPot->increment();
	wiperValue = digitalPot->getWiperValue();
	Serial.println(wiperValue);*/
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (Serial.available())
	{
		Serial.read();
		runTest();
	}
	/*
	if (!digitalPot->getIsIncreasing())
	{
		digitalPot->toggleIsIncreasing();
	}
	int wiperValue = digitalPot->getWiperValue();
	for (; wiperValue < TAP_COUNT; wiperValue++)
	{
		digitalPot->increment();
		int expectedValue = wiperValue * STEP_OHMS;
		int actualWiperValue = digitalPot->getWiperValue();
		int actualValue = actualWiperValue * STEP_OHMS;
		String output = "Expected TAP: " + String(wiperValue) + 
			" Expected value: " + String(expectedValue) + 
			" Actual TAP: " + String(actualWiperValue) +
			" Actual value: " + String(actualValue);
		Serial.println(output);
	}
	if (digitalPot->getIsIncreasing())
	{
		digitalPot->toggleIsIncreasing();
	}
	for (; wiperValue > 0; wiperValue--)
	{
		digitalPot->increment();
		long expectedValue = wiperValue * STEP_OHMS;
		int actualWiperValue = digitalPot->getWiperValue();
		long actualValue = actualWiperValue * STEP_OHMS;
		String output = "Expected TAP: " + String(wiperValue) +
			" Expected value: " + String(expectedValue) +
			" Actual TAP: " + String(actualWiperValue) +
			" Actual value: " + String(actualValue);
		Serial.println(output);
		
	}
	*/

}

void runTest()
{
	Serial.println("Testing Decrement");

	for (int i = 0; i < 100; i++)
	{
		int currentStep = digPot->getStep();
		float currentVoltage = digPot->getVoltage();
		Serial.print("Current Step: ");
		Serial.println(currentStep);

		Serial.print("Current Voltage: ");
		Serial.println(currentVoltage);

		Serial.println("Decrementing");
		digPot->decrementStep();
		Serial.println("------");
		delay(DELAY);
	}

	Serial.println("Testing Increment");

	for (int i = 0; i < 100; i++)
	{
		int currentStep = digPot->getStep();
		float currentVoltage = digPot->getVoltage();
		Serial.print("Current Step: ");
		Serial.println(currentStep);

		Serial.print("Current Voltage: ");
		Serial.println(currentVoltage);

		Serial.println("Incrementing");
		digPot->incrementStep();
		Serial.println("------");
		delay(DELAY);
	}
}
