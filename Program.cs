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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string userAction = " ";
            bool gameRunning;
            bool isStayMeny = true;

            List<Snake> SnakeBody = new List<Snake>();
            GameLogic gameLogic = new GameLogic();
            Draw draw = new Draw();
            XML xml = new XML();
            xml.ReadXML();

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
                            Console.SetCursorPosition(30, 0);
                            gameLogic.keyPressed(command, SnakeBody);
                            xml.DisplayScores();
                            //gameLogic.BodyRename(SnakeBody);
                            draw.DrawSnake(SnakeBody);
                            //draw.deleteLastPoss();
                            if (Console.KeyAvailable) command = Console.ReadKey().Key;
                            if (Settings.GameOver)
                            {
                                Console.Clear();
                                string name;
                                gameRunning = false;
                                Console.SetCursorPosition(20, 28);
                                Console.WriteLine("YOU LOSE!");
                                Console.SetCursorPosition(20, 29);
                                Console.WriteLine("Final Score:" + Settings.Score * 100);
                                Console.SetCursorPosition(20, 30);
                                Console.WriteLine("Enter your Name to exit");
                                xml.DisplayScores();
                                Console.SetCursorPosition(20, 31);
                                name = Console.ReadLine();
                                xml.SaveScores(name, Settings.Score * 100);
                                Console.ReadLine();
                                Console.Clear();
                                gameLogic.showMenu(out userAction);
                            }
                            System.Threading.Thread.Sleep(Settings.Speed);

                        } while (gameRunning);

                        break;
                    case "3":
                    case "s":
                    case "scores":
                        Console.Clear();
                        xml.DisplayScores();

                        break;
                    case "2":
                    case "e":
                    case "exit":
                        isStayMeny = false;
                        xml.WriteToXML<Score>();
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
