using Markit.Models;
using Newtonsoft.Json;
using System;

namespace Markit.Net.Http.Formatting {
    internal class QuoteConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Quote).Equals(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            reader.Read();
            reader.Read();

            var quote = new Quote();
            serializer.Populate(reader, quote);
            return quote;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
