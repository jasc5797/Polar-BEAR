// 
// 
// 

#include "LimitSwitch.h"


LimitSwitch::LimitSwitch(int limitPin)
{
	//bounce = Bounce();
	bounce.attach(limitPin);
	bounce.interval(INTERVAL);
}

bool LimitSwitch::update()
{
	return bounce.update();
}

bool LimitSwitch::read()
{
	return bounce.read();
}

bool LimitSwitch::pressed() 
{
	return bounce.rose();
}

bool LimitSwitch::released()
{
	return bounce.fell();
}

void LimitSwitch::test(char* name)
{
	bool stateChanged = update();
	if (stateChanged)
	{
		Serial.print(name);
		if (read())
		{
			
			Serial.println(" was pressed");
		}
		else
		{
			Serial.println(" was released");
		}
	}
}