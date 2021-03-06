using System.Runtime.Serialization;
using Service.MarketProduct.Domain.Models;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class CheckEnabledGrpcRequest
	{
		[DataMember(Order = 1)]
		public MarketProductType ProductType { get; set; }
	}
}