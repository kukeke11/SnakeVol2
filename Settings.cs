using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeVol2
{
    public enum Directions
    {
        up,
        down,
        right,
        left
    };
    class Settings
    {
        public static int x { get; set; }
        public static int y { get; set; }
        public static int foodX { get; set; }
        public static int foodY { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Directions direction { get; set; }

        public Settings()
        {
            foodX = 35;
            foodY = 21;
            Score = 0;
            Points = 100;
            Speed = 150;
            GameOver = false;
            direction = Directions.down;
        }
    }
}
