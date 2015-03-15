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
    class MultiCellBuffer
    {
        // Size of the Multi-Cell Buffer
        private const int N = 3; 

        // Helpers to keep track of buffer position
        int head = 0;
        int tail = 0;
        int nElements = 0;

        // Buffer for thread communication
        string[] buffer = new string[N];

        // Semaphores to control read/write access
        Semaphore write = new Semaphore(3, 3);
        Semaphore read = new Semaphore(2, 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order">String representation of the Order from the Travel Agency</param>
        public void setOneCell(string order)
        {
            write.WaitOne();
            Console.WriteLine("Thread: " + Thread.CurrentThread.Name + " Entred Write");
            lock (this)
            {
                while (nElements == N)
                {
                    Monitor.Wait(this);
                }

                buffer[tail] = order;
                tail = (tail + 1) % N;
                Console.WriteLine("Write to the buffer: {0}, {1}, {2}", order, DateTime.Now, nElements);
                nElements++;
                Console.WriteLine("Thread: " + Thread.CurrentThread.Name + " Leaving Write");
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
            Console.WriteLine("Thread: " + Thread.CurrentThread.Name + " Entered Read");
            lock (this)
            {
                string element;

                while (nElements == 0)
                {
                    Monitor.Wait(this);
                }

                element = buffer[head];
                head = (head + 1) % N;
                nElements--;
                Console.WriteLine("Read from the buffer: {0} , {1}, {2}", element, DateTime.Now, nElements);
                Console.WriteLine("Thread: " + Thread.CurrentThread.Name + " Leaving Read");
                read.Release();
                Monitor.Pulse(this);
                return element;
            }
        }
    }
}
