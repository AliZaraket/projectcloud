#pragma once
#include "SLLNode.h"
class SingleLink
{
private:
	SLLNode* head;
	SLLNode* tail;
	int size;
public:
	SingleLink();
	~SingleLink();
	void AddHead(int data);
	void AddTail(int data);
	void AddIndex(int data,int index);
	int RemoveHead();
	int RemoveTail();
	int RemoveIndex(int index);
	int Getsize();
	void Print();
	bool is_empty();
	bool is_in_list(int data);
	int Sum_after_index(int index);
	void append(SingleLink* L1, SingleLink* L2);
};

