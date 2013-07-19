using Markit.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Markit.Net.Http.Formatting {
    internal class TimeseriesConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Timeseries).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var target = new Target();
            serializer.Populate(reader, target);

            var open = target.Data.Series.Open.Values.ToArray();
            var high = target.Data.Series.High.Values.ToArray();
            var low = target.Data.Series.Low.Values.ToArray();
            var close = target.Data.Series.Close.Values.ToArray();
            var dates = target.Data.SeriesDates.ToArray();

            var timeseries = new Timeseries {
                Name = target.Data.Name,
                Symbol = target.Data.Symbol,
            };

            for (int i = 0; i < dates.Length; i++) {
                timeseries.Add(open[i], high[i], low[i], close[i]);
            }

            return timeseries;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public class Target {
            public Data Data { get; set; }
        }

        public class Data {
            public string Name { get; set; }
            public string Symbol { get; set; }
            public Series Series { get; set; }
            public SeriesDates SeriesDates { get; set; }
            public int SeriesDuration { get; set; }
            public SeriesLabelCoordinates SeriesLabelCoordinates { get; set; }
            public bool Matches { get; set; }
        }

        public class Series {
            public Item Open { get; set; }
            public Item High { get; set; }
            public Item Low { get; set; }
            public Item Close { get; set; }
        }

        public class SeriesDates : List<DateTimeOffset> {
            public SeriesDates() {
            }

            public SeriesDates(IEnumerable<DateTimeOffset> collection)
                : base(collection) {
            }
        }

        public class SeriesLabelCoordinates : List<double> {
            public SeriesLabelCoordinates() {
            }

            public SeriesLabelCoordinates(IEnumerable<double> collection)
                : base(collection) {
            }
        }

        public class Item {
            public double Min { get; set; }
            public double Max { get; set; }
            public List<double> Values { get; set; }
        }
    }
}
