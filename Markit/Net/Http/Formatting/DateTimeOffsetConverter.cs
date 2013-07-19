using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace Markit.Net.Http.Formatting {
    public class DateTimeOffsetConverter : DateTimeConverterBase {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var value = reader.Value.ToString();

            if (value.Contains(":") && value.Contains("-")) {
                //Thu Jul 18 15:59:59 UTC-04:00 2013
                return DateTimeOffset.ParseExact(value, "ddd MMM dd HH:mm:ss UTCzzz yyyy", CultureInfo.InvariantCulture);
            }
            else {
                //"Wed Jul 10 2013"
                return DateTimeOffset.Parse(value);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
