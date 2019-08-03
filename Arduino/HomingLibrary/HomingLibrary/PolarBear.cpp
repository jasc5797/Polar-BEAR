// 
// 
// 

#include "PolarBear.h"

PolarBear::PolarBear(QuadratureMotor* tiltMotor, QuadratureMotor* rotationMotor, StepperMotor* extensionMotor)
{
	this->tiltMotor = tiltMotor;
	this->rotationMotor = rotationMotor;
	this->extensionMotor = extensionMotor;
}

void PolarBear::update()
{

	updateComponents();
}

void PolarBear::updateComponents()
{
	tiltMotor->update();
	rotationMotor->update();
	extensionMotor->update();
}
