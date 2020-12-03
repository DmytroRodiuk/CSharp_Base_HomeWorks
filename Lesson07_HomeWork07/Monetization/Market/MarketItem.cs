using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson07_HomeWork07.Monetization.Market
{
    public class MarketItem
    {
        public int Price { get; set; }
        public bool IsDiscount { get; } = true;
        public int ItemType { get; }
    }
}
