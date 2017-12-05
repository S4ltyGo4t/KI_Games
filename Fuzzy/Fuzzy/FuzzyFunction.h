#pragma once
#include <iostream>
#include <cmath>
#include <cstring>
#include <string>
class FuzzyFunction
{
protected:
	double left, right;
	char*   type;
	char*  name;

public:
	FuzzyFunction();
	virtual ~FuzzyFunction();

	virtual void setInterval(double l, double r)
	{
		left = l; right = r;
	}

	virtual void setMiddle(double dL = 0,double dR = 0) = 0;

	virtual void setName(const char* s)
	{
		name = new char[strlen(s) + 1];
		strcpy(name, s);
	}

	bool	isDotInInterval(double t);

	char* getType()const
	{
		return type;
	}

	char*	getName() const
	{
		return name;
	}

	double	getLeft() const
	{
		return left;
	}

	double	getRight() const
	{
		return right;
	}
	//Wird bei implementierung überschrieben
	virtual double getValue(double t) = 0;
};
