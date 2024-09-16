#include <iostream>
#include <deque>
#include <vector>
using namespace std;

class Solution
{
	private:
		int n,k,p,start;
		vector<vector<bool>> A;
		vector<int> path;
		
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
		
		void Visit(int x)
		{
			if (path.empty() == 0)
			{
				int t = path.back();
				Clear(t,x);
			}
			path.push_back(x);
			start = 0;
		}
		
		void UnvisitLast()
		{
			int a = path.back();
			path.pop_back();
			if (path.empty() == 0)
			{
				int b = path.back();
				Restore(a,b);
			}
			start = a+1;
		}
		
		int FindNext(int from)
		{
			int x;
			for (x=start; x<n; x++)
			{
				if (A[from][x] == 1)
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
				cout << i+1 << ' ';
			}
			cout << endl;
		}
	
	public:
		Solution()
		{
			cin >> n >> k >> p;
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
			while (path.empty() == 0)
			{
				if (path.size() == k+1)
				{
					OutputPath();
					UnvisitLast();
					continue;
				}
				
				int last = path.back();
				int x=  FindNext(last);
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