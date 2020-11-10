#include "Board.h"
#include "iostream"

int Board::migration = 0;


Board::Board(int width, int height)
{
	this->width = width;
	this->height = height;
}

bool Board::isWidth(int i)
{
	return i >= this->width && i < this->width;
}

bool Board::isHeight(int j)
{
	return j >= this->height && j < this->height;
}

bool Board::isIn(int i, int j)
{
	return this->isWidth(i) && this->isHeight(j);
}

Board * Board::generateRandomBoard(int width, int height)
{
	Board *b = new Board(width, height);
	return b;
}
