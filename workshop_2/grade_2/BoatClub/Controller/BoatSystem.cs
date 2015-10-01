using System;
using System.Linq;

namespace BoatClub.Controller
{
    class BoatSystem
    {

        public void Start(View.Console view, Model.MemberRegister register)
        {
            ShowMainMenu(view, register);
        }


        private void ShowMainMenu(View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMenu(View.Console.MenuEvent.MainMenu, null);
                switch (view.GetMenuSelection())
                {
                    case View.Console.MenuEvent.AddNewMember:
                        HandleEventNewMember(view, register);
                        break;
                    case View.Console.MenuEvent.MemberListMenu:
                        HandleEventShowMemberListMenu(view, register);
                        break;
                    case View.Console.MenuEvent.MemberInfoMenu:
                        view.ShowInputInfo(View.Console.MenuEvent.MemberInfoMenu, null);
                        int id = view.InputMemberID();
                        if (id == 0)
                            break;

                        try
                        {
                            Model.Member m = register.GetMember(id);
                            HandleEventShowMemberInfoMenu(m, view, register);
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.NoMemberWithId, id.ToString());
                            view.Wait();
                        }
                        break;
                    case View.Console.MenuEvent.DeleteMember:
                        view.ShowInputInfo(View.Console.MenuEvent.DeleteMember, null);
                        id = view.InputMemberID();
                        if (id == 0)
                            break;

                        try
                        {
                            register.DeleteMember(register.GetMember(id));
                            register.Save();
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.NoMemberWithId, id.ToString());
                            view.Wait();
                        }
                        break;
                    case View.Console.MenuEvent.Exit:
                        return;
                }
            }
        }

        public void HandleEventNewMember(View.Console view, Model.MemberRegister register)
        {
            view.ShowInputInfo(View.Console.MenuEvent.AddNewMember, null);

            Model.Member m = new Model.Member(register.GetNextMemberId());

            try
            {
                m.Name = view.InputMemberName();
            }
            catch (ArgumentException)
            {
                view.ShowErrorMessage(View.Console.Error.InvalidMemberName, null);
                view.Wait();
                return;
            }
            try { m.PersonalNumber = view.InputMemberPersonalNumber(); }
            catch (ArgumentException)
            {
                view.ShowErrorMessage(View.Console.Error.InvalidPersonalNumber, null);
                view.Wait();
                return;
            }

            register.AddMember(m);
            register.Save();
        }

        public void HandleEventShowMemberListMenu(View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMenu(View.Console.MenuEvent.MemberListMenu, null);
                switch (view.GetMenuSelection())
                {
                    case View.Console.MenuEvent.MemberListSimple:
                        view.ShowMemberList(register.GetMemberList(), true);
                        view.Wait();
                        break;
                    case View.Console.MenuEvent.MemberListComplete:
                        view.ShowMemberList(register.GetMemberList(), false);
                        view.Wait();
                        break;
                    case View.Console.MenuEvent.Back:
                        // exit menu.
                        return;
                }
            }
        }

        public void HandleEventShowMemberInfoMenu(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMenu(View.Console.MenuEvent.MemberInfoMenu, member);
                switch (view.GetMenuSelection())
                {
                    case View.Console.MenuEvent.EditMemberName:
                        view.ShowInputInfo(View.Console.MenuEvent.EditMemberName, member);
                        try
                        {
                            member.Name = view.InputMemberName();
                            register.Save();
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.InvalidMemberName, null);
                            view.Wait();
                        }
                        break;
                    case View.Console.MenuEvent.EditMemberPersonalNumber:
                        view.ShowInputInfo(View.Console.MenuEvent.EditMemberPersonalNumber, member);
                        try
                        {
                            member.PersonalNumber = view.InputMemberPersonalNumber();
                            register.Save();
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.InvalidPersonalNumber, null);
                            view.Wait();
                        }
                        break;
                    case View.Console.MenuEvent.ManageBoatsMenu:
                        HandleEventShowManageBoatsMenu(member, view, register);
                        register.Save();
                        break;
                    case View.Console.MenuEvent.Back:
                        // exit menu.
                        return;
                }
            }
        }


        public void HandleEventShowManageBoatsMenu(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMenu(View.Console.MenuEvent.ManageBoatsMenu, member);
                int boatId;

                switch (view.GetMenuSelection())
                {
                    case View.Console.MenuEvent.AddBoat:
                        HandleEventAddNewBoat(member, view, register);
                        break;
                    case View.Console.MenuEvent.EditBoatMenu:
                        if (member.GetBoatCount() == 1)
                        {
                            boatId = member.GetBoats().First().ID;
                        }
                        else
                        {
                            view.ShowInputInfo(View.Console.MenuEvent.EditBoatMenu, member);
                            boatId = view.InputBoatID();
                        }

                        try
                        {
                            Model.Boat b = member.GetBoat(boatId);
                            HandleEventShowEditBoatMenu(member, b, view, register);
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.NoBoatWithId, boatId.ToString());
                            view.Wait();
                        }
                        break;
                    case View.Console.MenuEvent.DeleteBoat:                   
                        if (member.GetBoatCount() == 1)
                        {
                            boatId = member.GetBoats().First().ID;
                        }
                        else
                        {
                            view.ShowInputInfo(View.Console.MenuEvent.DeleteBoat, member);
                            boatId = view.InputBoatID();
                        }

                        try
                        {
                            member.DeleteBoat(boatId);
                            break;
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.NoBoatWithId, boatId.ToString());
                            view.Wait();
                        }
                        break;                   
                    case View.Console.MenuEvent.Back:
                        // exit menu
                        return;
                }
            }
        }

        private void HandleEventAddNewBoat(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            view.ShowInputInfo(View.Console.MenuEvent.AddBoat, member);
            Model.Boat boat = new Model.Boat();
            boat.ID = register.GetNextBoatIdFor(member);

            try
            {
                boat.Model = (Model.Boat.BoatModel)view.InputBoatModel();
            }
            catch(ArgumentException)
            {
                view.ShowErrorMessage(View.Console.Error.InvalidBoatModel, null);
                view.Wait();
                return;
            }
     
            try
            {
                boat.Length = view.InputBoatLenght();
            }
            catch (ArgumentException)
            {
                view.ShowErrorMessage(View.Console.Error.InvalidBoatLenght, null);
                view.Wait();
                return;
            }

            member.AddBoat(boat);
            register.Save();
        }

        private void HandleEventShowEditBoatMenu(Model.Member member, Model.Boat boat,
            View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMenu(View.Console.MenuEvent.EditBoatMenu, member);
                switch (view.GetMenuSelection())
                {
                    case View.Console.MenuEvent.EditBoatModel:
                        view.ShowInputInfo(View.Console.MenuEvent.EditBoatModel, member);
                        try
                        {
                            boat.Model = (Model.Boat.BoatModel)view.InputBoatModel();
                            register.Save();
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.InvalidBoatModel, null);
                            view.Wait();
                            return;
                        }
                        break;
                    case View.Console.MenuEvent.EditBoatLength:
                        view.ShowInputInfo(View.Console.MenuEvent.EditBoatLength, member);
                        try
                        {
                            boat.Length = view.InputBoatLenght();
                            register.Save();
                            break;
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.InvalidBoatLenght, null);
                            view.Wait();
                            break;
                        }
                    case View.Console.MenuEvent.Back:
                        // exit menu
                        return;
                }
            }
        }

    }

}
