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
        private string receiverId; // The identity of the receiver
        private int cardNo; // An integer that represents a credit card number
        private int amount; // Represents the number of rooms to order

        public string SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        public string ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }

        public int CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
