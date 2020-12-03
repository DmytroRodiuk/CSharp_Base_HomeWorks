using System;
using System.Collections.Generic;
using System.Text;
using Lesson07_HomeWork07.Monetization.Market;
using Lesson07_HomeWork07.Monetization.PaymentProcess;

namespace Lesson07_HomeWork07.Monetization
{
    public class Account
    {
        public User Owner { get; set; }

        public PaymentInfo PaymentInfo { get; set; }
        public Transaction[] PaymentHistory { get; set; }

        public Balance Balance { get; set; }

        public MarketItem[] PurchasedItems { get; }
    }
}
