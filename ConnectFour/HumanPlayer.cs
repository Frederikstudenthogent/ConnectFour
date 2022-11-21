using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string name) 
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int Zet { get; set; }
    }
}
