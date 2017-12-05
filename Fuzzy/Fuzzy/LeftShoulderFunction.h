#pragma once
#include "FuzzyFunction.h"
class LeftShoulderFunction :
	public FuzzyFunction
{
private:
	double shoulderPoint;
public:
	LeftShoulderFunction();
	~LeftShoulderFunction();
	void setMiddle(double dS,double dUseless);
	double getValue(double t);
};

