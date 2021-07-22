using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMoviesApp.Migrations
{
    public partial class AddTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    IdM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearM = table.Column<int>(type: "int", nullable: false),
                    statusM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingM = table.Column<int>(type: "int", nullable: false),
                    MovieTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.IdM);
                    table.ForeignKey(
                        name: "FK_Movies_MovieTypes_MovieTypeID",
                        column: x => x.MovieTypeID,
                        principalTable: "MovieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesTV",
                columns: table => new
                {
                    IdS = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearS = table.Column<int>(type: "int", nullable: false),
                    statusS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingS = table.Column<int>(type: "int", nullable: false),
                    MovieTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesTV", x => x.IdS);
                    table.ForeignKey(
                        name: "FK_SeriesTV_MovieTypes_MovieTypeId",
                        column: x => x.MovieTypeId,
                        principalTable: "MovieTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTypeID",
                table: "Movies",
                column: "MovieTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesTV_MovieTypeId",
                table: "SeriesTV",
                column: "MovieTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "SeriesTV");

            migrationBuilder.DropTable(
                name: "MovieTypes");
        }
    }
}
