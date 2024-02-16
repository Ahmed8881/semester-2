using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_PDWeek3_
{
    internal class shritori
    {
        public List<string> words;
        public bool game_over;
        public shritori()
        {
        words = new List<string>();
        game_over = false;
        }
        public object play(string word)
        {
            if (words.Count != 0)
            {
                for (int i = words.Count - 1; i >= 0; i--)
                {
                    if (word == words[i])
                   {
	game_over=true;
                       Console.WriteLine("Game Over");
                        Console.Write("Shritori Words: ");
                        return words.ToArray();
                    }

                }
                string word1 = words[words.Count - 1];
                if (word[0] == word1[word1.Length-1])
                {
	words.Add(word);
                  return words.ToArray();
                }
                game_over = true;
                Console.WriteLine("Game Over");
                Console.Write("Shritori Words: ");
                return words.ToArray(); ;
            }
	words.Add(word);
                  return words.ToArray();
        }
        public string restart()
        {
        words.Clear();
        game_over = false;
        return "Game Restarted";
        }
    }
}
