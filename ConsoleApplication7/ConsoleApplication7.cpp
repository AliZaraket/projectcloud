#include <iostream>
#include <iomanip>
using namespace std;
int main() {
    int arr[5] = { 0,2,3,4,5 };
    int max, min, i, j;
    for (i = 0; i < 5; i++) {
        for (j = 1; j < 5; j++) {
            if (arr[i] > arr[j]) {
                min = arr[i];
                arr[i] = arr[j];
                arr[j] = min;
            }
        }
    }
    min = 0;
    max = 0;
    for (i = 0; i < 4; i++)
        min += arr[i];
    for (i = 1; i < 5; i++)
        max += arr[i];
    cout << min << ' ' << max;
}