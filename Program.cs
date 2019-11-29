using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAction = " ";
            bool gameRunning;
            bool isStayMeny = true;

            List<Snake> SnakeBody = new List<Snake>();
            GameLogic gameLogic = new GameLogic();
            Draw draw = new Draw();          

            gameLogic.showMenu(out userAction);
            do
            {
                switch (userAction)
                {
                    case "p":
                    case "1":
                    case "play":
                        Console.Clear();
                        gameRunning = true;
                        gameLogic.gameStart(SnakeBody);
                        draw.DrawWalls();
                        draw.DrawSnake(SnakeBody);

                        ConsoleKey command = Console.ReadKey().Key;
                        do
                        {
                            //Console.Clear();
                            //draw.DrawWalls();
                            //draw.DrawApple();
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Score: " + Settings.Score);
                            gameLogic.keyPressed(command, SnakeBody);
                            gameLogic.BodyRename(SnakeBody);
                            draw.DrawSnake(SnakeBody);
                            draw.deleteLastPoss();
                            if (Console.KeyAvailable) command = Console.ReadKey().Key;
                            if (Settings.GameOver)
                            {
                                gameRunning = false;
                                Console.SetCursorPosition(28, 20);
                                Console.WriteLine("YOU LOSE!");
                                Console.SetCursorPosition(29, 20);
                                Console.WriteLine("Final Score:" + Settings.Score * 100);
                                Console.SetCursorPosition(30, 20);
                                Console.WriteLine("Press Enter to Continuel");
                                Console.ReadLine();
                                Console.Clear();
                                gameLogic.showMenu(out userAction);
                            }
                            System.Threading.Thread.Sleep(Settings.Speed);

                        } while (gameRunning);

                        break;
                    case "2":
                    case "e":
                    case "exit":
                        isStayMeny = false;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Looks like I did not think of that input :O!!!!");
                        Console.ReadLine();
                        Console.Clear();
                        gameLogic.showMenu(out userAction);
                        break;
                }
            } while (isStayMeny);
        }
    }
}
