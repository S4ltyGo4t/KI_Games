#include "Gen.h"

Gen::Gen()
{
}

Gen::Gen(string _name, float _cost, float _proceeds)
{
	name = _name;
	cost = _cost;
	proceeds = _proceeds;
}

Gen::~Gen()
{
}

void Gen::setName(string _name)
{
	name = _name;
}

void Gen::setCost(float _cost)
{
	cost = _cost;
}

void Gen::setproceeds(float _proceeds)
{
	proceeds = _proceeds;
}

string Gen::getName()
{
	return name;
}

float Gen::getCost()
{
	return cost;
}

float Gen::getProceeds()
{
	return proceeds;
}
