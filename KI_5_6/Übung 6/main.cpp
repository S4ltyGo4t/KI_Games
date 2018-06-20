#include <iostream>
#include <vector>
#include <algorithm>
#include <limits>
#include <queue>

#include "Node.h"

using namespace std;

typedef vector<Node> Graph;

float manhattenDistance(const Node &a, const Node &b)
{
	float x = static_cast<float>(fabs(a.getPosition().getX() - b.getPosition().getX()));
	float y = static_cast<float>(fabs(a.getPosition().getY() - b.getPosition().getY()));
	float z = static_cast<float>(fabs(a.getPosition().getZ() - b.getPosition().getZ()));

	return x + y + z;
}

void astar(const Graph &G, const int &source, const int &destination, vector<pair<int, float>> &path) {
	vector<float> d(G.size()); //Costs to reach each node from start
	vector<int> parent(G.size()); //Parent element for each node;

	for (Node node : G) {
		d[node.getID()] = std::numeric_limits<float>::max();
		parent[node.getID()] = -1;
	}

	auto comp = [](const pair<Node, float>& p1, const pair<Node, float> &p2) -> bool {return p1.second > p2.second; };
	priority_queue<pair<Node, float>, vector<pair<Node, float>>, decltype(comp)> Q(comp);

	d[source] = 0.0f;
	Q.push(make_pair(G[source], d[source]));

	while (!Q.empty()) {
		Node actualNode = Q.top().first;
		unsigned actualNodeID = Q.top().first.getID();

		if (actualNodeID == destination) break;
		Q.pop();

		for (pair<Node&, float> &edge : actualNode.getEdges()) {
			int nextNodeID = edge.first.getID();
			float nextNodeCosts = edge.second;
			if (d[nextNodeID] > d[actualNodeID] + nextNodeCosts) {
				//If new route is cheaper
				d[nextNodeID] = d[actualNodeID] + nextNodeCosts;
				float priority = d[nextNodeID] + manhattenDistance(G[actualNodeID],G[destination]) ;

				parent[nextNodeID] = actualNodeID;
				Q.push(make_pair(edge.first, priority)); //Push nextNode for discovery
			}
		}
	}

	path.clear();
	int p = destination;
	path.push_back(make_pair(destination, d[p]));
	while (p != source)
	{
		p = parent[p];
		path.push_back(make_pair(p, d[p]));
	}
}


void dijkstra(const Graph &G, const int &source, const int &destination, vector<pair<int, float>> &path)
{

	vector<float> d(G.size()); //Costs to reach each node from start
	vector<int> parent(G.size()); //Parent element for each node;

	for (Node node : G) {
		d[node.getID()] = std::numeric_limits<float>::max();
		parent[node.getID()] = -1;
	}

	auto comp = [](const pair<Node, float>& p1, const pair<Node, float> &p2) -> bool {return p1.second > p2.second; };
	priority_queue<pair<Node, float>, vector<pair<Node, float>>, decltype(comp)> Q (comp);

	d[source] = 0.0f;
	Q.push(make_pair(G[source], d[source]));

	while (!Q.empty())
	{
		//int u = Q.top().first;
		//if (u == destination) break;
		Node actualNode = Q.top().first;
		unsigned actualNodeID = Q.top().first.getID();
		if (actualNodeID == destination) break;
		Q.pop();

		for (pair<Node&, float> &edge : actualNode.getEdges()) {
			int nextNodeID = edge.first.getID();
			float nextNodeCosts = edge.second;
			if (d[nextNodeID] > d[actualNodeID] + nextNodeCosts) {
				//If new route is cheaper
				d[nextNodeID] = d[actualNodeID] + nextNodeCosts;
				parent[nextNodeID] = actualNodeID;
				Q.push(make_pair(edge.first, nextNodeCosts)); //Push nextNode for discovery
			}
		}
	}
	path.clear();
	int p = destination;
	path.push_back(make_pair(destination,d[p]));
	while (p != source)
	{
		p = parent[p];
		path.push_back(make_pair(p, d[p]));
	}
	
}

int main()
{
	cout << "Übung 6" << endl;
	Graph nodes;

	unsigned i = 0;

	//						Position		Name	ID
	nodes.push_back(Node(Vector3D(12, 0, 2), "A", i++)); //0
	nodes.push_back(Node(Vector3D(5, 0, 5), "B", i++));
	nodes.push_back(Node(Vector3D(20, 0, 5), "C", i++)); //2
	nodes.push_back(Node(Vector3D(3, 0, 10), "D", i++));
	nodes.push_back(Node(Vector3D(10, 0, 10), "E", i++)); //4
	nodes.push_back(Node(Vector3D(16, 0, 10), "F", i++));
	nodes.push_back(Node(Vector3D(5, 0, 15), "G", i++)); //6
	nodes.push_back(Node(Vector3D(13, 0, 15), "H", i++));
	nodes.push_back(Node(Vector3D(20, 0, 13), "I", i++)); //8
	nodes.push_back(Node(Vector3D(9, 0, 20), "J", i++));
	nodes.push_back(Node(Vector3D(20, 0, 20), "K", i++)); //10
	
	nodes[0].addEdge(nodes[1]);
	nodes[0].addEdge(nodes[2]);

	nodes[1].addEdge(nodes[3]);
	nodes[1].addEdge(nodes[4]);

	nodes[2].addEdge(nodes[8]);
	nodes[2].addEdge(nodes[4]);

	nodes[3].addEdge(nodes[6]);

	nodes[4].addEdge(nodes[5]);
	nodes[4].addEdge(nodes[2]);

	nodes[5].addEdge(nodes[7]);

	nodes[6].addEdge(nodes[7]);
	nodes[6].addEdge(nodes[9]);

	nodes[7].addEdge(nodes[8]);
	nodes[7].addEdge(nodes[10]);

	nodes[8].addEdge(nodes[10]);

	int source, destination;

	while (true) {
		//Print Names and IDs
		cout << endl << endl;
		for (Node &node : nodes) {
			cout << node.getName() << " ";
		}
		cout << endl;
		for (Node &node : nodes) {
			cout << node.getID() << " ";
		}
		cout << endl;

		cout << "Source:";
		cin >> source;
		cout << "Destination:";
		cin >> destination;

		//Do Path finding
		vector<pair<int, float>> path;
		dijkstra(nodes, source, destination, path);
		for (int i = path.size() - 1; i >= 0; i--)
			cout << "Node << " << nodes[path[i].first].getName() << " C:" << path[i].second << endl;

		astar(nodes, source, destination, path);
		for (int i = path.size() - 1; i >= 0; i--)
			cout << "Node << " << nodes[path[i].first].getName() << " C:" << path[i].second << endl;

	}

	return 0;
}