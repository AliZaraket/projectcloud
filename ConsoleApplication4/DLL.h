#pragma once
#include "node.h"
class DLL
{
private:
	int size;
	node* head;
	node* tail;
public:
	DLL();
	~DLL();
	void Add_head(int v);
	void Add_tail(int v);
	void Add_at_index(int v,int index);
	int Remove_head();
	int Remove_tail();
	int Remove_at_index(int index);
	int get_size();
	void Print();
};

