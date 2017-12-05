#include "TrapezFunction.h"



TrapezFunction::TrapezFunction()
{
	type = "TrapezFunction";
}


TrapezFunction::~TrapezFunction()
{
}

void TrapezFunction::setMiddle(double dL,double dR)
{
	leftMiddle = dL; 
	rightMiddle = dR;
}

double TrapezFunction::getValue(double t)
{
	if (t <= left)
		return 0;
	else if (t<leftMiddle)
		return (t - left) / (leftMiddle - left);
	else if (t <= rightMiddle)
		return 1.0;
	else if (t<right)
		return (right - t) / (right - rightMiddle);
	else
		return 0;
}
