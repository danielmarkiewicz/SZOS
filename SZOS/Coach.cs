﻿using System;
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
        private Coach[] _coaches;
        private Menu menu = new Menu();
        private string sportsDiscipline, licenseNumber;
        private protected decimal hourlyRate;
        private int _numberOfCoaches = 0;

        public Coach()
        {
        }
        public Coach(int sizeNumberOfCoach)
        {
            _coaches = new Coach[_numberOfCoaches];
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
            if (_numberOfCoaches < _coaches.Length)
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

                _coaches[_numberOfCoaches++] = newCoach;

                Console.WriteLine("Aby powrócić do MENU naciśnij ENTER");
                Console.ReadKey();
            }
            else
            {
                menu.MethodsWriteLineElementColor(new string[] { "Brak miejsc w klubie", "Aby powrócić do MENU naciśnij ENTER" });
            }
            Console.ReadKey();
        }

        public virtual string ShowCoaches(int i)
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
            if (_numberOfCoaches != 0)
            {
                Console.Write("Wpisz imie trenera/instruktora lub pozostaw puste zatwierdzając ENTER: ");
                name = Console.ReadLine();
                Console.Write("Wpisz trenera/instruktora osoby lub pozostaw puste zatwierdzając ENTER: ");
                surname = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Lista trenerów/instruktorów: ");
                for (int i = 0; i < _numberOfCoaches; i++)
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
    }
}
