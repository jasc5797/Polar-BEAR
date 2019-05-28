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

void SerialCommand::readCommand()
{

}

//probably dont need this
bool SerialCommand::isAvailable()
{
	return Serial.available() > 0;
}

void SerialCommand::read()
{
	if (Serial.available())
	{
		char value = (char)Serial.read();
		buffer.append(value);
	}
}

bool SerialCommand::hasCompleteCommand()
{
	return buffer.isTerminated();
}

//Need to change data type to some class that holds the command data
String SerialCommand::getParsedCommand()
{
	String command = "";//= buffer.getBuffer();
	buffer.clear();
	return command;
}

/*
//Gets called after every loop if data is available
void serialEvent()
{
	if (Serial.available())
	{
		serialCommand.read();
	}
}
*/

