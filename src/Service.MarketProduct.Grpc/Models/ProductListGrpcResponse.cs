using System.Runtime.Serialization;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class ProductListGrpcResponse
	{
		[DataMember(Order = 1)]
		public MarketProductGrpcModel[] Products { get; set; }
	}
}