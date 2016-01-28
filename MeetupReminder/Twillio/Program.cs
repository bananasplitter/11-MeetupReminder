using MeetupRemind.core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twillio.TwilioService;

namespace Twillio
{
    public class Program
    {
        static void Main(string[] args)
        {
            SmsService.SendSms("16193136336", "18587179028");
        }
    }
}
