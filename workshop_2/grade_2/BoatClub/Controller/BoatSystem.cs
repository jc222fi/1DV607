﻿using System;
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

            View.Console.MainMenuEvent e = view.GetMainMenuSelection();

            switch (e)
            {
                case View.Console.MainMenuEvent.AddNewMember:
                    HandleEventNewMember(view, register);
                    break;

                case View.Console.MainMenuEvent.ShowMemberListMenu:
                    HandleEventShowMemberListMenu(view, register);
                    break;
                case View.Console.MainMenuEvent.ShowMemberInfoMenu:
                    int id = view.InputMemberID();
                    if (id == 0)
                        break;
                    try
                    {
                        Model.Member m = register.GetMember(id);
                        HandleEventShowMemberInfoMenu(m, view, register);
                        break;
                    }
                    catch (ArgumentException)
                    {
                        view.ShowErrorMessage(View.Console.Error.NoMemberWithId, id.ToString());
                        view.Wait();
                        break;
                    }
                case View.Console.MainMenuEvent.DeleteMember:
                    int id2 = view.InputMemberID();
                    if (id2 == 0)
                        break;
                    try
                    {
                        register.DeleteMember(register.GetMember(id2));
                        register.Save();
                        break;
                    }
                    catch (ArgumentException)
                    {
                        view.ShowErrorMessage(View.Console.Error.NoMemberWithId, id2.ToString());
                        view.Wait();
                        break;
                    }

                case View.Console.MainMenuEvent.Exit:
                    return false;
            }

            return true;
        }


        public void HandleEventNewMember(View.Console view, Model.MemberRegister register)
        {
            view.ShowAddMemberInfo();

            Model.Member m = new Model.Member(register.GetNextMemberId());

            try
            {
                m.Name = view.InputMemberName();
            }
            catch (ArgumentException e)
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
                view.ShowMemberListMenu();
                switch (view.GetMemberListMenuSelection())
                {
                    case View.Console.MemberListMenuEvent.SimpleList:
                        view.ShowMemberList(register.GetMemberList(), true);
                        view.Wait();
                        break;
                    case View.Console.MemberListMenuEvent.CompleteList:
                        view.ShowMemberList(register.GetMemberList(), false);
                        view.Wait();
                        break;
                    case View.Console.MemberListMenuEvent.Back:
                        // exit menu.
                        return;
                }
            }
        }

        public void HandleEventShowMemberInfoMenu(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowMemberInfoMenu(member);
                switch (view.GetShowMemberInfoMenuSelection())
                {
                    case View.Console.MemberInfoMenuEvent.EditName:
                        view.ShowEditMemberInfo(member);
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
                    case View.Console.MemberInfoMenuEvent.EditPersonalNumber:
                        view.ShowEditMemberInfo(member);
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
                    case View.Console.MemberInfoMenuEvent.ShowManageBoatsMenu:
                        HandleEventShowManageBoatsMenu(member, view, register);
                        register.Save();
                        break;
                    case View.Console.MemberInfoMenuEvent.Back:
                        // exit menu.
                        return;
                }
            }
        }


        public void HandleEventShowManageBoatsMenu(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            while (true)
            {
                view.ShowManageBoatsMenu(member);
                switch (view.GetManageBoatsMenuSelection())
                {
                    case View.Console.ManageBoatsMenu.AddBoat:
                        HandleEventAddNewBoat(member, view, register);
                        break;
                    case View.Console.ManageBoatsMenu.DeleteBoat:
                        int boatId;
                        if (member.Boats.Count == 1)
                        {
                            boatId = member.Boats[0].ID;
                        }
                        else
                        {
                            view.ShowDeleteBoatInfo(member);
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
                    case View.Console.ManageBoatsMenu.EditBoat:
                        if (member.Boats.Count == 1)
                        {
                            boatId = member.Boats[0].ID;
                        }
                        else
                        {
                            view.ShowDeleteBoatInfo(member);
                            boatId = view.InputBoatID();
                        }

                        HandleEventShowEditBoatMenu(member, member.GetBoat(boatId), view, register);
                        break;
                    case View.Console.ManageBoatsMenu.Back:
                        // exit menu
                        return;
                }
            }
        }

        private void HandleEventAddNewBoat(Model.Member member, View.Console view, Model.MemberRegister register)
        {
            view.ShowAddNewBoatInfo(member);
            Model.Boat boat = new Model.Boat();
            boat.ID = register.GetNextBoatIdFor(member);
            view.ListBoatModels();
            try
            {
                boat.Model = view.InputBoatModel();

            }
            catch (ArgumentException)
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
                view.ShowEditBoatMenu(member);
                switch (view.GetEditBoatMenuSelection())
                {
                    case View.Console.EditBoatMenu.EditModel:
                        view.ShowEditBoatInfo(member);
                        try
                        {
                            view.ListBoatModels();
                            boat.Model = view.InputBoatModel();
                            register.Save();
                            break;
                        }
                        catch (ArgumentException)
                        {
                            view.ShowErrorMessage(View.Console.Error.InvalidBoatModel, null);
                            view.Wait();
                            break;
                        }
                    case View.Console.EditBoatMenu.EditLength:
                        view.ShowEditBoatInfo(member);
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
                    case View.Console.EditBoatMenu.Back:
                        // exit menu
                        return;
                }
            }
        }

    }

}
