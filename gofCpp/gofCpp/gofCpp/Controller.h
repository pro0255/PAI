#pragma once
#include "Board.h"
#include <vector>


class Controller
{
public:
	Controller();
	~Controller();
	bool nextState(int i, int j, Board &b);
private:
	bool runConditions(int numberOfLive, bool cState);
	vector<pair<int, int>> sur;
};

