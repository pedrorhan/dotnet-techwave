using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUrunEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", true, "1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", true, "2.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", true, "3.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", "4.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", "5.jpeg" });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Aktif", "Anasayfa", "Resim" },
                values: new object[] { "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", false, true, "6.jpeg" });

            migrationBuilder.InsertData(
                table: "Urunler",
                columns: new[] { "Id", "Aciklama", "Aktif", "Anasayfa", "Resim", "UrunAdi", "fiyat" },
                values: new object[,]
                {
                    { 7, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", false, true, "7.jpeg", "Apple Watch 13", 70000.0 },
                    { 8, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Tempora voluptatum harum, maxime ullam excepturi amet voluptas corporis, dolorum nam perspiciatis quos libero ipsam similique ratione laboriosam fugiat neque quidem rerum.", true, true, "8.jpeg", "Apple Watch 14", 80000.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { null, false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { null, false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Aciklama", "Anasayfa", "Resim" },
                values: new object[] { null, false, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Aciklama", "Resim" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Urunler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Aciklama", "Aktif", "Anasayfa", "Resim" },
                values: new object[] { null, true, false, null });
        }
    }
}
