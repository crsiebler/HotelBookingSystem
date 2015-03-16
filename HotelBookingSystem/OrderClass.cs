using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Order from the Travel Agency class and sent to the Hotel Suppliers through the Multi-Cell Buffer.
    /// </summary>
    public class OrderClass
    {
        private string senderId; // The identity of the sender (i.e. TravelAgency)
        private string receiverId; // The identity of the receiver (i.e. HotelSupplier)
        private long cardNo; // An integer that represents a credit card number
        private int amount; // Represents the number of rooms to order
        private DateTime dateCreated = DateTime.Now; // Time the order is placed

        /// <summary>
        /// Override method to display class fields as string.
        /// </summary>
        /// <returns>String Representation of the Order class</returns>
        public override string ToString()
        {
            return "ORDER\n\t{ID: " + SenderId
                + "}\n\t{RECEIVER_ID: " + ReceiverId
                + "}\n\t{CARD_NO: " + CardNo
                + "}\n\t{AMOUNT: " + Amount
                + "}\n\t{CREATED: " + DateCreated.ToString("d", CultureInfo.InvariantCulture) + "}";
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public long CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
