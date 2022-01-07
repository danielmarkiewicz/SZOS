using System;
using System.Collections.Generic;
using System.IO;
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
        protected Coach[] _coaches;
        private Menu menu = new Menu();
        private SportsGroups sportsGroups = new SportsGroups();
        private string sportsDiscipline, licenseNumber;
        private protected decimal hourlyRate;
        protected int NumberOfCoaches { get; set; }

        public Coach()
        {
        }

        public Coach(int sizeNumberOfCoach)
        {
            _coaches = new Coach[sizeNumberOfCoach];
        }

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

        /// <summary>
        /// AddNewCoach to metoda do dodawania nowych trenerów/instruktorów do klubu. Wykorzystuje ona klasę Coach, która dziedzieczy po Person. Wewnątrz Coach przechowywane sa dane szczególowe o trenerze/instruktorze
        /// </summary>
        public override void AddNew()
        {
            Console.Clear();
            if (NumberOfCoaches < _coaches.Length)
            {
                menu.MethodsWriteLineElementColor(new string[] { "Dodawanie nowego trenera/instruktora", "Wypełnij następujące pola: " });
                Coach newCoach = new Coach();
                Console.Write("Imie: ");
                newCoach.Name = Console.ReadLine();
                Console.Write("Nazwisko: ");
                newCoach.Surname = Console.ReadLine();
                Console.Write("Adres ");
                newCoach.Address = Console.ReadLine();
                Console.Write("PESEL: ");
                newCoach.Pesel = Convert.ToInt64(Console.ReadLine());
                Console.Write("Płeć(M/K): ");
                newCoach.Sex = Console.ReadLine();
                Console.Write("Dyscyplina: ");
                newCoach.SportsDiscipline = Console.ReadLine();
                Console.Write("Numer licencji: ");
                newCoach.LicenseNumber = Console.ReadLine();
                Console.Write("Stawka za godzinę zajęć: ");
                newCoach.HourlyRate = Convert.ToDecimal(Console.ReadLine());

                _coaches[NumberOfCoaches++] = newCoach;

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
                Console.ReadKey();
            }
            else
            {
                menu.MethodsWriteLineElementColor(new string[] { "Brak miejsc w klubie", "Aby powrócić do MENU naciśnij ENTER" });
            }
            Console.ReadKey();
        }

        public string ShowCoaches(int i)
        {
            return $"Id: {i + 1} " + "\n" +
                   $"Imie: {_coaches[i].Name} " + "\n" +
                   $"Nazwisko: {_coaches[i].Surname} " + "\n" +
                   $"Adres: {_coaches[i].Address} " + "\n" +
                   $"PESEL: {_coaches[i].Pesel} " + "\n" +
                   $"Płeć: {_coaches[i].Sex} " + "\n" +
                   $"Numer członkowski: {_coaches[i].LicenseNumber} " + "\n" +
                   $"{_coaches[i].TypeOfPerson()}. Stawka za godzinę zajęć: {_coaches[i].HourlyRate}" + "\n" +
                   $"";
        }

        public override void Search()
        {
            string name, surname;
            Console.Clear();
            Console.WriteLine("------------------Wyszukiawrka trenerów/instruktorów------------------");
            if (NumberOfCoaches != 0)
            {
                Console.Write("Wpisz imie trenera/instruktora lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz trenera/instruktora osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista trenerów/instruktorów: ");
                for (int i = 0; i < NumberOfCoaches; i++)
                {
                    if (name == _coaches[i].Name && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == _coaches[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == "" && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                    }
                }

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak trenerów/instruktorów w bazie danych.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }

            Console.ReadKey();
        }

        public void ReadCoachesFromFile()
        {
            string[] lines = File.ReadAllLines("Coaches.txt");
            foreach (string word in lines)
            {
                Coach newCoach = new Coach();
                string[] memberData = word.Split(';');
                newCoach.Name = memberData[0];
                newCoach.Surname = memberData[1];
                newCoach.Address = memberData[2];
                newCoach.Pesel = Convert.ToInt64(memberData[3]);
                newCoach.Sex = memberData[4];
                newCoach.SportsDiscipline = memberData[5];
                newCoach.LicenseNumber = memberData[6];
                newCoach.HourlyRate = Convert.ToInt64(memberData[7]);
                _coaches[NumberOfCoaches++] = newCoach;
            }
        }

        public void CreateSportsGroup()
        {
            Console.Clear();
            string sportsDiscipline;
            string licenceNumber;
            int numberOfGroups = 0;
            if (NumberOfCoaches != 0)
            {
                for (int i = 0; i < NumberOfCoaches; i++)
                {

                    if (_coaches[i] != null)
                    {

                        Console.Write("Wpisz dyscyplinę sportową grupy: ");
                        sportsDiscipline = Console.ReadLine();

                        Console.Write("Wpisz numer grupy: ");
                        short groupNumber = Convert.ToInt16(Console.ReadLine());
                        sportsGroups.GroupNumber = groupNumber;

                        Console.Write("Wpisz maksymalna liczbe osób w gupie: ");
                        var numberOfMembersInGroup = Convert.ToInt32(Console.ReadLine());
                        sportsGroups.MaxNumberOfMembersInGroup = numberOfMembersInGroup;

                        Console.WriteLine($"Trenerzy/instruktorzy dyscypliny {sportsDiscipline}: ");

                        if (sportsDiscipline == _coaches[i].SportsDiscipline)
                        {
                            Console.WriteLine(ShowCoaches(i));
                        }

                        //numberOfGroups = sportsGroups.NumberOfSportsGroups++;
                        //sportsGroups[numberOfGroups] = sportsGroups;

                        //Console.Write("Wpisz numer licencji wybranego trenera: ");
                        //licenceNumber = Console.ReadLine();
                        //for (int j = 0; i < NumberOfCoaches; i++)
                        //{
                        //    if (licenceNumber == _coaches[j].LicenseNumber)
                        //    {
                        //        sportsGroups[j].Name = _coaches[j].Name;
                        //        sportsGroups[j].Surname = _coaches[j].Surname;
                        //        sportsGroups[j].SportsDiscipline = _coaches[j].SportsDiscipline;
                        //        sportsGroups[j].LicenseNumber = _coaches[j].LicenseNumber;

                        //        _sportsGroups[j].MembersInGroup = 0;
                        //        _sportsGroups[j].GroupNumber = groupNumber;
                        //        _sportsGroups[j].MaxNumberOfMembersInGroup = numberOfMembersInGroup;
                        //        Console.WriteLine(
                        //            $"Trener {_sportsGroups[j].Name} {_sportsGroups[j].Surname} {_sportsGroups[j].SportsDiscipline} {_sportsGroups[j].LicenseNumber} grupa {_sportsGroups[j].GroupNumber} {_sportsGroups[j].MaxNumberOfMembersInGroup}");
                        //    }
                        //}
                    }
                    else
                    {
                        Console.WriteLine("Brak trenerów/instruktorów w bazie danych klubu");
                        break;
                    }
                }

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            else
            {
                Console.WriteLine("Brak osób i trenerów w bazie danych, nie można utworzyć grupy.");
                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
            }
            Console.ReadKey();
        }
    }
}
