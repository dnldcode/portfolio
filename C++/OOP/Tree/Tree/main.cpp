#include "header.h"
#include "subheader.h"

void main() 
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	Fish f1("trout1", 2.5, 10);
	Fish f2("trout2", 2.5, 250);
	Fish f3("trout3", 2.5, 306448);
	Fish f4("trout4", 2.5, 45630);
	Fish f5("trout5", 2.5, 540);
	FTree r;
	r.Insert(new Node(f1));
	r.Insert(new Node(f2));
	r.Insert(new Node(f3));
	r.Insert(new Node(f4));
	r.Insert(new Node(f5));
	r.Show(r.getRoot());

	Node *min = r.getMin(r.getRoot());
	Node *max = r.getMax(r.getRoot());
	cout << endl << L"Минимальный объект: " << min->data << endl;
	cout << L"Максимальный объект: " << max->data << endl;
}
