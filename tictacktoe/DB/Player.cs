using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tictacktoe.DB
{
    public class Player
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int score = 0;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
