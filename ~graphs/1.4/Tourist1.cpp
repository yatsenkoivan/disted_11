#include <iostream>
#include <vector>
#include <deque>
using namespace std;

class Solution
{
    private:
        int n, k;
        vector<vector<bool>> A;

        deque<int> Q;

        void Visit(int x)
        {
            Q.push_back(x);
        }

        void UnvisitLast()
        {
            Q.pop_back();
        }

        void Clear(int a, int b)
        {
            A[a][b] = 0;
            A[b][a] = 0;
        }

        void Restore(int a, int b)
        {
            A[a][b] = 1;
            A[b][a] = 1;
        }

        void OutputPath()
        {
            for (int i : Q)
            {
                cout << i+1 << ' ';
            }
            cout << endl;
        }

        void Deepen()
        {
            if (Q.size() == k+1)
            {
                OutputPath();
                return;
            }
            int current = Q.back();

            for (int i=0; i<n; i++)
            {
                if (A[current][i])
                {
                    Visit(i);
                    Clear(current, i);

                    Deepen();

                    Restore(current, i);
                    UnvisitLast();
                }
            }
        }

    public:
        Solution(int n, int k) : n{n}, k{k}
        {
            A = vector<vector<bool>>(n, vector<bool>(n,0));
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

        void Start(int p)
        {
            Visit(p-1);
            Deepen();
            UnvisitLast();
        }
};

int main()
{
    int n, k, p;
    cin >> n >> k >> p;

    Solution A(n, k);
    A.Start(p);
}