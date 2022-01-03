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
        private int _numberOfMembers = 1, _numberOfCoaches = 1, _numberOfGroups = 1;

        /// <summary>
        /// Konstruktor klasy SZOS_Manager, przyjmuje on póki co dwa parametry, maksymalną liczbę członków klubu, oraz maksymalną liczbę trenerów. 
        /// </summary>
        /// <param name="sizeNumberOfMembers">Maksymalna liczba członków klubu. Numeracja członków zaczyna się od 1, dlatego aby system mógł ich przyjąć np.: 100 parametr musi wynosić 101</param>
        /// <param name="sizeNumberOfCoach">Maksymalna liczba trenerów/instruktorów w klubie. Numeracja trenerów zaczyna się od 1, dlatego aby system mógł ich przyjąć np.: 100 parametr musi wynosić 101</param>
        /// <param name="sizeNumberOfGroups">Maksymalna liczba grup w klubie. Numeracja zaczyna się od 1, dlatego aby system mógł ich przyjąć np.: 100 parametr musi wynosić 101</param>
        public SZOS_Manager(int sizeNumberOfMembers, int sizeNumberOfCoach, int sizeNumberOfGroups)
        {
            _members = new Member[sizeNumberOfMembers];
            _coaches = new Coach[sizeNumberOfCoach];
            _sportsGroups = new SportsGroups[sizeNumberOfGroups];
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
            Console.WriteLine("6 - Grafik zajęć");
            Console.WriteLine("7 - Wyszukiwarka członków klubu");
            Console.WriteLine("8 - Wyszukiwarka trenerów/instruktorów");
            Console.WriteLine("0 - Zakończ");
        }

        /// <summary>
        /// Run służy do zarządaniem interakcjami wykonywanymi przez użytkownika w programie
        /// </summary>
        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();

                switch (action)
                {
                    case 1:
                    {
                        AddNewMember();
                        break;
                    }
                    case 2:
                    {
                        AddNewCoach();
                        break;
                    }
                    case 3:
                    {
                        AddTypeOfCardToMember();
                        break;
                    }
                    case 4:
                    {
                        CreateSportsGroup();
                        break;
                    }
                    case 5:
                    {
                        AddMembersToGroup();
                        break;
                    }

                    case 6:
                    {
                        break;
                    }
                    case 7:
                    {
                        SearchMemberOrMembers();
                        break;
                    }
                    case 8:
                    {
                        SearchCoaches();
                        break;
                    }
                    default:
                    {
                        Console.Write("Nieznane polecenie");
                        break;
                    }
                }
            }
            while (action != 0);
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
            string rodoAccept;
            if (_numberOfMembers < _members.Length)
            {
                Member newMember = new Member();
                Console.Write("Czy osoba wyraża zgodę RODO? (Tak/Nie): ");
                rodoAccept = Console.ReadLine();
                if (rodoAccept == "Tak")
                {
                    newMember.Rodo = true;
                }
                if (newMember.Rodo == true)
                {
                    Console.Write("Imie: ");
                    newMember.Name = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    newMember.Surname = Console.ReadLine();
                    Console.Write("Adres: ");
                    newMember.Address = Console.ReadLine();
                    Console.Write("PESEL: ");
                    newMember.Pesel = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Płeć: ");
                    newMember.Sex = Console.ReadLine();
                    _members[_numberOfMembers++] = newMember;
                }
                else if (rodoAccept == "Nie")
                {
                    Console.WriteLine("Zgoda RODO konieczna do założenia konta nowemu członkowi");
                    newMember.Rodo = false;
                }
            }
            else
            {
                Console.WriteLine("---------Brak miejsc w klubie-------");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// AddNewCoach to metoda do dodawania nowych trenerów/instruktorów do klubu. Wykorzystuje ona klasę Coach, która dziedzieczy po Person. Wewnątrz Coach przechowywane sa dane szczególowe o trenerze/instruktorze
        /// </summary>
        public void AddNewCoach()
        {
            if (_numberOfCoaches < _coaches.Length)
            {
                Coach newCoach = new Coach();
                Console.Write("Imie: ");
                newCoach.Name = Console.ReadLine();
                Console.Write("Nazwisko: ");
                newCoach.Surname = Console.ReadLine();
                Console.Write("Adres: ");
                newCoach.Address = Console.ReadLine();
                Console.Write("PESEL: ");
                newCoach.Pesel = Convert.ToInt64(Console.ReadLine());
                Console.Write("Płeć: ");
                newCoach.Sex = Console.ReadLine();
                Console.Write("Dyscyplina: ");
                newCoach.SportsDiscipline = Console.ReadLine();
                Console.Write("Numer licencji: ");
                newCoach.LicenseNumber = Console.ReadLine();
                Console.Write("Stawka za godzinę zajęć: ");
                newCoach.HourlyRate = Convert.ToDecimal(Console.ReadLine());

                _coaches[_numberOfCoaches++] = newCoach;
            }
            else
            {
                Console.WriteLine("---------Brak miejsc w klubie-------");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// ShowMembers wyświetla wszystkich członków zapisanych do klubu
        /// </summary>
        public void SearchMemberOrMembers()
        {
            string name, surname;

            Console.Write("Wpisz imie wyszukiwanej osoby: ");
            name = Console.ReadLine();
            Console.Write("Wpisz nazwisko wyszukiwanej osoby: ");
            surname = Console.ReadLine();

            for (int i = 1; i < _numberOfMembers; i++)
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

            Console.ReadKey();
        }

        /// <summary>
        /// ShowCoaches wyświetla wszystkich trenerów/instruktorów w klubie
        /// </summary>
        public void SearchCoaches()
        {
            string name, surname;

            Console.Write("Wpisz imie trenera/instruktora: ");
            name = Console.ReadLine();
            Console.Write("Wpisz trenera/instruktora osoby: ");
            surname = Console.ReadLine();

            for (int i = 1; i < _numberOfCoaches; i++)
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
            for (int i = 1; i < _numberOfMembers; i++)
            {
                if (inPutCardNumber == _members[i].MemberShipNumber)
                {
                    Console.WriteLine($"{_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()}");
                }
            }
            Console.Write($"Wpisz rodzaj pakietu (Silver/Gold/Weekend/Personal): ");
            cardType = Console.ReadLine();

            for (int i = 1; i < _numberOfMembers; i++)
            {
                if (inPutCardNumber == _members[i].MemberShipNumber)
                {
                    if (_members[i].MemberShipCard == "Brak aktywnego karnetu")
                    {
                        if (cardType == "Silver")
                        {
                            _clubCard.TypeOfCard = "Silver";
                            _members[i].MemberShipCard = _clubCard.TypeOfCard;
                        }
                        else if (cardType == "Gold")
                        {
                            _clubCard.TypeOfCard = "Gold";
                            _members[i].MemberShipCard = _clubCard.TypeOfCard;
                        }
                        else if (cardType == "Weekend")
                        {
                            _clubCard.TypeOfCard = "Weekend";
                            _members[i].MemberShipCard = _clubCard.TypeOfCard;
                        }
                        else if (cardType == "Personal")
                        {
                            _clubCard.TypeOfCard = "Personal";
                            _members[i].MemberShipCard = _clubCard.TypeOfCard;
                        }

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
            Console.Write("Wpisz dyscyplinę sportową grupy: ");
            sportsDiscipline = Console.ReadLine();

            Console.Write("Wpisz numer grupy: ");
            short groupNumber = Convert.ToInt16(Console.ReadLine());
            sportsGroups.GroupNumber = groupNumber;

            Console.Write("Wpisz maksymalna liczbe osób w gupie: ");
            var numberOfMembersInGroup = Convert.ToInt32(Console.ReadLine());
            sportsGroups.NumberOfMembersInGroup = numberOfMembersInGroup;

            Console.WriteLine($"Trenerzy/instruktorzy dyscypliny {sportsDiscipline}: ");
            for (int i = 1; i < _numberOfCoaches; i++)
            {
                if (sportsDiscipline == _coaches[i].SportsDiscipline)
                {
                    Console.WriteLine(ShowCoaches(i));
                }
            }

            _sportsGroups[_numberOfGroups++] = sportsGroups;

            Console.Write("Wpisz numer licencji wybranego trenera: ");
            licenceNumber = Console.ReadLine();
            for (int i = 1; i < _numberOfCoaches; i++)
            {
                if (licenceNumber == _coaches[i].LicenseNumber)
                {
                    _sportsGroups[i].GroupNumber = groupNumber; 
                    _sportsGroups[i].NumberOfMembersInGroup = numberOfMembersInGroup; 
                    Console.WriteLine($"Trener {_coaches[i].Name} {_coaches[i].Surname}  {_coaches[i].SportsDiscipline} {_coaches[i].LicenseNumber} grupa {_sportsGroups[i].GroupNumber} {_sportsGroups[i].NumberOfMembersInGroup}");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// ShowCoaches zwaraca dane trenerów/instruktorów
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego trenera. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns></returns>
        public string ShowCoaches(int i)
        {
            return $"{i} {_coaches[i].Name} {_coaches[i].Surname} {_coaches[i].Address} {_coaches[i].Pesel} {_coaches[i].Sex} {_coaches[i].LicenseNumber} {_coaches[i].HourlyRate} {_coaches[i].TypeOfPerson()}";
        }

        public void AddMembersToGroup()
        {
            for (int i = 1; i < _numberOfGroups; i++)
            {
                Console.WriteLine($"Grupa numer {_sportsGroups[i].GroupNumber} {_coaches[i].SportsDiscipline} Maksymalna liczba członków: {_sportsGroups[i].NumberOfMembersInGroup} {_coaches[i].TypeOfPerson()} {_coaches[i].Name} {_coaches[i].Surname}  {_coaches[i].LicenseNumber}");
            }
        }

        /// <summary>
        /// ShowCoaches zwaraca dane członków
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego członka. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns></returns>
        public string ShowMembers(int i)
        {
            return $"{i} {_members[i].Name} {_members[i].Surname} {_members[i].Address} {_members[i].Pesel} {_members[i].Sex} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()} {_members[i].MemberShipCard}";
        }
    }
}
