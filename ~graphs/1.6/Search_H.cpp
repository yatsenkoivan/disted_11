#include <iostream>
#include <vector>
#include <unordered_set>
#include <stack>
using namespace std;

class Solution
{
    private:
        int n;
        vector<vector<bool>> A;

        unordered_set<int> visited;
        stack<int> Q;

        void Visit(int x)
        {
            Q.push(x);
            visited.insert(x);
        }

        void GoBack()
        {
            Q.pop();
        }

        bool Deepen()
        {
            if (visited.size() == n)
            {
                return 1;
            }

            int current = Q.top();
            for (int i=0; i<n; i++)
            {
                if (A[current][i] && visited.find(i) == visited.end())
                {
                    Visit(i);
                    bool result = Deepen();
                    GoBack();

                    if (result) return 1;
                }
            }
            return 0;
        }

    public:
        Solution(int n) : n{n}
        {
            A = vector<vector<bool>>(n, vector<bool>(n, 0));
            visited.reserve(n);
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

        bool Check()
        {
            Visit(0);
            bool result = Deepen();
            GoBack();
            visited.clear();

            return result;
        }
};

int main()
{
    int n;
    cin >> n;
    Solution S(n);
    cout << (S.Check() ? "TRUE\n" : "FALSE\n");
}