// DebounceLimitSwitch.h

#ifndef _DEBOUNCELIMITSWITCH_h
#define _DEBOUNCELIMITSWITCH_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "Bounce2-master/src/Bounce2.h"

#define INTERVAL 20

class DebounceLimitSwitch
{
public:

	DebounceLimitSwitch(int limitPint);
	~DebounceLimitSwitch();

	bool isPressed();
	bool isHeld();

	Bounce bounce = Bounce();

	bool update();

	bool hasStateChanged();

	void Test();

private:
	int limitPin;
	bool state;
	bool stateChanged = false;



	bool read();
	
};

#endif

