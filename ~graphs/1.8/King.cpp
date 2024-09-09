#include <iostream>
#include <vector>
#include <queue>
using namespace std;

struct Point
{
	int x;
	int y;
	
	Point() : Point(0,0) {}
	Point(int x, int y) : x{x}, y{y} {}
	
	friend istream& operator>>(istream& in, Point& p)
	{
		in >> p.y >> p.x;
		p.y--;
		p.x--;
		return in;
	}
	
};

class Solution
{
	private:
		const int _UNREACHABLE = -1;
		const int _UNREACHED = -2;
		const int _ATTACKED = -3;

		int m, p;
		vector<vector<int>> board;
		Point start;
		Point end;

		void SetValue(const Point& point, int value)
		{
			board[point.y][point.x] = value;
		}
		int GetValue(const Point& point)
		{
			return board[point.y][point.x];
		}

		void SetPawn(const Point& point)
        {
            Point points[] =
            {
                point,
                Point(point.x-1, point.y-1),
                Point(point.x+1, point.y-1)
            };

            for (int i=0; i<3; i++)
            {
                Point& current = points[i];
                if (OutOfBound(current) == 0)
                    SetValue(current, _ATTACKED);
            }
        }

		bool OutOfBound(const Point& point)
		{
			return (point.x < 0 || point.x >= m ||
					point.y < 0 || point.y >= m);
		}

		bool IsEmpty(const Point& point)
		{
			return GetValue(point) == _UNREACHED;
		}

		bool IsPossibleToMove(const Point& point)
		{
			if (OutOfBound(point))
				return 0;
			if (IsEmpty(point) == 0)
				return 0;
			
			return 1;
		}

		void Broaden(const Point& current, queue<Point>& Q)
		{
			int x = current.x;
			int y = current.y;
			
			Point moves[] =
			{
				Point(x-1, y-1),	//LEFT-UP
				Point(x-1, y),		//LEFT
				Point(x-1, y+1),	//LEFT-DOWN
				Point(x, y-1),		//UP
				Point(x, y+1),		//DOWN
				Point(x+1, y-1),	//RIGHT-UP
				Point(x+1, y),		//RIGHT
				Point(x+1, y+1)		//RIGHT-DOWN
			};

			for (int i=0; i<8; i++)
			{
				Point& next = moves[i];
				if (IsPossibleToMove(next))
				{
					int nextValue = GetValue(current)+1;
					SetValue(next, nextValue);
					Q.push(next);
				}
			}
		}

	public:

		Solution(int m, int p) : m{m}, p{p}
		{
			board = vector<vector<int>>(m, vector<int>(m, _UNREACHED));
			for (int i=0; i<p; i++)
			{
				Point point;
				cin >> point;
				SetPawn(point);
			}
			cin >> start >> end;
			SetValue(start, 0);
		}

		void CalculateShortestPath()
		{
			queue<Point> Q;
			Q.push(start);

			while (Q.empty() == 0 && IsEmpty(end))
			{
				Point& current = Q.front();
				Broaden(current, Q);
				Q.pop();
			}
		}

		int GetShortestPath()
		{
			int value = GetValue(end);
			if (value >= 0)
				return value;
			return _UNREACHABLE;
		}
};

int main()
{
	int m, p;
	cin >> m >> p;
	
	Solution S(m, p);

	S.CalculateShortestPath();

	cout << S.GetShortestPath() << endl;
}
