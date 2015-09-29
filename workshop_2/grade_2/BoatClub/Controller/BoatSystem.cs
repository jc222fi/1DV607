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
                    HandleEventShowListMenu(view, register);
                    break;
                case View.Console.MainMenuEvent.Quit:
                    return false;
            }
            
            return true;
        }


        public void HandleEventNewMember(View.Console view, Model.MemberRegister register)
        {
            view.ShowAddMemberInfo();

            Model.Member m = new Model.Member(0);
            m.Name = view.InputMemberName();
            m.PersonalNumber = view.InputMemberPersonalNumber();
            register.AddMember(m);
            register.Save();
        }

        public void HandleEventShowListMenu(View.Console view, Model.MemberRegister register)
        {
            view.ShowMemberListMenu();
            View.Console.MemberListMenuEvent e2;
            e2 = view.GetMemberListMenuSelection();
            switch (e2)
            {
                case View.Console.MemberListMenuEvent.SimpleList:
                    view.ShowMemberList(register.GetMemberList(), true);
                    view.Wait();

                    HandleEventShowListMenu(view, register);
                    break;
                case View.Console.MemberListMenuEvent.CompleteList:
                    view.ShowMemberList(register.GetMemberList(), false);
                    view.Wait();

                    HandleEventShowListMenu(view, register);
                    break;
            }
        }

    }

}
