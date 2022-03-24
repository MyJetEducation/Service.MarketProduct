using System.Runtime.Serialization;
using Service.MarketProduct.Domain.Models;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class GetProductListGrpcRequest
	{
		[DataMember(Order = 1)]
		public bool? WithDisabled { get; set; }

		[DataMember(Order = 2)]
		public MarketProductType[] ProductTypes { get; set; }
	}
}