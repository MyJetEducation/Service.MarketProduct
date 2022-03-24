using Microsoft.EntityFrameworkCore.Migrations;
using Service.MarketProduct.Domain.Models;

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
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_market_product", x => x.ProductType));

	        foreach (MarketProductType productType in Enum.GetValues<MarketProductType>())
		        migrationBuilder.InsertData(tableName, "ProductType", Enum.GetName(productType), schema);
        }

        protected override void Down(MigrationBuilder migrationBuilder) => 
			migrationBuilder.DropTable(name: DatabaseContext.MarketProductTableName, schema: DatabaseContext.Schema);
    }
}
