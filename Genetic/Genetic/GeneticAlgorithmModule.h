#pragma once
#include "stdafx.h"
#include "Chromosom.h"

struct APtrComp
{
	bool operator()(Chromosom* lhs, Chromosom* rhs) const {
		if (lhs->getFitnessValue() < rhs->getFitnessValue())
		{
			return true;
		}
		else
		{
			return false;
		}
	};
};

class GeneticAlgorithmModule
{
private:
	set<Chromosom*, APtrComp> population;
	vector<set<Chromosom*, APtrComp>> generations;

public:
	GeneticAlgorithmModule();
	~GeneticAlgorithmModule();
	void GenerateChromosom(Gen * g1, Gen * g2, Gen * g3, Gen * g4, Gen * g5, Gen * g6);
	void GenerateChromosom(vector<Gen*> genes, float maxCost);
	void addGeneration(set<Chromosom*, APtrComp> _gen);
	set<Chromosom*, APtrComp> getPopulation();
	void printPopulation();
};

