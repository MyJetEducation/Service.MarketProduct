using System.ServiceModel;
using System.Threading.Tasks;
using Service.Core.Client.Models;
using Service.MarketProduct.Grpc.Models;

namespace Service.MarketProduct.Grpc
{
	[ServiceContract]
	public interface IMarketProductService
	{
		[OperationContract]
		ValueTask<ProductListGrpcResponse> GetProductListAsync(GetProductListGrpcRequest request);

		[OperationContract]
		ValueTask<ProductGrpcResponse> GetProductAsync(GetProductGrpcRequest request);

		[OperationContract]
		ValueTask<CommonGrpcResponse> UpdateProductAsync(UpdateProductGrpcRequest request);

		[OperationContract]
		ValueTask<CheckEnabledGrpcResponse> CheckEnabledAsync(CheckEnabledGrpcRequest request);
	}
}