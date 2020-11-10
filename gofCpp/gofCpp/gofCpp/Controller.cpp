#include "Controller.h"

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

bool Controller::nextState(int i, int j, Board & b)
{
	auto currentCell = b.pop[i* b.height + j];
	int numberOfLive = 0;
	for (int i = 0; i < this->sur.size(); i++)
	{
		auto p = this->sur.at(i);
		auto posY = i + p.first;
		auto posX = j + p.second;

		if (b.isIn(posY, posX)) {
			if (b.pop[posY * b.height + posX]) numberOfLive++;
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
