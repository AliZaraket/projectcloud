#pragma once
class node
{
private:
	char data;
	node* next;
public:
	node(char data, node* next);
	friend class stack;
};

