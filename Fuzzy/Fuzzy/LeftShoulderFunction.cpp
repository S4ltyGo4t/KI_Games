#include "LeftShoulderFunction.h"



LeftShoulderFunction::LeftShoulderFunction()
{
	type = "LeftShoudler";
}


LeftShoulderFunction::~LeftShoulderFunction()
{
}

void LeftShoulderFunction::setMiddle(double dS,double dUseless)
{
	shoulderPoint = dS;
}

double LeftShoulderFunction::getValue(double t)
{
	if (t <= left)
		return 0;
	else if (t <= shoulderPoint)
		return 1.0;
	else if (t < right)
		return (right - t) / (right - shoulderPoint);
	else
		return 0;
}
