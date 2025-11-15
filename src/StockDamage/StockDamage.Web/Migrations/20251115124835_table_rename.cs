using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockDamage.Web.Migrations
{
    /// <inheritdoc />
    public partial class table_rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDamageLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubItemCodes",
                table: "SubItemCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDamageVouchers",
                table: "StockDamageVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Godowns",
                table: "Godowns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "SubItemCodes",
                newName: "SubItemCode");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Stock");

            migrationBuilder.RenameTable(
                name: "StockDamageVouchers",
                newName: "StockDamageVoucher");

            migrationBuilder.RenameTable(
                name: "Godowns",
                newName: "Godown");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currencie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubItemCode",
                table: "SubItemCode",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDamageVoucher",
                table: "StockDamageVoucher",
                column: "VoucherNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Godown",
                table: "Godown",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencie",
                table: "Currencie",
                column: "CurrencyId");

            migrationBuilder.CreateTable(
                name: "StockDamage",
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
                    table.PrimaryKey("PK_StockDamage", x => x.AutoSlNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockDamage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubItemCode",
                table: "SubItemCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDamageVoucher",
                table: "StockDamageVoucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Godown",
                table: "Godown");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencie",
                table: "Currencie");

            migrationBuilder.RenameTable(
                name: "SubItemCode",
                newName: "SubItemCodes");

            migrationBuilder.RenameTable(
                name: "StockDamageVoucher",
                newName: "StockDamageVouchers");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "Godown",
                newName: "Godowns");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Currencie",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubItemCodes",
                table: "SubItemCodes",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDamageVouchers",
                table: "StockDamageVouchers",
                column: "VoucherNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Godowns",
                table: "Godowns",
                column: "AutoSlNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.CreateTable(
                name: "StockDamageLines",
                columns: table => new
                {
                    AutoSlNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountBDT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrACHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeID = table.Column<long>(type: "bigint", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GodownAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubItemAutoSlNo = table.Column<long>(type: "bigint", nullable: false),
                    VoucherNo = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDamageLines", x => x.AutoSlNo);
                });
        }
    }
}
