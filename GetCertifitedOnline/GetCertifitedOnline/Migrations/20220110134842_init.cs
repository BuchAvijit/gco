using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GetCertifitedOnline.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    adminId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    candidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    candidateQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    candidateAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    candidateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    candidateEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    candidateContanctNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.candidateId);
                });

            migrationBuilder.CreateTable(
                name: "certificationexams",
                columns: table => new
                {
                    examId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    examDuration = table.Column<int>(type: "int", nullable: false),
                    examDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificationexams", x => x.examId);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    courseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.courseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "certificationexams");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
