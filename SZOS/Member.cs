using System;
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
        private static readonly Random getrandom = new Random();
        private int membershipNumber;
        private string idNumber;
        private bool rodo;

        public Member()
        {
            MemberShipNumber = membershipNumber;
        }
        // public Member(string name, string surname, string address, string sex, long pesel) : base(name, surname, address, sex, pesel)
        // {
        //     Name = name;
        //     Surname = surname;
        //     Address = address;
        //     Sex = sex;
        //     Pesel = pesel;
        //     MemberShipNumber = membershipNumber;
        //     TypeOfPerson();
        // }

        public int MemberShipNumber
        {
            get => membershipNumber; 
            set => membershipNumber = GenerateMembershipNumber();
        }

        public int GenerateMembershipNumber()
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(10000, 32000);
            }
        }
    

        public override string TypeOfPerson()
        {
            return "Członek klubu";
        }
    }
}
