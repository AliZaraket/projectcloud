#include <iostream>
#include <vector>

using namespace std;

int main() {
    int t;
    vector<int> a1, a2, b1, b2;
    cin >> t;
    for (int i = 0; i < t; i++) {
        int f;
        cin >> f;
        a1.push_back(f);
        cin >> f;
        a2.push_back(f);
        cin >> f;
        b1.push_back(f);
        cin >> f;
        b2.push_back(f);
    }

    int x, y, m1, m2;
    for (int i = 0; i < t; i++) {
        if (a1[i] > a2[i]) {
            x = a2[i];
            y = a1[i];
        }
        else {
            x = a1[i];
            y = a2[i];
        }
        if (b1[i] > b2[i]) {
            m1 = b1[i];
            m2 = b2[i];
        }
        else {
            m1 = b2[i];
            m2 = b1[i];
        }

        if (x >= m1)
            cout << 4 << endl;
        else if (y > m1 && x >= m2)
            cout << 2 << endl;
        else
            cout << 0 << endl;
    }

    return 0;
}
