namespace Service.MarketProduct.Domain.Models
{
	public static class ProductTypeGroup
	{
		/// <summary>
		///     Товары типа "Маскот"
		/// </summary>
		public static MarketProductType[] MascotProductTypes =
		{
			MarketProductType.MascotEmotion,
			MarketProductType.MascotSkin,
			MarketProductType.MascotCharacter
		};

		/// <summary>
		///     Товары типа "Попытки"
		/// </summary>
		public static MarketProductType[] RetryPackProductTypes =
		{
			MarketProductType.RetryPack1,
			MarketProductType.RetryPack10,
			MarketProductType.RetryPack25,
			MarketProductType.RetryPack100
		};
	}
}