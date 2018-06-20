#pragma once
#include "Vector3D.h"
#include <string>
#include <vector>
#include <iostream>

using namespace std;


class Node {
private:
	Vector3D position;
	std::string name;
	unsigned id;
	std::vector<pair<Node&, float>> edges;
public:
	Node(Vector3D position, std::string name, unsigned id);
	void addEdge(Node &node);

	Vector3D getPosition() const;
	unsigned getID() const;
	string getName() const;
	std::vector<pair<Node&, float>>& getEdges();
};