using System.Text.Json.Serialization;

namespace Service.MarketProduct.Domain.Models
{
	/// <summary>
	///     Товар для маркета
	/// </summary>
	[JsonConverter(typeof (JsonStringEnumConverter))]
	public enum MarketProductType
	{
		//education types
		RetryPack1,
		RetryPack10,
		RetryPack25,
		RetryPack100,
		EducationProgressWipe,

		//mascot types
		MascotCharacter,
		MascotSkin,
		MascotEmotion
	}
}