#include <iostream>
#include "Board.h"
#include "Printer.h"
#include "Controller.h"
#include "GoF.h"

int main()
{

	//https://playgameoflife.com/ test
	Printer *p = new Printer();
	Controller *c = new Controller();
	GoF *g = new GoF(*c, *p);
	g->StartSequential(5);

	delete g;
}
