// PolarBear.h

#ifndef _POLARBEAR_h
#define _POLARBEAR_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

#include <ArduinoJson.hpp> 
#include <ArduinoJson.h>

#include "Component.h"
#include "Motor.h"
#include "QuadratureMotor.h"
#include "StepperMotor.h"
#include "EndEffector.h"
#include "SerialJSON.h"

class PolarBear
{
public:

	PolarBear(QuadratureMotor* tiltMotor, QuadratureMotor* rotationMotor, StepperMotor* extensionMotor, EndEffector* endEffector);

	void update();

private:
	QuadratureMotor* tiltMotor;
	QuadratureMotor* rotationMotor;
	StepperMotor* extensionMotor;
	EndEffector* endEffector;
	
	SerialJSON* serialJSON;

	void updateComponents();

};
#endif

