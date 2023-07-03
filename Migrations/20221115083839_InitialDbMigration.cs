using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphQL_DotNetCore.Migrations
{
    public partial class InitialDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnerAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    
                    table.ForeignKey(
                        name: "FK_OwnerAccounts_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });            

            

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Description", "Type" },
                values: new object[,]
                {
                    { "Cash account for our users", "Cash" },
                    { "Savings account for our users", "Savings" },
                    { "Income account for our users", "Income" },
                    { "Expense account for our users", "Expense" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Address", "DOB", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    {  "Chennai", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John@gmail.com", "John", "9898324233" },
                    {  "Pune", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Smith@gmail.com", "Smith", "9898312344" }
                });

            migrationBuilder.InsertData(
                table: "OwnerAccounts",
                columns: new[] {  "AccountId", "OwnerId" },
                values: new object[,]
                {
                    {  1, 1 },
                    {  1, 2 }
                });            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OwnerAccounts");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
