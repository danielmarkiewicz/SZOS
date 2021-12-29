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
        private short membershipNumber;
        private string idNumber;
        private bool rodo;

        public Member(): base()
        {
            TypeOfPerson();
        }
        public Member(string name, string surname, string addres, string sex, long pesel) : base(name, surname, addres, sex, pesel)
        {
            Name = name;
            Surname = surname;
            Address = addres;
            Sex = sex;
            Pesel = pesel;
            MemberShipNumber = membershipNumber;
            TypeOfPerson();
        }

        public short MemberShipNumber
        {
            get => membershipNumber; 
            set => membershipNumber = value;
        }

        public override string TypeOfPerson()
        {
            return "Członek klubu";
        }
    }
}
