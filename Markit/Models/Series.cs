using System.Collections.Generic;

namespace Markit.Models {
    internal class Series : List<Ohlc> {
        private Timeseries _timeseries;

        internal Series(Timeseries timeseries) {
            _timeseries = timeseries;
        }

        public void Add(double open, double high, double low, double close) {
            base.Add(new Ohlc(_timeseries) { Open = open, High = high, Low = low, Close = close });
        }
    }
}
