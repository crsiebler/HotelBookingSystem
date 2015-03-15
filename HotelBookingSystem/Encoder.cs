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
    static class Encoder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
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
