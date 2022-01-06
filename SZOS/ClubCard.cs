using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class ClubCard 
    {
        private string typeOfCard;
     
        public string TypeOfCard
        {
            get => typeOfCard;

            set
            {
                if (value == "Silver")
                {
                    typeOfCard = "Silver";
                }
                else if (value == "Gold")
                {
                    typeOfCard = "Gold";
                }
                else if (value == "Weekend")
                {
                    typeOfCard = "Weekend";
                }
                else if (value == "Personal")
                {
                    typeOfCard = "Personal";
                }
            }
        }
    }
}
