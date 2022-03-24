using Autofac;
using Microsoft.Extensions.Logging;
using Service.MarketProduct.Grpc;
using Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.MarketProduct.Client
{
    public static class AutofacHelper
    {
        public static void RegisterMarketProductClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
        {
            var factory = new MarketProductClientFactory(grpcServiceUrl, logger);

            builder.RegisterInstance(factory.GetMarketProductService()).As<IGrpcServiceProxy<IMarketProductService>>().SingleInstance();
        }
    }
}
