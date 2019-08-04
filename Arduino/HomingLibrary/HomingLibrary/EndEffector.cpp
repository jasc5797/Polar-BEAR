// 
// 
// 

#include "EndEffector.h"

EndEffector::EndEffector(int tiltPin, int rotationPin, char* name) : Component(name)
{
	tiltServo.attach(tiltPin);
	rotationServo.attach(rotationPin);
}

void EndEffector::move(int tiltDegrees, int rotationDegrees)
{
	tiltServo.write(tiltDegrees);
	rotationServo.write(rotationDegrees);
}




