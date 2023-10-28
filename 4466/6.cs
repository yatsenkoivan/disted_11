using System;
using System.Linq;
using System.Text;

namespace Application
{

    class Program
    {

        static public int Count(string S, string sub)
        {
            int res = 0;
            if (S.Length < sub.Length)
                return 0;
            for (int i=0; i<S.Length-sub.Length; i++)
            {
                if (S.Substring(i).StartsWith(sub))
                    res++;
            }
            return res;
        }

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string s1, s2;
            Console.WriteLine("Введіть перший рядок: ");
            s1 = Console.ReadLine();
            Console.WriteLine("Введіть другий рядок: ");
            s2 = Console.ReadLine();

            Console.WriteLine(s1.Count(x => x == '*') > s2.Count(x => x == '*') ? 1 : 2);
            Console.WriteLine(Count(s1, "*-*"));
        }
    }
}

