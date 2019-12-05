using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SnakeVol2
{
    class HighScoreNew
    {
        bool exists = false;
        string path = @"..\..\..\..\SnakeVol2\scoresXML.xml";
        public void FileExists()
        {
            if(File.Exists(path))
            {
                exists = true;
            }   
            else
            {
                exists = false;
            }
        }

        public void RunStuff()
        {
            FileExists();
            if (!exists)
            {

            }
        }
    }
}
