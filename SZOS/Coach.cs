using System;
using System.IO;

namespace SZOS
{
    /// <summary>
    /// Klasa Coach przechowuje informacje o członkach klubu, dziedziczy podstawowe informacje po klasie Person.
    /// </summary>
    class Coach : Person
    {
        private Coach[] _coaches;
        private Menu menu = new Menu();

        private string _sportsDiscipline, _licenseNumber;
        private decimal _hourlyRate;

        private Coach()
        {
        }

        public Coach(int sizeNumberOfCoach)
        {
            _coaches = new Coach[sizeNumberOfCoach];
        }

        ~Coach()
        {
            File.Copy("Coaches.txt", $"Coaches_backup.txt", true);
        }

        private int NumberOfCoaches { get; set; }

        private string SportsDiscipline
        {
            get => _sportsDiscipline;
            set
            {
                if (value != null)
                {
                    _sportsDiscipline = value;
                }
            }
        }

        private string LicenseNumber
        {
            get => _licenseNumber;

            set
            {
                if (value != null)
                {
                    _licenseNumber = value;
                }
            }
        }

        private decimal HourlyRate
        {
            get => _hourlyRate;

            set
            {
                if (value > 0)
                {
                    _hourlyRate = value;
                }
            }
        }

        /// <summary>
        /// Implemntacja abstrakcyjnej metody TypeOfPerson.
        /// </summary>
        /// <returns>Zwraca rodzaj osoby</returns>
        public override string TypeOfPerson()
        {
            return $"Trener/Instruktor dyscypliny {SportsDiscipline}";
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
                Console.Write("Adres: ");
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
                File.AppendAllText("Coaches.txt", $"\n{newCoach.Name};{newCoach.Surname};{newCoach.Address};{newCoach.Pesel};{newCoach.Sex};{newCoach.SportsDiscipline};{newCoach.LicenseNumber};{newCoach.HourlyRate}");

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

        /// <summary>
        /// ShowCoaches służy do wyświetlania informacji o trenerach/instruktorach
        /// </summary>
        /// <param name="i">Określa, który rekord ma być wyświetlony</param>
        /// <returns>Informacje o trenerze/instruktorze</returns>
        private string ShowCoaches(int i)
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

        /// <summary>
        /// Implementacja abstrakcyjnej metody Search. Służy do wyszukiwania trenerów/instruktorów.
        /// </summary>
        public override void Search()
        {
            string name, surname;
            Console.Clear();
            menu.MethodsWriteLineElementColor(new string[] {"------------------Wyszukiawrka trenerów/instruktorów------------------"});
            if (NumberOfCoaches != 0)
            {
                Console.Write("Wpisz imie trenera/instruktora lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz nazwisko trenera/instruktora lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista trenerów/instruktorów: ");
                for (int i = 0; i < NumberOfCoaches; i++)
                {
                    if (name == _coaches[i].Name && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == _coaches[i].Name && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == "" && surname == _coaches[i].Surname)
                    {
                        Console.WriteLine(ShowCoaches(i));
                        Console.WriteLine("-------------------------------------------------------------------");
                    }
                    else if (name == "" && surname == "")
                    {
                        Console.WriteLine(ShowCoaches(i));
                        Console.WriteLine("-------------------------------------------------------------------");
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

        /// <summary>
        /// ReadCoachesFromFile odczytuje dane trenerów/instruktorów z pliku
        /// </summary>
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
    }
}
