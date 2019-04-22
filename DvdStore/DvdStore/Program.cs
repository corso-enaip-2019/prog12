using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdStore
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Subscriber
    {
        public string Nickname { get; }
        public string FiscalCode { get; }
        public int Subscription { get; set; }

        public Subscriber (string nickname, string fiscalCode)
        {
            Nickname = nickname;
            FiscalCode = fiscalCode;

        }
    }

    class DvdRequest
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
    }

    interface ISubscription
    {
        int Subscribe(Subscriber subscriber);
        void GetDvd(DvdRequest request);
    }


}
