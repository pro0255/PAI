#include "GoF.h"


int GoF::WIDTH = 500;
int GoF::HEIGHT = 500;


bool GoF::VERBOSE = false;
bool GoF::TIME = true;


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

void GoF::StartSequential(int maxG)
{
	this->b = &Board::generateBoard(GoF::WIDTH, GoF::HEIGHT);
	Board::populateWithConfiguration(*this->b);
	int m = 0;

	clock_t begin = clock();

	while (maxG > m++) {
		if (GoF::VERBOSE) this->p->print(*this->b);
		auto newO = &this->SequentialIteration(*this->b);
		delete this->b;
		this->b = newO;
	}

	clock_t end = clock();
	double elapsed_secs = double(end - begin) / CLOCKS_PER_SEC;

	if (GoF::TIME) printf("Elapsed time: %f sec\n", elapsed_secs);
}

void GoF::StartParallel(int maxG)
{
	this->b = &Board::generateBoard(GoF::WIDTH, GoF::HEIGHT);
	Board::populateWithConfiguration(*this->b);
	int m = 0;


	clock_t begin = clock();
	while (maxG > m++) {
		if (GoF::VERBOSE) this->p->print(*this->b);
		auto newO = &this->ParallelIteration(*this->b, 4);
		delete this->b;
		this->b = newO;
	}

	clock_t end = clock();
	double elapsed_secs = double(end - begin) / CLOCKS_PER_SEC;

	if (GoF::TIME) printf("Elapsed time: %f sec\n", elapsed_secs);

}



void ThreadTask(int tS, int tE, Board *tOldB, Board *tNewB, Controller *c) {
	for (int i = tS; i < tE; i++)
	{
		for (int j = 0; j < tOldB->width; j++)
		{
			tNewB->pop[i * tNewB->height + j] = c->nextState(i, j, *tOldB);
		}
	}
}




Board & GoF::ParallelIteration(Board & oldB, int numberOfThreads)
{
	vector<thread> threads;
	Board *newB = &Board::copy(oldB);

	int size = round(oldB.width / float(numberOfThreads));
	int lastSize = oldB.width % ((numberOfThreads - 1) * size);

	for (int i = 0; i < numberOfThreads; i++)
	{

		int tS = i * size;
		if (i == (numberOfThreads - 1)) {
			int tE = tS + lastSize;
			threads.push_back(thread(ThreadTask, tS, tE, &oldB, newB, this->c));
		}
		else {
			int tE = (i + 1) * size;
			threads.push_back(thread(ThreadTask, tS, tE, &oldB, newB, this->c));
		}

	}

	for (auto &t : threads) {
		t.join();
	}

	return *newB;
}


