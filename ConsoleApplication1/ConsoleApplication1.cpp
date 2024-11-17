#include <iostream>
using namespace std;

class E {
public:
	char* msg;
	E() { msg = (char*)"class E"; };
};
class E1 :public E {
	E1() { msg = (char*)"Class E1"; };
};
class E2 :public E {
	E2() { msg = (char*)"Class E2"; };
};
void fun() {
	try {
		cout << "Type E1" << endl;
		E1 exp();
		throw exp;
	}
	catch (E& e) {
		cout << e.msg << endl;
		throw;
	}
	catch (E1& e) {
		cout << e.msg << endl;
		throw;
	}
	catch (E2& e) {
		cout << e.msg << endl;
		throw;
	}

}
int main() {
	try {
		cout << "In try block" << endl;
		fun();
	}
	catch (E2& e) {
		cout << e.msg << endl;
	}
	catch (...) {
		cout << "Exception";
	}
	return 0;
}