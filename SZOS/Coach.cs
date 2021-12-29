using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    abstract class Coach : Person
    {
        private string sportsDiscipline, licenseNumber;
        private short workingTime;

        public string SportsDiscipline 
        { 
            get => sportsDiscipline;
            set
            {
                if (sportsDiscipline != null)
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
                if (licenseNumber != null)
                {
                    licenseNumber = null;
                }
            }
        }

        public short WorkingTime
        {
            get => workingTime;

            set
            {
                if (workingTime > 0)
                {
                    workingTime = value;
                }
            }
        }

        public Coach()
        { }

        public Coach(string name, string surname, string address, string sex, long pesel, string sportsDiscipline, string licenseNumber) : base(name, surname, address, sex, pesel)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Sex = sex;
            Pesel = pesel;
            SportsDiscipline = sportsDiscipline;
            LicenseNumber = licenseNumber;
        }
    }
}
