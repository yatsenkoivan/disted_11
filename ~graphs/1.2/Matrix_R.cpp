#include <iostream>
#include <vector>
using namespace std;

vector<pair<int,int>> Input()
{
    int k;
    cin >> k;

    vector<pair<int,int>> E(k);

    for (int i=0; i<k; i++)
    {
        int a, b;
        cin >> a >> b;

        E[i] = {a,b};
    }

    return E;
}

vector<vector<bool>> CreateMatrix(int n, vector<pair<int,int>>& E)
{
    vector<vector<bool>> A(n, vector<bool>(n, 0));

    for (pair<int,int>& p : E)
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

    vector<pair<int,int>> edges = Input();
    vector<vector<bool>> M = CreateMatrix(n, edges);
    Output(M);
}