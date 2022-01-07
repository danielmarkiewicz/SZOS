using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class ClubCard : Member
    {
        
        private string typeOfCard;

        public override string MemberShipCard
        {
            get => typeOfCard;
             
            set
            {
                if (value == "1")
                {
                    typeOfCard = "Silver";
                }
                else if (value == "2")
                {
                    typeOfCard = "Gold";
                }
                else if (value == "3")
                {
                    typeOfCard = "Weekend";
                }
                else if (value == "4")
                {
                    typeOfCard = "Personal";
                }
            }
        }

        public override string ShowMembers(int i)
        {
            return $"Użytkownikowi {_members[i].Name} {_members[i].Surname} {_members[i].MemberShipNumber} aktywowano karnet {_members[i].MemberShipCard}";

        }
    }
}
