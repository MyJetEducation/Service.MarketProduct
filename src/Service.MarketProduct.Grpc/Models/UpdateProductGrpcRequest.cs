using System;
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
		public string Name { get; set; }

		[DataMember(Order = 3)]
		public string Description { get; set; }

		[DataMember(Order = 4)]
		public decimal? Price { get; set; }

		[DataMember(Order = 5)]
		public DateTime? Date { get; set; }

		[DataMember(Order = 6)]
		public bool Disabled { get; set; }
	}
}