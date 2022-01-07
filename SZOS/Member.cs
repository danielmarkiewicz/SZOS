using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    /// <summary>
    /// Klasa Member przechowuje informacje o członkach klubu, dziedziczy podstawowe informacje po klasie Person.
    /// </summary>
    class Member : Person
    {
        protected Member[] _members;
        private Menu menu = new Menu();
        private static readonly Random getrandom = new Random();
        private int membershipNumber, _numberOfMembers;
        private short memberSportsGroup;
        private string membershipCard;
        private bool rodo;
        
        public Member()
        {
            MemberShipNumber = membershipNumber;
            MemberShipCard = membershipCard;
        }

        public Member(int sizeNumberOfMembers)
        {
            _members = new Member[sizeNumberOfMembers];
        }

        public short MemberSportsGroup
        {
            get => memberSportsGroup;
            set => memberSportsGroup = value;
        }

        public int MemberShipNumber
        {
            get => membershipNumber; 
            set => membershipNumber = GenerateMembershipNumber();
        }

        public virtual string MemberShipCard
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

        public bool Rodo
        {
            get => rodo;
            set => rodo = value;
        }

        /// <summary>
        /// GenerateMembershipNumber generuje indywidualny numer członkowski w zakresie od 10000 do 32000
        /// </summary>
        /// <returns></returns>
        public int GenerateMembershipNumber()
        {
            lock (getrandom)
            {
                return getrandom.Next(10000, 32000);
            }
        }

        public override string TypeOfPerson()
        {
            return "Członek klubu";
        }

        /// <summary>
        /// AddNewMember to metoda do dodawania nowych członków do klubu. Wykorzystuje ona klasę Member, w której jest generowany indywidualny numer członkowski.
        /// </summary>
        public override void AddNew()
        {
            Console.Clear();
            if (_numberOfMembers < _members.Length)
            {
                Member newMember = new Member();
                menu.MethodsWriteLineElementColor(new string[] { "--------------Dodawanie nowego użytkowinka-------------", "Czy osoba wyraża zgodę RODO? (ENTER = Tak, ESC = Nie): " });
                Console.CursorVisible = false;
                ConsoleKeyInfo buttonRodo = Console.ReadKey();
                Console.CursorVisible = true;
                if (buttonRodo.Key == ConsoleKey.Enter)
                {
                    newMember.Rodo = true;

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
                    _members[_numberOfMembers++] = newMember;
                }
                else if (buttonRodo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine();
                    menu.MethodsWriteLineElementColor(new string[] { "Zgoda RODO konieczna do założenia konta nowemu członkowi", "Aby powrócić do MENU naciśnij ENTER" });
                    newMember.Rodo = false;
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
        /// ShowCoaches zwaraca dane członków
        /// </summary>
        /// <param name="i">Służy do określeni id zwracanego członka. Może być wykorzystane do pętli aby wyświetlić listę, lub używając bezpośrednio paramteru w wywołaniu, aby zwrócić konkretną wartość</param>
        /// <returns>Zwraca informacje o użytkowniku</returns>
        public virtual string ShowMembers(int i)
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
    }
}
