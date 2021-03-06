#include "stdafx.h"
#include "GeneticAlgorithmModule.h"

int main()
{
	Gen* cow = new Gen("Cow", 70.0f, 200.0f);
	cout << "Name: " << cow->getName() << " Cost: " << cow->getCost() << " Proceeds: " << cow->getProceeds() << endl;
	Gen* pig = new Gen("Pig", 20.0f, 80.0f);
	cout << "Name: " << pig->getName() << " Cost: " << pig->getCost() << " Proceeds: " << pig->getProceeds() << endl;
	Gen* sheep = new Gen("Sheep", 30.0f, 160.0f);
	cout << "Name: " << sheep->getName() << " Cost: " << sheep->getCost() << " Proceeds: " << sheep->getProceeds() << endl;
	Gen* chicken = new Gen("Chicken", 10.0f, 100.0f);
	cout << "Name: " << chicken->getName() << " Cost: " << chicken->getCost() << " Proceeds: " << chicken->getProceeds() << endl;
	Gen* ostrich = new Gen("Ostrich", 60.0f, 150.0f);
	cout << "Name: " << ostrich->getName() << " Cost: " << ostrich->getCost() << " Proceeds: " << ostrich->getProceeds() << endl;
	Gen* elephant = new Gen("Elephant", 90.0f, 300.0f);
	cout << "Name: " << elephant->getName() << " Cost: " << elephant->getCost() << " Proceeds: " << elephant->getProceeds() << endl;

	vector<Gen*> genes;
	genes.push_back(cow);
	genes.push_back(pig);
	genes.push_back(sheep);
	genes.push_back(chicken);
	genes.push_back(ostrich);
	genes.push_back(elephant);


	GeneticAlgorithmModule* fancyAI = new GeneticAlgorithmModule();
	for (int i = 0; i <= 50; i++)
	{
		fancyAI->GenerateChromosom(genes,2500000);
		
	}
	fancyAI->addGeneration(fancyAI->getPopulation());
	cout << "WOW! Fancy C++11 amazing shit incoming:" << endl;
	fancyAI->printPopulation();
	//for (int i = 0; i <= 50; i++)
	//{
	//	fancyAI->GenerateChromosom(cow, pig, sheep, chicken, ostrich, elephant);
	//}


	getchar();
	return 0;
}

