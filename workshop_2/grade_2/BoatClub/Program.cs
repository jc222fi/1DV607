using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {

            View.Console v = new View.Console();
            Model.MemberRegister mrg = new Model.MemberRegister();
            Controller.BoatSystem bs = new Controller.BoatSystem();
            while(bs.ShowMainMenu(v, mrg))
                ;
       
        }
    }
}
