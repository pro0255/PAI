#pragma once
#include <string>


using namespace std;

class Board
{
private:

	bool isWidth(int i);
	bool isHeight(int j);
public:
	~Board();
	Board(int width, int height);
	bool *pop;

	int width;
	int height;
	bool isIn(int i, int j);


	static void populateRandomBoard(Board &b);
	static Board& generateBoard(int width, int height);
	static Board& copy(Board &b);
	static int migration;
};

