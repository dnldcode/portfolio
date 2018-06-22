#include "Header.h"

int main()
{
	Chatter* ch1 = new Chatter("Alex");
	Chatter* ch2 = new Chatter("Mary");
	Chatter* ch3 = new Chatter("Jane");
	Chatter* ch4 = new Chatter("Bob");

	AbMediator* m1 = new Mediator1;

	m1->AddChatter(ch1);
	m1->AddChatter(ch2);
	m1->AddChatter(ch3);
	m1->AddChatter(ch4);

	ch1->Send_Message(m1,"Hello");
	ch3->Send_Message(m1, "Glad to see you");
	delete ch1, ch2, ch3, ch4, m1;
	return false;
}