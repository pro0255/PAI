#pragma once
#include "Board.h"

class Printer
{

private:
	char trueCell;
	char falseCell;

public:
	Printer(char trueCell, char falseCell);
	void print(Board *b);



};

