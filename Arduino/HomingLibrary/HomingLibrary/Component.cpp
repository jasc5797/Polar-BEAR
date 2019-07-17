
#include "Component.h"

Component::STATE Component::getState()
{
	return state; 
}


void Component::setState(STATE state)
{
	this->state = state;
}


void Component::update()
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

int Component::getTargetPosition()
{
	return targetPosition;
}

void Component::setTargetPosition(int targetPosition)
{
	this->targetPosition = targetPosition;
}

bool Component::isHoming()
{
	return state == HOME;
}

bool Component::isMoving()
{
	return state == MOVE;
}

bool Component::isStopped()
{
	return state == STOP;
}

bool Component::hasError()
{
	return state == ERROR;
}

bool Component::isRoughlyEqual(int value1, int value2)
{
	return abs(value1 - value2) <= MOTOR_ROUGHLY_EQUAL_STEPS;
}
