using Markit.Models;
using Markit.Net.Http;
using Markit.Net.Http.Configurators;
using Markit.Net.Http.Formatting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Markit {
    public partial class MarkitClient : IDisposable {
        private readonly MediaTypeFormatter _formatter = new MarkitMediaTypeFormatter();
        private readonly IEnumerable<MediaTypeFormatter> _formatters = new[] { new MarkitMediaTypeFormatter() };
        private HttpMessageHandler _handler;
        private HttpClient _client;
        private volatile bool _disposed;

        public MarkitClient(string uri = "http://dev.markitondemand.com/api") {
            _handler = new MarkitDelegatingHandler();
            _client = new HttpClient(_handler);
            _client.BaseAddress = new Uri(uri);
        }

        ~MarkitClient() {
            Dispose(false);
        }

        private Task<HttpResponseMessage> SendAsync(HttpMethod method, Action<IHttpRequestMessageConfigurator> configure) {
            var configurator = new HttpRequestMessageConfigurator();

            configurator.Method(method);
            configurator.BaseAddress(_client.BaseAddress);
            configure(configurator);

            var request = configurator.Build();
            return _client.SendAsync(request);
        }

        private Task<HttpResponseMessage> GetAsync(string path, Parameters parameters = null) {
            return SendAsync(HttpMethod.Get, x => {
                x.Path(path);
                x.Parameters(parameters);
            });
        }

        private Task<T> GetAsync<T>(string path, Parameters parameters = null) where T : class {
            return GetAsync(path, parameters)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult()
                .Content.ReadAsAsync<T>(_formatter);
        }

        public Task<Companys> GetCompanyAsync(string input) {
            return GetAsync<Companys>("lookup", new Parameters { { "input", input } });
        }

        public Task<Quote> GetQuoteAsync(string symbol) {
            return GetAsync<Quote>("quote", new Parameters { { "symbol", symbol } });
        }

        public Task<Timeseries> GetTimeseriesAsync(string symbol, int duration = 365) {
            return GetAsync<Timeseries>("timeseries", new Parameters { { "symbol", symbol }, { "duration", duration } });
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
            }
            _disposed = true;
        }
    }
}