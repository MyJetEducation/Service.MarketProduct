using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.MarketProduct.Settings
{
    public class SettingsModel
    {
        [YamlProperty("MarketProduct.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("MarketProduct.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("MarketProduct.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("MarketProduct.PostgresConnectionString")]
        public string PostgresConnectionString { get; set; }
    }
}
