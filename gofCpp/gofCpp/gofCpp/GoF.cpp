#include "GoF.h"

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
	Board::migration = 0;
	this->b = &Board::generateBoard(10, 10);
	Board::populateRandomBoard(*this->b);

	while (maxG < Board::migration) {
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
