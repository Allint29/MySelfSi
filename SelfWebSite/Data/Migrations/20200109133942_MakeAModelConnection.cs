using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfWebSite.Data.Migrations
{
    public partial class MakeAModelConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Persons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Persons",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassportSeria",
                table: "Persons",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PersonsPrimaryKey",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Population = table.Column<long>(nullable: false, defaultValue: 1000L),
                    Code = table.Column<int>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Manufacture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacture_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturesProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ManufactureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturesProducts", x => new { x.ManufactureId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ManufacturesProducts_Manufacture_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufacture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturesProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ApplicationUserId",
                table: "Persons",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryId",
                table: "Persons",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacture_CountryId",
                table: "Manufacture",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturesProducts_ProductId",
                table: "ManufacturesProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_ApplicationUserId",
                table: "Persons",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_ApplicationUserId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ManufacturesProducts");

            migrationBuilder.DropTable(
                name: "Manufacture");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PersonsPrimaryKey",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ApplicationUserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PassportSeria",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
