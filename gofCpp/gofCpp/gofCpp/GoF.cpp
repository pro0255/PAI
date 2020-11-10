#include "GoF.h"

int GoF::WIDTH = 5;
int GoF::HEIGHT = 5;


GoF::GoF(Controller &c, Printer &p)
{
	this->c = &c;
	this->p = &p;
}

GoF::~GoF()
{
	delete this->p;
	delete this->c;
}

void GoF::StartSequential(int maxG)
{
	this->b = &Board::generateBoard(GoF::WIDTH, GoF::HEIGHT);
	Board::populateRandomBoard(*this->b);

	int m = 0;
	while (maxG > m++) {
		this->p->print(*this->b);
		auto newO = &this->SequentialIteration(*this->b);
		delete this->b;
		this->b = newO;
	}
}

Board & GoF::SequentialIteration(Board & oldB)
{
	Board *newB = &Board::copy(oldB);
	for (int i = 0; i < oldB.height; i++)
	{
		for (int j = 0; j < oldB.width; j++)
		{
			newB->pop[i*newB->height + j] = c->nextState(i, j, oldB);
		}
	}
	return *newB;
}
