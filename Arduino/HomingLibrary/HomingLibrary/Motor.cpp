
#include "Motor.h"

Motor::STATE Motor::getState()
{
	return state; 
}


void Motor::setState(STATE state)
{
	this->state = state;
}


void Motor::update()
{
	switch (state)
	{
	case HOME:
		home();
		break;
	case MOVE:
		move();
		break;
	case STOP:
	default:
		break;
	}
}

int Motor::getTargetPosition()
{
	return targetPosition;
}

void Motor::setTargetPosition(int targetPosition)
{
	this->targetPosition = targetPosition;
}

bool Motor::isHoming()
{
	return state == HOME;
}

bool Motor::isMoving()
{
	return state == MOVE;
}

bool Motor::isStopped()
{
	return state == STOP;
}

bool Motor::hasError()
{
	return state == ERROR;
}

bool Motor::isRoughlyEqual(int value1, int value2)
{
	return abs(value1 - value2) <= MOTOR_ROUGHLY_EQUAL_STEPS;
}
