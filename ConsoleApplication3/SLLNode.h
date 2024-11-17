#pragma once
class SLLNode
{
private:
	int data;
	SLLNode* next;
public:
	SLLNode(int newdata, SLLNode* nextp);
	friend class SingleLink;
};

