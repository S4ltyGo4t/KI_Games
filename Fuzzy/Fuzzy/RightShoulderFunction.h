#pragma once
#include "FuzzyFunction.h"
class RightShoulderFunction :
	public FuzzyFunction
{
private:
	double shoulderPoint;
public:
	RightShoulderFunction();
	~RightShoulderFunction();
	void setMiddle(double dS,double dUseless);
	double getValue(double t);
};

