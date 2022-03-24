using Autofac;
using Service.Core.Client.Services;

namespace Service.MarketProduct.Modules
{
	public class ServiceModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<SystemClock>().AsImplementedInterfaces().SingleInstance();
		}
	}
}