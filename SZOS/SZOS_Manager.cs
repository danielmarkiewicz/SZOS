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
        private int _numberOfMembers = 1;

        /// <summary>
        /// Konstruktor klasy SZOS_Manager, przyjmuje on póki co dwa parametry, maksymalną liczbę członków klubu, oraz maksymalną liczbę trenerów. 
        /// </summary>
        /// <param name="sizeNumberOfMembers">Maksymalna liczba członków klubu</param>
        /// <param name="sizeNumberOfCoach">Maksymalna liczba trenerów/instruktorów w klubie</param>
        public SZOS_Manager(int sizeNumberOfMembers, int sizeNumberOfCoach )
        {
            _members = new Member[sizeNumberOfMembers];
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

        public void ShowMembers()
        {
            for (int i = 1; i < _members.Length; i++)
            {
                Console.WriteLine($"{i} {_members[i].Name} {_members[i].Surname} {_members[i].Address} {_members[i].Pesel} {_members[i].Sex}");
            }
        }
    }
}
