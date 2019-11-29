using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeVol2
{
    class Draw
    {
        public void DrawWalls()
        {
            for (int i = 1; i < 41; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(1, i);
                Console.WriteLine("#");
                Console.SetCursorPosition(70, i);
                Console.WriteLine("#");
            }
            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("#");
                Console.SetCursorPosition(i, 40);
                Console.WriteLine("#");
            }
        }
        public void DrawApple()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Settings.foodX, Settings.foodY);
            Console.Write("@");
        }

        public void DrawSnake(List<Snake> SnakeBody)
        {
            for (int i = 0; i < SnakeBody.Count; i++)
            {
                if (SnakeBody[i].name == "head")
                {
                    Console.SetCursorPosition(SnakeBody[0].xPos, SnakeBody[0].yPos);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("☺");
                }
                else
                {
                    Console.SetCursorPosition(SnakeBody[i].xPos, SnakeBody[i].yPos);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("o");
                }
            }
        }
        public void deleteLastPos(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
        }
        public void deleteLastPoss()
        {
            Console.SetCursorPosition(Settings.x, Settings.y);
            Console.WriteLine(" ");
        }
    }
}
