using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApi.Migrations
{
    public partial class EnterprisePerson1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnterprisePersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FantasyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterprisePersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualPersons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnterprisePersons");

            migrationBuilder.DropTable(
                name: "IndividualPersons");
        }
    }
}
