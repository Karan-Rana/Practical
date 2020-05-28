using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Practical.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<char>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<char>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AnnualBudget = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmploeeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    ClubId = table.Column<char>(nullable: false),
                    DepartmentId = table.Column<char>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmploeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "ClubId", "Name" },
                values: new object[,]
                {
                    { 'A', "Roadtrip" },
                    { 'B', "Boating" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "AnnualBudget", "Name" },
                values: new object[,]
                {
                    { 'm', 1000m, "Accounting" },
                    { 'n', 1200m, "Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmploeeId", "ClubId", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 'A', 'm', "Satish" },
                    { 2, 'B', 'm', "Hiren" },
                    { 4, 'A', 'm', "Chris" },
                    { 3, 'A', 'n', "Naren" },
                    { 5, 'B', 'n', "Jon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClubId",
                table: "Employees",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
