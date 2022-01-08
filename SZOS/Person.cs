namespace SZOS
{
    /// <summary>
    /// Przechowuje informacje podstawowe o Osobie. Pozostałe klasy będą dziedziczyć po niej takie rzeczy jak Imie, Nazwisko, Adres, Płeć, PESEL.
    /// </summary>
    abstract class Person
    {
        private string _name, _surname, _address, _sex;
        private long _pesel;

        protected long Pesel
        {
            get => _pesel;
            set
            {
                if(value > 0)
                {
                    _pesel = value;
                }
            }
        }

        protected string Sex
        {
            get => _sex;
            set
            {
                if (value == "M")
                {
                    _sex = value;
                }
                else if (value == "K")
                {
                    _sex = value;
                }
            }
        }

        protected string Address
        {
            get => _address;
            set
            {
                if (value != null)
                {
                    _address = value;
                }
            }
        }

        protected string Name
        {
            get => _name;
            set
            {
                if (value != null && value.Length < 40)
                {
                    _name = value;
                }
            }
        }

        protected string Surname
        {
            get => _surname;
            set
            {
                if (value != null && value.Length < 50)
                {
                    _surname = value;
                }
            }
        }

        public abstract string TypeOfPerson();

        public abstract void AddNew();

        public abstract void Search();
    }
}
