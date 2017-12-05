#include "FuzzySet.h"

FuzzySet::FuzzySet()
{
}


FuzzySet::~FuzzySet()
{
}

void FuzzySet::addRightShoulder(double leftInterval, double rightInterval, double midle, char* name)
{
	RightShoulderFunction *tmp = new RightShoulderFunction;
	tmp->setInterval(leftInterval, rightInterval);
	tmp->setMiddle(midle, 0);
	tmp->setName(name);
	functions.push_back(tmp);
}

void FuzzySet::addLeftShoulder(double leftInterval, double rightInterval, double midle, char* name)
{
	LeftShoulderFunction *tmp = new LeftShoulderFunction;
	tmp->setInterval(leftInterval, rightInterval);
	tmp->setMiddle(midle, 0);
	tmp->setName(name);
	functions.push_back(tmp);
}

void FuzzySet::addTrapez(double leftInterval, double rightInterval, double leftMidle, double rightMidle, char* name)
{
	TrapezFunction *tmp = new TrapezFunction;
	tmp->setInterval(leftInterval, rightInterval);
	tmp->setMiddle(leftMidle, rightMidle);
	tmp->setName(name);
	functions.push_back(tmp);
}

void FuzzySet::addTriangle(double leftInterval, double rightInterval, double midle, char* name)
{
	TriangleFunction *tmp = new TriangleFunction;
	tmp->setInterval(leftInterval, rightInterval);
	tmp->setMiddle(midle, 0);
	tmp->setName(name);
	functions.push_back(tmp);
}

std::pair<double, char*> FuzzySet::getValue(double tValue)
{
	std::pair<double, char*> ret = { 0,"no value found" };
	for (FuzzyFunction* item : functions)
	{
		if (item->getValue(tValue) >= ret.first)
		{
			ret.first = item->getValue(tValue);
			ret.second = item->getName();
		}
	}
	return ret;
}

double FuzzySet::AOM()
{
	double ret = 0;

	std::cout << "----------AOM----------" << std::endl;
	for (FuzzyFunction* item : functions)
	{
		double median = (item->getRight() - item->getLeft()) / 2;
		ret += item->getValue(median);
		std::cout << item->getType() << std::endl;
		std::cout << "Median: " << median << " Value: " << item->getValue(median) << std::endl;
	}

	return ret;
}

double FuzzySet::Centroid(double steps)
{
	//steps are "s" from formula
	double ret = 0;
	double left = 0;
	double right = 0;

	//Calculate the total range
	for (FuzzyFunction* item : functions)
	{
		if (item->getLeft() <= left)
		{
			left = item->getLeft();
		}
		if (item->getRight() >= right)
		{
			right = item->getRight();
		}
	}
	std::cout << "-------CENTROID--------" << std::endl;
	std::cout << "Fuzzy-Set goes from " << left << " to " << right << std::endl;

	//add all values from each step
	std::vector<double> stepValues;
	double iS = 0;
	for (int i = left + 1; i*steps <= right; i++)
	{
		iS = i * steps;

		double _val = 0;
		for (FuzzyFunction* item : functions)
		{
			_val += item->getValue(iS);
			stepValues.push_back(_val);
		}

		std::cout << "i*s = " << iS << " Added " << _val << std::endl;
	}

	//Calculate the Average
	int size = stepValues.size();
	for (double d : stepValues)
	{
		ret += d;
	}
	ret /= size;

	return ret;
}

