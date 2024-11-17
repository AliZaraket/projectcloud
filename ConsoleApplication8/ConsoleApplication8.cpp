#include <iostream>
#include <math.h>
#include <string>
using namespace std;
int main() {
    int n;
    string statement[150];
    cin >> n;
    for (int i = 0; i < n; i++) {
        cin >> statement[i];
    }
    int x = 0;
    for (int i = 0; i < n; i++) {
        if (statement[i].find('+')<statement[i].size())
            x++;
        else
            x--;
    }
    cout << x;
    
    return 0;
}