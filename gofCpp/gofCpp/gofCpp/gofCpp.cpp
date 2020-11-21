#include <iostream>
#include "Board.h"
#include "Printer.h"
#include "Controller.h"
#include "GoF.h"
#include <string>
#include <fstream>
#include <sstream>

using namespace std;

string RunWithWatch(GoF *g, int maxG, bool par) {

	clock_t begin = clock();
	if (par) {
		g->StartParallel(maxG);
	}
	else {
		g->StartSequential(maxG);
	}
	clock_t end = clock();
	double elapsed_secs = double(end - begin) / CLOCKS_PER_SEC;
	return to_string(elapsed_secs);
}



void WriteToFile(string seq, string par, int maxG, string path) {

	ofstream myfile(path);

	stringstream ss;


	ss << "Calcuation of Game of Life with " << maxG << " migration cycles\n" << "\tSequential " << seq << "\n\tParallel " << par;

	if (myfile.is_open()) {
		myfile << ss.str();
		myfile.close();
	}
}

void RunCalculation(GoF *g, int maxG) {
	string seq = RunWithWatch(g, maxG, false);
	string par = RunWithWatch(g, maxG, true);
	string p = "..//gofCpp//TestOutputs//example-" + to_string(maxG) + ".txt";
	//"..//gofCpp//TestOutputs//example.txt"
	WriteToFile(seq, par, maxG, p);
}

int main()
{

	//https://playgameoflife.com/ test
	Printer *p = new Printer();
	Controller *c = new Controller();
	GoF *g = new GoF(*c, *p);
	RunCalculation(g, 5);
	RunCalculation(g, 100);
	RunCalculation(g, 500);
	RunCalculation(g, 1000);
	delete g;
}
