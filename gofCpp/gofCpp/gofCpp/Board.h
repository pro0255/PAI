#pragma once
#include <string>


using namespace std;

class Board
{
private:

	bool isWidth(int i);
	bool isHeight(int j);
public:
	Board(int width, int height);
	bool **pop;

	int width;
	int height;
	bool isIn(int i, int j);

	static Board* generateRandomBoard(int width, int height);
	static int migration;
};

