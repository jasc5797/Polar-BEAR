// Buffer.h

#ifndef _BUFFER_h
#define _BUFFER_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

class Buffer
{
private:
	// These would be better suited for a ring buffer
	//const bool useMaxBufferSize = false;
	//const uint32_t maxBufferSize = 64;

	const char terminator = ';';

	String buffer = "";
	uint32_t length = 0;

public:

	void append(char value);
	void clear();
	//int GetLength();

	bool isTerminated();

	String getBuffer();

};




#endif

