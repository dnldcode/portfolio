#include "Header.h"

int main()
{
	Handler500* h500 = new Handler500(100);
	Handler200* h200 = new Handler200(50);
	Handler100* h100 = new Handler100(1000);
	Handler50* h50 = new Handler50(1000);
	Handler20* h20 = new Handler20(1000);
	Handler10* h10 = new Handler10(500);
	h20->setHandler(h100);
	h100->setHandler(h200);
	h200->setHandler(h500);

	Request rq(1120);
	h20->HandleRequest(&rq);
	rq.Show();
	return 0;
}