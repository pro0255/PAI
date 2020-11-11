#include "Controller.h"
#include "iostream"
using namespace std;
Controller::Controller()
{
	this->sur.push_back(make_pair(0, 1));
	this->sur.push_back(make_pair(1, 1));
	this->sur.push_back(make_pair(1, 0));
	this->sur.push_back(make_pair(1, -1));
	this->sur.push_back(make_pair(0, -1));
	this->sur.push_back(make_pair(-1, -1));
	this->sur.push_back(make_pair(-1, 0));
	this->sur.push_back(make_pair(-1, 1));
}

Controller::~Controller()
{

}


bool Controller::nextState(int inputI, int inputJ, Board & b)
{
	auto currentCell = b.pop[inputI* b.height + inputJ];
	int numberOfLive = 0;
	for (int i = 0; i < this->sur.size(); i++)
	{
		auto p = this->sur.at(i);
		auto posY = inputI + p.first;
		auto posX = inputJ + p.second;

		if (b.isIn(posY, posX)) {
			auto neigState = b.pop[posY * b.height + posX];

			if (neigState) {
				numberOfLive++;
			}
		}
	}
	return this->runConditions(numberOfLive, currentCell);
}

bool Controller::runConditions(int numberOfLive, bool state)
{
	if (state && numberOfLive < 2)
	{
		return false;
	}

	if (state && numberOfLive >= 2 && numberOfLive <= 3)
	{
		return true;
	}
	if (state && numberOfLive > 3)
	{
		return false;
	}
	if (!state && numberOfLive == 3)
	{
		return true;
	}
	return state;
}
