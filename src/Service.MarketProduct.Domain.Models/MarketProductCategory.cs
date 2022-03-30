using System.Text.Json.Serialization;

namespace Service.MarketProduct.Domain.Models
{
	/// <summary>
	///     Категория товара для маркета
	/// </summary>
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum MarketProductCategory
	{
		Education,
		Masccot
	}
}