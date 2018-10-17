#include "Fishes1.h"

void main()
{
	setlocale(LC_ALL, "Russian");
	Fish f1("fish 1", 20, 150);
	Fish f2("fish 2", 30, 170);
	Fish f3("fish 3", 40, 190);
	Fish f4("fish 4", 50, 210);
	Fish f5("fish 5", 60, 230);
	FILE *out = fopen("fishes.txt", "wb+");
	Fish fishes[5] = { f1,f2,f3,f4,f5 };
	fwrite(&fishes, sizeof(f1), 5, out);
	int num = 0;
	do
	{
		cout << "Enter element :";
		cin >> num;
		if (cin.fail()) 
		{
			cin.clear();
			cin.ignore();
		}
	} while (!(num > 0 && num < 6));
	fseek(out, (num - 1) * sizeof(f1), SEEK_SET);
	Fish tmp;
	fread(&tmp, sizeof(tmp), 1, out);
	cout << tmp;
	fclose(out);
}