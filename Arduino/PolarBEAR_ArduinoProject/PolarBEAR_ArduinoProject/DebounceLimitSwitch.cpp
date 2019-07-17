// 
// 
// 

#include "DebounceLimitSwitch.h"


DebounceLimitSwitch::DebounceLimitSwitch(int limitPin)
{
	this->limitPin = limitPin;
	bounce.attach(limitPin, INPUT);
	bounce.interval(INTERVAL);

	update();
	state = read();
	//Serial.println(state);
}

bool DebounceLimitSwitch::read()
{
	return bounce.read();
}

bool DebounceLimitSwitch::update()
{
	stateChanged = bounce.update();

	if (stateChanged)
	{
		if (bounce.fell())
		{
			state = false;
		}
		else if (bounce.rose())
		{
			state = true;
		}
	}

	return stateChanged;
}

bool DebounceLimitSwitch::isPressed()
{
	return state;
}

bool DebounceLimitSwitch::hasStateChanged()
{
	return stateChanged;
}


bool DebounceLimitSwitch::isHeld()
{
	return state && !stateChanged;
}

void DebounceLimitSwitch::Test()
{
	//Serial.println("Running Test");
	update();
	if (hasStateChanged())
	{
		if (isPressed())
		{
			Serial.println("Pressed");
		}
		else
		{
			Serial.println("Released");
		}
	}
}
