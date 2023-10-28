using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{

    class Program
    {

        static public void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string s;
            Console.WriteLine("Введіть рядок: ");
            s = Console.ReadLine();

            List<string> words = new List<string>();
            string word="";

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (word != "")
                        words.Add(word);
                    word = "";
                }
                else { word += s[i]; }
            }
            if (word != "")
                words.Add(word);

            Console.WriteLine(words.Count);
        }
    }
}

