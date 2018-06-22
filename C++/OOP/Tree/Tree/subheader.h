#pragma once

struct Node
{
	Fish data;
	Node *parent, *left, *right;
	Node(Fish &f)
	{
		data = f;
		left = right = parent = NULL;
	}
};

class FTree
{
private:
	Node *root;
public:
	FTree()
	{
		root = NULL;
	}
	void Insert(Node* n)
	{
		n->left = NULL;
		n->right = NULL;

		Node* node = root;
		Node* tmp = NULL;
		while (node != NULL) {
			tmp = node;
			if (n->data.getPrice() < node->data.getPrice())
			{
				node = node->left;
			}
			else
				node = node->right;
		}
		n->parent = tmp;
		if (tmp == NULL)
			root = n;
		else if (n->data.getPrice() < tmp->data.getPrice())
			tmp->left = n;
		else
			tmp->right = n;
	}

	void Show(Node* node)
	{
		if (node != NULL)
		{
			Show(node->left);
			cout << node->data;
			Show(node->right);
		}
	}

	Node* getRoot()
	{
		return root;
	}

	Node* getMin(Node* node)
	{
		if (node != NULL)
		{
			while (node->left != NULL)
				node = node->left;
		}
		return node;
	}

	Node* getMax(Node* node)
	{
		if (node != NULL)
		{
			while (node->right != NULL)
				node = node->right;
		}
		return node;
	}
};