using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSMQComponent1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing users...");

            string queuePath = @".\Private$\MyNetUsers";
            EnsureQueueExists(queuePath);
            MessageQueue queue = new MessageQueue(queuePath);
            while(true)
            {
                foreach (int iterator in Enumerable.Range(1, 10))
                {
                    User user = new User
                    {
                        Name = String.Format("Tomek{0}", iterator),
                        Email = String.Format("Tomek{0}@ha.co", iterator)
                    };

                    Console.WriteLine("Sending user {0}", iterator);
                    Message msg = new Message();
                    msg.Body = user;
                    queue.Send(msg);
                }
                Thread.Sleep(40000);

            }

        }

        // Creates the queue if it does not already exist.
        public static void EnsureQueueExists(string path)
        {
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path);
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public void DoSth()
        {
            Console.WriteLine("user data: ");
            Console.WriteLine(Name + " " + Email);
            Console.WriteLine();

            Thread.Sleep(3000);
        }
    }
}
