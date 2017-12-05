#include "stdafx.h"
#include "DecisionTree.h"


DecisionTree::DecisionTree()
{
}


DecisionTree::~DecisionTree()
{
}

void DecisionTree::addNodes(Node * n)
{
	nodes.push_back(n);
}

void DecisionTree::setCurrentNode(Node * n)
{
	currentNode = n;
}

void DecisionTree::decide(string decision)
{
	currentNode = currentNode->decide(decision);
	//cout << currentNode->getName();
}

Node * DecisionTree::getCurrentNode()
{
	return currentNode;
}
