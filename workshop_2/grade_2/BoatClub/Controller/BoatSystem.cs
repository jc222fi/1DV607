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

            switch (e)
            {
                case View.Console.MainMenuEvent.AddNewMember:
                    HandleEventNewMember(view, register);
                    break;

                case View.Console.MainMenuEvent.ShowMemberListMenu:
                    HandleEventShowListMenu(view, register);
                    break;
                case View.Console.MainMenuEvent.ShowEditMemberMenu:
                    view.ShowEditMemberMenu();
                    View.Console.EditMemberMenuEvent e3;
                    e3 = view.GetEditMemberMenuSelection();
                    switch (e3)
                    {
                        case View.Console.EditMemberMenuEvent.EditName:
                            int id = view.InputMemberID();
                            if (id != 0)
                            {
                                Model.Member m = register.GetMember(id);
                                m.Name = view.InputMemberName();
                            }
                            break;
                        case View.Console.EditMemberMenuEvent.EditPersonalNr:
                            int id2 = view.InputMemberID();
                            if (id2 != 0)
                            {
                                Model.Member m2 = register.GetMember(id2);
                                m2.PersonalNumber = view.InputMemberPersonalNumber();
                            }
                            break;
                        case View.Console.EditMemberMenuEvent.EditBoats:
                            HandleEventEditBoats(view, register);
                            view.Wait();
                            break;
                    }
                    register.Save();
                    break;

                case View.Console.MainMenuEvent.ShowMemberInfo:
                    int id3 = view.InputMemberID();
                    if (id3 != 0)
                    {
                        view.ShowMemberInfo(register.GetMember(id3));
                        view.Wait();
                    }
                    break;
                case View.Console.MainMenuEvent.DeleteMember:
                    int id4 = view.InputMemberID();
                    if (id4 != 0)
                    {
                          register.DeleteMember(register.GetMember(id4));
                    }
                    break;

                case View.Console.MainMenuEvent.Quit:
                    return false;
            }

            return true;
        }


        public void HandleEventNewMember(View.Console view, Model.MemberRegister register)
        {
            view.ShowAddMemberInfo();

            Model.Member m = new Model.Member(register.GetNextMemberId());
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

        public void HandleEventEditBoats(View.Console view, Model.MemberRegister register)
        {
            view.ShowEditBoatMenu();
            View.Console.EditBoatsMenuEvent e3;
            e3 = view.GetEditBoatsMenuSelection();
            switch (e3)
            {
                case View.Console.EditBoatsMenuEvent.AddBoat:
                    int id = view.InputMemberID();
                    if (id != 0)
                    {
                        Model.Member m = register.GetMember(id);
                        Model.Boat boat = new Model.Boat();
                        boat.ID = register.GetNextBoatIdFor(m);
                        boat.Model = view.InputBoatType();
                        boat.Length = view.InputBoatLenght();
                        m.AddBoat(boat);
                    }
                    break;
                case View.Console.EditBoatsMenuEvent.DeleteBoat:
                    int id2 = view.InputMemberID();
                    if (id2 != 0)
                    {
                        Model.Member m2 = register.GetMember(id2);
                        int boatid = view.InputBoatID();
                        m2.DeleteBoat(boatid);
                    }
                    break;
                case View.Console.EditBoatsMenuEvent.EditBoat:
                    int id3 = view.InputMemberID();
                    if (id3 != 0)
                    {
                        Model.Member m3 = register.GetMember(id3);
                        int boatid2 = view.InputBoatID();
                        Model.Boat boat2 = m3.GetBoat(boatid2);
                        boat2.Model = view.InputBoatType();
                        boat2.Length = view.InputBoatLenght();
                    }
                    break;
                case View.Console.EditBoatsMenuEvent.Abort:
                    //Abort
                    break;

            }
            register.Save();

        }

    }

}
