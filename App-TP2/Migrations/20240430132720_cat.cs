using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_TP2.Migrations
{
    /// <inheritdoc />
    public partial class cat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "souscategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorieid = table.Column<int>(type: "int", nullable: false),
                    nomCat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_souscategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_souscategories_categorie_Categorieid",
                        column: x => x.Categorieid,
                        principalTable: "categorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_souscategories_Categorieid",
                table: "souscategories",
                column: "Categorieid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "souscategories");

            migrationBuilder.DropTable(
                name: "categorie");
        }
    }
}
