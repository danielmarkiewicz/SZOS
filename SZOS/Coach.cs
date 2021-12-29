using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    /// <summary>
    /// Klasa Coach przechowuje informacje o członkach klubu, dziedziczy podstawowe informacje po klasie Person.
    /// </summary>
    class Coach : Person
    {
        private string sportsDiscipline, licenseNumber;
        private short workingTime;
        private protected decimal hourlyRate;

        public string SportsDiscipline 
        { 
            get => sportsDiscipline;
            set
            {
                if (value != null)
                {
                    sportsDiscipline = value;
                }
            }
        }

        public string LicenseNumber
        {
            get => licenseNumber;

            set
            {
                if (value != null)
                {
                    licenseNumber = value;
                }
            }
        }

        public short WorkingTime
        {
            get => workingTime;

            set
            {
                if (value > 0)
                {
                    workingTime = value;
                }
            }
        }

        public decimal HourlyRate
        {
            get => hourlyRate;

            set
            {
                if (value > 0)
                {
                    hourlyRate = value;
                }
            }
        }

        public Coach()
        {}

        // public Coach(string name, string surname, string address, string sex, long pesel, string sportsDiscipline, string licenseNumber, decimal hourlyRate) : base(name, surname, address, sex, pesel)
        // {
        //     Name = name;
        //     Surname = surname;
        //     Address = address;
        //     Sex = sex;
        //     Pesel = pesel;
        //     SportsDiscipline = sportsDiscipline;
        //     LicenseNumber = licenseNumber;
        //     HourlyRate = hourlyRate;
        //     TypeOfPerson();
        // }

        public override string TypeOfPerson()
        {
            return $"Trener/Instruktor dyscypliny {SportsDiscipline}";
        }
    }
}
