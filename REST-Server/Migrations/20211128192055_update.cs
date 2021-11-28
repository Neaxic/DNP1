using Microsoft.EntityFrameworkCore.Migrations;

namespace REST_Server.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adults_Job_JobTitlejobId",
                table: "adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "jobs");

            migrationBuilder.AlterColumn<int>(
                name: "JobTitlejobId",
                table: "adults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "jobId",
                table: "jobs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobs",
                table: "jobs",
                column: "jobId");

            migrationBuilder.AddForeignKey(
                name: "FK_adults_jobs_JobTitlejobId",
                table: "adults",
                column: "JobTitlejobId",
                principalTable: "jobs",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adults_jobs_JobTitlejobId",
                table: "adults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobs",
                table: "jobs");

            migrationBuilder.RenameTable(
                name: "jobs",
                newName: "Job");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitlejobId",
                table: "adults",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "jobId",
                table: "Job",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "jobId");

            migrationBuilder.AddForeignKey(
                name: "FK_adults_Job_JobTitlejobId",
                table: "adults",
                column: "JobTitlejobId",
                principalTable: "Job",
                principalColumn: "jobId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
