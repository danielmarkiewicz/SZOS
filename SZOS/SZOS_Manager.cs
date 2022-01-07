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

        private Member[] _members;
        private SportsGroups[] _sportsGroups;
        private SportsGroups[] _listOfMembersInSportsGroup;
        private int _numberOfMembers = 0, _numberOfCoaches = 0, _numberOfGroups = 0;

        /// <summary>
        /// Konstruktor klasy SZOS_Manager, przyjmuje on trzy parametry, maksymalną liczbę członków klubu, maksymalną liczbę trenerów oraz maskysmalną liczbę grup. 
        /// </summary>
        /// <param name="sizeNumberOfMembers">Maksymalna liczba członków klubu.</param>
        /// <param name="sizeNumberOfCoach">Maksymalna liczba trenerów/instruktorów w klubie.</param>
        /// <param name="sizeNumberOfGroups">Maksymalna liczba grup w klubie.</param>
        public SZOS_Manager(int sizeNumberOfMembers, int sizeNumberOfCoach, int sizeNumberOfGroups)
        {
            _members = new Member[sizeNumberOfMembers];
            _sportsGroups = new SportsGroups[sizeNumberOfGroups];
            _listOfMembersInSportsGroup = new SportsGroups[sizeNumberOfMembers];
        }

        /// <summary>
        /// Run służy do zarządaniem interakcjami wykonywanymi przez użytkownika w programie
        /// </summary>
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
                                coach.CreateSportsGroup();
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
                                AddMembersToGroup();
                                break;
                            }
                            case 1:
                            {
                                SearchGroups();
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


      

        /// <summary>
        /// ShowMembers wyświetla wszystkich członków zapisanych do klubu z możliwością filtrowania po imieniu, nazwisku lub imieniu i nazwisku
        /// </summary>
   

        /// <summary>
        /// TODO
        /// </summary>
        public void SearchGroups()
        {
            string name, surname;
            Console.Clear();
            if (_numberOfMembers != 0)
            {
                Console.Write("Wpisz numer grupy: ");
                name = Console.ReadLine();
                Console.Write("Wpisz nazwisko wyszukiwanej osoby: ");
                surname = Console.ReadLine();

                for (int i = 0; i < _numberOfMembers; i++)
                {
                    if (name == _members[i].Name && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowGroupsWithMembers(i));
                    }
                    else if (name == _members[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowGroupsWithMembers(i));
                    }
                    else if (name == "" && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowGroupsWithMembers(i));
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowGroupsWithMembers(i));
                    }
                }
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak osób w bazie danych.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// ShowCoaches wyświetla wszystkich trenerów/instruktorów w klubie z możliwością filtrowania po imieniu, nazwisku lub imieniu i nazwisku
        /// </summary>
       

        /// <summary>
        /// AddTypeOfCardToMember dodaje karnet do klubu określonemu członkowi. Karnet jest przypisywany na podstawie indywidualnego numeru członkowskiego. Jeżeli członek klubu posiada już karnet, metoda blokuje ponowne jego dodanie.
        /// </summary>


        /// <summary>
        /// CreateClass tworzy grupy zajęciowe na podstawie dyscypliny sportowej
        /// </summary>  
      

        /// <summary>
        /// DO edycji
        /// </summary>
        public void AddMembersToGroup()
        {
            Console.Clear();
            if (_numberOfGroups != 0)
            {
                Console.Write("Dostępne grupy zajęciowe w klubie: ");
                for (int i = 0; i < _numberOfGroups; i++)
                {
                    Console.WriteLine($"Grupa numer {_sportsGroups[i].GroupNumber} " +
                                      $"Dyscyplina sportowa {_sportsGroups[i].SportsDiscipline} " +
                                      $"Maksymalna liczba członków: {_sportsGroups[i].MaxNumberOfMembersInGroup} " +
                                      $"Aktualna liczba członków {_sportsGroups[i].MembersInGroup} " +
                                      $"{_sportsGroups[i].CoachGroup()} {_sportsGroups[i].Name} {_sportsGroups[i].Surname}  {_sportsGroups[i].LicenseNumber}");

                }

                Console.Write("Wpisz numer grupy: ");
                var groupNumber = Convert.ToInt16(Console.ReadLine());

                for (int i = 0; i < _numberOfGroups; i++)
                {
                    if (groupNumber == _sportsGroups[i].GroupNumber)
                    {
                        if (_sportsGroups[i].MembersInGroup != _sportsGroups[i].MaxNumberOfMembersInGroup)
                        {
                            Console.Write("Podaj numer członkowski: ");
                            var membershipNumber = Convert.ToInt32(Console.ReadLine());

                            for (int j = 0; j < _numberOfMembers; j++)
                            {
                                if (membershipNumber == _members[j].MemberShipNumber)
                                {
                                    //DO ZMIANY NA LISTE OSOB _ListOfMembersInGroup
                                    //_sportsGroups[i].member.Name = _members[j].Name;
                                    //Console.WriteLine(_sportsGroups[i].member.Name = _members[j].Name);
                                    _members[i].MemberSportsGroup = groupNumber;
                                    Console.WriteLine($"{_members[j].TypeOfPerson()} {_members[j].Name} {_members[j].Surname} {_members[j].MemberShipNumber} został zapisany do grupy {_members[i].MemberSportsGroup}");
                                    _sportsGroups[i].MembersInGroup++;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Grupa {_sportsGroups[i].GroupNumber} posiada maksymalną liczbę członków");
                        }
                    }
                }
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak utworzonych grup, nie można zapisać osoby.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// DO edycji
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string ShowGroupsWithMembers(int i)
        {
            return $"Grupa: {_members[i].MemberSportsGroup} {_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()} {_members[i].MemberShipCard}";
        }
        

        /// <summary>
        /// ShowCoaches zwaraca dane trenerów/instruktorów
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego trenera. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns>Zwraca informacje o trenerze</returns>
 
    }
}
