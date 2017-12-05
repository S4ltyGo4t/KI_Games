#pragma once
#include <vector>
#include <string>

using namespace std;

class Node
{
private:
	char decisionVariable;
	string name;
	vector<Node*> parents;
	vector<Node*> children;
public:
	Node();
	Node(string n);
	Node(char d, string n);
	~Node();
	char getDecVariable();
	string getName();
	void printName();
	void addChildren(Node * n);
	void addParent(Node* p);
	//vector<Node *> getChildren();
	vector<Node*> getParents();
	Node * getChildrenByTag(char tag);
	Node * decide(string decision);

	bool isEndNode();

};

