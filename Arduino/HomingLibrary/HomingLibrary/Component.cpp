// 
// 
// 

#include "Component.h"

Component::Component(char* name)
{
	setName(name);
}

char* Component::getName()
{
	return name;
}

void Component::setName(char* name)
{
	this->name = name;
}
