
namespace Markit.Net.Http.Configurators {
    internal interface IHttpRequestMessageConfigurator {
        IHttpRequestMessageConfigurator Path(string value);
        IHttpRequestMessageConfigurator Format(string value = "json");
        IHttpRequestMessageConfigurator Parameters(Parameters value);
    }
}
