using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Twillio.TwilioService
{
    public class SmsService
    {
        public static void Call(string message)
        {
        private const string TwilioAccountSid = "AC19b97b02a8a77263b285300901d59a5d";
        private const string TwilioAuthToken = "c2762364d916d8a7387e4fd47c57ae26";
        private const string FromNumber = "+16193136336";
        private const string To = "+185871790528";

        
            var twilio = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);
            twilio.SendSmsMessage(FromNumber, to, message);
        
        }
    }
}
