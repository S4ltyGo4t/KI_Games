#include "stdafx.h"
#include <iostream>
#include <cmath>
#include <cstring>
#include "FuzzySet.h"

#define KEINGELD "armer Schlucker"
#define BISCHENGELD "bissle"
#define VIELGELD "reicher Hund"

#define KEINEMOTIVATION "koi Lust"
#define BISCHENMOTIVATION "weiss it"
#define VIELMOTIVATION "gehmer los"

const double cdMinimumPrice = 0;
const double cdMaximumPrice = 70;

using namespace std;

int main()
{
	FuzzySet fSetMoney;
	fSetMoney.addLeftShoulder(0, 70, 25, "armer Schlucker");
	fSetMoney.addTriangle(15, 90, 60, "bissle");
	fSetMoney.addRightShoulder(70, 100, 90, "reicher Hund");

	FuzzySet fSetMotivation;
	fSetMoney.addLeftShoulder(0, 80, 30, "koi Lust");
	fSetMoney.addTriangle(35, 90, 60, "weiss it");
	fSetMoney.addRightShoulder(90, 100, 95, "richtig Bock");

	FuzzySet fSetDecision;
	fSetDecision.addLeftShoulder(0, 50, 25, "bleibmer daheim");
	fSetDecision.addRightShoulder(50, 100, 75, "gehmer Los");

	char* motivation = new char[strlen(fSetMotivation.getValue(40).second) + 1];
	strcpy(motivation, fSetMotivation.getValue(40).second);

	char* money = new char[strlen(fSetMoney.getValue(62).second) + 1];
	strcpy(money, fSetMoney.getValue(62).second);
		
	if (strcmp(money, KEINGELD) == 0 && strcmp(motivation,KEINEMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, KEINGELD) == 0 && strcmp(motivation, BISCHENMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, KEINGELD) == 0 && strcmp(motivation, VIELMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, BISCHENGELD) == 0 && strcmp(motivation, KEINEMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, BISCHENGELD) == 0 && strcmp(motivation, BISCHENMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, BISCHENGELD) == 0 && strcmp(motivation, VIELMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, VIELGELD) == 0 && strcmp(motivation, KEINEMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, VIELGELD) == 0 && strcmp(motivation, BISCHENMOTIVATION) == 0)
	{

	}
	else if (strcmp(money, VIELGELD) == 0 && strcmp(motivation, VIELMOTIVATION) == 0)
	{

	}

	getchar();
	return EXIT_SUCCESS;
}

