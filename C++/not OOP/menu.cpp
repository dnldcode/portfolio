#include <iostream>
#include <Windows.h>
#include <string>
using namespace std;
enum ConsoleColor
{

	Green = 2,
	LightYellow = 14

};

void SetColor(int text, int background)
{
	HANDLE hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleTextAttribute(hStdOut, (WORD)((background << 4) | text));
}


int main()
{
	setlocale(LC_ALL, "Russian");
START:
	char x;
	float S, s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5 = 0, s6 = 0, s7 = 0, s8 = 0, s9 = 0, s10 = 0, s11 = 0, s12 = 0, s13 = 0, s14 = 0, s15 = 0, s16 = 0, s17 = 0, s18 = 0, s19 = 0, s20 = 0;
	float f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0, f9 = 0, f10 = 0, f11 = 0, f12 = 0, f13 = 0, f14 = 0, f15 = 0, f16 = 0, f17 = 0, f18 = 0, f19 = 0, f20 = 0;
	short X,X1;
	SetColor(2, 0);
M:
	system("cls");
	cout << "\n\t\t\t\t ����\n" << endl;

	cout << "��� �����:\t\t\t ���-��:\t\t����:" << endl;
	if (f1 > 0)
	{
		cout << "���� �������� \t\t\t   " << f1 << "��." << "\t\t\t" << s1 << " ���." << endl;
	}
	if (f2 > 0)
	{
		cout << "���� ������ \t\t\t   " << f2 << "��." << "\t\t\t" << s2 << " ���." << endl;
	}
	if (f3 > 0)
	{
		cout << "���� ����� \t\t\t   " << f3 << "��." << "\t\t\t" << s3 << " ���." << endl;
	}
	if (f4 > 0)
	{
		cout << "���� ������� \t\t\t   " << f4 << "��." << "\t\t\t" << s4 << " ���." << endl;
	}
	if (f5 > 0)
	{
		cout << "���� ������ ���� \t\t   " << f5 << "��." << "\t\t\t" << s5 << " ���." << endl;
	}
	if (f6 > 0)
	{
		cout << "������� ���� \t\t\t   " << f6 << "��." << "\t\t\t" << s6 << " ���." << endl;
	}
	if (f7 > 0)
	{
		cout << "������ \t\t\t\t   " << f7 << "��." << "\t\t\t" << s7 << " ���." << endl;
	}
	if (f8 > 0)
	{
		cout << "������ ��� \t\t\t   " << f8 << "��." << "\t\t\t" << s8 << " ���." << endl;
	}
	if (f9 > 0)
	{
		cout << "������ ���� \t\t\t   " << f9 << "��." << "\t\t\t" << s9 << " ���." << endl;
	}
	if (f10 > 0)
	{
		cout << "������ \t\t\t\t   " << f10 << "��." << "\t\t\t" << s10 << " ���." << endl;
	}
	if (f11 > 0)
	{
		cout << "����� ��������� � ��������� \t   " << f11 << "��." << "\t\t\t" << s11 << " ���." << endl;
	}
	if (f12 > 0)
	{
		cout << "����� ��������� � ������� \t   " << f12 << "��." << "\t\t\t" << s12 << " ���." << endl;
	}
	if (f13 > 0)
	{
		cout << "����� ��������� �� �������� \t   " << f13 << "��." << "\t\t\t" << s13 << " ���." << endl;
	}
	if (f14 > 0)
	{
		cout << "����� ���������� � ��������� \t   " << f14 << "��." << "\t\t\t" << s14 << " ���." << endl;
	}
	if (f15 > 0)
	{
		cout << "����� ���������� � ������� \t   " << f15 << "��." << "\t\t\t" << s15 << " ���." << endl;
	}
	if (f16 > 0)
	{
		cout << "������� 0.5�\t\t\t   " << f16 << "��." << "\t\t\t" << s16 << " ���." << endl;
	}
	if (f17 > 0)
	{
		cout << "������� 0.7�\t\t\t   " << f17 << "��." << "\t\t\t" << s17 << " ���." << endl;
	}
	if (f18 > 0)
	{
		cout << "������� 0.5�\t\t\t   " << f18 << "��." << "\t\t\t" << s18 << " ���." << endl;
	}
	if (f19 > 0)
	{
		cout << "������� 1�\t\t\t   " << f19 << "��." << "\t\t\t" << s19 << " ���." << endl;
	}
	if (f20 > 0)
	{
		cout << "������� 2�\t\t\t   " << f20 << "��." << "\t\t\t" << s20 << " ���." << endl;
	}


	S = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15 + s16 + s17 + s18 + s19 + s20;
	SetColor(14, 0);
	cout << "\n��� ���� : " << S << " ���." << endl;

	SetColor(2, 0);
	cout << "\n\n������ : " << endl;
	cout << "1. ���� " << endl;
	cout << "2. ����� " << endl;
	cout << "3. �����" << endl;
	cout << "4. ������� " << endl;
	cout << "5. �������� ����� " << endl;
	cout << "6. �������� ���� " << endl;
M0:
	cin >> x;
	switch (x)
	{
	case '1':
	{	M1:
		system("cls");
		cout << "��������� ����(1�� - 25 �����) : \n" << endl;
		cout << "1. ���� �������� (21 ���.)" << endl;
		cout << "2. ���� ������ (18 ���.)" << endl;
		cout << "3. ���� ����� (25 ���.)" << endl;
		cout << "4. ���� ������� (19 ���.)" << endl;
		cout << "5. ���� ������ ���� (24 ���.)" << endl;
		cout << "6. � ������� ����\n" << endl;
	Z1:
		cin >> x;
		switch (x)
		{
		case '1':
		{
			system("cls");
			cout << "1. ���� �������� (21 ���.). ������� ���� �������?" << endl;
			cin >> f1;
			s1 = 21 * f1;
			goto M1;
		}
		case '2':
		{
			system("cls");
			cout << "2. ���� ������ (18 ���.). ������� ���� �������?" << endl;
			cin >> f2;
			s2 = 18 * f2;
			goto M1;

		}
		case '3':
		{
			system("cls");
			cout << "3. ���� ����� (25 ���.). ������� ���� �������?" << endl;
			cin >> f3;
			s3 = 25 * f3;
			goto M1;

		}
		case '4':
		{
			system("cls");
			cout << "4. ���� ������� (19 ���.). ������� ���� �������?" << endl;
			cin >> f4;
			s4 = 19 * f4;
			goto M1;

		}
		case '5':
		{
			system("cls");
			cout << "5. ���� ������ ���� (24 ���.). ������� ���� �������?" << endl;
			cin >> f5;
			s5 = 24 * f5;
			goto M1;

		}
		case '6':
		{
			system("cls");
			goto M;
		}
		default:
		{
			cout << "������������ ������! ���������� ��� ���!" << endl;
			goto Z1;
		}

		}
	}
	case '2':
	{
	M2:
		system("cls");
		cout << "��������� ����� : \n" << endl;
		cout << "1. ������� ���� 120 � / 6 �������� (22 ���.)" << endl;
		cout << "2. ������ 240 � / 8 �������� (84 ���.)" << endl;
		cout << "3. ������ ��� 250 � / 8 �������� (63 ���.)" << endl;
		cout << "4. ������ ���� 240 � / 8 �������� (57 ���.)" << endl;
		cout << "5. ������ 250 � / 8 �������� (66 ���.)" << endl;
		cout << "6. � ������� ����\n" << endl;
	Z2:
		cin >> x;
		switch (x)
		{
		case '1':
		{
			system("cls");
			cout << "1. ������� ���� 120 � / 6 �������� (22 ���.). ������� ���� �������?" << endl;
			cin >> f6;
			s6 = 22 * f6;
			goto M2;

		}
		case '2':
		{
			system("cls");
			cout << "2. ������ 240 � / 8 �������� (84 ���.). ������� ���� �������?" << endl;
			cin >> f7;
			s7 = 84 * f7;
			goto M2;

		}
		case '3':
		{
			system("cls");
			cout << "3. ������ ��� 250 � / 8 �������� (63 ���.). ������� ���� �������?" << endl;
			cin >> f8;
			s8 = 63 * f8;
			goto M2;

		}
		case '4':
		{
			system("cls");
			cout << "4. ������ ���� 240 � / 8 �������� (57 ���.). ������� ���� �������?" << endl;
			cin >> f9;
			s9 = 57 * f9;
			goto M2;

		}
		case '5':
		{
			system("cls");
			cout << "5. ������ 250 � / 8 �������� (66 ���.). ������� ���� �������?" << endl;
			cin >> f10;
			s10 = 66 * f10;
			goto M2;

		}
		case '6':
		{
			system("cls");
			goto M;
		}
		default:
		{
			cout << "������������ ������! ���������� ��� ���!" << endl;
			goto Z2;
		}

		}
	}
	case '3':
	{

	M3:
		system("cls");
		cout << "��������� �����(��� �� 300�) : \n" << endl;
		cout << "1. ����� ��������� � ��������� (59 ���.)" << endl;
		cout << "2. ����� ��������� � ������� (55 ���.)" << endl;
		cout << "3. ����� ��������� �� �������� (58 ���.)" << endl;
		cout << "4. ����� ���������� � ���������(59 ���.)" << endl;
		cout << "5. ����� ���������� � ������� (55 ���.)" << endl;
		cout << "6. � ������� ����\n" << endl;
	Z3:
		cin >> x;
		switch (x)
		{
		case '1':
		{
			system("cls");
			cout << "1. ����� ��������� � ��������� (59 ���.). ������� ���� �������?" << endl;
			cin >> f11;
			s11 = 59 * f11;
			goto M3;
		}
		case '2':
		{
			system("cls");
			cout << "2. ����� ��������� � ������� (84 ���.). ������� ���� �������?" << endl;
			cin >> f12;
			s12 = 55 * f12;
			goto M3;

		}
		case '3':
		{
			system("cls");
			cout << "3. ����� ��������� �� �������� (58 ���.). ������� ���� �������?" << endl;
			cin >> f13;
			s13 = 58 * f13;
			goto M3;

		}
		case '4':
		{
			system("cls");
			cout << "4. ����� ���������� � ���������(59 ���.). ������� ���� �������?" << endl;
			cin >> f14;
			s14 = 59 * f14;
			goto M3;

		}
		case '5':
		{
			system("cls");
			cout << "5. ����� ���������� � �������(55 ���.). ������� ���� �������?" << endl;
			cin >> f15;
			s15 = 55 * f15;
			goto M3;

		}
		case '6':
		{
			system("cls");
			goto M;
		}
		default:
		{
			cout << "������������ ������! ���������� ��� ���!" << endl;
			goto Z3;
		}



		}
	case '4':
	{
	M4:
		system("cls");
		cout << "��������� ������� : \n" << endl;
		cout << "1. ������� 0.5� (33 ���.)" << endl;
		cout << "2. ������� 0.7� (37 ���.)" << endl;
		cout << "3. ������� 0.5� (15 ���.)" << endl;
		cout << "4. ������� 1�(20 ���.)" << endl;
		cout << "5. ������� 2� (27 ���.)" << endl;
		cout << "6. � ������� ����\n" << endl;
	Z5:
		cin >> x;
		switch (x)
		{
		case '1':
		{
			system("cls");
			cout << "1. ������� 0.5� (33 ���.). ������� ���� �������?" << endl;
			cin >> f16;
			s16 = 33 * f16;
			goto M4;
		}
		case '2':
		{
			system("cls");
			cout << "2. ������� 0.7� (37 ���.). ������� ���� �������?" << endl;
			cin >> f17;
			s17 = 37 * f17;
			goto M4;

		}
		case '3':
		{
			system("cls");
			cout << "3. ������� 0.5� (15 ���.). ������� ���� �������?" << endl;
			cin >> f18;
			s18 = 15 * f18;
			goto M4;

		}
		case '4':
		{
			system("cls");
			cout << "4. ������� 1�(20 ���.). ������� ���� �������?" << endl;
			cin >> f19;
			s19 = 20 * f19;
			goto M4;

		}
		case '5':
		{
			system("cls");
			cout << "5. ������� 2� (27 ���.). ������� ���� �������?" << endl;
			cin >> f20;
			s20 = 27 * f20;
			goto M4;

		}
		case '6':
		{
			system("cls");
			goto M;
		}
		default:
		{
			cout << "������������ ������! ���������� ��� ���!" << endl;
			goto Z5;
		}

		}}
	case '5':
	{

		if (S > 0)
		{
		S5:
			system("cls");
			cout << "������ ����������� : \n" << endl;
			SetColor(14, 0);
			if (f1 > 0)
			{
				cout << "1. ���� �������� (" << f1 << "��.)" << "\t\t\t" << s1 << " ���." << endl;
			}
			if (f2 > 0)
			{
				cout << "2. ���� ������ (" << f2 << "��.)" << "\t\t\t" << s2 << " ���." << endl;
			}
			if (f3 > 0)
			{
				cout << "3. ���� ����� (" << f3 << "��.)" << "\t\t\t" << s3 << " ���." << endl;
			}
			if (f4 > 0)
			{
				cout << "4. ���� ������� (" << f4 << "��.)" << "\t\t\t" << s4 << " ���." << endl;
			}
			if (f5 > 0)
			{
				cout << "5. ���� ������ ���� (" << f5 << "��.)" << "\t\t\t" << s5 << " ���." << endl;
			}
			if (f6 > 0)
			{
				cout << "6. ������� ���� (" << f6 << "��.)" << "\t\t\t" << s6 << " ���." << endl;
			}
			if (f7 > 0)
			{
				cout << "7. ������ (" << f7 << "��.)" << "\t\t\t\t" << s7 << " ���." << endl;
			}
			if (f8 > 0)
			{
				cout << "8. ������ ��� (" << f8 << "��.)" << "\t\t\t" << s8 << " ���." << endl;
			}
			if (f9 > 0)
			{
				cout << "9. ������ ���� (" << f9 << "��.)" << "\t\t\t" << s9 << " ���." << endl;
			}
			if (f10 > 0)
			{
				cout << "10. ������ (" << f10 << "��.)" << "\t\t\t\t" << s10 << " ���." << endl;
			}
			if (f11 > 0)
			{
				cout << "11. ����� ��������� � ��������� (" << f11 << "��.)" << "\t" << s11 << " ���." << endl;
			}
			if (f12 > 0)
			{
				cout << "12. ����� ��������� � ������� (" << f12 << "��.)" << "\t" << s12 << " ���." << endl;
			}
			if (f13 > 0)
			{
				cout << "13. ����� ��������� �� �������� (" << f13 << "��.)" << "\t" << s13 << " ���." << endl;
			}
			if (f14 > 0)
			{
				cout << "14. ����� ���������� � ��������� (" << f14 << "��.)" << "\t" << s14 << " ���." << endl;
			}
			if (f15 > 0)
			{
				cout << "15. ����� ���������� � ������� (" << f15 << "��.)" << "\t" << s15 << " ���." << endl;
			}
			if (f16 > 0)
			{
				cout << "16. ������� 0.5� (" << f16 << "��.)" << "\t\t\t" << s16 << " ���." << endl;
			}
			if (f17 > 0)
			{
				cout << "17. ������� 0.7� (" << f17 << "��.)" << "\t\t\t" << s17 << " ���." << endl;
			}
			if (f18 > 0)
			{
				cout << "18. ������� 0.5� (" << f18 << "��.)" << "\t\t\t" << s18 << " ���." << endl;
			}
			if (f19 > 0)
			{
				cout << "19. ������� 1� (" << f19 << "��.)" << "\t\t\t" << s19 << " ���." << endl;
			}
			if (f20 > 0)
			{
				cout << "20. ������� 2� (" << f20 << "��.)" << "\t\t\t" << s20 << " ���." << endl;
			}
			S = s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15 + s16 + s17 + s18 + s19 + s20;
			cout << "\n����� ����� ������ : " << S << "���." << endl;
			SetColor(2, 0);
			cout << "��������������� - 1, ������� � ���� -2" << endl;
			G3:
			cin >> x;
			switch (x)
			{
			case '1':
			{
				cout << "\n������� ����� �����, ������� ������ �� ������." << endl;
			G:
				cin >> X;
				if (X > 0 && X <= 20)
				{

					cout << "������� �����, �� ������� ������ �������� ���������� ���������� �����" << endl;
				G1:
					cin >> X1;
					if (X1 >= 0)
					{
						switch (X)
						{
							
						case 1:
						 {
								f1 = X1;
								s1 = 21 * f1;
								goto S5;
							}
					
						case 2:
						{
							f2 = X1;
							s2 = 21 * f2;
							goto S5;
						}
						
					
						case 3:
						{
							f3 = X1;
							s3 = 21 * f3;
							goto S5;
						}
						
						case 4:
						{
							f4 = X1;
							s4 = 21 * f4;
							goto S5;
						}
						case 5:
						{
							f5 = X1;
							s5 = 21 * f5;
							goto S5;
						}
						case 6:
						{
							f6 = X1;
							s6 = 21 * f6;
							goto S5;
						}
						case 7:
						{
							f7 = X1;
							s7 = 21 * f7;
							goto S5;
						}
						case 8:
						{
							f8 = X1;
							s8 = 21 * f8;
							goto S5;
						}
						case 9:
						{
							f9 = X1;
							s9 = 21 * f9;
							goto S5;
						}
						case 10:
						{
							f10 = X1;
							s10 = 21 * f10;
							goto S5;
						}
						case 11:
						{
							f11 = X1;
							s11 = 21 * f11;
							goto S5;
						}
						case 12:
						{
							f12 = X1;
							s12 = 21 * f12;
							goto S5;
						}
						case 13:
						{
							f13 = X1;
							s13 = 21 * f13;
							goto S5;
						}
						case 14:
						{
							f14 = X1;
							s14 = 21 * f14;
							goto S5;
						}
						case 15:
						{
							f15 = X1;
							s15 = 21 * f15;
							goto S5;
						}
						case 16:
						{
							f16 = X1;
							s16 = 21 * f16;
							goto S5;
						}
						case 17:
						{
							f17 = X1;
							s17 = 21 * f17;
							goto S5;
						}
						case 18:
						{
							f18 = X1;
							s18 = 21 * f18;
							goto S5;
						}
						case 19:
						{
							f19 = X1;
							s19 = 21 * f19;
							goto S5;
						}
						case 20:
						{
							f20 = X1;
							s20 = 21 * f20;
							goto S5;
						}
							}
						
						
					
						

					}
					else
					{
						cout << "������������ ������! ���������� ��� ���!" << endl;
						goto G1;
					}

				}
				else
				{
					cout << "������������ ������! ���������� ��� ���!" << endl;
					goto G;
				}}
			case '2':
				goto M;
			default:
			{cout << "������������ ������! ���������� ��� ���!" << endl;
				goto G3;
			}
		}

			
		}
			else
				cout << "\n�� ��� ������ �� ��������!" << endl;
			goto M0;

	}
	case '6':
	{
		if (S > 0)
		{
		S6:
			system("cls");
			cout << "\n\t\t\t\t �ר�\n" << endl;
			cout << "������ ����������� : \n" << endl;
			SetColor(14, 0);
			if (f1 > 0)
			{
				cout << "���� �������� (" << f1 << "��.)" << "\t\t\t" << s1 << " ���." << endl;
			}
			if (f2 > 0)
			{
				cout << "���� ������ (" << f2 << "��.)" << "\t\t\t" << s2 << " ���." << endl;
			}
			if (f3 > 0)
			{
				cout << "���� ����� (" << f3 << "��.)" << "\t\t\t" << s3 << " ���." << endl;
			}
			if (f4 > 0)
			{
				cout << "���� ������� (" << f4 << "��.)" << "\t\t\t" << s4 << " ���." << endl;
			}
			if (f5 > 0)
			{
				cout << "���� ������ ���� (" << f5 << "��.)" << "\t\t\t" << s5 << " ���." << endl;
			}
			if (f6 > 0)
			{
				cout << "������� ���� (" << f6 << "��.)" << "\t\t\t" << s6 << " ���." << endl;
			}
			if (f7 > 0)
			{
				cout << "������ (" << f7 << "��.)" << "\t\t\t\t" << s7 << " ���." << endl;
			}
			if (f8 > 0)
			{
				cout << "������ ��� (" << f8 << "��.)" << "\t\t\t" << s8 << " ���." << endl;
			}
			if (f9 > 0)
			{
				cout << "������ ���� (" << f9 << "��.)" << "\t\t\t" << s9 << " ���." << endl;
			}
			if (f10 > 0)
			{
				cout << "������ (" << f10 << "��.)" << "\t\t\t\t" << s10 << " ���." << endl;
			}
			if (f11 > 0)
			{
				cout << "����� ��������� � ��������� (" << f11 << "��.)" << "\t" << s11 << " ���." << endl;
			}
			if (f12 > 0)
			{
				cout << "����� ��������� � ������� (" << f12 << "��.)" << "\t" << s12 << " ���." << endl;
			}
			if (f13 > 0)
			{
				cout << "����� ��������� �� �������� (" << f13 << "��.)" << "\t" << s13 << " ���." << endl;
			}
			if (f14 > 0)
			{
				cout << "����� ���������� � ��������� (" << f14 << "��.)" << "\t" << s14 << " ���." << endl;
			}
			if (f15 > 0)
			{
				cout << "����� ���������� � ������� (" << f15 << "��.)" << "\t" << s15 << " ���." << endl;
			}
			if (f16 > 0)
			{
				cout << "������� 0.5� (" << f16 << "��.)" << "\t\t\t" << s16 << " ���." << endl;
			}
			if (f17 > 0)
			{
				cout << "������� 0.7� (" << f17 << "��.)" << "\t\t\t" << s17 << " ���." << endl;
			}
			if (f18 > 0)
			{
				cout << "������� 0.5� (" << f18 << "��.)" << "\t\t\t" << s18 << " ���." << endl;
			}
			if (f19 > 0)
			{
				cout << "������� 1� (" << f19 << "��.)" << "\t\t\t" << s19 << " ���." << endl;
			}
			if (f20 > 0)
			{
				cout << "������� 2� (" << f20 << "��.)" << "\t\t\t" << s20 << " ���." << endl;
			}
			SetColor(2, 0);
			cout << "\n����� ����� ������ : " << S << "���." << endl;
			cout << "\n����������� �����.(1 - �����������, 2 - ��������, 3 - �����)" << endl;
		S1:
			cin >> X;
			if (X == 1)
			{
				system("cls");
				SetColor(14, 0);
				cout << "\n��� ����� ������� �������! " << endl;
				cout << "���� ��� � ������ �������� !\n" << endl;
				SetColor(2, 0);
				break;
			}
			else if (X == 2)
			{
				cout << "����� �������. (1 - ��������� � ����, 2 - �����, 3 - �����)" << endl;
			S2:
				cin >> X;
				if (X == 1)
				{
					goto START;
				}
				else if (X == 2)
				{
					break;
				}
				else if (X == 3)
				{
					goto S6;
				}
				else
				{
					cout << "������������ ������! ���������� ��� ���!" << endl;
					goto S2;
				}
			}
			else if (X == 3)
			{
				goto M;
			}
			else
			{
				cout << "������������ ������! ���������� ��� ���!" << endl;
				goto S1;
			}


		}
		else
			cout << "\n�� ��� ������ �� ��������!" << endl;
		goto M0;

		break;
	}


	default:
	{
		cout << "������������ ������! ���������� ��� ���!" << endl;
		goto M0;
	}

	}

	cout << "\n" << endl;
	}

}