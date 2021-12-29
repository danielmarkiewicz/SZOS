using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class Member : Person
    {
        private short membershipNumber;

        public Member():base()
        {
            TypeOfPerson();
        }
        public Member(string name, string surname, string addres, string sex) : base(name, surname, addres, sex)
        {
            Name = name;
            Surname = surname;
            Addres = addres;
            Sex = sex;
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
            return "Użytkownik";
        }
    }
}
