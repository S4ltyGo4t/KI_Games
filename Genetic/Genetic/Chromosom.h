#pragma once
#include "stdafx.h"
#include "Gen.h"

class Chromosom
{
private:
	map<Gen*, int> cows;

	vector<Gen*> genes;
	map<map<string, int>,Gen*> genneees;
	float cost;
	float fitnessValue;

public:

	Chromosom();
	Chromosom(float max);
	~Chromosom();

	bool operator< (const Chromosom& chrom) const
	{
		cout << "Current: " << fitnessValue << "new one: " << chrom.fitnessValue << endl;
		if (fitnessValue <= chrom.fitnessValue)
		{
			return true;
		}
		else
		{
			return false;
		}
		return (fitnessValue < chrom.fitnessValue);
	}

	vector<Gen*> getGenes();
	float getCost();
	float getFitnessValue();
	void CalcFitness();
	bool isAccepted(float _maxCost);
	void addGen(Gen* g);
	void printFitness();
};

