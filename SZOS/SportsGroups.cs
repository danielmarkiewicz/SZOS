using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class SportsGroups : Coach
    {
        private int numberOfMembersInGroup;
        private short groupNumber;

        public SportsGroups()
        { 
        }

        public int NumberOfMembersInGroup
        {
            get => numberOfMembersInGroup;
            set
            {
                if (value != 0)
                {
                    numberOfMembersInGroup = value;
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
    }
}
