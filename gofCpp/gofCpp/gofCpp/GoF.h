#pragma once
#include "Controller.h"
#include "Printer.h"
#include "Board.h"

class GoF
{
private:
	Controller *c;
	Printer *p;
	Board *b;
	Board &SequentialIteration(Board& oldB);


public:
	GoF(Controller &c, Printer &p);
	~GoF();
	void StartSequential(int);
};

