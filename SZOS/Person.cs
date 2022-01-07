using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    /// <summary>
    /// Przechowuje informacje podstawowe o Osobie. Pozostałe klasy będą dziedziczyć po niej takie rzeczy jak Imie, Nazwisko, Adres, Płeć, PESEL.
    /// </summary>
    abstract class Person
    {
        private string name, surname, address, sex;
        private long _pesel;

        protected long Pesel
        {
            get => _pesel;
            set
            {
                _pesel = value;
            }
        }

        protected string Sex
        {
            get => sex;
            set
            {
                if (value == "M")
                {
                    sex = value;
                }
                else if (value == "K")
                {
                    sex = value;
                }
            }
        }

        protected string Address
        {
            get => address;
            set
            {
                if (value != null)
                {
                    address = value;
                }
            }
        }

        protected string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length < 40)
                {
                    name = value;
                }
            }
        }

        protected string Surname
        {
            get => surname;
            set
            {
                if (value != null && value.Length < 50)
                {
                    surname = value;
                }
            }
        }

        public abstract string TypeOfPerson();

        public abstract void AddNew();

        public abstract void Search();
    }
}
