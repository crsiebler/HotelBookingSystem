using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// Name:   Cory Siebler
/// ASUID:  1000832292
/// Email:  csiebler@asu.edu
/// Class:  ASU CSE 445 (#11845)
namespace HotelBookingSystem
{
    /// <summary>
    /// The Encoder converts the Order object into a string and sends the encoded string back to the caller. 
    /// </summary>
    public static class Encoder
    {
        /// <summary>
        /// Utilizes XmlSerializer to encode the OrderClass into a string.
        /// </summary>
        /// <param name="order">OrderClass created by the TravelAgency</param>
        /// <returns>String representation of the Order from the Travel Agency</returns>
        public static string EncodeOrder(OrderClass order)
        {
            XmlSerializer serializer = new XmlSerializer(order.GetType());

            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, order);
                return sw.ToString();
            }
        }
    }
}
