using Service.MarketProduct.Domain.Models;

namespace Service.MarketProduct.Postgres.Models
{
	public class MarketProductEntity
	{
		public DateTime? Date { get; set; }

		public bool? Disabled { get; set; }

		public MarketProductType ProductType { get; set; }

		public decimal? Price { get; set; }

		public MarketProductCategory Category { get; set; }
	}
}