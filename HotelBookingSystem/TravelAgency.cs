using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// Name:   Cory Siebler
/// ASUID:  1000832292
/// Email:  csiebler@asu.edu
/// Class:  ASU CSE 445 (#11845)
namespace HotelBookingSystem
{
    class TravelAgency
    {
        private const int BASE_ROOM_ORDER = 10;
        private const int BULK_ROOM_ORDER = 25;

        private double price = PricingModel.BASE_RATE;
        private static bool hotelsActive = true;
        private static bool roomsNeeded = true;

        // Array of Credit Cards for Testing
        private long[] ccNums =
        {
            4916039504020044,   // Visa
            5106907925117390,   // Mastercard
            374951333742767,    // American Express
            36751711436416,     // Diner's Club
            6011046631647226,   // Discover
            3553991022581867    // JCB
        };

        /// <summary>
        /// 
        /// </summary>
        public static void Run()
        {
            while (hotelsActive)
            {
                if (roomsNeeded)
                {
                    CreateBaseOrder();
                    roomsNeeded = false;
                }
                else
                {
                    Thread.Sleep(10000);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        public void Subscribe(HotelSupplier hotel)
        {
            hotel.PriceCut += new HotelSupplier.PriceCutHandler(CreateBulkOrder);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateBaseOrder()
        {
            //

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="e"></param>
        private static void CreateBulkOrder(HotelSupplier hotel, PriceCutEventArgs e)
        {
            roomsNeeded = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool HotelsActive
        {
            get { return TravelAgency.hotelsActive; }
            set { TravelAgency.hotelsActive = value; }
        }
    }
}
