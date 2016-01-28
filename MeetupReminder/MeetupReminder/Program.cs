using MeetupRemind.core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the group you want to see meetups for");
            string groupname = Console.ReadLine();

            var meetups = MeetupService.GetMeetupsFor(groupname).Result;

            Console.ReadLine();
        }
    }
}
