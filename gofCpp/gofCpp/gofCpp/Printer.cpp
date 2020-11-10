#include "Printer.h"
#include "iostream"

using namespace std;

Printer::Printer(char trueCell, char falseCell)
{
	this->falseCell = falseCell;
	this->trueCell = trueCell;
}

void Printer::print(Board & b)
{
	cout << "=================" << endl;

	for (int i = 0; i < b.height; i++)
	{
		for (int j = 0; j < b.width; j++)
		{
			printf("%c", b.pop[i*b.height + j] ? this->trueCell : this->falseCell);
		}
		cout << endl;
	}

	cout << "=================" << endl;
}
