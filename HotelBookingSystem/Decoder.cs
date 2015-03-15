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
    /// 
    /// </summary>
    static class Decoder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encodedOrder"></param>
        /// <returns></returns>
        public static OrderClass DecodeOrder(string encodedOrder)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(OrderClass));

            using (TextReader tr = new StringReader(encodedOrder))
            {
                return (OrderClass) deserializer.Deserialize(tr);
            }
        }
    }
}
