using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ekipage.Migrations
{
    public partial class MoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horse",
                columns: table => new
                {
                    HorseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseName = table.Column<string>(nullable: false),
                    HorseTemper = table.Column<string>(nullable: true),
                    HorseDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horse", x => x.HorseId);
                });

            migrationBuilder.CreateTable(
                name: "LessonContent",
                columns: table => new
                {
                    LessonContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lesson = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContent", x => x.LessonContentId);
                });

            migrationBuilder.CreateTable(
                name: "Rider",
                columns: table => new
                {
                    RiderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiderName = table.Column<string>(nullable: false),
                    Preference = table.Column<string>(nullable: true),
                    HorseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rider", x => x.RiderId);
                    table.ForeignKey(
                        name: "FK_Rider_Horse_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horse",
                        principalColumn: "HorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateForLesson",
                columns: table => new
                {
                    DateForLessonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    LessonContentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateForLesson", x => x.DateForLessonId);
                    table.ForeignKey(
                        name: "FK_DateForLesson_LessonContent_LessonContentId",
                        column: x => x.LessonContentId,
                        principalTable: "LessonContent",
                        principalColumn: "LessonContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateForLesson_LessonContentId",
                table: "DateForLesson",
                column: "LessonContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rider_HorseId",
                table: "Rider",
                column: "HorseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateForLesson");

            migrationBuilder.DropTable(
                name: "Rider");

            migrationBuilder.DropTable(
                name: "LessonContent");

            migrationBuilder.DropTable(
                name: "Horse");
        }
    }
}
