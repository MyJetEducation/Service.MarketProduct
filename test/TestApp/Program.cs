using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.Core.Client.Models;
using Service.Grpc;
using Service.MarketProduct.Client;
using Service.MarketProduct.Domain.Models;
using Service.MarketProduct.Grpc;
using Service.MarketProduct.Grpc.Models;
using GrpcClientFactory = ProtoBuf.Grpc.Client.GrpcClientFactory;

namespace TestApp
{
	public class Program
	{
		private static async Task Main()
		{
			GrpcClientFactory.AllowUnencryptedHttp2 = true;
			ILogger<Program> logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Program>();

			Console.Write("Press enter to start");
			Console.ReadLine();

			var factory = new MarketProductClientFactory("http://localhost:5001", logger);
			IGrpcServiceProxy<IMarketProductService> serviceProxy = factory.GetMarketProductService();
			IMarketProductService client = serviceProxy.Service;

			var rand = new Random(100);

			foreach (MarketProductType productType in Enum.GetValues<MarketProductType>())
			{
				string productName = Enum.GetName(productType);

				CommonGrpcResponse commonGrpcResponse = await client.UpdateProductAsync(new UpdateProductGrpcRequest
				{
					ProductType = productType,
					Disabled = false,
					Category = MarketProductCategory.Education,
					Price = rand.Next(),
					Priority = 10
				});

				if (commonGrpcResponse.IsSuccess == false)
					throw new Exception($"Can't update product {productName}!");
			}

			ProductListGrpcResponse productListGrpcResponse = await client.GetProductListAsync(new GetProductListGrpcRequest
			{
				WithDisabled = true
			});
			Console.WriteLine(JsonConvert.SerializeObject(productListGrpcResponse));

			CheckEnabledGrpcResponse enabledMascotReposnse = await client.CheckEnabledAsync(new CheckEnabledGrpcRequest
			{
				ProductType = MarketProductType.MascotSkin
			});
			Console.WriteLine(JsonConvert.SerializeObject(enabledMascotReposnse));

			ProductGrpcResponse productGrpcResponse = await client.GetProductAsync(new GetProductGrpcRequest
			{
				ProductType = MarketProductType.EducationProgressWipe
			});
			Console.WriteLine(JsonConvert.SerializeObject(productGrpcResponse));

			Console.WriteLine("End");
			Console.ReadLine();
		}
	}
}