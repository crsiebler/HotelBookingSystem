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
    class OrderClass
    {
        private string senderId; // The identity of the sender
        private int cardNo; // An integer that represents a credit card number
        private int amount; // Represents the number of rooms to order

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ORDER {ID: " + senderId + "} {CARD_NO: " + cardNo + "} {AMOUNT: " + amount + "}";
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
        public int CardNo
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
