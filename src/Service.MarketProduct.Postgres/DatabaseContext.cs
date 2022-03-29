using Microsoft.EntityFrameworkCore;
using MyJetWallet.Sdk.Postgres;
using MyJetWallet.Sdk.Service;
using Service.MarketProduct.Postgres.Models;

namespace Service.MarketProduct.Postgres
{
	public class DatabaseContext : MyDbContext
	{
		public const string Schema = "education";
		public const string MarketProductTableName = "market_product";

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<MarketProductEntity> MarketProductEntities { get; set; }

		public static DatabaseContext Create(DbContextOptionsBuilder<DatabaseContext> options)
		{
			MyTelemetry.StartActivity($"Database context {Schema}")?.AddTag("db-schema", Schema);

			return new DatabaseContext(options.Options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Schema);

			SetUserInfoEntityEntry(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private static void SetUserInfoEntityEntry(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MarketProductEntity>().ToTable(MarketProductTableName);

			modelBuilder.Entity<MarketProductEntity>().Property(e => e.Date);
			modelBuilder.Entity<MarketProductEntity>().Property(e => e.Disabled);
			modelBuilder.Entity<MarketProductEntity>().Property(e => e.Price);
			modelBuilder.Entity<MarketProductEntity>().Property(e => e.Name);
			modelBuilder.Entity<MarketProductEntity>().Property(e => e.Description);
			modelBuilder.Entity<MarketProductEntity>().Property(e => e.ProductType).HasConversion<string>().IsRequired();

			modelBuilder.Entity<MarketProductEntity>().HasKey(e => e.ProductType);
		}
	}
}