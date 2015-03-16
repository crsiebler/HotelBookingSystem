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
    /// Custom class that derives EventArgs. Adds the Price and Id fields to pass to the TravelAgency.
    /// </summary>
    public class PriceCutEventArgs : EventArgs
    {
        private double price;
        private string id;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        public PriceCutEventArgs(string id, double price)
        {
            this.Id = id;
            this.Price = price;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
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
