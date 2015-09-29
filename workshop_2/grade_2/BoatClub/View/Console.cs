﻿using System;
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
            EditPersonalNr,
            ShowEditBoatsMenu,
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


        public enum Error
        {
            InvalidInput,
            NoMemberWithId
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
            System.Console.WriteLine("{0}. Edit Personal Number", (int)EditMemberMenuEvent.EditPersonalNr);
            System.Console.WriteLine("{0}. Edit Boats", (int)EditMemberMenuEvent.ShowEditBoatsMenu);
            System.Console.WriteLine("{0}. Abort", (int)EditMemberMenuEvent.Abort);
        }

 

        public MainMenuEvent GetMainMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)MainMenuEvent.None && option <= (int)MainMenuEvent.Quit)
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

        public void ShowEditMemberNameInfo()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("------Edit Name------");
        }

        public void ShowEditMemberPersonalNrInfo()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("------Edit Personal Number-----");
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
            return double.Parse(System.Console.ReadLine()); //Unhandled
        }

        public int InputMemberID()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write("Enter Member ID (0 to abort): ");

            int id;
            if (Int32.TryParse(System.Console.ReadLine(), out id))
            {
                return id;
            }

            return -1;
        }

        public int InputBoatID()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.Write("Enter Boat ID: ");

            int id;
            if(Int32.TryParse(System.Console.ReadLine(), out id))
            {
                return id;
            }

            return -1;
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
                foreach (Model.Member m in list)
                {
                    System.Console.WriteLine("---------------------------------");
                    System.Console.WriteLine();

                    System.Console.WriteLine("{0,-16}{1}", "ID:", m.ID);
                    System.Console.WriteLine("{0,-16}{1}", "Name:", m.Name);
                    System.Console.WriteLine("{0,-16}{1}", "Personal Nr:", m.PersonalNumber);
                    System.Console.WriteLine("{0,-16}{1}", "Boats:", m.Boats.Count == 0 ? "None" : "");

                    if (m.Boats.Count > 0)
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

        public void ShowMemberInfo(Model.Member m)
        {

            System.Console.Clear();
            System.Console.WriteLine("---------------------------------");
            System.Console.WriteLine();

            System.Console.WriteLine("{0,-16}{1}", "ID:", m.ID);
            System.Console.WriteLine("{0,-16}{1}", "Name:", m.Name);
            System.Console.WriteLine("{0,-16}{1}", "Personal Nr:", m.PersonalNumber);
            System.Console.WriteLine("{0,-16}{1}", "Boats:", m.Boats.Count == 0 ? "None" : "");

            if (m.Boats.Count > 0)
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


        public void Wait()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Press enter to continue...");
            System.Console.ReadLine();
        }

    }
}
