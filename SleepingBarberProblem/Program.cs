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
        static void Main(string[] args)
        {

        }
    }

    public class Barber
    {
        public bool isBarberChairFree = false;
        public bool isBarberReady = true;
        public Queue<Customer> customers = new Queue<Customer>(10);

        public void work()
        {
            while(true)
            {

            }
        }

        public void CutHair()
        {
            Thread.Sleep(2000);
        }

        public void GoToSleep()
        {
            isBarberChairFree = false;
            isBarberReady = true;
        }
    }

    public class Customer
    {
        string Name { get; set; }
        Barber MyBarber { get; set; } 

        public Customer(string name, Barber barber)
        {
            Name = name;
            MyBarber = barber;
        }

        public void WakeUpBarber()
        {
            MyBarber.barberChair.WaitOne();
            MyBarber.
        }
    }


}
