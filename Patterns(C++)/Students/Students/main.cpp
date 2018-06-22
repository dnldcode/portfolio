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
	Student s1("Сергей", "Голишевский", "Группа 1", "serega@mail.ru");
	Student s2("Никита", "Бобырь", "Группа 2", "nikit0s@mail.ru");
	Student s3("Владимир", "Стрижаков", "Группа3", "vovan@mail.ru");
	Student s4("Алексей", "Мащенко", "Группа4", "l3xabest@mail.ua");
	Student s5("Нео", "Матрица", "Группа4", "matrix@mail.ua");
	Student s6("Алексей", "Воробьев", "Группа5", "l3xan@mail.ua");
	Student s7("Иван", "Боровец", "Группа2", "ivan@mail.ua");
	Student s8("Витя", "Ак", "Группа1", "vityaAK@mail.ua");
	Student s9("Андрей", "Терешков", "Группа1", "andr@mail.ua");
	Student s10("Миша", "Макаренко", "Группа5", "misha@mail.ua");
	Student s[10] = { s1,s2,s3,s4,s5,s6,s7,s8,s9,s10 };
	for (int i = 0;i < 10;i++)
		students.insert(s[i]);

	for_each(students.begin(), students.end(), show);
	passExam("Физика", students);
	//for (int i = 0;i < 10;i++)
	s1.showExams();
	return 0;
}