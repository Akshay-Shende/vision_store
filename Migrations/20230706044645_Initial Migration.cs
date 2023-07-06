using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace VisionStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerFirstName = table.Column<string>(type: "longtext", nullable: false),
                    CustomerLastName = table.Column<string>(type: "longtext", nullable: false),
                    CustomerEmailAddress = table.Column<string>(type: "longtext", nullable: false),
                    CustomerContactNo = table.Column<string>(type: "longtext", nullable: false),
                    CustomerAddress = table.Column<string>(type: "longtext", nullable: false),
                    CustomerCity = table.Column<string>(type: "longtext", nullable: false),
                    CustomerPin = table.Column<int>(type: "int", nullable: false),
                    CustomerCountry = table.Column<string>(type: "longtext", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    CustomerPassword = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "deliveryMethods",
                columns: table => new
                {
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DeliveryMethodDescription = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryMethods", x => x.DeliveryMethodId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DiscountCouponCode = table.Column<string>(type: "longtext", nullable: false),
                    DiscountCouponDescription = table.Column<string>(type: "longtext", nullable: false),
                    DiscountCouponPercentage = table.Column<int>(type: "int", nullable: false),
                    DiscountCouponCodeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DiscountCouponCodeValidTill = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.DiscountId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "manufacturers",
                columns: table => new
                {
                    ManuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ManufacturerName = table.Column<string>(type: "longtext", nullable: false),
                    ManufacturerDescription = table.Column<string>(type: "longtext", nullable: false),
                    ManuCity = table.Column<string>(type: "longtext", nullable: false),
                    ManuGrade = table.Column<string>(type: "varchar(1)", nullable: false),
                    ManuCountry = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturers", x => x.ManuId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preferredPaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaymentMethodDescription = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preferredPaymentMethods", x => x.PaymentMethodId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodUses = table.Column<string>(type: "longtext", nullable: false),
                    TotalValue = table.Column<float>(type: "float", nullable: false),
                    DiscountAppliedId = table.Column<int>(type: "int", nullable: false),
                    DiscountTableDiscountId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "DiscountId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "longtext", nullable: false),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: false),
                    ProductFeature = table.Column<string>(type: "longtext", nullable: false),
                    ManuId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerManuId = table.Column<int>(type: "int", nullable: true),
                    ProductSize = table.Column<string>(type: "longtext", nullable: false),
                    ProductSubCategory = table.Column<string>(type: "longtext", nullable: false),
                    ProductUnit = table.Column<int>(type: "int", nullable: false),
                    ProductInventoryLevel = table.Column<int>(type: "int", nullable: false),
                    ProductUnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    ProductPriceCurrency = table.Column<string>(type: "longtext", nullable: false),
                    ProductInventoryThreshold = table.Column<int>(type: "int", nullable: false),
                    ProductImageUrl = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_manufacturers_ManufacturerManuId",
                        column: x => x.ManufacturerManuId,
                        principalTable: "manufacturers",
                        principalColumn: "ManuId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    UserEmailId = table.Column<string>(type: "longtext", nullable: false),
                    UserContactNo = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    UserSecreteQuestion = table.Column<string>(type: "longtext", nullable: false),
                    UserSecreteAnswer = table.Column<string>(type: "longtext", nullable: false),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CartTimestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    productsProductId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "ProductId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "purchaseProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: true),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PurchasedUnits = table.Column<int>(type: "int", nullable: false),
                    DeliveryInstruction = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseProducts_products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_purchaseProducts_purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

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
