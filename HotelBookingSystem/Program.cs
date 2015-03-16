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
    /// 
    /// </summary>
    public class Program
    {
        public const bool DEBUG = true;

        private const int K = 2; // Number of Hotel Suppliers
        private const int N = 5; // Number of Travel Agencies

        private static Thread[] hotelThreads = new Thread[K];
        private static Thread[] agencyThreads = new Thread[N];

        public static MultiCellBuffer mb = new MultiCellBuffer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Initialize the Hotel Agencies
            for (int i = 0; i < K; ++i)
            {
                hotelThreads[i] = new Thread(HotelSupplier.Run);
                hotelThreads[i].Start();
                while (!hotelThreads[i].IsAlive);
            }

            // Initialize the Travel Agencies
            for (int i = 0; i < N; ++i)
            {
                agencyThreads[i] = new Thread(TravelAgency.Run);
                agencyThreads[i].Start();
                while (!agencyThreads[i].IsAlive);
            }

            // Block the main thread execution
            for (int i = 0; i < K; i++)
            {
                hotelThreads[i].Join();
            }

            // Block the main thread execution
            for (int i = 0; i < N; i++)
            {
                agencyThreads[i].Join();
            }

            // Wait for the Hotels to perform P_MAX price cuts
            for (int i = 0; i < K; ++i)
            {
                while (hotelThreads[i].IsAlive);
            }

            // Alert the Travel Agencies that the Hotels are no longer active
            for (int i = 0; i < N; ++i)
            {
                TravelAgency.HotelsActive = false;
            }

            // Wait for user to hit a button
            Console.ReadKey();
        }
    }
}
