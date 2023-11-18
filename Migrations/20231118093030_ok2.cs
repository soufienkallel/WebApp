using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class ok2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Producers_ProdID",
                table: "Films");

            migrationBuilder.CreateTable(
                name: "FavoriteFilms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteFilms_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteFilms_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFilms_FilmId",
                table: "FavoriteFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFilms_UserID",
                table: "FavoriteFilms",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Producers_ProdID",
                table: "Films",
                column: "ProdID",
                principalTable: "Producers",
                principalColumn: "ProdID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Producers_ProdID",
                table: "Films");

            migrationBuilder.DropTable(
                name: "FavoriteFilms");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Producers_ProdID",
                table: "Films",
                column: "ProdID",
                principalTable: "Producers",
                principalColumn: "ProdID");
        }
    }
}
