using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UrunAdi = table.Column<string>(type: "TEXT", nullable: false),
                    fiyat = table.Column<double>(type: "REAL", nullable: false),
                    Aktif = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aktif", "UrunAdi", "fiyat" },
                values: new object[,]
                {
                    { 1, false, "Apple Watch 7", 10000.0 },
                    { 2, true, "Apple Watch 8", 20000.0 },
                    { 3, true, "Apple Watch 9", 30000.0 },
                    { 4, false, "Apple Watch 10", 40000.0 },
                    { 5, true, "Apple Watch 11", 50000.0 },
                    { 6, true, "Apple Watch 12", 60000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urunler");
        }
    }
}
