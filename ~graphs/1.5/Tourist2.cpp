#include <iostream>
#include <vector>
#include <deque>
#include <unordered_set>
using namespace std;

class Solution
{
    private:
        int n, k;
        vector<vector<bool>> A;

        unordered_set<int> visited;
        deque<int> Q;

        void Visit(int x)
        {
            Q.push_back(x);
            visited.insert(x);
        }

        void UnvisitLast()
        {
            int x = Q.back();
            Q.pop_back();
            visited.erase(x);
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
            if (Q.size() == k)
            {
                OutputPath();
                return;
            }
            int current = Q.back();

            for (int i=0; i<n; i++)
            {
                if (A[current][i] && visited.find(i) == visited.end())
                {
                    Visit(i);
                    Deepen();
                    UnvisitLast();
                }
            }
        }

    public:
        Solution(int n, int k) : n{n}, k{k}
        {
            visited = unordered_set<int>(k);
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