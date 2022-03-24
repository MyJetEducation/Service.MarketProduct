using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Service.Core.Client.Models;
using Service.MarketProduct.Grpc;
using Service.MarketProduct.Grpc.Models;

namespace Service.MarketProduct.Services
{
	public class MarketProductService : IMarketProductService
	{
		private readonly ILogger<MarketProductService> _logger;

		public MarketProductService(ILogger<MarketProductService> logger)
		{
			_logger = logger;
		}

		public ValueTask<ProductListGrpcResponse> GetProductList(GetProductListGrpcRequest request)
		{
			throw new NotImplementedException();
		}

		public ValueTask<ProductGrpcResponse> GetProduct(GetProductGrpcRequest request)
		{
			throw new NotImplementedException();
		}

		public ValueTask<CommonGrpcResponse> UpdateProduct(UpdateProductGrpcRequest request)
		{
			throw new NotImplementedException();
		}

		public ValueTask<CheckEnabledGrpcResponse> CheckEnabled(CheckEnabledGrpcRequest request)
		{
			throw new NotImplementedException();
		}
	}
}