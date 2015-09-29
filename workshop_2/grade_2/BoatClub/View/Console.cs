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
            CompleteList,
            Abort
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
            System.Console.Clear();
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

        public void ShowMemberListMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("---------Menu---------");
            System.Console.WriteLine("{0}. Show Simple Member List", (int)MemberListMenuEvent.SimpleList);
            System.Console.WriteLine("{0}. Show Complete Member List", (int)MemberListMenuEvent.CompleteList);
            System.Console.WriteLine("{0}. Abort", (int)MemberListMenuEvent.Abort);

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

        public MemberListMenuEvent GetMemberListMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)MemberListMenuEvent.None && option <= (int)MemberListMenuEvent.Abort)
            {
                return (MemberListMenuEvent)option;
            }
            else
            {
                return MemberListMenuEvent.None;
            }
        }


        public void ShowAddMemberInfo()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("----Add New Member----");
        }

        public String InputMemberName()
        {           
            System.Console.Write("Name: ");
            return System.Console.ReadLine();
        }

        public String InputMemberPersonalNumber()
        {
            System.Console.Write("Personal Number: ");
            return System.Console.ReadLine();
        }


        public String InputBoatType()
        {
            System.Console.Write("Enter boat type: ");
            return System.Console.ReadLine();
        }

        public double InputBoatLenght()
        {
            System.Console.Write("Enter boat lenght: ");
            return double.Parse(System.Console.ReadLine());
        }

        public void ShowMemberList(IEnumerable<Model.Member> list, Boolean simple)
        {
            System.Console.Clear();
            System.Console.WriteLine();

            if (simple)
            {
                System.Console.WriteLine("{0,-5} {1,-26} {2,-16}", "ID", "Name", "Personal Number");
                System.Console.WriteLine("------------------------------------------------");

                foreach (Model.Member m in list)
                {
                    System.Console.WriteLine("{0,-5} {1,-26} {2,-16}", m.ID, m.Name, m.PersonalNumber);
                }
            }
            else
            {
                foreach(Model.Member m in list)
                {
                    System.Console.WriteLine("---------------------------------");
                    System.Console.WriteLine();

                    System.Console.WriteLine("{0,-16}{1}", "ID:", m.ID);
                    System.Console.WriteLine("{0,-16}{1}", "Name:", m.Name);
                    System.Console.WriteLine("{0,-16}{1}", "Personal Nr:", m.PersonalNumber);
                    System.Console.WriteLine("{0,-16}{1}", "Boats:", m.Boats.Count == 0 ? "None" : "");
  
                    if(m.Boats.Count > 0)
                    {
                        System.Console.WriteLine();

                        System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3,-6}", "", "ID", "Model", "Length");
                        System.Console.WriteLine("    ----- ------------ ------");

                        foreach (Model.Boat b in m.Boats)
                        {
                            System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3}m", "", b.ID, b.Model,
                                b.Length.ToString("0.00"));
                        }
                    }
                   
                    System.Console.WriteLine();
                }
            }
              
        }

        public void Wait()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Press enter to continue...");
            System.Console.ReadLine();
        }

    }
}
