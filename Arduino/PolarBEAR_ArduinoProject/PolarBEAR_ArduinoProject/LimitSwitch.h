// LimitSwitch.h

#ifndef _LIMITSWITCH_h
#define _LIMITSWITCH_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#define MIN_INTERVAL 20

class LimitSwitch
{
public:
	LimitSwitch(int limitPin);
	~LimitSwitch();

	bool isTriggered();
	bool isPressed();

private:
	int limitPin;

	bool wasPressed = false;

	unsigned long timeLastStateChange;

	bool read();
	bool isReady();

	void updateReady(bool pressed);
};

#endif