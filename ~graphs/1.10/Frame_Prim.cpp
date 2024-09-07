#include <iostream>
#include <vector>
#include <unordered_set>
using namespace std;

class Solution
{
    private:
        int n;
        vector<vector<int>> A;
        int totalLength;
        vector<pair<int,int>> Q;
    public:
        Solution(int n) : n{n}
        {
            A = vector<vector<int>>(n, vector<int>(n,0));
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    cin >> A[i][j];
                }
            }
        }
        void Calculate()
        {
            totalLength = 0;
            Q.reserve(n-1);

            unordered_set<int> unlinked(n);
            for (int i=0; i<n; i++)
            {
                unlinked.insert(i);
            }

            vector<int> previous(n);
            previous[0] = -1;

            vector<int> distances(n, -1);
            distances[0] = 0;

            for (int i=0; i<n; i++)
            {
                int next;
                int edgeLength = -1;
                for (int j : unlinked)
                {
                    if (distances[j] == -1)
                        continue;
                    if (edgeLength == -1 || distances[j] < edgeLength)
                    {
                        next = j;
                        edgeLength = distances[next];
                    }
                }
                
                unlinked.erase(next);
                totalLength += edgeLength;

                for (int j : unlinked)
                {
                    if (A[next][j] == 0)
                        continue;
                    if (distances[j] == -1 || A[next][j] < distances[j])
                    {
                        distances[j] = A[next][j];
                        previous[j] = next;
                    }
                }
            }

            for (int i=1; i<n; i++)
            {
                Q.push_back({previous[i]+1, i+1});
            }
        }
        void OutputResult()
        {
            cout << totalLength << endl;
            for (pair<int,int>& p : Q)
            {
                cout << p.first << ' ' << p.second << endl;
            }
        }
};

int main()
{
    int n;
    cin >> n;

    Solution S(n);
    S.Calculate();
    S.OutputResult();   
}