#include "stdafx.h"
#include "Chromosom.h"


Chromosom::Chromosom()
{
	Gen* cow = new Gen("Cow", 70.0f, 200.0f);
	cows[cow] = 5;
	float t = cow->getProceeds() * cows[cow];

	map<string, int> mapKeyCow;
	mapKeyCow["cow"] = 1;
	genneees[mapKeyCow] = cow;
	//genneees.insert("cow", 5, cow);
}

Chromosom::Chromosom(float max)
{
	float tmp = 0;
	for (Gen* g : genes)
	{
		tmp += g->getCost();
	}
	cost = tmp;
}


Chromosom::~Chromosom()
{
}

vector<Gen*> Chromosom::getGenes()
{
	return genes;
}

float Chromosom::getCost()
{
	return cost;
}

float Chromosom::getFitnessValue()
{
	return fitnessValue;
}

void Chromosom::CalcFitness()
{
	float tmp = 0;
	for (Gen* g : genes)
	{
		tmp += g->getProceeds();
	}
	fitnessValue = tmp;
}

bool Chromosom::isAccepted(float _maxCost)
{
	float tmp = 0;
	for (Gen* g : genes)
	{
		tmp += g->getCost();
	}

	if (tmp > _maxCost)
	{
		return false;
	}
	else
	{
		CalcFitness();
		return true;
	}
}

void Chromosom::addGen(Gen* g)
{
	genes.push_back(g);
}

void Chromosom::printFitness()
{
	cout << "FitnessValue: " << fitnessValue << endl;
}
