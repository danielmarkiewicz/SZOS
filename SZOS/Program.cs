using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class Program
    {
        static void Main(string[] args)
        {
            SZOS_Manager szosManager = new SZOS_Manager(2, 2);
            
            szosManager.AddNewMember();
            
            szosManager.ShowMembers();
            szosManager.ShowMembers();

            szosManager.AddNewCoach();

            szosManager.ShowCoaches();

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
