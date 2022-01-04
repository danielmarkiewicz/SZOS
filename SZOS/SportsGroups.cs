﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class SportsGroups : Coach
    {
        public Member member = new Member();
        private int maxNumberOfMembersInGroup, membersInGroup;
        private short groupNumber;

        public SportsGroups()
        { 
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

        public override string TypeOfPerson()
        {
            return "Grupa trenera ";
        }
    }
}
