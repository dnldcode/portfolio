#pragma once

char names[30][20] = { "Lionel Messi","Cristiano Ronaldo","Franck Ribéry","Sergio Ramos","Gerard Piqué ","Mario Gomez","Carlos Tévez","Vincent Kompany","Giorgio Chiellini","Yaya Touré","Andrea Pirlo","Iker Casillas","Gianluigi Buffon","Edinson Cavani","Juan Mata","Mesut Özil","Gareth Bale","Thiago Silva","Nemanja Vidić","Philipp Lahm","Wayne Rooney","David Silva","Sergio Agüero","Schweinsteiger","Arjen Robben","Zlatan Ibrahimović","Xavi","Robin van Persie","Andres Iniesta","Falcao" };
int same[30], sameid;
class Player
{
protected:
	int skill;
	int price;
	char name[20];
public:
	Player()
	{	
		strcpy(this->name, names[rand() % 30]);
		this->skill = rand() % 10 + 1;
		this->price = this->skill * 30000;
	}
	virtual double Striker() = 0;
	virtual double Goalkeeper() = 0;
	virtual double Middlefielder() = 0;
	int getPrice()
	{
		return this->price;
	}
	char *getName()
	{
		return name;
	}
	int getSkill()
	{
		return this->skill;
	}
};

class PStriker : public Player
{
public:
	virtual double Striker()
	{
		return this->skill;
	}
	virtual double Goalkeeper()
	{
		return 0;
	}
	virtual double Middlefielder()
	{
		return 0;
	}
};
class PGoalkeeper : public Player
{
public:
	virtual double Striker()
	{
		return 0;
	}
	virtual double Goalkeeper()
	{
		return this->skill;
	}
	virtual double Middlefielder()
	{
		return 0;
	}
};
class PMiddlefielder : public Player
{
public:
	virtual double Striker()
	{
		return 0;
	}
	virtual double Goalkeeper()
	{
		return 0;
	}
	virtual double Middlefielder()
	{
		return this->skill;
	}
};