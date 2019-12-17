using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.SOLID
{
    class SMS
    {
        public string Number { get; set; }
        public string Content { get; set; }

        public void SendSMS()
        {
            Console.WriteLine("Sending SMS...");
        }
    }

    class MMS
    {
        public string Number { get; set; }
        public byte[] Content { get; set; }

        public void SendMMS()
        {
            Console.WriteLine("Sending MMS...");
        }
    }

    class Mail
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public void SendMail()
        {
            Console.WriteLine("Sending Mail...");
        }
    }

    class Messenger
    {
        public SMS SMS { get; set; }
        public MMS MMS { get; set; }
        public Mail Mail { get; set; }


        public void SendMessage()
        {
            SMS.SendSMS();
            MMS.SendMMS();
            Mail.SendMail();
        }

    }
}
