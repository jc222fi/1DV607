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
                    HandleEventNewMember(view, register);
                    break;

                case View.Console.MainMenuEvent.ShowMemberListMenu:
                    view.ShowMemberListMenu();
                    View.Console.MemberListMenuEvent e2;
                    e2 = view.GetMemberListMenuSelection();
                    switch (e2)
                    {
                        case View.Console.MemberListMenuEvent.SimpleList:
                            view.ShowMemberList(register.GetMemberList(), true);
                            break;
                        case View.Console.MemberListMenuEvent.CompleteList:
                            view.ShowMemberList(register.GetMemberList(), false);
                            break;
                    }
                    break;
                case View.Console.MainMenuEvent.Quit:
                    return false;
            }
            
            return true;
        }


        public void HandleEventNewMember(View.Console view, Model.MemberRegister register)
        {
            Model.Member m = new Model.Member(0);
            m.Name = view.InputMemberName();
            m.PersonalNumber = view.InputMemberPersonalNumber();
            register.AddMember(m);
            register.Save();

        }



    }
}
