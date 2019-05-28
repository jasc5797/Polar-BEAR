#include "Arduino.h"
#include "Library1.h"
#include "foo/Baa.h"


Library1Class::Library1Class()
{
}


Library1Class::~Library1Class()
{
}

void Library1Class::hello(String msg)
{
	Serial.println(msg);
}
