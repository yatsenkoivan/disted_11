#include <iostream>
#include <vector>
using namespace std;

class Solution
{
    private:
        int n, k, p;
        vector<vector<bool>> A;

        vector<int> path;

        void Visit(int x)
        {
            path.push_back(x);
        }

        void UnvisitLast()
        {
            path.pop_back();
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
            for (int i : path)
            {
                cout << i+1 << ' ';
            }
            cout << endl;
        }

        void Deepen()
        {
        	//OutputPath();
            if (path.size() == k+1)
            {
                OutputPath();
                return;
            }
            int current = path.back();

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
        Solution(int n, int k, int p) : n{n}, k{k}, p{p}
        {
            A = vector<vector<bool>>(n, vector<bool>(n,0));
            path.reserve(k+1);
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

        void Start()
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

    Solution S(n, k, p);
    S.Start();
}