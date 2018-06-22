#include "Header.h"
#include "setExam.h"

void show(Student s)
{
	cout << s << endl;
}
void passExam(string subject, set<Student> &s)
{
	setExam1 se(subject);
	//for_each(s.begin(), s.end(), se);
	set<Student>::iterator it = s.begin();
	for (it;it != s.end();it++)
	{
		pair<string, int> p = make_pair(subject, rand() % 4 + 1);
		it->setExam(p);
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
	srand(time(NULL));
	set<Student> students;
	Student s1("������", "�����������", "������ 1", "serega@mail.ru");
	Student s2("������", "������", "������ 2", "nikit0s@mail.ru");
	Student s3("��������", "���������", "������3", "vovan@mail.ru");
	Student s4("�������", "�������", "������4", "l3xabest@mail.ua");
	Student s5("���", "�������", "������4", "matrix@mail.ua");
	Student s6("�������", "��������", "������5", "l3xan@mail.ua");
	Student s7("����", "�������", "������2", "ivan@mail.ua");
	Student s8("����", "��", "������1", "vityaAK@mail.ua");
	Student s9("������", "��������", "������1", "andr@mail.ua");
	Student s10("����", "���������", "������5", "misha@mail.ua");
	Student s[10] = { s1,s2,s3,s4,s5,s6,s7,s8,s9,s10 };
	for (int i = 0;i < 10;i++)
		students.insert(s[i]);

	for_each(students.begin(), students.end(), show);
	passExam("������", students);
	//for (int i = 0;i < 10;i++)
	s1.showExams();
	return 0;
}