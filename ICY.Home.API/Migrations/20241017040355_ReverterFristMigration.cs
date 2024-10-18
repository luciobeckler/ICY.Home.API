using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICY.Home.API.Migrations
{
    /// <inheritdoc />
    public partial class ReverterFristMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TiposSerialized",
                table: "Pokemons",
                newName: "TiposSerializados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TiposSerializados",
                table: "Pokemons",
                newName: "TiposSerialized");
        }
    }
}
