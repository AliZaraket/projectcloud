#include "SingleLink.h"
#include <iostream>
using namespace std;
SingleLink::SingleLink() {
	head = tail = NULL;
	size = 0;
}
void SingleLink::AddHead(int data){
	if (size == 0) {
		head = tail = new SLLNode(data, NULL);
	}
	else {
		SLLNode* newnode = new SLLNode(data, head);
		head = newnode;
	}
	size++;
}
void SingleLink::AddTail(int data) {
	if (size == 0) {
		head = tail = new SLLNode(data, NULL);
	}
	else {
		tail->next = new SLLNode(data, NULL);
		tail = tail->next;
	}
	size++;
}
void SingleLink::AddIndex(int data, int index) {
	if (index >= size)
		AddTail(data);
	else {
		int i=0;
		SLLNode* temp = head;
		while (i < index - 1) {
			temp = temp->next;
			i++;
		}
		temp->next = new SLLNode(data, temp->next);
		size++;	
	}
}
int SingleLink::RemoveHead() {
	if (size == 0)
		return -1;
	int temp = head->data;
	if (size == 1) {
		delete head;
		head = tail = NULL;
	}
	else {
		SLLNode* node = head;
		head = head->next;
		delete node;	
	}
	size--;
	return temp;
}
int SingleLink::RemoveTail() {
	if (size == 0)
		return -1;
	if (size == 1) {
		int temp = head->data;
		delete head;
		head = tail = NULL;
		size--;
		return temp;
	}
	SLLNode* temp = head;
	while (temp->next != tail)
		temp = temp->next;
	int i = tail->data;
	delete tail;
	tail = temp;
	tail->next = NULL;
	size--;
	return i;
}
int SingleLink::RemoveIndex(int index) {
	if (size == 0 || index >= size)
		return RemoveTail();
	if (index == 0)
		return RemoveHead();
	else {
		SLLNode* temp = head;
		SLLNode* pred = NULL;
		int i = 0;
		while (i < index) {
			pred = temp;
			temp = temp->next;
			i++;
		}
		pred->next = temp->next;
		int data = temp->data;
		delete temp;
		size--;
		return data;
	}
}
int SingleLink::Getsize() {
	return size;
}
bool SingleLink::is_empty() {
	return (size == 0);
}
bool SingleLink::is_in_list(int data) {
	if (size == 0)
		cout << "List is empty" << endl;
	SLLNode* temp = head;
	while (temp != NULL) {
		if (temp->data == data)
			return true;
		temp = temp->next;
	}
	return false;
}
void SingleLink::Print() {
	SLLNode* temp = head;
	while (temp != NULL) {
		cout << temp->data << "->";
		temp = temp->next;
	}
	cout << "NULL"<<endl;
}
int SingleLink::Sum_after_index(int index) {
	SLLNode* temp = head;
	int sum=0, i = 0;
	if (size == 0 ||index>=size)
		return 0;
	else {
		while ((i<=index)) {
			temp = temp->next;
			i++;
		}
		while (temp != NULL) {
			sum += temp->data;
			temp = temp->next;
		}
		return sum;
	}
}
void SingleLink::append(SingleLink* L1, SingleLink* L2) {
	SLLNode* temp = L2->head;
	while (temp != NULL) {
		L1->AddTail(temp->data);
		temp = temp->next;
	}
}
