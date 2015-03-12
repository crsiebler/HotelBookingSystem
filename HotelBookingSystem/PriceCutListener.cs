using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class PriceCutListener
    {
        private TravelAgency travelAgency;

        public PriceCutListener(TravelAgency travelAgency)
        {
            this.travelAgency = travelAgency;
            // Add "ListChanged" to the Changed event on "List":
            this.travelAgency.PriceCut += new EventHandler(PriceCut);
        }

        // This will be called whenever the list changes:
        private void PriceCut(object sender, EventArgs e)
        {
            Console.WriteLine("This is called when the event fires.");
        }

        public void Detach()
        {
            // Detach the event and delete the list:
            List.Changed -= new EventHandler(ListChanged);
            List = null;
        }
    }
}
