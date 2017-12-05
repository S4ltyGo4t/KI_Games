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

//double FuzzySet::getValue(double tValue)
//{
//	double ret = 0;
//	for(FuzzyFunction* item : functions)
//	{
//		if(item->getValue(tValue) >= ret)
//		{
//			ret = item->getValue(tValue);
//		}
//	}
//
//	std::cout << "The fuzzified value of " << tValue << " is: " << ret << std::endl;
//	return ret;
//	//printf("The Fuzzified Value of " + tValue + "is: " + ret);
//}
std::pair<double,char*> FuzzySet::getValue(double tValue)
{
	std::pair<double, char*> ret = {0,"no value found"};
	for (FuzzyFunction* item : functions)
	{
		if (item->getValue(tValue) >= ret.first)
		{
			ret.first = item->getValue(tValue);
			ret.second = item->getName();
		}
	}

	////TODO MAKE NEW Function to print values
	//std::cout << "The fuzzified value of " << tValue << " is: " << ret.first << std::endl;
	//std::cout << "Its name is: " << ret.second << "\n"<<std::endl;

	return ret;
}

std::pair<double, char*> FuzzySet::centroid(double tValue)
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

	////TODO MAKE NEW Function to print values
	//std::cout << "The fuzzified value of " << tValue << " is: " << ret.first << std::endl;
	//std::cout << "Its name is: " << ret.second << "\n" << std::endl;

	return ret;
}

std::pair<double, char*> FuzzySet::AOM(double tValue)
{


	std::pair<double, char*> ret = { 0,"no value found" };

	for (FuzzyFunction* item : functions)
	{
		item->getValue(item->)

		//if (item->getValue(tValue) >= ret.first)
		//{
		//	ret.first = item->getValue(tValue);
		//	ret.second = item->getName();
		//}
	}

	//TODO MAKE NEW Function to print values
	//std::cout << "The fuzzified value of " << tValue << " is: " << ret.first << std::endl;
	//std::cout << "Its name is: " << ret.second << "\n" << std::endl;

	return ret;
}
