// 
// 
// 

#include "Buffer.h"


void Buffer::append(char value)
{
	buffer += value;
	length++;
}

void Buffer::clear()
{
	buffer = "";
	length = 0;
}

bool Buffer::isTerminated()
{
	return buffer[length - 1] == terminator;
}


String Buffer::getBuffer()
{
	return buffer;
}


