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
    /// <summary>
    /// The HotelSupplier uses a pricing model to calculate the room price. If the new price is lower than the previous price, it emits a
    /// (promotional) event and calls the event handlers in the travel agencies that have subscribed to the event. ⦁The HotelSupplier receives
    /// the encoded string from the MultiCellBuffer and sends the string to the Decoder for decoding. The HotelSupplier creates a new thread to
    /// process the order.
    /// </summary>
    public class HotelSupplier
    {
        private const int P_MAX = 10; // Constant for Maximum Price Cuts

        private static int p = 0; // Counter for the price cuts
        private static double currentPrice = 0.0; // Current Unit Price for the rooms
        private static double previousPrice = 0.0; // Previous Unit Price for the rooms
        private static Random random = new Random(); // Random number generator

        public delegate void PriceCutHandler(HotelSupplier sender, PriceCutEventArgs e);
        public static event PriceCutHandler PriceCut;

        /// <summary>
        /// Event fired once a PriceCut has occurred.
        /// </summary>
        private static void PriceCutEvent()
        {
            // Make sure the event is subscribed to
            if (PriceCut != null)
            {
                // Fire the PriceCut event
                Console.WriteLine("EVENT: Performing Price Cut Event");
                PriceCut(null, new PriceCutEventArgs(currentPrice));
            }
            else
            {
                Console.WriteLine("ERROR: No PriceCut event subscribers");
            }
        }

        /// <summary>
        /// Execution thread for the HotelSupplier class. Sets the price from the PricingModel, fires PriceCut events if price is lowered, and
        /// processes any orders received from the Multi-Cell buffer.
        /// </summary>
        public static void Run()
        {
            // Continue until P_MAX price cuts have been sent
            while (p < P_MAX)
            {
                // Calculate the Unit Price for rooms from the Pricing model
                SetPrice();

                // Check if the previous price was more than the current price
                if (currentPrice < previousPrice)
                {
                    // PriceCut has been made, fire the event
                    PriceCutEvent();
                }

                // Initialize the Previous Price to the Current Price
                previousPrice = currentPrice;

                // Retrieve and Process orders from the Multi-Cell buffer
                ProcessOrder(RetrieveOrder());
            }
        }

        /// <summary>
        /// Calculate the price from the PricingModel.
        /// </summary>
        private static void SetPrice()
        {
            DateTime today = DateTime.Now;
            DateTime future = today.AddDays(random.Next(1,10));

            if (Program.DEBUG) Console.WriteLine("PRICING: Starting Calculation");

            previousPrice = currentPrice;
            currentPrice = PricingModel.GetRates(random.NextDouble(), today, future);

            if (Program.DEBUG) Console.WriteLine("PRICING: Price Finalized ({0})", currentPrice.ToString("C"));
        }

        /// <summary>
        /// Collect orders from the Multi-Cell Buffer
        /// </summary>
        /// <returns></returns>
        private static OrderClass RetrieveOrder()
        {
            return Decoder.DecodeOrder(Program.mb.getOneCell());
        }

        /// <summary>
        /// Create a new thread to process the order.
        /// </summary>
        /// <param name="order"></param>
        private static void ProcessOrder(OrderClass order)
        {
            OrderProcessing processor = new OrderProcessing(order);
            Thread processingThread = new Thread(new ThreadStart(processor.ProcessOrder));
            processingThread.Start();
        }
    }
}
