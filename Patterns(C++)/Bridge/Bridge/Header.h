#pragma once
#include <iostream>
#include <Windows.h>
#include <iomanip>
#include <ctime>
#include <string>
#include <functional>
#include <algorithm>

using namespace std;

class BaseSender
{
public:
	virtual void Send_Message(string title, string body) = 0;
};
class EmailSender : public BaseSender
{
public:
	virtual void Send_Message(string title, string body)
	{
		printf(" Email : %s \n Text : %s \n", title.c_str(), body.c_str());
	}
};
class MsmqSender : public BaseSender
{
public:
	virtual void Send_Message(string title, string body)
	{
		printf(" MSMQ : %s\n Text : %s \n", title.c_str(), body.c_str());
	}
};
class WebServiceSender : public BaseSender
{
public:
	virtual void Send_Message(string title, string body)
	{
		printf(" WebService : %s\n Text : %s \n", title.c_str(), body.c_str());
	}
};
class Message
{
protected:
	BaseSender* sender;
	string title, body;
public:
	Message(BaseSender* sender, string title, string body)
	{
		this->sender = sender;
		this->title = title;
		this->body = body;
	}
	virtual void Send()
	{
		sender->Send_Message(this->title, this->body);
	}
	void setSender(BaseSender* sender)
	{
		this->sender = sender;
	}
};
class SuperMessage : public Message
{
protected:
	int status;
public:
	SuperMessage(BaseSender* sender, string title, string body, int status) : Message(sender, title, body)
	{
		this->status = status;
	}
	void Send()
	{
		cout << "\n Importance : " << status << endl;
		sender->Send_Message(title, body);
	}
};