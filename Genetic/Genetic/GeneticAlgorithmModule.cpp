#include "stdafx.h"
#include "GeneticAlgorithmModule.h"


GeneticAlgorithmModule::GeneticAlgorithmModule()
{
}


GeneticAlgorithmModule::~GeneticAlgorithmModule()
{
}

void GeneticAlgorithmModule::GenerateChromosom(Gen * g1, Gen * g2, Gen * g3, Gen * g4, Gen * g5, Gen * g6)
{
	Chromosom* c1 = new Chromosom();
	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g1);
	}

	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g2);
	}

	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g3);
	}

	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g4);
	}

	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g5);
	}

	for (int i = 0; i < (rand()); i++)
	{
		c1->getGenes().push_back(g6);
	}
	c1->CalcFitness();
	c1->printFitness();
	population.insert(c1);
	cout << c1->getGenes().size() << endl;

}


void GeneticAlgorithmModule::GenerateChromosom(vector<Gen*> genes, float maxCost)
{
	Chromosom* c = new Chromosom();
	for (int i = 0; i < genes.size(); i++)
	{
		for (int n = 0; n < (rand()); n++)
		{
			c->addGen(genes[i]);
		}
	}
	
	if (c->isAccepted(maxCost))
	{
		c->CalcFitness();
		population.insert(c);
	}
}


void GeneticAlgorithmModule::addGeneration(set<Chromosom*, APtrComp> _gen)
{
	generations.push_back(_gen);
}

set<Chromosom*, APtrComp> GeneticAlgorithmModule::getPopulation()
{
	return population;
}

void GeneticAlgorithmModule::printPopulation()
{
	for (auto f : population)
	{
		f->printFitness();
	}
}
