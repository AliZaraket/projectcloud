#include "DLL.h"
#include <iostream>
using namespace std;
DLL::DLL() {
	head = tail = NULL;
	size = 0;
}
void DLL::Add_head(int v) {
	if (size == 0) {
		head = tail = new node(v, NULL, NULL);
	}
	else {
		head = new node(v, head, NULL);
		head->next->prev = head;
	}
	size++;
}
void DLL::Add_at_index(int v, int index) {
	node* temp = head;
	node* pred=temp->next;
	int i = 0;
	while (i < index - 1) {
		temp = temp->next;
		pred = pred->next;
		i++;
	}
	temp->next = new node(v, pred, temp);
	pred->prev = temp->next;
	size++;
}
void DLL::Print() {
	node* temp = head;
	cout << "NULL" << "<-";
	while (temp != NULL) {
		cout << temp->data << "<-->";
		temp = temp->next;
	}
	cout << "NULL" << endl;

}
