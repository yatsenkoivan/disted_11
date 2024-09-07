#include <iostream>
#include <vector>
#include <deque>
#include <set>
using namespace std;

struct Edge
{
    int from, to;
    int weight;

    Edge(int from, int to, int weight) : from{from}, to{to}, weight{weight}
    {}

    friend bool operator<(const Edge& e1, const Edge& e2)
    {
        if (e1.weight < e2.weight) return 1;
        if (e1.weight > e2.weight) return 0;

        if (e1.from < e2.from) return 1;
        if (e1.from > e2.from) return 0;

        return e1.to < e2.to;
    }
};

class Solution
{
    private:
        int n;
        set<Edge> edges;
        int totalLength;
        vector<Edge> Q;

        void CreateEdges(const vector<vector<int>>& M)
        {
            for (int i=0; i<n; i++)
            {
                for (int j=i+1; j<n; j++)
                {
                    if (M[i][j] == 0) continue;
                    edges.insert(Edge(i, j, M[i][j]));
                }
            }
        }
    public:
        Solution()
        {
            cin >> n;
            vector<vector<int>> A(n, vector<int>(n,0));
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++)
                {
                    cin >> A[i][j];
                }
            }
            CreateEdges(A);
        }

        void Calculate()
        {
            vector<int> links(n);
            for (int i=0; i<n; i++)
            {
                links[i] = i;
            }

            totalLength = 0;
            Q.reserve(n-1);

            set<Edge>::const_iterator i = edges.cbegin();
            for (set<Edge>::const_iterator i = edges.cbegin(); i != edges.cend() && Q.size() != n-1; i++)
            {
                const Edge& e = *i;

                if (links[e.from] == links[e.to])
                    continue;

                Q.push_back(e);
                totalLength += e.weight;

                for (int i=0; i<n; i++)
                {
                    if (links[i] == links[e.to] && i != e.to)
                    {
                        links[i] = links[e.from];
                    }
                }
                links[e.to] = links[e.from];
            }
        }

        void OutputResult()
        {
            cout << totalLength << endl;
            for (Edge& edge : Q)
            {
                cout << edge.from+1 << ' ' << edge.to+1 << endl;
            }
        }
};

int main()
{
    Solution S;
    S.Calculate();
    S.OutputResult();
}