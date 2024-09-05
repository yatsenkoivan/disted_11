#include <iostream>
#include <vector>
#include <deque>
#include <map>
using namespace std;

class Solution
{
    private:
        int n;
        vector<vector<int>> A;
        int length;
        deque<pair<int,int>> Q;
    public:
        Solution()
        {
            cin >> n;
            A = vector<vector<int>>(n, vector<int>(n, 0));
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
            length = 0;
            Q = deque<pair<int,int>>();
            int links[n];
            
            for (int i=0; i<n; i++)
            {
                links[i] = i;
            }

            for (int k=0; k<n-1; k++)
            {
                int minLength = -1;
                int a,b;
                for (int i=0; i<n; i++)
                {
                    for (int j=i+1; j<n; j++)
                    {
                        int edgeLength = A[i][j];

                        if (links[i] == links[j] || edgeLength == 0)
                            continue;

                        if (minLength == -1 ||
                            minLength > edgeLength)
                        {
                            minLength = edgeLength;
                            a = i;
                            b = j;
                        }
                    }
                }
                length += minLength;
                Q.push_back({a+1, b+1});
                for (int x=0; x<n; x++)
                {
                    if (links[x] == links[b] && x != b)
                        links[x] = links[a];
                }
                links[b] = links[a];
            }
        }

        void OutputResult()
        {
            cout << length << endl;
            for (pair<int,int>& i : Q)
            {
                cout << i.first << ' ' << i.second << endl;
            }
        }
};

int main()
{
    Solution S;
    S.Calculate();
    S.OutputResult();
}