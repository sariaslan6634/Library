using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_YeniKitapEkleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b1b2c3d4-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "PageNumber", "Title", "Writer" },
                values: new object[] { "Dostoyevski'nin başyapıtı", 671, "Suç ve Ceza", "Fyodor Dostoyevski" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "IsAvailable", "PageNumber", "Title", "Writer" },
                values: new object[] { new Guid("b1b2c3d4-0000-0000-0000-000000000002"), "Distopik bir gelecek hikayesi", false, 328, "1984", "George Orwell" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b1b2c3d4-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b1b2c3d4-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "PageNumber", "Title", "Writer" },
                values: new object[] { "Description", 200, "Title", "Writer" });
        }
    }
}
