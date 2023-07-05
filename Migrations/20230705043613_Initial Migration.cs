using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisionStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPin = table.Column<int>(type: "int", nullable: false),
                    CustomerCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deliveryMethods",
                columns: table => new
                {
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryMethods", x => x.DeliveryMethodId);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCouponDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountCouponPercentage = table.Column<int>(type: "int", nullable: false),
                    DiscountCouponCodeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountCouponCodeValidTill = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    ManuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuGrade = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ManuCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.ManuId);
                });

            migrationBuilder.CreateTable(
                name: "preferredPaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preferredPaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodUses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalValue = table.Column<float>(type: "real", nullable: false),
                    DiscountAppliedId = table.Column<int>(type: "int", nullable: false),
                    DiscountTableDiscountId = table.Column<int>(type: "int", nullable: false),
                    FinalValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_purchases_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchases_discounts_DiscountTableDiscountId",
                        column: x => x.DiscountTableDiscountId,
                        principalTable: "discounts",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductManufacturer = table.Column<int>(type: "int", nullable: false),
                    ManufacturerManuId = table.Column<int>(type: "int", nullable: false),
                    ProductSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSubCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductUnit = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryLevel = table.Column<int>(type: "int", nullable: false),
                    ProductUnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    ProductPriceCurrency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductInventoryThreshold = table.Column<int>(type: "int", nullable: false),
                    ProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_manufacturers_ManufacturerManuId",
                        column: x => x.ManufacturerManuId,
                        principalTable: "manufacturers",
                        principalColumn: "ManuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSecreteQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSecreteAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userMasters_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: false),
                    SelectedUnits = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carts_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carts_products_productsProductId",
                        column: x => x.productsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PurchasedUnits = table.Column<int>(type: "int", nullable: false),
                    DeliveryInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseProducts_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseProducts_purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerId",
                table: "carts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_productsProductId",
                table: "carts",
                column: "productsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ManufacturerManuId",
                table: "products",
                column: "ManufacturerManuId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseProducts_ProductsProductId",
                table: "purchaseProducts",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseProducts_PurchaseId",
                table: "purchaseProducts",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_CustomerId",
                table: "purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_DiscountTableDiscountId",
                table: "purchases",
                column: "DiscountTableDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_userMasters_RoleId",
                table: "userMasters",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "deliveryMethods");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "preferredPaymentMethods");

            migrationBuilder.DropTable(
                name: "purchaseProducts");

            migrationBuilder.DropTable(
                name: "userMasters");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "manufacturers");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "discounts");
        }
    }
}
