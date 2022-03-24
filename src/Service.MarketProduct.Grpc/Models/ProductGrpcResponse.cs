using System.Runtime.Serialization;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class ProductGrpcResponse
	{
		[DataMember(Order = 1)]
		public MarketProductGrpcModel Product { get; set; }
	}
}