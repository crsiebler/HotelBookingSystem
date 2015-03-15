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
    /// <summary>
    /// 
    /// </summary>
    static class PricingModel
    {
        public const double BASE_RATE = 85.0; // Standard Rate 

        private const int LOW_SPAN = 2; // 2 Day Stay
        private const int MED_SPAN = 4; // 4 Day Stay
        private const int HIGH_SPAN = 7; // 7 Day Stay
        private const double LOW_OCCUPANCY = .40; // 40% Not Vacant
        private const double MED_OCCUPANCY = .65; // 65% Not Vacant
        private const double HIGH_OCCUPANCY = .90; // 90% Not Vacant

        private const double LOW_SPAN_ADJUST = 1.25; // 25% Markup
        private const double MED_SPAN_ADJUST = 1.0; // Full Price
        private const double HIGH_SPAN_ADJUST = .75; // 25% Rebate
        private const double MAX_SPAN_ADJUST = .5; // 50% Rebate

        private const double LOW_OCCUPANCY_ADJUST = 0.5; // 50% Rebate
        private const double MED_OCCUPANCY_ADJUST = 1.0; // Full Price
        private const double HIGH_OCCUPANCY_ADJUST = 1.5; // 50% Markup
        private const double MAX_OCCUPANCY_ADJUST = 2.0; // 100% Markup

        /// <summary>
        /// 
        /// </summary>
        /// <param name="occupancy"></param>
        /// <param name="checkIn"></param>
        /// <param name="checkOut"></param>
        /// <returns></returns>
        public static double GetRates(double occupancy, DateTime checkIn, DateTime checkOut)
        {
            TimeSpan span = checkOut - checkIn;

            return BASE_RATE * AdjustForSpan(span) * AdjustForOccupancy(occupancy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="span"></param>
        /// <returns></returns>
        private static double AdjustForSpan(TimeSpan span)
        {
            if (span.TotalDays < LOW_SPAN)
            {
                return LOW_SPAN_ADJUST;
            }
            else if (span.TotalDays < MED_SPAN)
            {
                return MED_SPAN_ADJUST;
            }
            else if (span.TotalDays < HIGH_SPAN)
            {
                return HIGH_SPAN_ADJUST;
            }
            else
            {
                return MAX_SPAN_ADJUST;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="occupancy"></param>
        /// <returns></returns>
        private static double AdjustForOccupancy(double occupancy)
        {
            if (occupancy < LOW_OCCUPANCY)
            {
                return LOW_OCCUPANCY_ADJUST;
            }
            else if (occupancy < MED_OCCUPANCY)
            {
                return MED_OCCUPANCY_ADJUST;
            }
            else if (occupancy < HIGH_OCCUPANCY)
            {
                return HIGH_OCCUPANCY_ADJUST;
            }
            else
            {
                return MAX_OCCUPANCY_ADJUST;
            }
        }
    }
}
