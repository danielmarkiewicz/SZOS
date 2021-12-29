using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZOS
{
    class ClubCard 
    {
        public ClubCard()
        { }

        private string typeOfCard;
                
        public string TypeOfCard
        {
            get => typeOfCard;
            set
            {
                typeOfCard = value;
            }
        }

    }
}
