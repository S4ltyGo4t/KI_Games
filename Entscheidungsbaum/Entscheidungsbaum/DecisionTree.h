#pragma once
#include "Node.h"
#include <list>

using namespace std;

class DecisionTree
{
private:
	Node* currentNode;
	list<Node*> nodes;

public:
	DecisionTree();
	~DecisionTree();
	void addNodes(Node* n);
	void setCurrentNode(Node* n);
	void decide(string decision);
	Node * getCurrentNode();
};

