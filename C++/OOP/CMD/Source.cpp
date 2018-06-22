#include <iostream>
#include <Windows.h>
#include <ctime>
#include <iomanip>
#include <io.h>
#include <fcntl.h>
#include <conio.h>
using namespace std;

void main(int num,char *arg[])
{
	setlocale(LC_ALL, "Russian");
	if (num > 0)
	{
		if (num == 3)
		{
			FILE *out = fopen(arg[1], "rb");
				if (!out)
				{
					cout << "error1" << endl;
				}
				char buf[256];
				FILE *in = fopen(arg[2], "wb");
				while (!feof(out))
				{
					fread(buf, sizeof(buf), 1, out);
					fwrite(buf, sizeof(buf), 1, in);
					cout << buf << endl;
				}
				
				fclose(in);
				fclose(out);
		}
		if (num < 3 || num > 3)
			cout << "error2" << endl;
	}
	else 
		cout << "error3" << endl;
}