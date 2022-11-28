using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataverseMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ContactPhone", "Email", "Firstname", "Surname" },
                values: new object[,]
                {
                    { 1, "4083 Bluff Street", "+306948521396", "HamedJeihlan@gmail.com", "Hamed", "Jeihlan" },
                    { 2, "1079 West Street", "+306948521391", "LongLien@gmail.com", "Long", "Lien" },
                    { 3, "1180 West Fork Drive", "+306948321396", "HamedJeihlan@gmail.com", "Hamed", "Jeihlan" },
                    { 4, "3841 Agriculture Lane", "+306948621396", "AdrinDatsk@gmail.com", "Adrin", "Datsk" },
                    { 5, "288 Ridenour Street", "+306948521296", "DostilOnzurnes@gmail.com", "Dostil", "Onzurnes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
