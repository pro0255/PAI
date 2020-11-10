#include <iostream>
#include "Board.h"
#include "Printer.h"

int main()
{
	int width = 10;
	int height = 10;

	Printer *p = new Printer();
	Board &b = Board::generateBoard(width, height);
	Board::populateRandomBoard(b);
	p->print(b);
}
