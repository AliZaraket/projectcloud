#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

string findNthEvenLengthPalindrome(string n) {
    // Create the palindrome by appending the reverse of the string n
    string palindrome = n + string(n.rbegin(), n.rend());
    return palindrome;
}

int main() {
    string n;
    cin >> n;

    // Output the nth even-length palindrome
    cout << findNthEvenLengthPalindrome(n) << endl;

    return 0;
}
