#include "Printer.h"
#include "iostream"

using namespace std;

Printer::Printer(char trueCell, char falseCell)
{
	this->falseCell = falseCell;
	this->trueCell = trueCell;
}

void Printer::print(Board * b)
{
	for (int i = 0; i < b->width; i++)
	{
		for (int i = 0; i < b->height; i++)
		{
			cout << '*';

		}
		cout << endl;
	}
}
