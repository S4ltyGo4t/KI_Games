#include "stdafx.h"
#include "Node.h"


Node::Node()
{

}

Node::Node(string n)
{
	decisionVariable = NULL;
	name = n;

}

Node::Node(char d, string n)
{
	decisionVariable = d;
	name = n;
}


Node::~Node()
{
}

char Node::getDecVariable()
{
	return decisionVariable;
}

string Node::getName()
{
	return name;
}

void Node::printName()
{
	cout << name << endl;
}

void Node::addChildren(Node* child)
{
	children.push_back(child);
}

void Node::addParent(Node* parent)
{
	parents.push_back(parent);
}

//vector<Node *> Node::getChildren()
//{	
//		return children;	
//}

vector<Node*> Node::getParents()
{
	return parents;
}

Node * Node::getChildrenByTag(char tag)
{
	Node* ret;
	for (Node * p : children)
	{
		if (p->getDecVariable() == tag)
		{
			//cout << "Found node with tag " << tag << endl;
			ret = p;
			return ret;
		}
	};
}

Node * Node::decide(string decision)
{
	if (decision == "yes")
		return(getChildrenByTag('y'));
	else if (decision == "no")
		return(getChildrenByTag('n'));
}

bool Node::isEndNode()
{
	if (children.size() == 0)
		return true;
	else
		return false;
}
