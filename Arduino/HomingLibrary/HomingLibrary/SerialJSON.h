// SerialJSON.h

#ifndef _SERIALJSON_h
#define _SERIALJSON_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

// *** Libraries ***

// Third Party Libraries
#include <ArduinoJson.hpp> 
#include <ArduinoJson.h>

// *** Macro Definitions ***

// Status Marcros
#define STATUS "Status"
#define STATUS_OPENED "Opened"
#define STATUS_READY "Ready"
#define STATUS_WAITING "Waiting"
#define STATUS_STOPPED "Stopped"
#define STATUS_CLOSED "Closed"

// Command Macros
#define COMMAND "Command"
#define COMMAND_OPEN "Open"
#define COMMAND_CLOSE "Close"
#define COMMAND_RUN "Run"
#define COMMAND_STOP "Stop"
#define COMMAND_FINISHED "Finished"

// Command Type Macros
#define TYPE_HOME "Home"
#define TYPE_DELAY "Delay"
#define TYPE_TILT "Tilt"
#define TYPE_ROTATION "Rotation"
#define TYPE_EXTENSION "Extension"
#define TYPE_END_EFFECTOR "End Effector"

// Command Value Macros
#define VALUE_DEGREES "Degrees"
#define VALUE_LENGTH "Length"
#define VALUE_TILT_DEGREES "TiltDegrees"
#define VALUE_ROTATION_DEGREES "RotationDegrees"
#define VALUE_DISTANCE "Distance"
#define VALUE_COMPONENT "Component"

// Serial Macros
#define TERMINATOR ";"

class SerialJSON
{
public:
	SerialJSON();

	void sendStatus(char* status);

	DynamicJsonDocument readCommand();

	bool isEqual(char* value1, char* value2);

};

#endif

