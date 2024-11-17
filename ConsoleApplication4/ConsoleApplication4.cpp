#include <iostream>
#include "DLL.h"
using namespace std;

int main() {
	DLL* L1 = new DLL();
	L1->Add_head(5);
	L1->Add_head(3);
	L1->Add_head(2);
	L1->Add_at_index(4, 2);
	L1->Print();
	return 0;

}