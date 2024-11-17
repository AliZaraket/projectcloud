#include <iostream>
#include <vector>
using namespace std;


// Recursive function to count the numeber of distinct ways
// to make the sum by using n coins


bool Sum(int* A, int sum, int n) {
	if (sum == 0)
		return true;
	if (n < 0)
		return false;
	if (sum < A[n])
		return Sum(A, sum, n - 1);
	else
		return (Sum(A, sum - A[n], n - 1) || Sum(A, sum, n - 1));
}
int main() {
	int A[3] = { 1,2,3 };
	cout << Sum(A, 7, 2);
}
