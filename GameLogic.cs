using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SnakeVol2
{
    class GameLogic
    {
        public void gameStart(List<Snake> SnakeBody)
        {
            new Settings();
            SnakeBody.Clear();
            Snake head = new Snake { xPos = 35, yPos = 20, name="head",direction="down" };
            SnakeBody.Add(head);
        }
        public void showMenu(out string userAction)
        {
            string menu = @"  
                
               1) Play                ██████████                                        
                                    ██░░░░░░░░░░██                                      
               2) Exit              ██░░░░░░░░░░░░██                                    
                                  ██░░██░░░░░░██░░██                                    
                                  ██░░██░░░░░░██░░▒▒██                                  
                                  ██░░░░░░░░░░░░░░▒▒██                                  
                                    ██▒▒▒▒▒▒▒▒▒▒▒▒██                                    
                                      ██████████████                                    
                                  ████░░░░██░░░░▒▒████                                  
                                ██░░░░░░██░░░░░░▒▒██▒▒██                                
                              ██░░░░██▒▒▒▒▒▒▒▒▒▒██░░▒▒▒▒██                              
                              ██▒▒░░░░██████████░░░░▒▒██▒▒██                            
                              ██▒▒░░░░░░░░░░░░░░░░░░▒▒██▒▒██                            
                                ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▒▒██                            
                                  ██████████████████    ██                              
                                                               ";
            Console.WriteLine(menu);

            userAction = Console.ReadLine().ToLower();
        }
        public void keyPressed(ConsoleKey command, List<Snake> SnakeBody)
        {
            switch (command)
            {
                case ConsoleKey.LeftArrow:
                    Settings.direction = Directions.left;
                    break;
                case ConsoleKey.UpArrow:
                    Settings.direction = Directions.up;
                    break;
                case ConsoleKey.DownArrow:
                    Settings.direction = Directions.down;
                    break;
                case ConsoleKey.RightArrow:
                    Settings.direction = Directions.right;
                    break;
            }
            directiongo(SnakeBody);
        }
        public void directiongo(List<Snake> SnakeBody)
        {
            if (Settings.direction == Directions.left && SnakeBody[0].direction != "right")
            {
                SnakeBody.First().direction = "left";
            }
            else if(Settings.direction == Directions.right && SnakeBody[0].direction != "left")
            {
                SnakeBody.First().direction = "right";
            }
            else if (Settings.direction == Directions.up && SnakeBody[0].direction != "down")
            {
                SnakeBody.First().direction = "up";
            }
            else if (Settings.direction == Directions.down && SnakeBody[0].direction != "up")
            {
                SnakeBody.First().direction = "down";
            }
            movePlayer(SnakeBody);
        }
        public void movePlayer(List<Snake> SnakeBody)
        {
            Draw draw = new Draw();
            for(int i = SnakeBody.Count - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    int x, y;
                    switch (SnakeBody.First().direction)
                    {
                        case "up":
                            x = SnakeBody[Settings.Score].xPos;
                            y = SnakeBody[Settings.Score].yPos;
                            SnakeBody[i].yPos--;
                            draw.deleteLastPos(x, y);
                            break;
                        case "down":
                            x = SnakeBody[Settings.Score].xPos;
                            y = SnakeBody[Settings.Score].yPos;
                            SnakeBody[i].yPos++;
                            draw.deleteLastPos(x, y);
                            break;
                        case "right":
                            x = SnakeBody[Settings.Score].xPos;
                            y = SnakeBody[Settings.Score].yPos;
                            SnakeBody[i].xPos++;
                            draw.deleteLastPos(x, y);
                            break;
                        case "left":
                            x = SnakeBody[Settings.Score].xPos;
                            y = SnakeBody[Settings.Score].yPos;
                            SnakeBody[i].xPos--;
                            draw.deleteLastPos(x, y);
                            break;
                    }
                    if (SnakeBody[0].xPos == 1 || SnakeBody[0].xPos == 70 || SnakeBody[0].yPos == 40 || SnakeBody[0].yPos == 1)
                    {
                        die();
                    }

                    for (int j = 1; j < SnakeBody.Count; j++)
                    {
                        if (SnakeBody[i].xPos == SnakeBody[j].xPos && SnakeBody[i].yPos == SnakeBody[j].yPos)
                        {
                            die();
                        }
                    }

                    if (SnakeBody[0].xPos == Settings.foodX && SnakeBody[0].yPos == Settings.foodY)
                    {
                        eat(SnakeBody);
                    }
                }
                else
                {
                    SnakeBody[i].xPos = SnakeBody[i - 1].xPos;
                    SnakeBody[i].yPos = SnakeBody[i - 1].yPos;
                }
            }
        }
        private void generateFood()
        {
            Random random = new Random();
            Settings.foodX = random.Next(0 + 2, 70 - 2);
            Settings.foodY = random.Next(0 + 2, 40 - 2);
            Draw draw = new Draw();
            draw.DrawApple();
        }
        private void eat(List<Snake> SnakeBody)
        {
            Snake body = new Snake
            {
                xPos = SnakeBody[SnakeBody.Count - 1].xPos,
                yPos = SnakeBody[SnakeBody.Count - 1].yPos
            };
            SnakeBody.Add(body);
            Settings.Score++;
            generateFood();
        }
        private void die()
        {
            Settings.GameOver = true;
        }
        public void BodyRename(List<Snake> SnakeBody)
        {
            for (int i = 0; i < SnakeBody.Count; i++)
            {
                if(i == 0)
                {
                    SnakeBody[i].name = "head";
                    Console.SetCursorPosition(73, 6);
                    Console.WriteLine("Head is part nr" + i);
                }
                else if(i == SnakeBody.Count-1 && i > 0)
                {
                    SnakeBody[i].name = "tail";
                    Console.SetCursorPosition(73, 4);
                    Console.WriteLine("Tail is part nr" + i);
                    Settings.x = SnakeBody[i].xPos;
                    Settings.y = SnakeBody[i].yPos;
                }
                else
                {
                    SnakeBody[i].name = "body";
                    Console.SetCursorPosition(73, 7+i);
                    Console.WriteLine("Body is part nr" + i);
                }
            }
        }

     
    }
}
