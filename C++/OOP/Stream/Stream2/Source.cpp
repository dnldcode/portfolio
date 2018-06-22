#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <fstream>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	char ch;
	ifstream in("picture1.jpg", ios::in | ios::binary);
	ofstream out("picture2.jpg", ios::out | ios::binary);
	while (in.get(ch))
		out.put(ch);
	in.close();
	out.close();
	return 0;
}