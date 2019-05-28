// 
// 
// 

#include "X9C104.h"

X9C104::X9C104(int pinCS, int pinUD, int pinINC, int pinRW)
{
	//init(pinCS, pinUD, pinINC, pinRW);
	this->pinCS = pinCS;
	this->pinUD = pinUD;
	this->pinINC = pinINC;
	this->pinRW = pinRW;

	pinMode(pinCS, OUTPUT);
	pinMode(pinUD, OUTPUT);
	pinMode(pinINC, OUTPUT);
	pinMode(pinRW, INPUT);

	digitalWrite(pinCS, LOW);
	digitalWrite(pinUD, LOW);
	digitalWrite(pinINC, HIGH);
	
}


void X9C104::incrementStep(const bool store = false)
{
	digitalWrite(pinUD, HIGH);
	step(store);
}

void X9C104::decrementStep(const bool store = false)
{
	digitalWrite(pinUD, LOW);
	step(store);
}

void X9C104::setStep(const uint8_t newStep, const bool store = false)
{
	int currentStep = getStep();

	if (newStep > STEP_COUNT || newStep == currentStep)
	{
		return;
	}

	do
	{
		currentStep = getStep();
		if (currentStep < newStep)
		{
			incrementStep();
		}
		else
		{
			decrementStep();
		}
	} while (currentStep != newStep);

	if (store)
	{
		storeStep();
	}
}

void X9C104::step(const bool store = false)
{
	digitalWrite(pinINC, HIGH);
	digitalWrite(pinCS, LOW);
	delayMicroseconds(20000);
	digitalWrite(pinINC, LOW);

	if (store)
	{
		storeStep();
	}
}

int X9C104::getStep()
{
	return analogRead(pinRW);
}

void X9C104::storeStep()
{
	digitalWrite(pinINC, HIGH);
	digitalWrite(pinCS, HIGH);
	delayMicroseconds(20000);
	digitalWrite(pinCS, LOW);
}

float X9C104::getVoltage()
{
	return getStep() * VOLTAGE / 1023.0;
}
