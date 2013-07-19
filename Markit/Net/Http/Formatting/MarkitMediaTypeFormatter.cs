using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Markit.Net.Http.Formatting {
    internal class MarkitMediaTypeFormatter : JsonMediaTypeFormatter {
        public MarkitMediaTypeFormatter() {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/javascript"));
            SerializerSettings.Converters.Add(new QuoteConverter());
            SerializerSettings.Converters.Add(new TimeseriesConverter());
            SerializerSettings.Converters.Add(new DateTimeOffsetConverter());
        }

        public override bool CanReadType(Type type) {
            return base.CanReadType(type);
        }

        public override bool CanWriteType(Type type) {
            return base.CanWriteType(type);
        }
    }
}