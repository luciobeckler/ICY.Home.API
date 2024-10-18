using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICY.Home.API.Migrations
{
    /// <inheritdoc />
    public partial class FristMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    levelEvolucao = table.Column<int>(type: "int", nullable: false),
                    condicaoEvolucao = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    idPokemoEvolucao = table.Column<int>(type: "int", nullable: true),
                    TiposSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
