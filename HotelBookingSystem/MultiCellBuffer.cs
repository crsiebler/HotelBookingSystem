using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// Name:   Cory Siebler
/// ASUID:  1000832292
/// Email:  csiebler@asu.edu
/// Class:  ASU CSE 445 (#11845)
namespace HotelBookingSystem
{
    /// <summary>
    /// Synchronization for the communication between the Travel Agency Threads and the Hotel Supplier Threads.
    /// Utilizes a buffer of N size to store the order information as a string. The Travel Agency (Producer)is responsible for encoding the 
    /// string while the Hotel Supplier (Consumer) is responsible for decoding the string.
    /// </summary>
    public class MultiCellBuffer
    {
        // Size of the Multi-Cell Buffer
        private const int N = 3;
        private const int WRITE_RESOURCES = 1;
        private const int READ_RESOURCES = 2;

        // Helpers to keep track of buffer position
        int head = 0;
        int tail = 0;
        int nElements = 0;

        // Buffer for thread communication
        string[] buffer = new string[N];

        // Semaphores to control read/write access
        Semaphore write = new Semaphore(WRITE_RESOURCES, WRITE_RESOURCES);
        Semaphore read = new Semaphore(READ_RESOURCES, READ_RESOURCES);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">String representation of the Order from the Travel Agency</param>
        public void setOneCell(string order)
        {
            write.WaitOne();
            Console.WriteLine("THREAD: " + Thread.CurrentThread.Name + " Entered Write");
            lock (this)
            {
                while (nElements == N)
                {
                    if (Program.DEBUG) Console.WriteLine("MONITOR: Write Waiting {0}", Thread.CurrentThread.Name);
                    Monitor.Wait(this);
                }

                buffer[tail] = order;
                tail = (tail + 1) % N;
                Console.WriteLine("WRITING: ({0}) Multi-Cell Buffer\n\n{1}\n{2}, Elements: {3}\n",
                    Thread.CurrentThread.Name,
                    order,
                    DateTime.Now,
                    nElements
                );
                nElements++;
                Console.WriteLine("THREAD: ({0}) Leaving Write", Thread.CurrentThread.Name);
                write.Release();
                Monitor.Pulse(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getOneCell()
        {
            read.WaitOne();
            Console.WriteLine("THREAD: " + Thread.CurrentThread.Name + " Entered Read");
            lock (this)
            {
                string element;

                while (nElements == 0)
                {
                    if (Program.DEBUG) Console.WriteLine("MONITOR: Read Waiting {0}", Thread.CurrentThread.Name);
                    Monitor.Wait(this);
                }

                element = buffer[head];
                head = (head + 1) % N;
                nElements--;
                Console.WriteLine("READING: ({0}) Multi-Cell Buffer\n\n{1}\n{2}, Elements: {3}\n", 
                    Thread.CurrentThread.Name,
                    element, 
                    DateTime.Now,
                    nElements
                );
                Console.WriteLine("THREAD: ({0}) Leaving Read", Thread.CurrentThread.Name);
                read.Release();
                Monitor.Pulse(this);
                return element;
            }
        }
    }
}
