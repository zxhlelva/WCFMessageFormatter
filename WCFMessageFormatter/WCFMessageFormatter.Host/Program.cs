using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WCFMessageFormatter.Services;

namespace WCFMessageFormatter.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(TankService)))
            {
                host.Open();
                Console.WriteLine("Service is running");
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
                host.Close();
            }
        }

        public class  Test
        {
            public Test(string p1)
            {
                this.P1 = p1;
            }

            public string P1 { get; set; }

            public string P2 { get; set; }
        }
    }
}
