using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Shiritori
    {
        private List<string> words;
        private bool game_over;

        public Shiritori()
        {
            words = new List<string>();
            game_over = false;
        }

        public bool Play(string word)
        {
            if (game_over)
            {
                Console.WriteLine("Game over!");
                return false;
            }

            if (!words.Contains(word))
            {
                words.Add(word);
                Console.WriteLine($"Valid play! Current words: [{string.Join(", ", words)}]");
                return true;
            }
            if (words.Count == 0 || (!words.Contains(word) && words[words.Count - 1][words[words.Count - 1].Length - 1] == word[0]))
            {
                words.Add(word);
                Console.WriteLine($"Valid play! Current words: [{string.Join(", ", words)}]");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid play!");
                return false;
            }

        }

        public string Restart()
        {
            words.Clear();
            game_over = false;
            return "Game restarted!";
        }
    }
}
