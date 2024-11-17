#include <iostream>
#include <string.h>
#include "stack.h"
using namespace std;

bool ispanadrome(string s) {
	char c;
	int i;
	stack* s1 = new stack();
	for (i = 0; i < s.length(); i++) 
		s1->push(s[i]);
	for (i = 0; i < s.length();i++) {
		if (s1->pop() != s[i])
			return false;
	}
	return true;
}
int main() {
	string s = "dad";
	if (ispanadrome(s))
		cout << "The word is panadrome";
	else
		cout << "The word is not panadrome";
	return 0;

}