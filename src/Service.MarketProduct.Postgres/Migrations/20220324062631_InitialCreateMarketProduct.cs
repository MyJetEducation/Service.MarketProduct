using Microsoft.EntityFrameworkCore.Migrations;
using Service.MarketProduct.Domain.Models;
using Service.MarketProduct.Postgres.Models;

#nullable disable

namespace Service.MarketProduct.Postgres.Migrations
{
    public partial class InitialCreateMarketProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var schema = DatabaseContext.Schema;
            var tableName = DatabaseContext.MarketProductTableName;
            
			migrationBuilder.EnsureSchema(name: schema);

	        migrationBuilder.CreateTable(
                name: tableName,
                schema: schema,
                columns: table => new
                {
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Disabled = table.Column<bool>(type: "boolean", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_market_product", x => x.ProductType));

	        void InsertData(MarketProductType productType, MarketProductCategory category) => migrationBuilder.InsertData(
		        tableName,
		        new[] {nameof(MarketProductEntity.ProductType), nameof(MarketProductEntity.Category), nameof(MarketProductEntity.Priority)},
		        new object[] {productType.ToString(), category.ToString(), 0},
		        schema);

            InsertData(MarketProductType.RetryPack1, MarketProductCategory.Education);
            InsertData(MarketProductType.RetryPack10, MarketProductCategory.Education);
            InsertData(MarketProductType.RetryPack25, MarketProductCategory.Education);
            InsertData(MarketProductType.RetryPack100, MarketProductCategory.Education);
            InsertData(MarketProductType.EducationProgressWipe, MarketProductCategory.Education);
            InsertData(MarketProductType.MascotCharacter, MarketProductCategory.Masccot);
            InsertData(MarketProductType.MascotSkin, MarketProductCategory.Masccot);
            InsertData(MarketProductType.MascotEmotion, MarketProductCategory.Masccot);
        }

        protected override void Down(MigrationBuilder migrationBuilder) => 
			migrationBuilder.DropTable(name: DatabaseContext.MarketProductTableName, schema: DatabaseContext.Schema);
    }
}
