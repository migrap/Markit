using System;

namespace Markit.Models {
    public class Quote {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double LastPrice { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public double MarketCap { get; set; }
        public long Volume { get; set; }
        public double ChangeYtd { get; set; }
        public double ChangePercentYtp { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }

        public override string ToString() {
            return (new { Timestamp, Status, Name, Symbol, LastPrice, Change, ChangePercent, MarketCap, Volume, ChangeYtd, ChangePercentYtp, High, Low, Open }).ToString();
        }
    }
}
