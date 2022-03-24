using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.MarketProduct.Grpc;
using Service.Grpc;

namespace Service.MarketProduct.Client
{
    [UsedImplicitly]
    public class MarketProductClientFactory : GrpcClientFactory
    {
        public MarketProductClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
        {
        }

        public IGrpcServiceProxy<IMarketProductService> GetMarketProductService() => CreateGrpcService<IMarketProductService>();
    }
}
