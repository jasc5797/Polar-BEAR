// 
// 
// 

#include "StepperMotor.h"

StepperMotor::StepperMotor(int stepPin, int directionPin)
{
	this->stepPin;
	this->directionPin;
	pinMode(stepPin, OUTPUT);
	pinMode(directionPin, OUTPUT);
}

void StepperMotor::step(int degrees)
{
	setDirection(degrees);
	int microSeconds = degreesToMicroSeconds(degrees);
	// Could add something that breaks up the stepper movement into multiple chunks
	// This way interrupts can be disabled during critical sections but can still have time to handle interrupts for other things
	//noInterrupts();
	// critical, time-sensitive code here
	digitalWrite(stepPin, HIGH);
	delayMicroseconds(microSeconds);
	digitalWrite(stepPin, LOW);
	//interrupts();
}

void StepperMotor::setDirection(int degrees)
{
	if (degrees >= 0)
	{
		digitalWrite(directionPin, HIGH);
	}
	else
	{
		digitalWrite(directionPin, LOW);
	}
}

void StepperMotor::stepContinuous(int degrees)
{

}

void StepperMotor::stepBatch(int degrees)
{

}

int StepperMotor::degreesToMicroSeconds(int degrees)
{
	return (degrees / 360.0) * TOTAL_STEPS;
}
