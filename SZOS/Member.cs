using System;
using System.IO;

namespace SZOS
{
    /// <summary>
    /// Klasa Member przechowuje informacje o członkach klubu, dziedziczy podstawowe informacje po klasie Person.
    /// </summary>
    class Member : Person
    {
        private Member[] _members;
        private Menu menu = new Menu();
        private static readonly Random getrandom = new Random();
        private int membershipNumber;
        private string membershipCard;
        private bool _rodo;

        protected Member()
        {
            MemberShipNumber = membershipNumber;
            MemberShipCard = membershipCard;
            NumberOfMembers = NumberOfMembers;
        }

        public Member(int sizeNumberOfMembers)
        {
            _members = new Member[sizeNumberOfMembers];
        }

        ~Member()
        {
            File.Copy("Members.txt", $"Members_backup.txt", true);
        }

        private int NumberOfMembers { get; set; }

        private int MemberShipNumber
        {
            get => membershipNumber;
            set => membershipNumber = GenerateMembershipNumber();
        }

        protected virtual string MemberShipCard
        {
            get => membershipCard;
            set
            {
                if (value == null)
                {
                    membershipCard = "Brak aktywnego karnetu";
                }
                else
                {
                    membershipCard = value;
                }
            }
        }

        private bool RodoAgreement
        {
            set => _rodo = value;
        }

        /// <summary>
        /// GenerateMembershipNumber generuje indywidualny numer członkowski w zakresie od 10000 do 32000
        /// </summary>
        /// <returns></returns>
        private int GenerateMembershipNumber()
        {
            lock (getrandom)
            {
                return getrandom.Next(10000, 32000);
            }
        }

        /// <summary>
        /// Implemntacja abstrakcyjnej metody TypeOfPerson.
        /// </summary>
        /// <returns>Zwraca rodzaj osoby</returns>
        public override string TypeOfPerson()
        {
            return "Członek klubu";
        }

        /// <summary>
        /// Implementacja abstrakcyjnej metody do dodawania nowych członków do klubu. Wykorzystuje ona klasę Member, w której jest generowany indywidualny numer członkowski.
        /// </summary>
        public override void AddNew()
        {
            Console.Clear();
            if (NumberOfMembers < _members.Length)
            {
                Member newMember = new Member();
                menu.MethodsWriteLineElementColor(new string[] { "--------------Dodawanie nowego użytkowinka-------------", "Czy osoba wyraża zgodę RODO? (ENTER = Tak, ESC = Nie): " });
                Console.CursorVisible = false;
                ConsoleKeyInfo buttonRodo = Console.ReadKey();
                Console.CursorVisible = true;
                if (buttonRodo.Key == ConsoleKey.Enter)
                {
                    newMember.RodoAgreement = true;

                    Console.WriteLine("Wypełnij następujące pola:");
                    Console.Write("Imie: ");
                    newMember.Name = Console.ReadLine();
                    Console.Write("Nazwisko: ");
                    newMember.Surname = Console.ReadLine();
                    Console.Write("Adres: ");
                    newMember.Address = Console.ReadLine();
                    Console.Write("PESEL: ");
                    newMember.Pesel = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Płeć(M/K): ");
                    newMember.Sex = Console.ReadLine();

                    Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
                    _members[NumberOfMembers++] = newMember;
                    File.AppendAllText("Members.txt", $"\n{newMember.Name};{newMember.Surname};{newMember.Address};{newMember.Pesel};{newMember.Sex}");
                }
                else if (buttonRodo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    menu.MethodsWriteLineElementColor(new string[] { "Zgoda RODO konieczna do założenia konta nowemu członkowi", "Aby powrócić do MENU naciśnij ENTER" });
                    newMember.RodoAgreement = false;
                }
            }
            else
            {
                menu.MethodsWriteLineElementColor(new string[] { "Brak miejsc w klubie", "Aby powrócić do MENU naciśnij ENTER" });
            }
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Implementacja abstrakcyjnej metody Search. Służy do wyszukiwania członków klubu.
        /// </summary>
        public override void Search()
        {
            string name, surname;
            Console.Clear();
            menu.MethodsWriteLineElementColor(new string[] { "------------Wyszukiawrka członków klubu-----------------" });
            if (NumberOfMembers != 0)
            {
                Console.Write("Wpisz imie osoby lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz nazwisko osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista członków klubu: ");
                Console.WriteLine("---------------------");
                for (int i = 0; i < NumberOfMembers; i++)
                {
                    if (name == _members[i].Name && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowMembers(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == _members[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowMembers(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == "" && surname == _members[i].Surname)
                    {
                        Console.WriteLine(ShowMembers(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowMembers(i));
                        Console.WriteLine("-------------------------------------------------------------------");
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
        /// AddTypeOfCardToMember służy do dodawania karnetu członkowi klubu.
        /// </summary>
        public void AddTypeOfCardToMember()
        {
            ClubCard clubCard = new ClubCard();
            int inPutCardNumber, cardType;
            Console.Clear();
            if (this.NumberOfMembers != 0)
            {
                Search();

                Console.WriteLine();
                Console.Write("Wpisz numer karty członkowskiej: ");
                inPutCardNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Dodawanie pakietu dla: ");
                for (int i = 0; i < NumberOfMembers; i++)
                {
                    if (inPutCardNumber == _members[i].MemberShipNumber)
                    {
                        Console.WriteLine($"{_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()}");
                    }
                }

                Console.Clear();
                menu.Configure(new string[] { $"Wybierz rodzaj pakietu", "Silver", "Gold", "Weekend", "Personal" });

                cardType = menu.Open();

                for (int i = 0; i < NumberOfMembers; i++)
                {
                    if (inPutCardNumber == _members[i].MemberShipNumber)
                    {
                        if (_members[i].MemberShipCard == "Brak aktywnego karnetu")
                        {
                            clubCard.MemberShipCard = cardType.ToString();
                            _members[i].MemberShipCard = clubCard.MemberShipCard;

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Użytkownikowi {_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} aktywowano karnet {_members[i].MemberShipCard}");
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
                menu.MethodsWriteLineElementColor(new string[] { "Brak osób w bazie danych.", "Aby powrócić do MENU naciśnij ENTER" });
            }
            Console.ReadKey();
        }

        /// <summary>
        /// ShowCoaches zwaraca dane członków
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego członka. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns>Zwraca informacje o użytkowniku</returns>
        private string ShowMembers(int i)
        {
            return $"Id: {i + 1} " + "\n" +
                   $"Imie: {_members[i].Name} " + "\n" +
                   $"Nazwisko: {_members[i].Surname} " + "\n" +
                   $"Adres: {_members[i].Address} " + "\n" +
                   $"PESEL: {_members[i].Pesel} " + "\n" +
                   $"Płeć: {_members[i].Sex} " + "\n" +
                   $"Numer członkowski: {_members[i].MemberShipNumber} " + "\n" +
                   $"{_members[i].TypeOfPerson()} posiadający karnet {_members[i].MemberShipCard}" + "\n" +
                   $"";
        }
        
        /// <summary>
        /// ReadCoachesFromFile odczytuje dane członków z pliku
        /// </summary>
        public void ReadMemberFromFile()
        {
            string[] lines = File.ReadAllLines("Members.txt");
            foreach (string word in lines)
            {
                Member newMember = new Member();
                string[] memberData = word.Split(';');
                newMember.Name = memberData[0];
                newMember.Surname = memberData[1];
                newMember.Address = memberData[2];
                newMember.Pesel = Convert.ToInt64(memberData[3]);
                newMember.Sex = memberData[4];
                _members[NumberOfMembers++] = newMember;
            }
        }
    }
}
