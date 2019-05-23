using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSMQComponent2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing users...");

            string queuePath = @".\Private$\MyNetUsers";

            EnsureQueueExists(queuePath);
            MessageQueue queue = new MessageQueue(queuePath);
            queue.Purge();
            User myUser = new User();
            Object o = new Object();
            System.Type[] arrTypes = new System.Type[2];
            arrTypes[0] = myUser.GetType();
            arrTypes[1] = o.GetType();

            queue.Formatter = new XmlMessageFormatter(arrTypes);

            while (true)
            {
                User user = (User)queue.Receive().Body;
                Console.WriteLine("I received new user: {0}, performing some action on him...", user.Name);
                Console.WriteLine();
                user.DoSth();
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
