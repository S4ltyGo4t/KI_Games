#include "TriangleFuncion.h"



TriangleFunction::TriangleFunction()
{
	type = "TriangleFunction";
}


TriangleFunction::~TriangleFunction()
{
}

void TriangleFunction::setMiddle(double dL, double dR)
{
	middle = dL;
}

double TriangleFunction::getValue(double t)
{
	if (t <= left)
		return 0;
	else if (t<middle)
		return (t - left) / (middle - left);
	else if (t == middle)
		return 1.0;
	else if (t<right)
		return (right - t) / (right - middle);
	else
		return 0;
}