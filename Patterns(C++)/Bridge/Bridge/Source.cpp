#include "Header.h"

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	EmailSender* es = new EmailSender;
	Message* msg = new Message(es, "microsoft@gmail.com", "sample text");

	msg->Send();
	MsmqSender* qsender = new MsmqSender;
	msg->setSender(qsender);
	msg->Send();

	SuperMessage* sm = new SuperMessage(es, "microsoft@gmail.com", "sample text", 5);
	sm->Send();

	delete es;
	delete msg;
	delete qsender;
	delete sm;

	return false;
}