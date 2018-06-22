#include "Header.h"

void Show(Child &c)
{
	cout << c << endl;
}

class Match
{
private:
	int mage;
	string msex;
public:
	Match(int age = 0, string sex = "No Sex")
	{
		this->mage = age;
		this->msex = sex;
	}
	bool operator()(Child &child)
	{
		if (!child.getHasFriend() && child.getAge() == mage && child.getSex() != msex)
			return 1;
		else
			return 0;
	}

};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(time(NULL));
	cout << endl;
	list<Child> kids;
	for (int i = 0;i < 5;i++)
	{
		kids.push_back(Child(girls[rand() % 10], rand() % 5 + 6, "дев"));
		kids.push_front(Child(boys[rand() % 10], rand() % 5 + 6, "мал"));
	}
	//random_shuffle(kids.begin(), kids.end());
	for_each(kids.begin(), kids.end(), Show);
	list<Child> friends;
	list<Child>::iterator it = kids.begin();
	list<Child>::iterator itf;
	while (it != kids.end())
	{
		itf = find_if(kids.begin(), kids.end(), Match(it->getAge(), it->getSex()));
		if (itf == kids.end())
		{
			it++;
			continue;
		}
		if (!itf->getHasFriend())
		{
			it->setHasFriend(1);
			itf->setHasFriend(1);
			friends.push_back(*it);
			friends.push_back(*itf);
		}
		it++;
	}
	cout << "------------------\n" << endl;
	for_each(friends.begin(), friends.end(), Show);
	return 0;
}