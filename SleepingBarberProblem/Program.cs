using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SleepingBarberProblem
{
    class Program
    {
        static Mutex mutex = new Mutex();

        static Semaphore barbers = new Semaphore(0, 1);

        static Semaphore waitingRoom = new Semaphore(0, 10);
        static int waitnng = 0;

        public static void Barber()
        {
            while (true)
            {

                if (waitnng == 0)
                {
                    Console.WriteLine("Golibroda śpi");
                }
                else
                {
                    Console.WriteLine("Golibroda idzie po kolejnego klienta");
                }
                waitingRoom.WaitOne();
                mutex.WaitOne();

                waitnng -= 1;
                barbers.Release();
                mutex.ReleaseMutex();
                cutChair();
                Console.WriteLine();
            }
        }

        private static void cutChair()
        {
            Console.WriteLine("Golibroda ścina włosy klienta");
            Thread.Sleep(3000);
            Console.WriteLine("Golibroda kończy scinać włosy klienta");

        }

        public static void Customer()
        {
            Console.WriteLine("Klient wchodzi do poczekalni...");

            mutex.WaitOne();
            if (waitnng < 10)
            {
                waitnng += 1;
                waitingRoom.Release(1);
                mutex.ReleaseMutex();
                Console.WriteLine("Klient siada w poczekalni...");

                barbers.WaitOne();
                getHairCut();
            }
            else
            {
                Console.WriteLine("Ups, zabrakło miejsc... Klient wychodzi");

                mutex.ReleaseMutex();
            }

            
        }

        private static void getHairCut()
        {
        }

        public static void GenerateCustomers()
        {
            foreach(var i in Enumerable.Range(0,20))
            {
                var thread = new Thread(Customer);
                thread.Start();
            }
        }

        static void Main(string[] args)
        {
            var barberThread = new Thread(Barber);
            barberThread.Start();

            Thread.Sleep(3000);
            GenerateCustomers();

            Console.ReadKey();
        }
    }
}
