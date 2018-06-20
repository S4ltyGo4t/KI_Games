#pragma once
#include "stdafx.h"

class Gen
{
private:
	string name;
	float cost;
	float proceeds;

public:
	Gen();
	Gen(string _name,float _cost, float _proceeds);
	~Gen();
	void setName(string _name);
	void setCost(float _cost);
	void setproceeds(float _proceeds);
	string getName();
	float getCost();
	float getProceeds();
};

