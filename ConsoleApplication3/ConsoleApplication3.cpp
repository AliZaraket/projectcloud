#include <iostream>
#include "SingleLink.h"
#include "SLLNode.h"
using namespace std;

int main() {
	SingleLink* L1=new SingleLink();
	SingleLink* L2 = new SingleLink();
	if (L1->is_empty() == true)
		cout << "The list is empty" << endl;
	L1->AddHead(5);
	L1->AddTail(4);
	L1->AddTail(6);
	L1->AddIndex(3, 2);
	L2->AddHead(1);
	L2->AddHead(7);
	L2->AddHead(8);
	L2->AddHead(9);
	L1->append(L1, L2);
	L1->Print();
	return 1;
}