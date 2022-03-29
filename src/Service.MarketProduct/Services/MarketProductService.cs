using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Core.Client.Extensions;
using Service.Core.Client.Models;
using Service.Core.Client.Services;
using Service.MarketProduct.Domain.Models;
using Service.MarketProduct.Grpc;
using Service.MarketProduct.Grpc.Models;
using Service.MarketProduct.Mappers;
using Service.MarketProduct.Postgres;
using Service.MarketProduct.Postgres.Models;

namespace Service.MarketProduct.Services
{
	public class MarketProductService : IMarketProductService
	{
		private readonly ILogger<MarketProductService> _logger;
		private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;
		private readonly ISystemClock _systemClock;

		public MarketProductService(ILogger<MarketProductService> logger, DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder, ISystemClock systemClock)
		{
			_logger = logger;
			_dbContextOptionsBuilder = dbContextOptionsBuilder;
			_systemClock = systemClock;
		}

		public async ValueTask<ProductListGrpcResponse> GetProductListAsync(GetProductListGrpcRequest request)
		{
			bool withDisabled = request.WithDisabled.GetValueOrDefault();
			MarketProductType[] productTypes = request.ProductTypes;
			MarketProductEntity[] entities = null;

			try
			{
				entities = await GetContext()
					.MarketProductEntities
					.WhereIf(!withDisabled, model => model.Disabled == false || model.Disabled == null)
					.WhereIf(!productTypes.IsNullOrEmpty(), model => productTypes.Contains(model.ProductType))
					.ToArrayAsync();
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return new ProductListGrpcResponse
			{
				Products = entities?.Select(entity => entity.ToGrpcModel()).ToArray()
			};
		}

		public async ValueTask<ProductGrpcResponse> GetProductAsync(GetProductGrpcRequest request)
		{
			MarketProductEntity entity = await GetEntity(request.ProductType);

			return new ProductGrpcResponse
			{
				Product = entity.ToGrpcModel()
			};
		}

		public async ValueTask<CommonGrpcResponse> UpdateProductAsync(UpdateProductGrpcRequest request)
		{
			DatabaseContext context = GetContext();

			MarketProductEntity entity = await GetEntity(request.ProductType, context);
			if (entity == null)
				return CommonGrpcResponse.Fail;

			entity.MapEntityModel(request, _systemClock.Now);

			try
			{
				context.MarketProductEntities.Update(entity);
				await context.SaveChangesAsync();

				return CommonGrpcResponse.Success;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);

				return CommonGrpcResponse.Fail;
			}
		}

		private async ValueTask<MarketProductEntity> GetEntity(MarketProductType productType, DatabaseContext context = null)
		{
			context ??= GetContext();

			try
			{
				return await context
					.MarketProductEntities
					.FirstOrDefaultAsync(model => model.ProductType == productType);
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return await ValueTask.FromResult<MarketProductEntity>(null);
		}

		public async ValueTask<CheckEnabledGrpcResponse> CheckEnabledAsync(CheckEnabledGrpcRequest request)
		{
			bool? enabled = null;

			try
			{
				enabled = await GetContext()
					.MarketProductEntities
					.Where(model => model.ProductType == request.ProductType)
					.Select(model => model.Disabled == null || model.Disabled == false)
					.FirstOrDefaultAsync();
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return new CheckEnabledGrpcResponse
			{
				Enabled = enabled.GetValueOrDefault()
			};
		}

		private DatabaseContext GetContext() => DatabaseContext.Create(_dbContextOptionsBuilder);
	}
}