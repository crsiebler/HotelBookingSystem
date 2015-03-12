using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Name:   Cory Siebler
/// ASUID:  1000832292
/// Email:  csiebler@asu.edu
/// Class:  ASU CSE 445 (#11845)
namespace HotelBookingSystem
{
    class TravelAgency
    {
        public event EventHandler PriceCut;

        private double price;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPriceCut(EventArgs e)
        {
            if (PriceCut != null)
                PriceCut(this, e);
        }

        public double Price
        {
            get { return price; }
            set
            {
                OnPriceCut(EventArgs.Empty);
                price = value; 
            }
        }

    }
}
