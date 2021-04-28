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
            this.Zone = zone;
        }

        public void CheckIn(Card card, Fare fare, DateTime requestDate)
        {
            if (requestDate > card.ExpirationDate)
                card.AuthorizeDebit(fare);
            else
            {
                if (this.Zone == Zone.B && card.Zone == Zone.A)
                    throw new InvalidZoneException();
            }
        }
    }
}
