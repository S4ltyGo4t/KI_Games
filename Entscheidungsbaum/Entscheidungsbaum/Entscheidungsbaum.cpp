#include "stdafx.h"
#include "DecisionTree.h"
#include "Node.h"

int main()
{
	string input;
	//bool running = true;

	Node * startNode = new Node("Weekend?");
	Node * Node1end = new Node('y',"No lecture during weekends! Stay home!");
	Node * Node2 = new Node('n',"Is the lecture before 10 AM?");
	Node * Node3 = new Node('n',"Is it cold outside?" );
	Node * Node4end = new Node('y',"Nah, too early. Stay Home!" );
	Node * Node5end = new Node('y',"Too cold. Stay home!");
	Node * Node6 = new Node('n',"Is your best mate going?");
	Node * Node7end = new Node('n',"Stay Home! Its gonna be boring.");
	Node * Node8 = new Node('y', "Is the lecture interesting?");
	Node * Node9end = new Node('y', "Okay. Go to Uni, come on.");
	Node * Node10end = new Node('n', "Don't go. Its not worth it!");
	
	startNode->addChildren(Node1end);
	startNode->addChildren(Node2);

	Node2->addChildren(Node4end);
	Node2->addChildren(Node3);

	Node3->addChildren(Node5end);
	Node3->addChildren(Node6);

	Node6->addChildren(Node7end);
	Node6->addChildren(Node8);

	Node8->addChildren(Node9end);
	Node8->addChildren(Node10end);

	DecisionTree lectureTree;
	lectureTree.setCurrentNode(startNode);

	cout << "Should I go to the Lecture - A decision Tree. Type either 'yes' or 'no' to decide" << endl; 

	while (!lectureTree.getCurrentNode()->isEndNode())
		{
			lectureTree.getCurrentNode()->printName();
			cin >> input;
			lectureTree.decide(input);
		}
	cout << "Your Decision: " << endl;
	lectureTree.getCurrentNode()->printName();

	getchar();
	getchar();
	getchar();
    return 0;
}

