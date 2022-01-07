﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class SportsGroups : Coach
    {
        private int maxNumberOfMembersInGroup, membersInGroup;
        private short groupNumber;
        private int numberOfGroups;

        private SportsGroups[] _sportsGroups;
        
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
    }
}
