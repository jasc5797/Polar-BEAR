// 
// 
// 

#include "SerialBuffer.h"

void SerialBuffer::receive()
{
	char value = (char)Serial.read();
	buffer.append(value);
}

String SerialBuffer::readBuffer()
{
	String value = buffer.getBuffer();
	buffer.clear();
	return value;
}

bool SerialBuffer::isAvailable()
{
	return buffer.isTerminated();
}
