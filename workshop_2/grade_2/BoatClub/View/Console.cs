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

        public enum MenuEvent
        {
            Invalid,
            Back,
            MainMenu,
                AddNewMember,
                MemberListMenu,
                    MemberListSimple,
                    MemberListComplete,
                MemberInfoMenu,
                    EditMemberName,
                    EditMemberPersonalNumber,           
                    ManageBoatsMenu,
                        AddBoat,
                        EditBoatMenu,
                            EditBoatModel,
                            EditBoatLength,
                        DeleteBoat,
                DeleteMember,               
                Exit
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

        private Menu _baseMenu;
        private Menu _currentMenu;


        public Console()
        {
            // Build menu tree
            _baseMenu = new Menu("Menu - BoatClub", 
                (int)MenuEvent.MainMenu, null);

            _baseMenu.Additem((int)MenuEvent.AddNewMember, "Add Member");

            Menu memberListMenu = new Menu("Menu - Member Lists", 
                (int)MenuEvent.MemberListMenu, "View Member List");
            memberListMenu.Additem((int)MenuEvent.MemberListSimple, "Simple List");
            memberListMenu.Additem((int)MenuEvent.MemberListComplete, "Complete List");
            memberListMenu.Additem((int)MenuEvent.Back, "...Back");
            _baseMenu.AddSubMenu(memberListMenu);

            Menu memberInfoMenu = new Menu("Menu - Member Information", 
                (int)MenuEvent.MemberInfoMenu, "View Member Info");
            memberInfoMenu.Additem((int)MenuEvent.EditMemberName, "Edit Name");
            memberInfoMenu.Additem((int)MenuEvent.EditMemberPersonalNumber, "Edit Personal Number");
            
            Menu manageBoatsMenu = new Menu("Menu - Manage Boats", 
                (int)MenuEvent.ManageBoatsMenu, "Manage Boats");
            manageBoatsMenu.Additem((int)MenuEvent.AddBoat, "Add Boat");
            
            Menu editBoatMenu = new Menu("Menu - Edit Boat", 
                (int)MenuEvent.EditBoatMenu, "Edit Boat");
            editBoatMenu.Additem((int)MenuEvent.EditBoatModel, "Edit Model");
            editBoatMenu.Additem((int)MenuEvent.EditBoatLength, "Edit Length");
            editBoatMenu.Additem((int)MenuEvent.Back, "...Back");
            manageBoatsMenu.AddSubMenu(editBoatMenu);

            manageBoatsMenu.Additem((int)MenuEvent.DeleteBoat, "Delete Boat");
            manageBoatsMenu.Additem((int)MenuEvent.Back, "...Back");
            memberInfoMenu.AddSubMenu(manageBoatsMenu);

            memberInfoMenu.Additem((int)MenuEvent.Back, "...Back");
            _baseMenu.AddSubMenu(memberInfoMenu);

            _baseMenu.Additem((int)MenuEvent.DeleteMember, "Delete Member");
            _baseMenu.Additem((int)MenuEvent.Exit, "Quit");
        }


        ///<summary>
        /// Show menu, supply member if member information
        /// should be shown above menu.
        /// </summary>
        public void ShowMenu(MenuEvent menuId, Model.Member member)
        {
            Menu menu = _baseMenu.GetSubMenu((int)menuId);

            // true Menu for menuId exists.
            if(menu != null)
            {
                _currentMenu = menu;

                System.Console.Clear();
                if (member != null)
                {
                    PrintHeader("Member Information");
                    PrintMemberInfo(member);
                    System.Console.WriteLine();
                }

                PrintHeader(menu.Header);
                foreach (View.MenuItem i in menu.GetItems())
                {
                    System.Console.WriteLine("{0}. {1}", menu.GetListIndex(i), i.Title);
                }
            }  
        }
     
        public MenuEvent GetMenuSelection()
        {
            ConsoleKeyInfo cki = System.Console.ReadKey(true);

            // special case, allow navigate back using backspace.
            if (cki.Key == ConsoleKey.Backspace)
                return MenuEvent.Back;

            int selection = (int)MenuEvent.Invalid;           
            Int32.TryParse(cki.KeyChar.ToString(), out selection);

            if(selection != (int)MenuEvent.Invalid)
            {
                if(selection >= _currentMenu.GetListIndex(_currentMenu.GetItems().First())
                    && selection <= _currentMenu.GetListIndex(_currentMenu.GetItems().Last())) {
                    return (MenuEvent)_currentMenu.GetItemId(selection);
                }
            }

            return MenuEvent.Invalid;
        }


        public void ShowInputInfo(MenuEvent action, Model.Member member)
        {
            if(member != null)
            {
                System.Console.Clear();
                PrintHeader("Member Information");
                PrintMemberInfo(member);
            }
            
            System.Console.WriteLine();

            switch(action)
            {
                case MenuEvent.AddNewMember:
                    PrintHeader("Add new Member");
                    break;
                case MenuEvent.MemberInfoMenu:
                    PrintHeader("View Member Info");
                    break;
                case MenuEvent.EditMemberName:
                    PrintHeader("Edit Member");
                    break;
                case MenuEvent.AddBoat:
                    PrintHeader("Add new Boat");
                    break;
                case MenuEvent.EditBoatMenu:
                case MenuEvent.EditBoatLength:
                case MenuEvent.EditBoatModel:
                    PrintHeader("Edit Boat");
                    break;
                case MenuEvent.DeleteBoat:
                    PrintHeader("Delete Boat");
                    break;
                case MenuEvent.DeleteMember:
                    PrintHeader("Delete Member");
                    break;
            }
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
            System.Console.Write("Member ID: ");

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
                    System.Console.WriteLine("{0,-5} {1,-26} {2,-16} {3}", m.ID, m.Name, m.PersonalNumber, m.GetBoatCount());
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


        private void PrintHeader(String title)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(" " + title);
            System.Console.WriteLine("-----------------------------");
        }

        private void PrintMemberInfo(Model.Member member)
        {
            System.Console.WriteLine("{0,-16}{1}", "ID:", member.ID);
            System.Console.WriteLine("{0,-16}{1}", "Name:", member.Name);
            System.Console.WriteLine("{0,-16}{1}", "Personal Nr:", member.PersonalNumber);
            System.Console.WriteLine("{0,-16}{1}", "Boats:", member.GetBoatCount() == 0 ? "None" : "");

            if (member.GetBoatCount() > 0)
            {
                System.Console.WriteLine();

                System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3,-6}", "", "ID", "Model", "Length");
                System.Console.WriteLine("    ----- ------------ ------");

                foreach (Model.Boat b in member.GetBoats())
                {
                    System.Console.WriteLine("{0,4}{1,-5} {2,-12} {3}m", "", b.ID, GetNameForBoatModel(b.Model),
                        b.Length.ToString("0.0"));
                }
            }
        }

        public void Wait()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
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
