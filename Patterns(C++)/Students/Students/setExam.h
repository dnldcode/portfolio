#pragma once

class setExam1
{
	string subject;
public:
	setExam1(string subject)
	{
		this->subject = subject;
	}
	void operator()(Student s)
	{
		pair<string, int> p = make_pair(this->subject, rand() % 4 + 1);
		s.setExam(p);
	}

};