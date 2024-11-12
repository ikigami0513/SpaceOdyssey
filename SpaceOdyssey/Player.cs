using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceOdyssey
{
    internal class Player
    {
        public string Name;
        public int Food = Settings.INIT_FOOD;
        public int Water = Settings.INIT_WATER;

        public Player(string name)
        {
            Name = name;
        }
    }
}
