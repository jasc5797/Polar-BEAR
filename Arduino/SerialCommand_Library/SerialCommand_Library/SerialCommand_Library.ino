/*
 Name:		SerialCommand_Library.ino
 Created:	5/20/2019 1:32:55 AM
 Author:	stinsoncerraj
*/

// the setup function runs once when you press reset or power the board

#include "SerialCommand.h"

SerialCommand serialCommand;

void setup() {
	serialCommand.init(115200);
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (Serial.available())
	{
		serialCommand.recieve();

		if (serialCommand.isAvailable())
		{
			String command = serialCommand.readCommand();
			Serial.println(command);
		}
	}
}
