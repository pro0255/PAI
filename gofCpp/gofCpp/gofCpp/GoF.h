#pragma once
#include "Controller.h"
#include "Printer.h"
#include "Board.h"
#include <vector>
#include <thread>
#include "iostream"
#include "math.h"

using namespace std;

class GoF
{
private:
	Controller *c;
	Printer *p;
	Board *b;
	Board &SequentialIteration(Board& oldB);
	Board &ParallelIteration(Board& oldB, int numberOfThreads);



public:
	GoF(Controller &c, Printer &p);
	~GoF();
	void StartSequential(int);
	void StartParallel(int);

	static int WIDTH;
	static int HEIGHT;
};

