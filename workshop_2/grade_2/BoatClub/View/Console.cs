using System;
using System.Collections.Generic;
using System.Globalization;
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
            ShowMemberInfoMenu,
            DeleteMember,
            Exit
        }

        public enum MemberListMenuEvent
        {
            None,         
            SimpleList,
            CompleteList,
            Back
        }

        public enum MemberInfoMenuEvent
        {
            None,
            EditName,
            EditPersonalNumber,
            ShowManageBoatsMenu,
            Back
        }

        public enum ManageBoatsMenuEvent
        {
            None,            
            AddBoat,
            EditBoat,
            DeleteBoat,
            Back
        }

        public enum EditBoatMenuEvent
        {
            None,
            EditModel,
            EditLength,
            Back
        }


        public enum Error
        {
            NoMemberWithId,
            NoBoatWithId,
            InvalidBoatLenght,
            InvalidPersonalNumber,
            InvalidMemberName,
            InvalidBoatModel
        }
        

        public void ShowMainMenu()
        {
            System.Console.Clear();
            PrintHeader("Menu - BoatClub");
            System.Console.WriteLine("{0}. Add Member", (int)MainMenuEvent.AddNewMember);
            System.Console.WriteLine("{0}. Show Member List", (int)MainMenuEvent.ShowMemberListMenu);
            System.Console.WriteLine("{0}. Show Member Info", (int)MainMenuEvent.ShowMemberInfoMenu);
            System.Console.WriteLine("{0}. Delete Member", (int)MainMenuEvent.DeleteMember);
            System.Console.WriteLine("{0}. Exit", (int)MainMenuEvent.Exit);
        }

        public void ShowMemberListMenu()
        {
            System.Console.Clear();
            PrintHeader("Menu - Member Lists");       
            System.Console.WriteLine("{0}. Show Simple Member List", (int)MemberListMenuEvent.SimpleList);
            System.Console.WriteLine("{0}. Show Complete Member List", (int)MemberListMenuEvent.CompleteList);
            System.Console.WriteLine("{0}. ...Back", (int)MemberListMenuEvent.Back);
        }


        public void ShowMemberInfoMenu(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Menu - Edit Member");
            System.Console.WriteLine("{0}. Edit Name", (int)MemberInfoMenuEvent.EditName);
            System.Console.WriteLine("{0}. Edit Personal Number", (int)MemberInfoMenuEvent.EditPersonalNumber);
            System.Console.WriteLine("{0}. Manage Boats", (int)MemberInfoMenuEvent.ShowManageBoatsMenu);
            System.Console.WriteLine("{0}. ...Back", (int)MemberInfoMenuEvent.Back);
        }

        public void ShowManageBoatsMenu(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Menu - Manage Boats");
            System.Console.WriteLine("{0}. Add Boat", (int)ManageBoatsMenuEvent.AddBoat);
            System.Console.WriteLine("{0}. Edit Boat", (int)ManageBoatsMenuEvent.EditBoat);
            System.Console.WriteLine("{0}. Delete Boat", (int)ManageBoatsMenuEvent.DeleteBoat);
            System.Console.WriteLine("{0}. ...Back", (int)ManageBoatsMenuEvent.Back);
        }

        public void ShowEditBoatMenu(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Menu - Edit Boat");           
            System.Console.WriteLine("{0}. Edit Model", (int)EditBoatMenuEvent.EditModel);
            System.Console.WriteLine("{0}. Edit Length", (int)EditBoatMenuEvent.EditLength);
            System.Console.WriteLine("{0}. ...Back", (int)EditBoatMenuEvent.Back);
        }
        

        public MainMenuEvent GetMainMenuSelection()
        {
            System.Console.WriteLine();
            System.Console.Write("Selection: ");
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)MainMenuEvent.None && option <= (int)MainMenuEvent.Exit)
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

            if (option > (int)MemberListMenuEvent.None && option <= (int)MemberListMenuEvent.Back)
            {
                return (MemberListMenuEvent)option;
            }
            else
            {
                return MemberListMenuEvent.None;
            }
        }

        public MemberInfoMenuEvent GetShowMemberInfoMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)MemberInfoMenuEvent.None && option <= (int)MemberInfoMenuEvent.Back)
            {
                return (MemberInfoMenuEvent)option;
            }
            else
            {
                return MemberInfoMenuEvent.None;
            }
        }

        public ManageBoatsMenuEvent GetManageBoatsMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)ManageBoatsMenuEvent.None && option <= (int)ManageBoatsMenuEvent.Back)
            {
                return (ManageBoatsMenuEvent)option;
            }
            else
            {
                return ManageBoatsMenuEvent.None;
            }
        }

        public EditBoatMenuEvent GetEditBoatMenuSelection()
        {
            int option = System.Console.ReadKey().KeyChar - '0';

            if (option > (int)ManageBoatsMenuEvent.None && option <= (int)ManageBoatsMenuEvent.Back)
            {
                return (EditBoatMenuEvent)option;
            }
            else
            {
                return EditBoatMenuEvent.None;
            }
        }


        public void ShowAddMemberInfo()
        {
            System.Console.WriteLine();
            PrintHeader("Add new Member");
        }

        public void ShowEditMemberInfo(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Edit Member");
        }

        public void ShowAddNewBoatInfo(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Add new Boat");
        }

        public void ShowEditBoatInfo(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Edit Boat");
        }

        public void ShowDeleteBoatInfo(Model.Member member)
        {
            System.Console.Clear();
            PrintHeader("Member Information");
            PrintMemberInfo(member);
            System.Console.WriteLine();
            PrintHeader("Delete Boat");
        }
    


        public string InputMemberName()
        {
            System.Console.Write("Name: ");
            return System.Console.ReadLine();
        }

        public string InputMemberPersonalNumber()
        {
            System.Console.Write("Personal Number: ");
            return System.Console.ReadLine();
        }

        public int InputBoatModel()
        {
            System.Console.WriteLine("{0}. Sailboat", (int)Model.Boat.BoatModel.Sailboat);
            System.Console.WriteLine("{0}. Motorsailer", (int)Model.Boat.BoatModel.Motorsailor);
            System.Console.WriteLine("{0}. Kayak/Canoe", (int)Model.Boat.BoatModel.KayakCanoe);
            System.Console.WriteLine("{0}. Other", (int)Model.Boat.BoatModel.Other);
            System.Console.WriteLine();
            System.Console.Write("Model: ");
            String input = System.Console.ReadLine();
            int model = -1;
            Int32.TryParse(input, out model);
            return model;
        }

        public double InputBoatLenght()
        {
            System.Console.Write("Length: ");
            try
            {
                return Convert.ToDouble(System.Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture);
            }
            catch (FormatException) { }

            return 0;
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
            System.Console.Write("Boat ID: ");

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

            if (simple)
            {
                PrintHeader("Simple Member List");
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine("{0,-5} {1,-26} {2,-16} {3}", "ID", "Name", "Personal Number", "Boats");
                System.Console.WriteLine("-------------------------------------------------------");

                foreach (Model.Member m in list)
                {
                    System.Console.WriteLine("{0,-5} {1,-26} {2,-16} {3}", m.ID, m.Name, m.PersonalNumber, m.Boats.Count);
                }
            }
            else
            {
                PrintHeader("Complete Member List");
                foreach (Model.Member m in list)
                {                   
                    System.Console.WriteLine();
                    PrintMemberInfo(m);
                    System.Console.WriteLine();
                    System.Console.WriteLine("-----------------------------");
                }
            }
        }


        public void ShowErrorMessage(Error e, String arg)
        {
            System.Console.Clear();
            PrintHeader("Error");

            switch(e)
            {
                case Error.NoMemberWithId:
                    System.Console.WriteLine("No member with id={0} exists.", arg);
                    break;
                case Error.NoBoatWithId:
                    System.Console.WriteLine("No boat with id={0} exists for member.", arg);
                    break;
                case Error.InvalidBoatLenght:
                    System.Console.WriteLine("Invalid input, boat length must be greater than 0.");
                    break;
                case Error.InvalidMemberName:
                    System.Console.WriteLine("Invalid input, name cannot be empty.");
                    break;
                case Error.InvalidPersonalNumber:
                    System.Console.WriteLine("Invalid format for personal number.\n(YYMMDD-XXXX)");
                    break;
                case Error.InvalidBoatModel:
                    System.Console.WriteLine("Invalid boat model selected.");
                    break;
            }

            System.Console.WriteLine();
        }


        public void Wait()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }

        private void PrintMemberInfo(Model.Member member)
        {
            System.Console.WriteLine("{0,-16}{1}", "ID:", member.ID);
            System.Console.WriteLine("{0,-16}{1}", "Name:", member.Name);
            System.Console.WriteLine("{0,-16}{1}", "Personal Nr:", member.PersonalNumber);
            System.Console.WriteLine("{0,-16}{1}", "Boats:", member.Boats.Count == 0 ? "None" : "");

            if (member.Boats.Count > 0)
            {
                System.Console.WriteLine();

                System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3,-6}", "", "ID", "Model", "Length");
                System.Console.WriteLine("    ----- ------------ ------");

                foreach (Model.Boat b in member.Boats)
                {
                    System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3}m", "", b.ID, GetNameForBoatModel(b.Model),
                        b.Length.ToString("0.0"));
                }
            }
        }

        private void PrintHeader(String title)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(" " + title);
            System.Console.WriteLine("-----------------------------");
        }

        private string GetNameForBoatModel(Model.Boat.BoatModel model)
        {
            switch(model)
            {
                case Model.Boat.BoatModel.Sailboat:
                    return "Sailboat";
                case Model.Boat.BoatModel.Motorsailor:
                    return "Motorsailor";
                case Model.Boat.BoatModel.KayakCanoe:
                    return "Kayak/Canoe";
                case Model.Boat.BoatModel.Other:
                    return "Other";
            }

            return null;
        }

    }
}
