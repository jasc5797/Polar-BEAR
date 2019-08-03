// LimitSwitch.h

#ifndef _LIMITSWITCH_h
#define _LIMITSWITCH_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif


//#include <Bounce2-master/src/Bounce2.h>
#include <Bounce2.h>
#include "Component.h"

#define INTERVAL 20

class LimitSwitch : public Component
{
public:

	LimitSwitch(int limitPin, char* name = "Limit Switch");
	~LimitSwitch();

	// Bounce Wrappers
	bool update();
	bool read();
	bool pressed();
	bool released();


	// Test Functions
	void test();

private:

	Bounce bounce = Bounce();
};

#endif

