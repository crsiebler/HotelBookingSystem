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
    class HotelSupplier
    {
        private const int P_MAX = 10;

        private static int p = 0;
        private static double currentPrice = 0.0;
        private static double previousPrice = 0.0;
        private static Random random = new Random();

        public delegate void MyEventHandler(object sender, MyEventArgs e)

        public event MyEventHandler MyEvent;

        public void RaisesMyEvent()
        {
           if(MyEvent != null)
           {
              MyEvent(this, new EventArgs(/*any info you want handlers to have*/));
           }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Run()
        {
            // Continue until P_MAX price cuts have been sent
            while (p < P_MAX)
            {
                SetPrice();
                ProcessOrder(RetrieveOrder());
            }
        }

        private static void SetPrice()
        {
            DateTime today = DateTime.Now;
            DateTime future = today.AddDays(random.Next(1,10));
            
            previousPrice = currentPrice;
            currentPrice = PricingModel.GetRates(random.NextDouble(), today, future);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static OrderClass RetrieveOrder()
        {
            return Decoder.DecodeOrder(Program.mb.getOneCell());
        }

        /// <summary>
        /// 
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
