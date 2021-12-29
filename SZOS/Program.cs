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
            SZOS_Manager szosManager = new SZOS_Manager(1, 0);

            szosManager.AddNewMember();

            szosManager.ShowMembers();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
