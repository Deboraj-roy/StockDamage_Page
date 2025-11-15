using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockDamage.Web.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Godowns",
                columns: table => new
                {
                    AutoSlNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodownNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodownName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Godowns", x => x.AutoSlNo);
                });

            migrationBuilder.CreateTable(
                name: "StockDamageLines",
                columns: table => new
                {
                    AutoSlNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNo = table.Column<long>(type: "bigint", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GodownAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    SubItemAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    BatchNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountBDT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DrACHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<long>(type: "bigint", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDamageLines", x => x.AutoSlNo);
                });

            migrationBuilder.CreateTable(
                name: "StockDamageVouchers",
                columns: table => new
                {
                    VoucherNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrACHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<long>(type: "bigint", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDamageVouchers", x => x.VoucherNo);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    AutoSlNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodownAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    SubItemAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.AutoSlNo);
                });

            migrationBuilder.CreateTable(
                name: "SubItemCodes",
                columns: table => new
                {
                    AutoSlNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubItemCodeValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItemCodes", x => x.AutoSlNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Godowns");

            migrationBuilder.DropTable(
                name: "StockDamageLines");

            migrationBuilder.DropTable(
                name: "StockDamageVouchers");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "SubItemCodes");
        }
    }
}
