using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Controller
{
    class BoatSystem
    {

        public bool ShowMainMenu(View.Console view, Model.MemberRegister register)
        {
            view.ShowMainMenu();
           
            View.Console.MainMenuEvent e;

            e = view.GetMainMenuSelection();

            switch(e)
            {
                case View.Console.MainMenuEvent.AddNewMember:
                    Model.Member m = new Model.Member(0);
                    m.Name = "Daniel Nilsson";
                    m.PersonalNumber = "930501-0036";
                    register.AddMember(m);

                    Model.Member m2 = new Model.Member(1);
                    m2.Name = "Daniel Blixt";
                    m2.PersonalNumber = "910501-0036";
                    register.AddMember(m2);


                    register.Save();
                    break;


                case View.Console.MainMenuEvent.Quit:
                    return false;
            }




            /*
            if (e == View.Console.Event.Quit)
            {
                return false;
            }
            if (e == View.Console.Event.Add)
            {
                view.addMember(a_reg);

            }
            if(e == View.Console.Event.Show)
            {
                view.displayMemberList(a_reg);
            }
            if(e == View.Console.Event.Delete)
            {
                view.deleteMember(a_reg);
            }
            if(e == View.Console.Event.Look)
            {
                view.lookAtMember(a_reg);
            }
            if(e == View.Console.Event.Update)
            {
                view.updateMember(a_reg);
            }


               */
            return true;
        }





    }
}
