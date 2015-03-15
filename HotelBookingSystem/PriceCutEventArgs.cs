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
    /// <summary>
    /// 
    /// </summary>
    class PriceCutEventArgs : EventArgs
    {
        private double price;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        public PriceCutEventArgs(double price)
        {
            this.Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }
    }
}
