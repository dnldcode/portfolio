#pragma once

struct Node 
{
	Fish node;
	Node *next, *prev;
	Node(Fish &f)
	{
		node = f;
		next = prev = NULL;
	}
};

class FList 
{
private:
	Node *head;
	Node *tail;
	int size;
public:
	FList() 
	{
		head = tail = NULL;
		size = 0;
	}
	void addHead(Fish &f) 
	{
		Node* tmp = new Node(f);
		tmp->prev = NULL;
		tmp->next = head;
		if (head != NULL)
			head->prev = tmp;
		if (size == 0)
			head = tail = tmp;
		else
			head = tmp;
		size++;
	}
	void show(int pos)
	{
		if (pos < 1 || pos > size)
			return;
		Node* tmp = NULL;
		int posi;
		if (pos <= size / 2)
		{
			tmp = head;
			posi = 1;
			while (posi < pos)
			{
				tmp = tmp->next;
				posi++;
			}
		}
		else {
			tmp = tail;
			posi = 1;
			while (posi <= size - pos)
		
			{
				tmp = tmp->prev;
				posi++;
			}
		}
		cout << tmp->node << endl;
	}
};