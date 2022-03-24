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
		ValueTask<ProductListGrpcResponse> GetProductList(GetProductListGrpcRequest request);

		[OperationContract]
		ValueTask<ProductGrpcResponse> GetProduct(GetProductGrpcRequest request);

		[OperationContract]
		ValueTask<CommonGrpcResponse> UpdateProduct(UpdateProductGrpcRequest request);

		[OperationContract]
		ValueTask<CheckEnabledGrpcResponse> CheckEnabled(CheckEnabledGrpcRequest request);
	}
}