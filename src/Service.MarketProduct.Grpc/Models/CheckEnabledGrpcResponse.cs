using System.Runtime.Serialization;

namespace Service.MarketProduct.Grpc.Models
{
	[DataContract]
	public class CheckEnabledGrpcResponse
	{
		[DataMember(Order = 1)]
		public bool Enabled { get; set; }
	}
}