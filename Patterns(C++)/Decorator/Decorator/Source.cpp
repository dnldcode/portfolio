#include "Header.h"

int main()
{
	setlocale(LC_ALL, "Russian");
	Text* t = new Text;
	t->setText("Test line of text");
	t->Display();
	Text* tbold = new BoldDecorator(t);
	tbold->Display();
	Text* titalic = new ItalicDecorator(tbold);
	titalic->Display();
	Text* big = new BigDecorator(titalic);
	big->Display();
	t->Create_File("123.html");
	tbold->Create_File("123.html");
	titalic->Create_File("123.html");
	big->Create_File("123.html");
	delete tbold;
	delete titalic;
	delete t;
	return false;
}