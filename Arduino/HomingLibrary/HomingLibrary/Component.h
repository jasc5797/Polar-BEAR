// Component.h

#ifndef _COMPONENT_h
#define _COMPONENT_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

class Component
{
public:
	Component(char* name);

	char* getName();
	void setName(char* name);

protected:
	char* name;
};

#endif

