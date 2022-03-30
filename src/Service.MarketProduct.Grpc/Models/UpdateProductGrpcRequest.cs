using System.Runtime.Serialization;
using Service.MarketProduct.Domain.Models;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class UpdateProductGrpcRequest
	{
		[DataMember(Order = 1)]
		public MarketProductType ProductType { get; set; }

		[DataMember(Order = 2)]
		public MarketProductCategory Category { get; set; }

		[DataMember(Order = 3)]
		public decimal? Price { get; set; }

		[DataMember(Order = 4)]
		public bool Disabled { get; set; }

		[DataMember(Order = 5)]
		public int Priority { get; set; }
	}
}