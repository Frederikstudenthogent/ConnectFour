using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class ComputerPlayer : Player
    {      

        public string Name { get; } = "R2D2";

        public override int Zet { get; set; }
    } 
}
