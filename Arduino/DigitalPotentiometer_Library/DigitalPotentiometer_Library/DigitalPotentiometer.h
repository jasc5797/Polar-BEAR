// DigitalPotentiometer.h

#ifndef _DIGITALPOTENTIOMETER_h
#define _DIGITALPOTENTIOMETER_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

class DigitalPotentiometer
{
#define POT_VALUE 100000L
#define TAP_COUNT 99
#define STEP_OHMS POT_VALUE / TAP_COUNT
#define PULSE_DELAY 100
public:
	DigitalPotentiometer(const int pinUD, const int pinINC, const int pinCS, const int pinRW);
	//~DigitalPotentiometer();

	void increment();

	bool getIsIncreasing();

	void toggleIsIncreasing();

	int getWiperValue();


private:

	int pinUD;
	int pinINC;
	int pinCS;
	int pinRW;

	bool isIncreasing = true;
	

};

#endif

