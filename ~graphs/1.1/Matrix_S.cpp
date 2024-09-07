#include <iostream>
#include <vector>
#include <deque>
using namespace std;

vector<vector<bool>> Input()
{
    int n;
    cin >> n;

    vector<vector<bool>> A(n, vector<bool>(n, 0));

    for (int i=0; i<n; i++)
    {
        for (int j=0; j<n; j++)
        {
            bool x;
            cin >> x;
            A[i][j] = x;
        }
    }

    return A;
}

deque<pair<int,int>> CreateEdges(const vector<vector<bool>>& A)
{
    int n = A.size();
    deque<pair<int,int>> E;

    for (int i=0; i<n; i++)
    {
        for (int j=i; j<n; j++)
        {
            if (A[i][j])
            {
                E.push_back({i+1, j+1});
            }
        }
    }
    return E;
}

void Output(deque<pair<int,int>>& E)
{
    cout << E.size() << endl;
    for (pair<int,int>& i : E)
    {
        cout << i.first << ' ' << i.second << endl;
    }
}

int main()
{
    vector<vector<bool>> M = Input();
    deque<pair<int,int>> edges = CreateEdges(M);
    Output(edges);
}