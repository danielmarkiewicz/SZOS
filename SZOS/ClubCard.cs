namespace SZOS
{
    class ClubCard : Member
    {
        private string _typeOfCard;

        protected override string MemberShipCard
        {
            get => _typeOfCard;
             
            set
            
            {
                if (value == "1")
                {
                    _typeOfCard = "Silver";
                }
                else if (value == "2")
                {
                    _typeOfCard = "Gold";
                }
                else if (value == "3")
                {
                    _typeOfCard = "Weekend";
                }
                else if (value == "4")
                {
                    _typeOfCard = "Personal";
                }
            }
        }
    }
}
