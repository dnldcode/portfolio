#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <functional>
#include <algorithm>
#include <string>

using namespace std;

class Text
{
protected:
	string text;
public:
	Text() {}
	virtual void Display()
	{
		cout << text << endl;
	}
	void setText(string text)
	{
		this->text = text;
	}
	string getText()
	{
		return this->text;
	}
	virtual void Create_File(const string file)
	{
		FILE *f = fopen(file.c_str(), "a");
		fprintf(f, "%s<br>", text.c_str());
		fclose(f);
	}
};
class AbDecorator : public Text
{
protected:
	Text* dtext;
public:
	AbDecorator(Text* dtext)
	{
		this->dtext = dtext;
	}
};
class BoldDecorator : public AbDecorator
{
public:
	BoldDecorator(Text* dtext) : AbDecorator(dtext)
	{
		setText("<b>"+dtext->getText()+"</b>");
	}
	virtual void Display()
	{
		cout << this->text << endl;
	}
};
class ItalicDecorator : public AbDecorator
{
public:
	ItalicDecorator(Text* dtext) : AbDecorator(dtext)
	{
		setText("<i>" + dtext->getText() + "</b>");
	}
	virtual void Display()
	{
		cout << this->text << endl;
	}
};
class BigDecorator : public AbDecorator
{
public:
	BigDecorator(Text* dtext) : AbDecorator(dtext)
	{
		setText("<big>" + dtext->getText() + "</big>");
	}
	virtual void Display()
	{
		cout << this->text << endl;
	}
};