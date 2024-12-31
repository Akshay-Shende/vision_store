using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace VisionStore.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchasedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_productsProductId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_productsProductId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "productsProductId",
                table: "carts");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedUnits",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "purchasedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserMasterId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: true),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    TotalValue = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchasedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchasedProducts_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_purchasedProducts_userMasters_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "userMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_carts_ProductId",
                table: "carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedProducts_ProductsProductId",
                table: "purchasedProducts",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedProducts_UserMasterId",
                table: "purchasedProducts",
                column: "UserMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts");

            migrationBuilder.DropTable(
                name: "purchasedProducts");

            migrationBuilder.DropIndex(
                name: "IX_carts_ProductId",
                table: "carts");

            migrationBuilder.AlterColumn<int>(
                name: "SelectedUnits",
                table: "carts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "productsProductId",
                table: "carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carts_productsProductId",
                table: "carts",
                column: "productsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_productsProductId",
                table: "carts",
                column: "productsProductId",
                principalTable: "products",
                principalColumn: "ProductId");
        }
    }
}
