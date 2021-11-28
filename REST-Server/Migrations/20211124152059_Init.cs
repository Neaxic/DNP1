using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    jobId = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.jobId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "adults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobTitlejobId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    HairColor = table.Column<string>(type: "TEXT", nullable: true),
                    EyeColor = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adults_Job_JobTitlejobId",
                        column: x => x.JobTitlejobId,
                        principalTable: "Job",
                        principalColumn: "jobId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_adults_JobTitlejobId",
                table: "adults",
                column: "JobTitlejobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adults");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
