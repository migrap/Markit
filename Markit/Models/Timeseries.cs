using System.Collections.Generic;

namespace Markit.Models {
    public class Timeseries : IEnumerable<Ohlc> {
        private readonly Series _series;

        public string Name { get; set; }
        public string Symbol { get; set; }

        public Timeseries() {
            _series = new Series(this);
        }

        public IEnumerator<Ohlc> GetEnumerator() {
            return _series.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        internal void Add(double open, double high, double low, double close) {
            _series.Add(open, high, low, close);
        }
    }
}