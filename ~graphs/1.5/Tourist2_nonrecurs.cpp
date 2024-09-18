#include <iostream>
#include <vector>
#include <unordered_set>
using namespace std;

class Solution
{
	private:
		int n, k, p, start;
		vector<vector<bool>> A;
		unordered_set<int> visited;
		vector<int> path;
		
		void Visit(int x)
		{
			path.push_back(x);
			visited.insert(x);
			start = 0;
		}
		
		void UnvisitLast()
		{
			int last = path.back();
			path.pop_back();
			visited.erase(last);
			start = last+1;
		}
		
		int FindNext(int from)
		{
			int x;
			for (x=start; x<n; x++)
			{
				if (A[from][x] && visited.find(x) == visited.end())
				{
					break;
				}
			}
			return x;
		}
		
		void OutputPath()
		{
			for (int i : path)
			{
				cout << (i+1) << ' ';
			}
			cout << endl;
		}
		
	public:
		
		Solution()
		{
			cin >> n >> k >> p;
			A = vector<vector<bool>>(n, vector<bool>(n, 0));
			
			visited.reserve(k);
			path.reserve(k);
			
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
			
			while (path.empty() == 0)
			{
				if (path.size() == k)
				{
					OutputPath();
					UnvisitLast();
					continue;
				}
				
				int last = path.back();
				int x = FindNext(last);
				
				if (x == n)
				{
					UnvisitLast();
				}
				else
				{
					Visit(x);
				}
			}
		}
};

int main()
{
	Solution S;
	S.Start();
}