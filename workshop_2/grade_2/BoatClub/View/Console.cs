using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class Console
    {

        public enum MainMenuEvent
        {
            None,
            AddNewMember,
            ShowMemberListMenu,   // show submenu for simple or complete list.
            ShowMemberInfo,   
            ShowEditMemberMenu, // show submenu for edit name, personal number or boats.
            DeleteMember,           
            Quit
        }

        public enum MemberListMenuEvent
        {
            None,
            SimpleList,
            CompleteList
        }

        public enum EditMemberMenuEvent
        {
            None,
            EditName,
            EditPernonalNr,
            EditBoats
        }

        public enum EditBoatsMenuEvent
        {
            None,
            AddBoat,
            EditBoat,
            DeleteBoat
        }



        public void ShowMainMenu()
        {
            //System.Console.Clear();
            System.Console.WriteLine("Welcome to the boatclub");
            System.Console.WriteLine();
            System.Console.WriteLine("---------Menu---------");
            System.Console.WriteLine("{0}. Add Member", (int)MainMenuEvent.AddNewMember);
            System.Console.WriteLine("{0}. Show Member List", (int)MainMenuEvent.ShowMemberListMenu);
            System.Console.WriteLine("{0}. Show Member Info", (int)MainMenuEvent.ShowMemberInfo);
            System.Console.WriteLine("{0}. Edit Member", (int)MainMenuEvent.ShowEditMemberMenu);
            System.Console.WriteLine("{0}. Delete Member", (int)MainMenuEvent.DeleteMember);
            System.Console.WriteLine("{0}. Quit", (int)MainMenuEvent.Quit);

            //System.Console.WriteLine("Choose and option, a: Add member q: Quit s: Show list of members");
        }

       
        public MainMenuEvent GetMainMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';
                  
            if(option > (int)MainMenuEvent.None && option <= (int)MainMenuEvent.Quit)
            {
                return (MainMenuEvent)option;
            }
            else
            {
                return MainMenuEvent.None;
            }
        }




    }
}
