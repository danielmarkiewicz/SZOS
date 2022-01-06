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

        public override string TypeOfPerson()
        {
            return $"Trener/Instruktor dyscypliny {SportsDiscipline}";
        }

        public virtual string CoachGroup()
        {
            return "Trener/instruktor prowadzi zajęcia dla grup: ";
        }
    }
}
