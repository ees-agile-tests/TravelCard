using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCard
{
    public class Station
    {
       public Zone Zone { get; set; }
        public Station(Zone zone)
        {
            Zone = zone;
        }

        public void CheckIn(Card card, Fare fare, DateTime requestDate)
        {
            if (requestDate > card.ExpirationDate)
                card.AuthorizeDebit(fare);
            else
            {
                if (Zone != card.Zone)
                    if (card.Zone == Zone.B)
                    {
                        //TO DO approved CheckIn    
                    }
            }
        }
    }
}
