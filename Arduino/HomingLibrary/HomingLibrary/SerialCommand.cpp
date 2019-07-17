// 
// 
// 

#include "SerialCommand.h"


bool SerialCommand::init(const uint32_t speed)
{
	Serial.begin(speed);

	/*
	//Not useful on Mega which does not use USB CDC
	while (!Serial)
	{
		// wait for serial port to connect. Needed for native USB port only
	}
	*/

	return Serial;
}

void SerialCommand::recieve()
{
	serialBuffer.receive();

	if (isAvailable())
	{
		Serial.println(COMMAND_RECIEVED);
	}
}

bool SerialCommand::isAvailable()
{
	return serialBuffer.isAvailable();
}

String SerialCommand::readCommand()
{
	//Process command here
	return serialBuffer.readBuffer();
}
