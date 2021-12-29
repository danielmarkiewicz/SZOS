using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{ 
    /// <summary>
    /// Klasa, w której będzie umieszczony cały kod startowy i UI. W klasi program tylko bedzie odpalona metoda run tej klasy
    /// </summary>
    class SZOS_Manager
    {
        private Member[] _members;
        private int _numberOfMembers;

        public SZOS_Manager(int sizeNumberOfMembers, int sizeNumberOfCoach )
        {
            _members = new Member[sizeNumberOfMembers];
        }
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
                newMember.Addres = Console.ReadLine();
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
            foreach (var member in _members)
            {
                Console.WriteLine(_members);
            }
        }
    }
}
