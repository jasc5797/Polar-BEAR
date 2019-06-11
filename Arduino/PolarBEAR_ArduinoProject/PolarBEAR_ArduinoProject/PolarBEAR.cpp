// 
// 
// 

#include "PolarBEAR.h"


PolarBear::PolarBear(QuadratureMotor* quadratureMotor1, QuadratureMotor* quadratureMotor2, StepperMotor* stepperMotr)
{
	this->quadratureMotor1 = quadratureMotor1;
	this->quadratureMotor2 = quadratureMotor2;

	this->stepperMotor = stepperMotor;
}