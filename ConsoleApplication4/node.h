#pragma once
class node
{
private:
	int data;
	node* next;
	node* prev;
public:
	node(int data1, node* next1,node* prev1);
	friend class DLL;
};

