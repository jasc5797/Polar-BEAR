// 
// 
// 

#include "PolarBear.h"

PolarBear::PolarBear(QuadratureMotor* tiltMotor, QuadratureMotor* rotationMotor, StepperMotor* extensionMotor, EndEffector* endEffector)
{
	this->tiltMotor = tiltMotor;
	this->rotationMotor = rotationMotor;
	this->extensionMotor = extensionMotor;
	this->endEffector = endEffector;

	serialJSON = new SerialJSON();
}

void PolarBear::update()
{

	//updateComponents();
	
}

void PolarBear::updateComponents()
{
	tiltMotor->update();
	rotationMotor->update();
	extensionMotor->update();
}
