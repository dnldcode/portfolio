#include "Header.h"

int main()
{
	RealShop shop1("Shop1");
	RealShop shop2("Shop2");
	RealShop shop3("Shop3");
	RealShop shop4("Shop4");

	Product product1("Tesla 3", 35000);
	product1.Subscribe(&shop1);
	product1.Subscribe(&shop2);
	product1.Subscribe(&shop3);

	product1.ChangePrice(34500);
	product1.NotifyAll();
	product1.Unsubscribe(&shop2);
	cout << "---" << endl;
	product1.NotifyAll();
	return false;
}