// SerialBuffer.h

#ifndef _SERIALBUFFER_h
#define _SERIALBUFFER_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include "Buffer.h";

// Wrapper for Serial
// Reads char from Serial into a Buffer (String)
class SerialBuffer
{

public:
	void receive();

	String readBuffer();

	bool isAvailable();

private:
	Buffer buffer;


	
};

#endif

