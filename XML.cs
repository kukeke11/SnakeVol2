using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace SnakeVol2
{
    class XML
    {
        string path2 = @"C:\Users\marti\source\repos\SnakeVol2\SnakeVol2";
        string path = @"..\..\..\..\SnakeVol2\scoresXML.xml";
        public List<Score> Scores = new List<Score>();
        public void SaveScores(string namee, int scoree)
        {
            if (Scores.Count == 0)
            {
                Score scoress = new Score
                {
                    name = namee,
                    score = scoree,
                };
                Scores.Add(scoress);
                Console.SetCursorPosition(20, 32);
                Console.WriteLine(namee + "Score Saved");
            }
            else
            {
                for (int i = 0; i < Scores.Count; i++)
                {
                    if (Scores[i].name == namee)
                    {
                        Scores[i].score = scoree;
                        Console.SetCursorPosition(20, 32);
                        Console.WriteLine(namee + " Score Updated");
                        return;
                    }
                    else
                    {
                        Score scoress = new Score
                        {
                            name = namee,
                            score = scoree,
                            id = i
                        };
                        Scores.Add(scoress);
                        Console.SetCursorPosition(20, 32);
                        Console.WriteLine(namee + "Score Saved");
                        return;
                    }
                }
            }
            
        }
        public void DisplayScores()
        {
            if(Scores.Count > 0)
            {
                Console.SetCursorPosition(73, 0);
                Console.WriteLine("########HighScores########");
                Sorter();
                Scores.Reverse();
                for (int i = 0; i < Scores.Count; i++)
                {
                    Console.SetCursorPosition(73, i + 2);
                    Console.WriteLine(i+1 + ") " + Scores[i].name + ": " + Scores[i].score);
                }
            }
            else
            {
                return;
            }
        }
        public void Sorter()
        {
            if(Scores.Count > 1)
            {
                Scores.Sort();
            }
            else
            {
                return;
            }
        }
        public void ReadXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));
            using (FileStream stream = File.OpenRead(path))
            {
                List<Score> ScoresTemp = (List<Score>)serializer.Deserialize(stream);
                TemptoMain(ScoresTemp);
            }
        }
        public void TemptoMain(List<Score> ScoresTemp)
        {
            for (int i = 0; i < ScoresTemp.Count; i++)
            {
                SaveScores(ScoresTemp[i].name, ScoresTemp[i].score);
            }
        }

        public void WriteToXML<Score>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Score>));
            using (TextWriter tw = new StreamWriter(path))
            {
                serializer.Serialize(tw, Scores);
            }
        }
    }
}
