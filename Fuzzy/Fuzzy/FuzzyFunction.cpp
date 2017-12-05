#include "FuzzyFunction.h"



FuzzyFunction::FuzzyFunction()
{
}


FuzzyFunction::~FuzzyFunction()
{
	delete[] name; name = NULL;
}

bool FuzzyFunction::isDotInInterval(double t)
{
	if ((t >= left) && (t <= right)) 
		return true; 
	else 
		return false;
}