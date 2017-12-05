#pragma once
#include "FuzzyFunction.h"
class TrapezFunction :
	public FuzzyFunction
{
private:
	double leftMiddle, rightMiddle;
public:
	TrapezFunction();
	~TrapezFunction();

	void	setMiddle(double dL, double dR);
	double	getValue(double t);
};

