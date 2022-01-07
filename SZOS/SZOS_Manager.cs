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
        private Coach[] _coaches;
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
            _coaches = new Coach[sizeNumberOfCoach];
            _sportsGroups = new SportsGroups[sizeNumberOfGroups];
            _listOfMembersInSportsGroup = new SportsGroups[sizeNumberOfMembers];
        }

        /// <summary>
        /// Run służy do zarządaniem interakcjami wykonywanymi przez użytkownika w programie
        /// </summary>
        public void Run()
        {
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
                                AddTypeOfCardToMember();
                                break;
                            }
                            case 2:
                            {
                                SearchMemberOrMembers();
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
                                CreateSportsGroup();
                                break;
                            }
                            case 2:
                            {
                                oc_SearchCoaches();
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

 
        //public void AddNewMember()
        //{
        //    Console.Clear();
        //    if (_numberOfMembers < _members.Length)
        //    {
        //        Member newMember = new Member();
        //        MethodsWriteLineElementColor(new string[]{"--------------Dodawanie nowego użytkowinka-------------","Czy osoba wyraża zgodę RODO? (ENTER = Tak, ESC = Nie): "});
        //        Console.CursorVisible = false;
        //        ConsoleKeyInfo buttonRodo = Console.ReadKey();
        //        Console.CursorVisible = true;
        //        if (buttonRodo.Key == ConsoleKey.Enter)
        //        {
        //            newMember.Rodo = true;
                
        //            Console.WriteLine("Wypełnij następujące pola:");
        //            Console.Write("Imie: ");
        //            newMember.Name = Console.ReadLine();
        //            Console.Write("Nazwisko: ");
        //            newMember.Surname = Console.ReadLine();
        //            Console.Write("Adres: ");
        //            newMember.Address = Console.ReadLine();
        //            Console.Write("PESEL: ");
        //            newMember.Pesel = Convert.ToInt64(Console.ReadLine());
        //            Console.Write("Płeć(M/K): ");
        //            newMember.Sex = Console.ReadLine();
                    
        //            Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
        //            _members[_numberOfMembers++] = newMember;
        //        }
        //        else if (buttonRodo.Key == ConsoleKey.Escape)
        //        {
        //            Console.WriteLine();
        //            MethodsWriteLineElementColor(new string[] { "Zgoda RODO konieczna do założenia konta nowemu członkowi", "Aby powrócić do MENU naciśnij ENTER" });
        //            newMember.Rodo = false;
        //        }
        //    }
        //    else
        //    {
        //        MethodsWriteLineElementColor(new string[] { "Brak miejsc w klubie", "Aby powrócić do MENU naciśnij ENTER" });
        //    }
        //    Console.ReadKey();
        //    Console.Clear();
        //}

        
        //public void AddNewCoach()
        //{
        //    Console.Clear();
        //    if (_numberOfCoaches < _coaches.Length)
        //    {
        //        MethodsWriteLineElementColor(new string[] { "Dodawanie nowego trenera/instruktora", "Wypełnij następujące pola: "});
        //        Coach newCoach = new Coach();
        //        Console.Write("Imie: ");
        //        newCoach.Name = Console.ReadLine();
        //        Console.Write("Nazwisko: ");
        //        newCoach.Surname = Console.ReadLine();
        //        Console.Write("Adres ");
        //        newCoach.Address = Console.ReadLine();
        //        Console.Write("PESEL: ");
        //        newCoach.Pesel = Convert.ToInt64(Console.ReadLine());
        //        Console.Write("Płeć(M/K): ");
        //        newCoach.Sex = Console.ReadLine();
        //        Console.Write("Dyscyplina: ");
        //        newCoach.SportsDiscipline = Console.ReadLine();
        //        Console.Write("Numer licencji: ");
        //        newCoach.LicenseNumber = Console.ReadLine();
        //        Console.Write("Stawka za godzinę zajęć: ");
        //        newCoach.HourlyRate = Convert.ToDecimal(Console.ReadLine());

        //        _coaches[_numberOfCoaches++] = newCoach;

        //        Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
        //        Console.ReadKey();
        //    }
        //    else
        //    {
        //        MethodsWriteLineElementColor(new string[] {"Brak miejsc w klubie", "Aby powrócić do MENU naciśnij ENTER"});
        //    }
        //    Console.ReadKey();
        //}

        /// <summary>
        /// ShowMembers wyświetla wszystkich członków zapisanych do klubu z możliwością filtrowania po imieniu, nazwisku lub imieniu i nazwisku
        /// </summary>
        public void SearchMemberOrMembers()
        {
            string name, surname;
            Console.Clear();
            MethodsWriteLineElementColor(new string[]{ "------------Wyszukiawrka członków klubu-----------------" }); 
            if (_numberOfMembers != 0)
            {
                Console.Write("Wpisz imie osoby lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz nazwisko osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista członków klubu: ");
                Console.WriteLine("---------------------");
                for (int i = 0; i < _numberOfMembers; i++)
                {
                    if (name == _members[i].Name && surname == _members[i].Surname)
                    {
                        Console.WriteLine(member.ShowMembers(i));
                    }
                    else if (name == _members[i].Name && surname == "")
                    {
                        Console.WriteLine(member.ShowMembers(i));
                    }
                    else if (name == "" && surname == _members[i].Surname)
                    {
                        Console.WriteLine(member.ShowMembers(i));
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(member.ShowMembers(i));
                    }
                }
                Console.WriteLine("Aby kontynuować naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak osób w bazie danych.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }

            Console.ReadKey();
        }

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
        public void SearchCoaches()
        {
            string name, surname;
            Console.Clear();
            Console.WriteLine("------------------Wyszukiawrka trenerów/instruktorów------------------");
            if (_numberOfCoaches != 0)
            {
                Console.Write("Wpisz imie trenera/instruktora lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz trenera/instruktora osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista trenerów/instruktorów: ");
                for (int i = 0; i < _numberOfCoaches; i++)
                {
                    if (name == _coaches[i].Name && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == _coaches[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == "" && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                }

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak trenerów/instruktorów w bazie danych.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// AddTypeOfCardToMember dodaje karnet do klubu określonemu członkowi. Karnet jest przypisywany na podstawie indywidualnego numeru członkowskiego. Jeżeli członek klubu posiada już karnet, metoda blokuje ponowne jego dodanie.
        /// </summary>
        public void AddTypeOfCardToMember()
        {
            ClubCard _clubCard = new ClubCard();
            int inPutCardNumber, cardType;
            Console.Clear();
            if (_numberOfMembers != 0)
            {
                SearchMemberOrMembers();

                Console.WriteLine();
                Console.Write("Wpisz numer karty członkowskiej: ");
                inPutCardNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Dodawanie pakietu dla: ");
                for (int i = 0; i < _numberOfMembers; i++)
                {
                    if (inPutCardNumber == _members[i].MemberShipNumber)
                    {
                        Console.WriteLine($"{_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()}");
                    }
                }

                Console.Clear();
                Configure(new string[]{$"Wybierz rodzaj pakietu", "Silver", "Gold", "Weekend","Personal"});
                
                cardType = Open();

                for (int i = 0; i < _numberOfMembers; i++)
                {
                    if (inPutCardNumber == _members[i].MemberShipNumber)
                    {
                        if (_members[i].MemberShipCard == "Brak aktywnego karnetu")
                        {
                            _clubCard.MemberShipCard = cardType.ToString();
                            _members[i].MemberShipCard = _clubCard.MemberShipCard;

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(_clubCard.ShowMembes(i));
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Osoba o numerze karty {_members[i].MemberShipNumber} posiada już karnety typu {_members[i].MemberShipCard} w klubie.");
                        }
                    }
                }
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                MethodsWriteLineElementColor(new string[]{ "Brak osób w bazie danych.", "Aby powrócić do MENU naciśnij ENTER" });
            }
            Console.ReadKey();
        }

        /// <summary>
        /// CreateClass tworzy grupy zajęciowe na podstawie dyscypliny sportowej
        /// </summary>
        public void CreateSportsGroup()
        {
            SportsGroups sportsGroups = new SportsGroups();
            Console.Clear();
            string sportsDiscipline;
            string licenceNumber;
            if (_numberOfMembers != 0 && _numberOfCoaches != 0)
            {
                for (int i = 0; i < _numberOfCoaches; i++)
                {

                    if (_coaches[i] != null)
                    {

                        Console.Write("Wpisz dyscyplinę sportową grupy: ");
                        sportsDiscipline = Console.ReadLine();

                        Console.Write("Wpisz numer grupy: ");
                        short groupNumber = Convert.ToInt16(Console.ReadLine());
                        sportsGroups.GroupNumber = groupNumber;

                        Console.Write("Wpisz maksymalna liczbe osób w gupie: ");
                        var numberOfMembersInGroup = Convert.ToInt32(Console.ReadLine());
                        sportsGroups.MaxNumberOfMembersInGroup = numberOfMembersInGroup;

                        Console.WriteLine($"Trenerzy/instruktorzy dyscypliny {sportsDiscipline}: ");

                        if (sportsDiscipline == _coaches[i].SportsDiscipline)
                        {
                            Console.WriteLine(ShowCoaches(i));
                        }

                        _sportsGroups[_numberOfGroups++] = sportsGroups;

                        Console.Write("Wpisz numer licencji wybranego trenera: ");
                        licenceNumber = Console.ReadLine();
                        for (int j = 0; i < _numberOfCoaches; i++)
                        {
                            if (licenceNumber == _coaches[j].LicenseNumber)
                            {
                                _sportsGroups[j].Name = _coaches[j].Name;
                                _sportsGroups[j].Surname = _coaches[j].Surname;
                                _sportsGroups[j].SportsDiscipline = _coaches[j].SportsDiscipline;
                                _sportsGroups[j].LicenseNumber = _coaches[j].LicenseNumber;

                                _sportsGroups[j].MembersInGroup = 0;
                                _sportsGroups[j].GroupNumber = groupNumber;
                                _sportsGroups[j].MaxNumberOfMembersInGroup = numberOfMembersInGroup;
                                Console.WriteLine(
                                    $"Trener {_sportsGroups[j].Name} {_sportsGroups[j].Surname} {_sportsGroups[j].SportsDiscipline} {_sportsGroups[j].LicenseNumber} grupa {_sportsGroups[j].GroupNumber} {_sportsGroups[j].MaxNumberOfMembersInGroup}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Brak trenerów/instruktorów w bazie danych klubu");
                        break;
                    }
                }

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak osób i trenerów w bazie danych, nie można utworzyć grupy.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            Console.ReadKey();
        }

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
        
        //public string ShowMembers(int i)
        //{
        //    return $"Id: {i + 1} " + "\n" +
        //           $"Imie: {_members[i].Name} " + "\n" +
        //           $"Nazwisko: {_members[i].Surname} " + "\n" +
        //           $"Adres: {_members[i].Address} " + "\n" +
        //           $"PESEL: {_members[i].Pesel} " + "\n" +
        //           $"Płeć: {_members[i].Sex} " + "\n" +
        //           $"Numer członkowski: {_members[i].MemberShipNumber} " + "\n" +
        //           $"{_members[i].TypeOfPerson()} posiadający karnet {_members[i].MemberShipCard}" + "\n" +
        //           $"";
        //}

        /// <summary>
        /// ShowCoaches zwaraca dane trenerów/instruktorów
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego trenera. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns>Zwraca informacje o trenerze</returns>
        public string ShowCoaches(int i)
        {
            return $"Id: {i + 1} " + "\n" +
                   $"Imie: {_coaches[i].Name} " + "\n" +
                   $"Nazwisko: {_coaches[i].Surname} " + "\n" +
                   $"Adres: {_coaches[i].Address} " + "\n" +
                   $"PESEL: {_coaches[i].Pesel} " + "\n" +
                   $"Płeć: {_coaches[i].Sex} " + "\n" +
                   $"Numer członkowski: {_coaches[i].LicenseNumber} " + "\n" +
                   $"{_coaches[i].TypeOfPerson()}. Stawka za godzinę zajęć: {_coaches[i].HourlyRate}" + "\n" +
                   $"";
        }
    }
}
