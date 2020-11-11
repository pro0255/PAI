#include "Board.h"
#include "iostream"
#include <stdio.h>

int Board::migration = 0;


Board::~Board()
{
	if (pop != nullptr) {
		delete[]this->pop;
		this->pop = nullptr;
	}
}

Board::Board(int width, int height)
{
	Board::migration++;
	this->width = width;
	this->height = height;
	this->pop = nullptr;
}

bool Board::isWidth(int i)
{
	return i >= 0 && i < this->width;
}

bool Board::isHeight(int j)
{
	return j >= 0 && j < this->height;
}

bool Board::isIn(int i, int j)
{
	return this->isWidth(i) && this->isHeight(j);
}


void Board::populateWithConfiguration(Board &b) {
	try {
		for (int i = 0; i < b.height; i++)
		{
			for (int j = 0; j < b.width; j++)
			{
				b.pop[i*b.height + j] = false;
			}
		}
		b.pop[0 * b.height + 1] = true;
		b.pop[1 * b.height + 2] = true;
		b.pop[2 * b.height + 0] = true;
		b.pop[2 * b.height + 1] = true;
		b.pop[2 * b.height + 2] = true;

	}
	catch (char* e) {
		throw "Borad is to small";
	}
}


void Board::populateRandomBoard(Board &b)
{

	srand(2);
	for (int i = 0; i < b.height; i++)
	{
		for (int j = 0; j < b.width; j++)
		{
			float r = static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
			if (r >= .5) {
				b.pop[i*b.height + j] = true;
			}
			else {
				b.pop[i*b.height + j] = false;
			}
		}
	}
}




Board & Board::generateBoard(int width, int height)
{
	auto *b = new Board(width, height);
	b->pop = new bool[width * height];
	return *b;
}

Board & Board::copy(Board & b)
{

	auto *newB = new Board(b.width, b.height);
	newB->pop = new bool[b.width * b.height];
	//for (int i = 0; i < b.height; i++)
	//{
	//	for (int j = 0; j < b.width; j++)
	//	{
	//		newB->pop[i*newB->height + j] = b.pop[i*b.height + j];
	//	}
	//}

	return *newB;
}
