// 
// 
// 

#include "SerialJSON.h"

SerialJSON::SerialJSON()
{
}

void SerialJSON::sendStatus(char* status)
{
	const int capacity = JSON_OBJECT_SIZE(2);
	StaticJsonDocument<capacity> statusJSON;

	statusJSON[STATUS] = status;
	
	serializeJsonPretty(statusJSON, Serial);
	Serial.println(TERMINATOR);
}

DynamicJsonDocument SerialJSON::readCommand()
{
	DynamicJsonDocument commandJSON(500);
	deserializeJson(commandJSON, Serial);
	return commandJSON;
}

bool SerialJSON::isEqual(char* value1, char* value2)
{
	return strcmp(value1, value2) == 0;
}
