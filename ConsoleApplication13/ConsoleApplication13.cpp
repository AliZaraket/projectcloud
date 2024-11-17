#include <iostream>
#include <vector>
using namespace std;

int main() {
    int t;
    vector<int> n, s, m, l, r;
    cin >> t;
    int k;
    for (int i = 0; i < t; i++) {
        cin >> k;
        n.push_back(k);
        cin >> k;
        s.push_back(k);
        cin >> k;
        m.push_back(k);
        for (int j = 0; j < n[i]; j++) {
            cin >> k;
            l.push_back(k);
            cin >> k;
            r.push_back(k);
        }
    }

    int d = 0;
    for (int i = 0; i < t; i++) {
        d = 0;
        if (m[i] - r[d + n[i] - 1] >= s[i]) {
            cout << "YES" << endl;
            continue;
        }
        if (l[d] >= s[i]) {
            cout << "YES" << endl;
            continue;
        }
        bool found = false;
        for (int j = 0; j < n[i] - 1; j++) {
            if (l[d + j + 1] - r[d + j] >= s[i]) {
                cout << "YES" << endl;
                found = true;
                break;
            }
        }
        if (!found) {
            cout << "NO" << endl;
        }
        d += n[i];
    }
    return 0;
}
