// 
// 
// 

#include "LimitSwitch.h"

LimitSwitch::LimitSwitch(int limitPin)
{
	this->limitPin = limitPin;
	pinMode(limitPin, INPUT);
	timeLastStateChange = 0;	
}

bool LimitSwitch::isTriggered()
{
	bool pressed = read();
	bool held = pressed && wasPressed;
	bool ready = isReady();

	updateReady(pressed);

	wasPressed = pressed;
	return pressed && ready && !held;
}

bool LimitSwitch::isPressed()
{
	bool pressed = read();
	bool ready = isReady();

	updateReady(pressed);

	wasPressed = pressed;
	return pressed && ready;
}


// Returns true if the limit switch is pressed
// This is for limit switches that are normally closed
bool LimitSwitch::read()
{
	return digitalRead(limitPin) == HIGH;
}


// Makes sure the limit switch is not pressed multiple times within a set interval (MIN_INTERVAL)
bool LimitSwitch::isReady()
{
	unsigned long currentTime = millis();
	return currentTime - timeLastStateChange > MIN_INTERVAL;
}

void LimitSwitch::updateReady(bool pressed)
{
	if (pressed != wasPressed && isReady())
	{
		//This can run into an issue if the MIN_INTERVAL is too high and the limit switch is pressed rapidly
		//Under those circumstances isTriggered() will never return true
		timeLastStateChange = millis();
	}
}

