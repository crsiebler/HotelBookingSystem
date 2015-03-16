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
    /// Main Thread for the Hotel Booking System. Initializes the HotelSupplier threads and the TravelAgency threads. Alerts the TravelAgency
    /// threads when the HotelSupplier threads are complete. Also holds the Multi-Cell Buffer used to communicate with the HotelSupplier and the
    /// TravelAgency threads.
    /// </summary>
    public class Program
    {
        public const bool DEBUG = false;

        private const int K = 2; // Number of Hotel Suppliers
        private const int N = 5; // Number of Travel Agencies

        private static Thread[] hotelThreads = new Thread[K];
        private static Thread[] agencyThreads = new Thread[N];
        private static HotelSupplier[] hotelSuppliers = new HotelSupplier[K];

        public static MultiCellBuffer mb = new MultiCellBuffer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            // Initialize the Hotel Agencies
            for (int i = 0; i < K; ++i)
            {
                HotelSupplier hotelSupplier = new HotelSupplier();
                hotelSuppliers[i] = hotelSupplier;
                hotelThreads[i] = new Thread(hotelSupplier.Run);
                hotelThreads[i].Name = "HotelSupplier_" + i;
                hotelThreads[i].Start();
                while (!hotelThreads[i].IsAlive);
            }

            // Initialize the Travel Agencies
            for (int i = 0; i < N; ++i)
            {
                TravelAgency travelAgency = new TravelAgency();
                
                // Loop through the Hotel Suppliers and Subscribe to the Price Cut event
                for (int j= 0; j < K; ++j)
                {
                    travelAgency.Subscribe(hotelSuppliers[j]);
                }

                agencyThreads[i] = new Thread(travelAgency.Run);
                agencyThreads[i].Name = "TravelAgency_" + i;
                agencyThreads[i].Start();
                while (!agencyThreads[i].IsAlive);
            }

            // Wait for the Hotels to perform P_MAX price cuts
            for (int i = 0; i < K; ++i)
            {
                while (hotelThreads[i].IsAlive) ;
            }

            // Alert the Travel Agencies that the Hotels are no longer active
            for (int i = 0; i < N; ++i)
            {
                TravelAgency.HotelsActive = false;
            }

            // Wait for the Travel Agency to close
            for (int i = 0; i < N; ++i)
            {
                while (agencyThreads[i].IsAlive) ;
            }

            Console.WriteLine("\n\nPROGRAM COMPLETED");

            // Wait for user to hit a button
            Console.ReadKey();
        }
    }
}
