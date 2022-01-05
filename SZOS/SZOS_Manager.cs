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
    class SZOS_Manager
    {
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
        /// PrintMainMenu wyswietla listę dostpęnych opcji/funkcji w programie
        /// </summary>
        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję: ");
            Console.WriteLine("1 - Dodanie członka klubu");
            Console.WriteLine("2 - Dodanie trenera/instruktora");
            Console.WriteLine("3 - Zakupienie karnetu");
            Console.WriteLine("4 - Utworzenie grupy zajęciowej");
            Console.WriteLine("5 - Zapisy do grup zajęciowych");
            Console.WriteLine("6 - Wyszukiwarka grup zajęciowych");
            Console.WriteLine("7 - Wyszukiwarka członków klubu");
            Console.WriteLine("8 - Wyszukiwarka trenerów/instruktorów");
            Console.WriteLine("ESC - Zakończ");
        }

        /// <summary>
        /// Run służy do zarządaniem interakcjami wykonywanymi przez użytkownika w programie
        /// </summary>
        public void Run()
        {
            ConsoleKeyInfo buttonMenu;
            do
            {
                PrintMainMenu();
                buttonMenu = Console.ReadKey();
                switch (buttonMenu.Key)
                {
                    case ConsoleKey.D1:
                    {
                        AddNewMember();
                        break;
                    }
                    case ConsoleKey.D2:
                    {
                        AddNewCoach();
                        break;
                    }
                    case ConsoleKey.D3:
                    {
                        AddTypeOfCardToMember();
                        break;
                    }
                    case ConsoleKey.D4:
                    {
                        CreateSportsGroup();
                        break;
                    }
                    case ConsoleKey.D5:
                    {
                        AddMembersToGroup();
                        break;
                    }
                    case ConsoleKey.D6:
                    {
                        SearchGroups();
                        break;
                    }
                    case ConsoleKey.D7:
                    {
                        SearchMemberOrMembers();
                        break;
                    }
                    case ConsoleKey.D8:
                    {
                        SearchCoaches();
                        break;
                    }  
                    case ConsoleKey.D9:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            }
            while (buttonMenu.Key != ConsoleKey.Escape);
        }

        private int SelectedAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }

        /// <summary>
        /// AddNewMember to metoda do dodawania nowych członków do klubu. Wykorzystuje ona klasę Member, w której jest generowany indywidualny numer członkowski.
        /// </summary>
        public void AddNewMember()
        {
            Console.Clear();
            if (_numberOfMembers < _members.Length)
            {
                Member newMember = new Member();
                Console.WriteLine("Dodawanie nowego członka. Wypełnij następujące pola: ");
                Console.Write("Czy osoba wyraża zgodę RODO? (Kliknięcie t = Tak, Kliknięcie n = Nie): ");
                ConsoleKeyInfo buttonRodo = Console.ReadKey();
                if (buttonRodo.Key == ConsoleKey.T)
                {
                    newMember.Rodo = true;
                }
                Console.WriteLine();
                if (newMember.Rodo == true)
                {
                    Console.WriteLine("Wypełnij następujące pola: ");
                    Console.Write("Imie: ");
                    newMember.Name = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    newMember.Surname = Console.ReadLine();
                    Console.Write("Adres (Ulica, Miasto, Kod pocztowy): ");
                    newMember.Address = Console.ReadLine();
                    Console.Write("PESEL: ");
                    newMember.Pesel = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Płeć (M/K): ");
                    newMember.Sex = Console.ReadLine();
                    Console.WriteLine("Aby zakończyć naciśnij ENTER");
                    _members[_numberOfMembers++] = newMember;
                }
                else if (buttonRodo.Key == ConsoleKey.N)
                {
                    Console.WriteLine();
                    Console.WriteLine("Zgoda RODO konieczna do założenia konta nowemu członkowi");
                    Console.WriteLine("Aby zakończyć naciśnij ENTER");
                    newMember.Rodo = false;
                }
            }
            else
            {
                Console.WriteLine("Brak miejsc w klubie");
                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// AddNewCoach to metoda do dodawania nowych trenerów/instruktorów do klubu. Wykorzystuje ona klasę Coach, która dziedzieczy po Person. Wewnątrz Coach przechowywane sa dane szczególowe o trenerze/instruktorze
        /// </summary>
        public void AddNewCoach()
        {
            Console.Clear();
            if (_numberOfCoaches < _coaches.Length)
            {
                Console.WriteLine("Dodawanie nowego trenera/instruktora. Wypełnij następujące pola: ");
                Coach newCoach = new Coach();
                Console.Write("Imie: ");
                newCoach.Name = Console.ReadLine();
                Console.Write("Nazwisko: ");
                newCoach.Surname = Console.ReadLine();
                Console.Write("Adres (Ulica, Miasto, Kod pocztowy): ");
                newCoach.Address = Console.ReadLine();
                Console.Write("PESEL: ");
                newCoach.Pesel = Convert.ToInt64(Console.ReadLine());
                Console.Write("Płeć (M/K): ");
                newCoach.Sex = Console.ReadLine();
                Console.Write("Dyscyplina: ");
                newCoach.SportsDiscipline = Console.ReadLine();
                Console.Write("Numer licencji: ");
                newCoach.LicenseNumber = Console.ReadLine();
                Console.Write("Stawka za godzinę zajęć: ");
                newCoach.HourlyRate = Convert.ToDecimal(Console.ReadLine());

                _coaches[_numberOfCoaches++] = newCoach;

                Console.WriteLine("Aby zakończyć naciśnij ENTER");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Brak miejsc w klubie"); 
                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// ShowMembers wyświetla wszystkich członków zapisanych do klubu
        /// </summary>
        public void SearchMemberOrMembers()
        {
            string name, surname;
            Console.Clear();
            Console.WriteLine("Wyszukiawrka członków klubu.");
            if (_numberOfMembers != 0)
            {
                Console.Write("Wpisz imie osoby lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz nazwisko osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista członków klubu: ");
                for (int i = 0; i < _numberOfMembers; i++)
                {
                    if (name == _members[i].Name && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowMembers(i));
                    }
                    else if (name == _members[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowMembers(i));
                    }
                    else if (name == "" && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowMembers(i));
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowMembers(i));
                    }
                }

                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak osób w bazie danych.");
                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }

            Console.ReadKey();
        }

        public void SearchGroups()
        {
            string name, surname;
            if(_numberOfMembers != 0)
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
            }
            else
            {
                Console.WriteLine("Brak członków w bazie danych.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// ShowCoaches wyświetla wszystkich trenerów/instruktorów w klubie
        /// </summary>
        public void SearchCoaches()
        {
            string name, surname;
            Console.Clear();
            Console.WriteLine("Wyszukiawrka trenerów/instruktorów.");
            if(_numberOfCoaches != 0)
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

                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak trenerów/instruktorów w bazie danych.");
                Console.WriteLine("Aby zakończyć naciśnij ENTER");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// AddTypeOfCardToMember dodaje karnet do klubu określonemu członkowi. Karnet jest przypisywany na podstawie indywidualnego numeru członkowskiego. Jeżeli członek klubu posiada już karnet, metoda blokuje ponowne jego dodanie.
        /// </summary>
        public void AddTypeOfCardToMember()
        {
            ClubCard _clubCard = new ClubCard();
            int inPutCardNumber;
            string cardType;

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
            Console.Write($"Wpisz rodzaj pakietu (Silver/Gold/Weekend/Personal): ");
            cardType = Console.ReadLine();

            for (int i = 0; i < _numberOfMembers; i++)
            {
                if (inPutCardNumber == _members[i].MemberShipNumber)
                {
                    if (_members[i].MemberShipCard == "Brak aktywnego karnetu")
                    {
                        _clubCard.TypeOfCard = cardType;
                        _members[i].MemberShipCard = _clubCard.TypeOfCard;

                        Console.WriteLine($"Użytkownikowi {_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} aktywowano karnet {_members[i].MemberShipCard}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Osoba o numerze karty {_members[i].MemberShipNumber} posiada już karnety typu {_members[i].MemberShipCard} w klubie. Enter");
                        Console.ReadKey();
                    }
                }
            }
        }

        /// <summary>
        /// CreateClass tworzy grupy zajęciowe na podstawie dyscypliny sportowej
        /// </summary>
        public void CreateSportsGroup()
        {
            SportsGroups sportsGroups = new SportsGroups();
            string sportsDiscipline;
            string licenceNumber;

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
                            Console.WriteLine($"Trener {_sportsGroups[j].Name} {_sportsGroups[j].Surname} {_sportsGroups[j].SportsDiscipline} {_sportsGroups[j].LicenseNumber} grupa {_sportsGroups[j].GroupNumber} {_sportsGroups[j].MaxNumberOfMembersInGroup}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Brak trenerów/instruktorów w bazie danych klubu");
                    break;
                }
            }

           

            Console.ReadKey();
        }

        public void AddMembersToGroup()
        {
            
            Console.Write("Dostępne grupy zajęciowe w klubie: ");
            for (int i = 0; i < _numberOfGroups; i++)
            {
                Console.WriteLine($"Grupa numer {_sportsGroups[i].GroupNumber} " +
                                  $"Dyscyplina sportowa {_sportsGroups[i].SportsDiscipline} " +
                                  $"Maksymalna liczba członków: {_sportsGroups[i].MaxNumberOfMembersInGroup} " +
                                  $"Aktualna liczba członków {_sportsGroups[i].MembersInGroup} " +
                                  $"{_sportsGroups[i].TypeOfPerson()} {_sportsGroups[i].Name} {_sportsGroups[i].Surname}  {_sportsGroups[i].LicenseNumber}");

            }

            Console.Write("Wpisz numer grupy: ");
            var groupNumber = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < _numberOfGroups; i++)
            {
                if (groupNumber == _sportsGroups[i].GroupNumber)
                {
                    if(_sportsGroups[i].MembersInGroup != _sportsGroups[i].MaxNumberOfMembersInGroup)
                    {
                        Console.Write("Podaj numer członkowski: ");
                        var membershipNumber = Convert.ToInt32(Console.ReadLine());

                        for (int j = 0; j < _numberOfMembers; j++)
                        {
                            if (membershipNumber == _members[j].MemberShipNumber)
                            {
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
            Console.ReadKey();
        }

        public string ShowGroupsWithMembers(int i)
        {
            return $"Grupa: {_members[i].MemberSportsGroup} {_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()} {_members[i].MemberShipCard}";
        }

        /// <summary>
        /// ShowCoaches zwaraca dane członków
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego członka. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns></returns>
        public string ShowMembers(int i)
        {
            return $"{i+1} {_members[i].Name} {_members[i].Surname} {_members[i].Address} {_members[i].Pesel} {_members[i].Sex} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()} {_members[i].MemberShipCard}";
        }


        /// <summary>
        /// ShowCoaches zwaraca dane trenerów/instruktorów
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego trenera. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns></returns>
        public string ShowCoaches(int i)
        {
            return $"{i+1} {_coaches[i].Name} {_coaches[i].Surname} {_coaches[i].Address} {_coaches[i].Pesel} {_coaches[i].Sex} {_coaches[i].LicenseNumber} {_coaches[i].HourlyRate} {_coaches[i].TypeOfPerson()}";
        }

    }
}
