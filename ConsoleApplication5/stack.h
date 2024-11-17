#pragma once
#include <iostream>
#include "node.h"
class stack
{
private:
	node* head;
	int size;
public:
	stack();
	~stack();
	void push(char data);
	char pop();
	char top();
	int getsize();
	bool isempty();
};

