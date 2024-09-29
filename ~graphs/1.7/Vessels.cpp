#include <iostream>
#include <vector>
#include <queue>
using namespace std;

class Solution
{
	private:
		int a, b, n;
		
		vector<int> transition;
		queue<int> Q;
		
		bool IsValueCorrect(int x)
		{
			return (x >= 0 && x <= n && transition[x] == -1);
		}
		
		void Broaden(int x)
		{
			vector<int> delta = {a, -a, b, -b};
			
			for (int i : delta)
			{
				int next = x+i;
				
				if (IsValueCorrect(next) == 0) continue;
				
				Q.push(next);
				transition[next] = x;
			}
		}
		
	public:
		Solution()
		{
			cin >> a >> b >> n;
		}
		
		void Calculate()
		{
			transition = vector<int>(n+1, -1);
			
			Q = queue<int>();
			Q.push(0);
			transition[0] = -2;
			
			while (Q.empty() == 0 && transition[n] == -1)
			{
				int current = Q.front();
				Broaden(current);
				Q.pop();
			}
		}
		
		void OutputResult()
		{
			if (transition[n] == -1)
			{
				cout << -1 << endl;
				return;
			}
			
			deque<int> path;
			
			int current = n;
			
			while (current != -2)
			{
				path.push_front(current);
				current = transition[current];
			}
			
			cout << path.size()-1 << endl;
			for (int i : path)
			{
				cout << i << ' ';
			}
			cout << endl;
		}
		
		
};

int main()
{
	Solution S;
	S.Calculate();
	S.OutputResult();
}
