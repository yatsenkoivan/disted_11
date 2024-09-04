#include <iostream>
#include <vector>
using namespace std;

class Solution
{
    private:
        int n;
        vector<vector<int>> distances;
        vector<int> pupilCounts;


    public:
        Solution(int n) : n{n}
        {
            distances = vector<vector<int>>(n, vector<int>(n));
            pupilCounts = vector<int>(n);

            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    cin >> distances[i][j];
                }
            }
            for (int i=0; i<n; i++)
            {
                cin >> pupilCounts[i];
            }
        }

        int GetOptimalVertex()
        {
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    if (i == j) continue;

                    for (int k=0; k<n; k++)
                    {
                        if (distances[i][k] == 0 || distances[k][j] == 0) continue;

                        int alternativeCost = distances[i][k] + distances[k][j];
                        if (distances[i][j] == 0)
                        {
                            distances[i][j] = alternativeCost;
                        }
                        else
                        {
                            distances[i][j] = min(distances[i][j], alternativeCost);
                        }

                    }
                }
            }

            int minCost = -1;
            int ind = -1;

            for (int i=0; i<n; i++)
            {
                int alternative = 0;
                for (int j=0; j<n; j++)
                {
                    alternative += pupilCounts[j] * distances[j][i];
                }

                if (minCost == -1 || alternative < minCost)
                {
                    minCost = alternative;
                    ind = i;
                }
            }

            return ind+1;
        }
};

int main()
{
    int n;
    cin >> n;

    Solution S(n);

    cout << S.GetOptimalVertex() << endl;
}