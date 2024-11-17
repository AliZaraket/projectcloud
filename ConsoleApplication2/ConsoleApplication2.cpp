 #include <iostream>
#include "linetype.h"
using namespace std;

int main() {
	linetype line1(5, 10, 7), line2(1, 2, 3);
	cout << line1;
	cout << line2;
	if (line1 || line2)
		cout << "The two lines are parallel" << endl;
	cout << ++line1;
	cin >> line1;
	cout << --line1;

	return 0;
}

