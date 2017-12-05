#include "RightShoulderFunction.h"



RightShoulderFunction::RightShoulderFunction()
{
	type = "RightShoudler";
}


RightShoulderFunction::~RightShoulderFunction()
{
}

void RightShoulderFunction::setMiddle(double dS,double dUseless)
{
	shoulderPoint = dS;
}

double RightShoulderFunction::getValue(double t)
{
	if (t <= left)
		return 0;
	else if (t <= shoulderPoint)
		return (t - left) / (shoulderPoint - left);
	else if (t < right)
		return 1.0;
	else
		return 0;
}


