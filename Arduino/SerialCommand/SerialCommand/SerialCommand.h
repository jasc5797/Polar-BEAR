// SerialCommand.h

#pragma once
#include "Arduino.h"

//#include <HardwareSerial.h>
#include <Buffer.h>

class SerialCommand
{
public:

	bool init(const uint32_t speed);

	void readCommand();

	bool isAvailable();

	void read();

	bool hasCompleteCommand();

	String getParsedCommand();

	//I liek de nugget
	

private:

	Buffer buffer;

};

//extern SerialCommand serialCommand;

//void serialEvent(); //-Gets called when data is available. Not sure if this pattern should be used


