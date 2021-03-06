using System;

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
            int buttonMenu;
            do
            {
                Configure(new string[] { "System Zarządzania Obiektem Sportowym", "Członkowie", "Trenerzy/Instruktorzy", "Zamknij program - ESC" });
                buttonMenu = Open();
                switch (buttonMenu)
                {
                    case 1:
                    {
                        Console.Clear();
                        Configure(new string[] { "Dodanie członka klubu", "Zakupienie karnetu", "Wyszukiwarka członków klubu", "Powrót - ESC" });
                        var buttonMenuMembers = Open();
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
                        Configure(new string[] { "Dodanie trenera/instrukora", "Wyszukiwarka trenerów/instruktorów", "Powrót - ESC" });
                        var buttonMenuCoaches = Open();
                        switch (buttonMenuCoaches)
                        {
                            case 0:
                            {
                                coach.AddNew();
                                break;
                            }
                            case 1:
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
                        Environment.Exit(0);
                        break;
                    }
                }
            }
            while (buttonMenu != -1 && buttonMenu != 3);
        }

    }
}
