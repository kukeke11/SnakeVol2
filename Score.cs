using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeVol2
{
    public class Score : IComparable<Score>
    {
        public int CompareTo(Score other)
        {
            if (this.score > other.score)
            {
                return 1;
            }
            else if (this.score < other.score)
            {
                return -1;
            }
            else
                return 0;
        }
        public string name { get; set; }
        public int score { get; set; }
        public int id { get; set; }

        public override string ToString()
        {
            return "name: " + name +
                " score " + score;
        }
    }
}
