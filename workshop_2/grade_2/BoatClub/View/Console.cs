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
            EditBoats,
            Abort
        }

        public enum EditBoatsMenuEvent
        {
            None,
            AddBoat,
            EditBoat,
            DeleteBoat, 
            Abort
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
            System.Console.WriteLine("---------Member List Menu---------");
            System.Console.WriteLine("{0}. Show Simple Member List", (int)MemberListMenuEvent.SimpleList);
            System.Console.WriteLine("{0}. Show Complete Member List", (int)MemberListMenuEvent.CompleteList);
            System.Console.WriteLine("{0}. Abort", (int)MemberListMenuEvent.Abort);
        }
        public void ShowEditBoatMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("---------Edit Boat Menu---------");
            System.Console.WriteLine("{0}. Add Boat", (int)EditBoatsMenuEvent.AddBoat);
            System.Console.WriteLine("{0}. Edit Boat", (int)EditBoatsMenuEvent.EditBoat);
            System.Console.WriteLine("{0}. Delete Boat", (int)EditBoatsMenuEvent.DeleteBoat);
            System.Console.WriteLine("{0}. Abort", (int)EditBoatsMenuEvent.Abort);
        }

        public void ShowEditMemberMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("---------Edit Member Menu---------");
            System.Console.WriteLine("{0}. Edit Name", (int)EditMemberMenuEvent.EditName);
            System.Console.WriteLine("{0}. Edit Personal Number", (int)EditMemberMenuEvent.EditPernonalNr);
            System.Console.WriteLine("{0}. Edit Boats", (int)EditMemberMenuEvent.EditBoats);
            System.Console.WriteLine("{0}. Abort", (int)EditMemberMenuEvent.Abort);
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

        public EditMemberMenuEvent GetEditMemberMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)EditMemberMenuEvent.None && option <= (int)EditMemberMenuEvent.Abort)
            {
                return (EditMemberMenuEvent)option;
            }
            else
            {
                return EditMemberMenuEvent.None;
            }
        }

        public EditBoatsMenuEvent GetEditBoatsMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)EditBoatsMenuEvent.None && option <= (int)EditBoatsMenuEvent.Abort)
            {
                return (EditBoatsMenuEvent)option;
            }
            else
            {
                return EditBoatsMenuEvent.None;
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
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.WriteLine("{0,-5} {1,-26} {2,-16}", "ID", "Name", "Personal Number");
            System.Console.WriteLine("------------------------------------------------");

            if (simple)
            {            
                foreach (Model.Member m in list)
                {

                    System.Console.WriteLine("{0,-5} {1,-26} {2,-16}", m.ID, m.Name, m.PersonalNumber);



                    /*
                    System.Console.WriteLine("Name: {0}", m.Name);
                    System.Console.WriteLine("Personal number: {0}", m.PersonalNumber);
                    System.Console.WriteLine("ID: {0}", m.ID);
                    if (!simple)
                    {
                        foreach (Model.Boat b in m.Boats)
                        {
                            System.Console.WriteLine("Boat ID: {0}", b.ID);
                            System.Console.WriteLine("Boat Type: {0}", b.Model);
                            System.Console.WriteLine("Boat Length: {0}", b.Length);
                        }
                    }

        */
                }
            }
            else
            {
                foreach(Model.Member m in list)
                {
                    System.Console.WriteLine("{0,-5} {1,-26} {2,-16}", m.ID, m.Name, m.PersonalNumber);

                    System.Console.WriteLine();
                    System.Console.WriteLine("      ------------Owned Boats------------");

                    System.Console.WriteLine("{0,5} {1,-5} {2, -16} {3, -8}", "", "ID", "MODEL", "LENGTH");
                    System.Console.WriteLine("      -----------------------------------");

                    foreach (Model.Boat b in m.Boats)
                    {
                        System.Console.WriteLine("{0,5} {1,-5} {2, -16} {3, -8}", "", b.ID, b.Model, b.Length);
                        //System.Console.WriteLine("Boat ID: {0}", "", b.ID);
                        //System.Console.WriteLine("Boat Type: {0}", b.Model);
                        //System.Console.WriteLine("Boat Length: {0}", b.Length);
                    }

                    System.Console.WriteLine();

                }


            }



           
            System.Console.WriteLine();
            System.Console.WriteLine("Press space to continue....");
        }

        public void Wait()
        {
            Boolean stop = false;
            while(!stop)
            {
                char c = System.Console.ReadKey().KeyChar;
                if(c == ' ')
                {
                    stop = true;
                }

            }
        }



    }
}
