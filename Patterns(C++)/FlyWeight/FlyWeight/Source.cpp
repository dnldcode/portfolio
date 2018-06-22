#include "Header.h"

int main()
{
	string text = "lazy dog is sleeping on the wet straw";
	
	CharFactory factory;
	BaseSymbol *c;
	ofstream out("text.html");
	for (string::iterator it = text.begin(); it != text.end();it++)
	{
		c = factory.getSymbol(*it);
		cout << (c->getChar());
		out << c->DisplaySymbol(20, "green");
	}
	cout << endl << factory.getPoolSize() << endl;
	factory.showPool();
	out.close();
	return 0;
}