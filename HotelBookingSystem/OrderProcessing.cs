using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/// Name:   Cory Siebler
/// ASUID:  1000832292
/// Email:  csiebler@asu.edu
/// Class:  ASU CSE 445 (#11845)
namespace HotelBookingSystem
{
    /// <summary>
    /// Creates a Thread to process the order.
    /// Returns a rate based on the following: unitPrice*NoOfRooms + Tax + LocationCharge
    /// </summary>
    class OrderProcessing
    {
        private string CC_REGEX
            = "^(?:4[0-9]{12}(?:[0-9]{3})?"         // Visa
            + "|  5[1-5][0-9]{14}"                  // MasterCard
            + "|  3[47][0-9]{13}"                   // American Express
            + "|  3(?:0[0-5]|[68][0-9])[0-9]{11}"   // Diners Club
            + "|  6(?:011|5[0-9]{2})[0-9]{12}"      // Discover
            + "|  (?:2131|1800|35\\d{3})\\d{11}"    // JCB
            + ")$";

        private OrderClass order;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        public OrderProcessing(OrderClass order)
        {
            this.Order = order;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ProcessOrder()
        {
            if (order != null)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccNum"></param>
        /// <returns></returns>
        private bool ValidateCreditCard(long ccNum)
        {
            return Regex.IsMatch(ccNum.ToString(), CC_REGEX);
        }

        /// <summary>
        /// 
        /// </summary>
        public OrderClass Order
        {
            get { return order; }
            private set { order = value; }
        }

    }
}
