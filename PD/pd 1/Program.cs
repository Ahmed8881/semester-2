using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
namespace task02pd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char direction1 = 'r';
            char direction2 = 'r';
            char direction3 = 'r';
            char[,] board = new char[10, 40];
            Player player = new Player('P', 20, 8);
            Enemy enemy1 = new Enemy('e', 2, 2);
            Enemy enemy2 = new Enemy('x', 17, 2);
            Enemy enemy3 = new Enemy('n', 30, 2);
            Thread.Sleep(150);
            string[] boardRows = {
    "#######################################",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#                                     #",
    "#######################################"
};
            for (int i = 0; i < boardRows.Length; i++)
            {
                for (int j = 0; j < boardRows[i].Length; j++)
                {
                    board[i, j] = boardRows[i][j];
                }
            }
            board[player.pY, player.pX] = player.playerchar;
            board[enemy1.eY, enemy1.eX] = enemy1.enemychar;
            board[enemy2.eY, enemy2.eX] = enemy2.enemychar;
            board[enemy3.eY, enemy3.eX] = enemy3.enemychar;
            Console.Clear();
            printboard(board);
            while (true)
            {
                Thread.Sleep(150);
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveplayerleft(player,board);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveplayerright(player,board);
                }
                if (enemystrike(enemy1, board, direction1))
                {
                    if (direction1 == 'l')
                        direction1 = 'r';
                    else if (direction1 == 'r')
                        direction1 = 'l';
                }

                if (enemystrike(enemy2, board, direction2))
                {
                    if (direction2 == 'l')
                        direction2 = 'r';
                    else if (direction2 == 'r')
                        direction2 = 'l';
                }
                if (enemystrike(enemy3, board, direction3))
                {
                    if (direction3 == 'l')
                        direction3 = 'r';
                    else if (direction3 == 'r')
                        direction3 = 'l';
                }
                moveenemy(enemy1,board, direction1);
                moveenemy(enemy2,board, direction2);
                moveenemy(enemy3,board, direction3);
                Console.Clear();
                printboard(board);
            }
        }
        static void printboard(char[,] board)
        {
            string print = "";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    print += board[i, j];
                }
                print += "\n";
            }
            Console.Write(print);
        }
        static void moveplayerright(Player player,char[,] board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (board[i, j] == player.playerchar)
                    {
                        board[i, j] = ' ';
                        if (j < 37)
                        {
                            board[i, j + 1] = player.playerchar;
                        }
                        else
                        {
                            board[i, j] = player.playerchar;
                        }
                        break;
                    }
                }
            }
        }
        static void moveplayerleft(Player player, char[,] board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (board[i, j] == player.playerchar)
                    {
                        board[i, j] = ' ';
                        if (j > 1)
                        {
                            board[i, j - 1] = player.playerchar;
                        }
                        else
                        {
                            board[i, j] = player.playerchar;
                        }
                        break;
                    }
                }
            }
        }
        static void moveenemy(Enemy enemy,char[,] board, char direction)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (board[i, j] == enemy.enemychar)
                    {
                        board[i, j] = ' ';
                        if (direction == 'l')
                        { 
                            board[i, j - 1] = enemy.enemychar;
                        }
                        else if (direction == 'r')
                        {
                            board[i, j + 1] = enemy.enemychar;
                        }
                        break;
                    }
                }
            }
        }
        static bool enemystrike(Enemy enemy,char[,] board, char direction)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    if (board[i, j] == enemy.enemychar)
                    {
                        if (direction == 'l')
                        {
                            if (board[i, j - 1] == ' ')
                                return false;
                            else
                                return true;
                        }
                        else if (direction == 'r')
                        {
                            if (board[i, j + 1] == ' ')
                                return false;
                            else
                                return true;
                        }
                        break;
                    }
                }
            }
            return true;
        }
    }
}



