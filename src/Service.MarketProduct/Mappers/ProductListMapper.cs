using System;
using Service.MarketProduct.Grpc.Models;
using Service.MarketProduct.Postgres.Models;

namespace Service.MarketProduct.Mappers
{
	public static class ProductListMapper
	{
		public static MarketProductGrpcModel ToGrpcModel(this MarketProductEntity entity) => new MarketProductGrpcModel
		{
			Date = entity.Date,
			Disabled = entity.Disabled == true,
			Description = entity.Description,
			Name = entity.Name,
			Price = entity.Price,
			ProductType = entity.ProductType
		};

		public static void MapEntityModel(this MarketProductEntity entity, UpdateProductGrpcRequest request, DateTime now)
		{
			entity.Disabled = request.Disabled;
			entity.Date = now;
			entity.Description = request.Description;
			entity.Name = request.Name;
			entity.Price = request.Price;
			entity.ProductType = request.ProductType;
		}
	}
}