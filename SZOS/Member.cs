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
        private static readonly Random getrandom = new Random();
        private int membershipNumber;
        private short memberSportsGroup;
        private string membershipCard;
        private bool rodo;

        public Member()
        {
            MemberShipNumber = membershipNumber;
            MemberShipCard = membershipCard;
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
        
    }
}
