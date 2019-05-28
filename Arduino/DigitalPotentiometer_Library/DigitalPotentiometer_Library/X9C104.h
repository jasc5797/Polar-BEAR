// X9C104.h

#ifndef _X9C104_h
#define _X9C104_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define VOLTAGE 5.0
#define RESISTANCE 100000L
#define STEP_COUNT 100

class X9C104
{
private:
	int pinCS;
	int pinUD;
	int pinINC;
	int pinRW;

	void step(const bool store = false);

public:
	X9C104(int pinCS, int pinUD, int pinINC, int pinRW);

	//void init(int pinCS, int pinUD, int pinINC, int pinRW);

	void incrementStep(const bool store = false);
	void decrementStep(const bool store = false);
	void setStep(const uint8_t newStep, const bool store = false);
	int getStep();

	void storeStep();

	float getVoltage();
};

#endif

