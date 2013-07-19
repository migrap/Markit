using System;

namespace Markit.Models {
    public class Ohlc {
        private Timeseries _timeseries;

        internal Ohlc(Timeseries timeseries) {
            _timeseries = timeseries;
        }

        public string Name { get { return _timeseries.Name; } }
        public string Symbol { get { return _timeseries.Symbol; } }
        public DateTimeOffset DateTime { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }

        public override string ToString() {
            return (new { DateTime, Name, Symbol, Open, High, Low, Close }).ToString();
        }
    }
}
