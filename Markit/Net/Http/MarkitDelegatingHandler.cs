using System.Net;
using System.Net.Http;

namespace Markit.Net.Http {
    internal class MarkitDelegatingHandler : DelegatingHandler {
        public MarkitDelegatingHandler() {
            InnerHandler = new HttpClientHandler {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None,
            };
        }
    }
}