#include "Product.h"

string CategoryName[5] = { "Процессоры", "Видеокарты", "Операт.память", "Мат. платы", "Винчестеры" };
string CPUName[3] = { "Intel Core i3-7100",  "Intel Core i7-6700K",  "AMD Ryzen 7 1700" };
string GPUName[3] = { "GTX 1080",  "GTX 1070",  "GTX 1080 ti" };
string ROMName[3] = { "Kingston 8GB",  "Kingston 4GB",  "Samsung 4GB" };
string MBName[3] = { "Asus 1151",  "Msi AM4",  "Gigabyte AM3+" };
string HDDName[3] = { "WesternDigital 1TB",  "Samsung 1TB",  "SeaGate 750GB" };

void MakeCategories(vector<Category> &categories)
{	while (categoryn != 5)
		categories.push_back(Category(++categoryn,CategoryName[categoryn - 1]));
}
void MakeProducts(vector<Category>::iterator itc, vector<Product> &products)
{
	do {
		if (itc->getCategoryId() == 1)
		{
			int q1 = 0;
			while (q1 != 3)
				products.push_back(Product(++productn, CPUName[q1++], rand() % 5001 + 5000, rand() % 6 + 5, itc->getCategoryId()));
		}
		else if (itc->getCategoryId() == 2)
		{
			int q2 = 0;
			while (q2 != 3)
				products.push_back(Product(++productn, GPUName[q2++], rand() % 5001 + 5000, rand() % 6 + 3, itc->getCategoryId()));
		}
		else if (itc->getCategoryId() == 3)
		{
			int q3 = 0;
			while (q3 != 3)
				products.push_back(Product(++productn, ROMName[q3++], rand() % 701 + 800, rand() % 8 + 2, itc->getCategoryId()));
		}
		else if (itc->getCategoryId() == 4)
		{
			int q4 = 0;
			while (q4 != 3)
				products.push_back(Product(++productn, MBName[q4++], rand() % 2001 + 2000, rand() % 11 + 3, itc->getCategoryId()));
		}
		else if (itc->getCategoryId() == 5)
		{
			int q5 = 0;
			while (q5 != 3)
				products.push_back(Product(++productn, HDDName[q5++], rand() % 1001 + 1000, rand() % 6 + 4, itc->getCategoryId()));
		}
		itc++;
	} while (products.size() != 15);
}
void ShowProducts(Product p)
{
	cout << p;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));

	vector<Category> categories;
	vector<Product> products;
	MakeCategories(categories);
	vector<Category>::iterator itc = categories.begin();
	vector<Product>::iterator itp;
	MakeProducts(itc, products);
	random_shuffle(products.begin(), products.end());

	char way;
	int w;
	int balance = rand() % 50001 + 50000;
	Order order(itp);
	cout << "\n Ваш баланс : " << setw(6) << balance << " грн.\n" << endl;
	while (1 == true)
	{
		cout << "\n Хотите посмотреть доступные товары?(1 - да, любая другая - нет)\n\n Ответ : ";
		cin >> way;
		cout << endl;
		if (way == '1')
		{
			for_each(products.begin(), products.end(), ShowProducts);
			cout << "\n Введите Id товара который хотите купить : ";
			cin >> w;
			if (w >= products.size() || w <= 0)
			{
				cout << "\n Данного товара не существует!" << endl;
				continue;
			}
			itp = products.begin();
			while (itp->getProductId() != w)
				itp++;
			if (itp->getProductPrice() > balance)
			{
				cout << "\n У вас недостаточно денег на балансе!\n" << endl;
				continue;
			}
			cout << "\n Введите кол-во товара : ";
			cin >> w;
			if (w > itp->getProductCount())
			{
				cout << "\n В магазине недостаточно товара!\n" << endl;
				continue;
			}
			if (w <= 0)
			{
				cout << "\n Указано неверное кол-во!\n" << endl;
				continue;
			}
			if ((itp->getProductPrice() * w) > balance)
			{
				cout << "\n У вас недостаточно денег на балансе!\n" << endl;
				continue;
			}
			cout << "\n Ваш заказ :\n";
			cout << *itp;
			printf("\n Вы уверены что хотите купить данные товар в размере %d штук за %d грн.?(1 - да, любая другая - нет)\n Ответ :", w, w*itp->getProductPrice());
			cin >> way;
			if (way == '1')
			{
				order.setCount(w);
				order.setIterator(itp);
				order.MakeOrder(balance, products);
			}
			else
			{
				cout << "\n Введено неверное значение!" << endl;
				continue;
			}
		}
		else
			exit(EXIT_SUCCESS);
	}
	return false;
}