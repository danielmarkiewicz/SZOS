using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    /// <summary>
    /// W tej klasie znajdują się wszystkie metody, którymi będzie zarządany program, ich implementacja będzie odbywać się tutaj. Jedyna metoda jaka będzie ruszana w klasie Program to run.
    /// </summary>
    class SZOS_Manager : Menu
    {
        private Member member = new Member(100);
        private Coach coach = new Coach(50);

        public void Run()
        {
            member.ReadMemberFromFile();
            coach.ReadCoachesFromFile();
            int buttonMenu, buttonMenuMembers, buttonMenuCoaches, buttonMenuGroups;
            do
            {
                Configure(new string[] { "System Zarządzania Obiektem Sportowym", "Członkowie", "Trenerzy/Instruktorzy", "Grupy zajęciowe", "Zamknij program - ESC" });
                buttonMenu = Open();
                switch (buttonMenu)
                {
                    case 1:
                    {
                        Console.Clear();
                        Configure(new string[] { "Dodanie członka klubu", "Zakupienie karnetu", "Wyszukiwarka członków klubu", "Powrót - ESC" });
                        buttonMenuMembers = Open();
                        switch (buttonMenuMembers)
                        {
                            case 0:
                            {
                                member.AddNew();;
                                break;
                            }
                            case 1:
                            {
                                member.AddTypeOfCardToMember();
                                break;
                            }
                            case 2:
                            {
                                member.Search();
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    }
                    case 2:
                    {
                        Console.Clear();
                        Configure(new string[] { "Dodanie trenera/instrukora", "Dodanie grupy zajęciowej trenerowi/instruktorowi", "Wyszukiwarka trenerów/instruktorów", "Powrót - ESC" });
                        buttonMenuCoaches = Open();
                        switch (buttonMenuCoaches)
                        {
                            case 0:
                            {
                                coach.AddNew();
                                break;
                            }
                            case 1:
                            {
                                break;
                            }
                            case 2:
                            {
                                coach.Search();
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    }
                    case 3:
                    {
                        Console.Clear();
                        Configure(new string[] { "Dodanie członka do grupy zajęciowej",  "Wyszukiwarka grup zajęciowych", "Powrót - ESC" });
                        buttonMenuGroups = Open();
                        switch (buttonMenuGroups)
                        {
                            case 0:
                            {
                                //AddMembersToGroup(); asalk - 
                                break;
                            }
                            case 1:
                            {
                                //SearchGroups();
                                break;
                            }
                        }
                        Console.Clear();
                        break;
                    }
                    case 4:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
            while (buttonMenu != -1 && buttonMenu != 4);
        }

    }
}
