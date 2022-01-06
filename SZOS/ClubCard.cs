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
    }
}
