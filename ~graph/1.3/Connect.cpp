#include <iostream>
#include <vector>
#include <unordered_set>
#include <stack>
using namespace std;

/*
 *  INPUT
 */
int n;
vector<vector<bool>> A;


/*
 *  Alg2
 */
unordered_set<int> S;
stack<int> Q;

void InputMatrix()
{
    A = vector<vector<bool>>(n, vector<bool>(n, 0));
    for (int i=0; i<n; i++)
    {
        for (int j=0; j<n; j++)
        {
            bool x;
            cin >> x;
            A[i][j] = x;
        }
    }
}

bool Alg1()
{
    int n = A.size();

    unordered_set<int> S(n);
    S.insert(0);

    for (int i=1; i<n; i++)
    {
        bool found=0;
        for (int j=0; j<n && found==0; j++)
        {
            if (A[i][j] && S.find(j) != S.end())
            {
                found = 1;
                S.insert(i);
            }
        }
        if (found == 0) return 0;
    }
    return 1;
}


bool Alg2_base()
{
    if (S.size() == n) return 1;

    int current = Q.top();
    for (int i=0; i<n; i++)
    {
        if (A[current][i] && S.find(i) == S.end())
        {
            S.insert(i);

            Q.push(i);
            bool res = Alg2_base();
            Q.pop();

            if (res) return 1;
        }
    }
    return 0;
}

bool Alg2()
{
    S = unordered_set<int>(A.size());
    S.insert(0);
    Q.push(0);
    return Alg2_base();
}

int main()
{
    int k;
    cin >> n >> k;

    InputMatrix();

    bool result = false;
    switch(k)
    {
        case 1:
            result = Alg1();
            break;
        case 2:
            result = Alg2();
            break;
    }
    
    cout << (result ? "TRUE\n" : "FALSE\n");
}