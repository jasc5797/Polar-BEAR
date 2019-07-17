// SerialCommand.h

#ifndef _SERIALCOMMAND_h
#define _SERIALCOMMAND_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "SerialBuffer.h"
#include "Command.h"
//#include <HardwareSerial.h>

class SerialCommand
{
public:

	bool init(const uint32_t speed);

	void recieve();

	//I liek de nugget

	bool isAvailable();

	String readCommand();

private:
	SerialBuffer serialBuffer;

	//const char COMMAND_RECIEVED = '1';

	const String COMMAND_RECIEVED = "command received;";
};

#endif

