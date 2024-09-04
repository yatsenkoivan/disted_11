#include <iostream>
#include <unordered_set>
#include <queue>
using namespace std;

struct State
{
    int value;
    State* parent;
    deque<State*> children;

    State(int value, State* parent=nullptr) : value{value}, parent{parent}
    {}

    ~State()
    {
        for (State* i : children)
        {
            delete i;
        }
    }

    void AddChild(State* child)
    {
        children.push_back(child);
    }

    void Output()
    {
        State* current = this;
        deque<int> values;
        while (current != nullptr)
        {
            values.push_front(current->value);
            current = current->parent;
        }

        cout << values.size()-1 << endl;
        for (int i : values)
        {
            cout << i << ' ';
        }
        cout << endl;
    }
};

class Solution
{
    private:
        int a, b, n;
        bool found;
        unordered_set<int> foundStates;

        void TryAddNext(State* c, int inc, queue<State*>& Q)
        {
            int newValue = c->value + inc;

            if (found)
                return;
            if (newValue < 0 || newValue > n)
                return;
            if (foundStates.find(newValue) != foundStates.end())
                return;

            foundStates.insert(newValue);
            State* newState = new State(newValue, c);
            c->AddChild(newState);

            if (newValue == n)
                found = 1;

            Q.push(newState);
        }

    public:
        Solution(int a, int b, int n) : a{a}, b{b}, n{n}
        {}

        void FindShortestWay()
        {
            State* root = new State(0);

            queue<State*> Q;
            Q.push(root);

            found = 0;
            while (Q.empty()==0 && found==0)
            {
                State* c = Q.front();
                TryAddNext(c, a, Q);
                TryAddNext(c, -a, Q);
                TryAddNext(c, b, Q);
                TryAddNext(c, -b, Q);
                Q.pop();
            }

            if (found)
            {
                State* last = Q.back();
                last->Output();
            }
            else
            {
                cout << "-1\n";
            }

            delete root;
        }
};

int main()
{
    int a, b, n;
    cin >> a >> b >> n;

    Solution S(a,b,n);

    S.FindShortestWay();
}