using System;
using System.Net.Http;

namespace Markit.Net.Http.Configurators {
    internal class HttpRequestMessageConfigurator : IHttpRequestMessageConfigurator {
        private HttpMethod _method;
        private string _path;
        private string _format = "json";
        private Parameters _parameters;

        private Uri _baseaddress;

        internal IHttpRequestMessageConfigurator BaseAddress(Uri value) {
            _baseaddress = value;
            return this;
        }

        internal IHttpRequestMessageConfigurator Method(HttpMethod method) {
            _method = method;
            return this;
        }

        public IHttpRequestMessageConfigurator Path(string value) {
            _path = value;
            return this;
        }

        public IHttpRequestMessageConfigurator Format(string value = "json") {
            _format = value;
            return this;
        }

        public IHttpRequestMessageConfigurator Parameters(Parameters value) {
            _parameters = value;
            return this;
        }

        public HttpRequestMessage Build() {
            var builder = new UriBuilder(_baseaddress) {
                Query = _parameters.ToQueryString(),
            };

            builder.Path = "{0}/{1}/{2}".FormatWith(builder.Path, _path, _format);

            var message = new HttpRequestMessage {
                Method = _method,
                RequestUri = builder.Uri,
            };

            return message;
        }
    }
}