#include <iostream>
#include <vector>
#include <deque>
using namespace std;

deque<pair<int,int>> Input()
{
    int k;
    cin >> k;

    deque<pair<int,int>> D;

    for (int i=0; i<k; i++)
    {
        int a, b;
        cin >> a >> b;

        D.push_back({a,b});
    }

    return D;
}

vector<vector<bool>> CreateMatrix(int n, deque<pair<int,int>>& D)
{
    vector<vector<bool>> A(n, vector<bool>(n, 0));

    for (pair<int,int>& p : D)
    {
        int a = p.first - 1;
        int b = p.second - 1;

        A[a][b] = 1;
        A[b][a] = 1;
    }

    return A;
}

void Output(const vector<vector<bool>>& A)
{
    int n = A.size();
    for (int i=0; i<n; i++)
    {
        for (int j=0 ; j<n; j++)
        {
            cout << A[i][j] << ' ';
        }
        cout << endl;
    }
}

int main()
{
    int n;
    cin >> n;

    deque<pair<int,int>> edges = Input();
    vector<vector<bool>> M = CreateMatrix(n, edges);
    Output(M);
}