using System;
using System.Collections.Generic;
using System.Linq;
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
        private int _numberOfMembers = 1;
        private int _numberOfCoaches = 1;

        /// <summary>
        /// Konstruktor klasy SZOS_Manager, przyjmuje on póki co dwa parametry, maksymalną liczbę członków klubu, oraz maksymalną liczbę trenerów. 
        /// </summary>
        /// <param name="sizeNumberOfMembers">Maksymalna liczba członków klubu. Numeracja członków zaczyna się od 1, dlatego aby system mógł ich przyjąć np.: 100 parametr musi wynosić 101</param>
        /// <param name="sizeNumberOfCoach">Maksymalna liczba trenerów/instruktorów w klubie. Numeracja treneró zaczyna się od 1, dlatego aby system mógł ich przyjąć np.: 100 parametr musi wynosić 101</param>
        public SZOS_Manager(int sizeNumberOfMembers, int sizeNumberOfCoach )
        {
            _members = new Member[sizeNumberOfMembers];
            _coaches = new Coach[sizeNumberOfCoach];
        }

        /// <summary>
        /// AddNewMember to metoda do dodawania nowych członków do klubu. Wykorzystuje ona klasę Member, w której jest generowany indywidualny numer członkowski.
        /// </summary>
        public void AddNewMember()
        {
            if (_numberOfMembers < _members.Length)
            {
                Member newMember = new Member();
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
            else
            {
                
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
                
            }
        }

        /// <summary>
        /// ShowMembers wyświetla wszystkich członków zapisanych do klubu
        /// </summary>
        public void ShowMembers()
        {
            for (int i = 1; i < _members.Length; i++)
            {
                Console.WriteLine($"{i} {_members[i].Name} {_members[i].Surname} {_members[i].Address} {_members[i].Pesel} {_members[i].Sex} {_members[i].MemberShipNumber} {_members[i].TypeOfPerson()}");
            }
        }

        /// <summary>
        /// ShowCoaches wyświetla wszystkich trenerów/instruktorów w klubie
        /// </summary>
        public void ShowCoaches()
        {
            for (int i = 1; i < _coaches.Length; i++)
            {
                Console.WriteLine($"{i} {_coaches[i].Name} {_coaches[i].Surname} {_coaches[i].Address} {_coaches[i].Pesel} {_coaches[i].Sex} {_coaches[i].SportsDiscipline} {_coaches[i].LicenseNumber} {_coaches[i].HourlyRate} {_coaches[i].TypeOfPerson()}");
            }
        }
    }
}
