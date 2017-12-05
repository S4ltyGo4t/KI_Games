#pragma once
#include "FuzzyFunction.h"
class TriangleFunction :
	public FuzzyFunction
{
private:
	double middle;
public:
	TriangleFunction();
	~TriangleFunction();

	void	setMiddle(double dL, double dR);

	double	getValue(double t);
};

