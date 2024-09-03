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
                    Q.push_back(i);
                    Clear(current, i);

                    Deepen();

                    Restore(current, i);
                    Q.pop_back();
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
            Q.push_back(p-1);
            Deepen();
            Q.pop_back();
        }
};

int main()
{
    int n, k, p;
    cin >> n >> k >> p;

    Solution A(n, k);
    A.Start(p);
}