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
	if (tiltDegrees != 0)
	{
		int currentTilt = tiltServo.read();
		int targetTilt = currentTilt + tiltDegrees;
		tiltServo.write(targetTilt);
		delay(200);
	}

	if (rotationDegrees != 0)
	{
		int currentRotation = rotationServo.read();
		int targetRotation = currentRotation + rotationDegrees;
		rotationServo.write(targetRotation);
		delay(200);
	}
}




