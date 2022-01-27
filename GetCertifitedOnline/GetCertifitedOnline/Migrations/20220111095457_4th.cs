using Microsoft.EntityFrameworkCore.Migrations;

namespace GetCertifitedOnline.Migrations
{
    public partial class _4th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "candidates",
                newName: "CandidateAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CandidateAddress",
                table: "candidates",
                newName: "CustomerAddress");
        }
    }
}
