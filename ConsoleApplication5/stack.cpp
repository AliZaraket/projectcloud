#include "stack.h"
#include <iostream>
using namespace std;

stack::stack() {
	head = NULL;
	size = 0;
}
void stack::push(char s) {
	if (size == 0)
		head = new node(s, NULL);
	else 
		head = new node(s, head);
	size++;
}
char stack::pop() {
	char s = head->data;
	node* newnode = head;
	head = head->next;
	delete newnode;
	size--;
	return s;
}
char stack::top() {
	return (head->data);
}
int stack::getsize() {
	return size;
}
bool stack::isempty() {
	return (size == 0);
}
stack::~stack() {
	while (head != NULL) 
		pop();
}
