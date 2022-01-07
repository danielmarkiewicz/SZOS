using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class SportsGroups : Coach
    {

        protected SportsGroups[] _sportsGroups;
        private int maxNumberOfMembersInGroup, membersInGroup;
        private short groupNumber;
        private int numberOfGroups;

        public SportsGroups()
        { }

        public SportsGroups(int sizeNumberOfGroups)
        {
            _sportsGroups = new SportsGroups[sizeNumberOfGroups];
        }
        public int MembersInGroup
        {
            get => membersInGroup;

            set
            {
                if (value > 0)
                {
                    membersInGroup = value;
                }
            }
        }

        public int MaxNumberOfMembersInGroup
        {
            get => maxNumberOfMembersInGroup;
            set
            {
                if (value != 0)
                {
                    maxNumberOfMembersInGroup = value;
                }
            }
        }

        public short GroupNumber
        {
            get => groupNumber;
            set
            {
                if (value > 0)
                {
                    groupNumber = value;
                }
            }
        }

        public int NumberOfSportsGroups
        {
            get => numberOfGroups;
            set => numberOfGroups = value;
        }

        public void CreateSportsGroup()
        {
            SportsGroups sportsGroups = new SportsGroups();
            Console.Clear();
            string sportsDiscipline;
            string licenceNumber;
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

                        _sportsGroups[numberOfGroups++] = sportsGroups;

                        Console.Write("Wpisz numer licencji wybranego trenera: ");
                        licenceNumber = Console.ReadLine();
                        for (int j = 0; i < NumberOfCoaches; i++)
                        {
                            if (licenceNumber == _coaches[j].LicenseNumber)
                            {
                                _sportsGroups[j].Name = _coaches[j].Name;
                                _sportsGroups[j].Surname = _coaches[j].Surname;
                                _sportsGroups[j].SportsDiscipline = _coaches[j].SportsDiscipline;
                                _sportsGroups[j].LicenseNumber = _coaches[j].LicenseNumber;

                                _sportsGroups[j].MembersInGroup = 0;
                                _sportsGroups[j].GroupNumber = groupNumber;
                                _sportsGroups[j].MaxNumberOfMembersInGroup = numberOfMembersInGroup;
                                Console.WriteLine(
                                    $"Trener {_sportsGroups[j].Name} {_sportsGroups[j].Surname} {_sportsGroups[j].SportsDiscipline} {_sportsGroups[j].LicenseNumber} grupa {_sportsGroups[j].GroupNumber} {_sportsGroups[j].MaxNumberOfMembersInGroup}");
                            }
                        }
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
