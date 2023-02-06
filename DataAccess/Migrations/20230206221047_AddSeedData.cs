using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "whiskies",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "whiskies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "start_date",
                table: "infinity_bottle",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "end_date",
                table: "infinity_bottle",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date",
                table: "history",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "sub_category",
                table: "category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "region",
                table: "category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name", "region", "sub_category" },
                values: new object[,]
                {
                    { 1, "Scotch", "Islay", "Islay Single Malt" },
                    { 2, "Scotch", "Highland", "Highland Single Malt" },
                    { 3, "Scotch", "Lowland", "Lowland Single Malt" },
                    { 5, "Scotch", "Strathspey", "Speyside Single Malt" },
                    { 6, "Bourbon", "America", "Kentucky Straight Bourbon Whiskey" },
                    { 7, "Rye", "America", "Kentucky Straight Rye Whiskey" },
                    { 8, "Irish", "Ireland", "Irish Single Malt" }
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "code", "name" },
                values: new object[,]
                {
                    { "CA", "Canada" },
                    { "FR", "France" },
                    { "GB", "United Kingdom" },
                    { "IE", "Ireland" },
                    { "JP", "Japan" },
                    { "NO", "Norway" },
                    { "TW", "Taiwan" },
                    { "US", "United States" }
                });

            migrationBuilder.InsertData(
                table: "history",
                columns: new[] { "id", "amount", "date", "infinity_bottle_id", "whisky_id" },
                values: new object[,]
                {
                    { 1, 4, new DateOnly(2023, 1, 1), 1, 1 },
                    { 2, 4, new DateOnly(2023, 1, 2), 1, 2 },
                    { 3, 4, new DateOnly(2023, 1, 3), 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "infinity_bottle",
                columns: new[] { "id", "bottle_name", "bottle_size", "end_date", "number_of_bottles", "start_date" },
                values: new object[] { 1, "Sample Infinity Bottle", 70, null, 1, new DateOnly(2023, 1, 1) });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "id", "address", "city", "country", "name", "postal_code", "state" },
                values: new object[,]
                {
                    { 1, "222 W Merchandise Mart Plz Ste 1600", "Chicago", "US", "Beam Suntory", "60654", "Illinois" },
                    { 2, "225 S 11th St, Waco", "Waco, Texas", "US", "Balcones Distilling", "76701", "Texas" },
                    { 3, "22 Avenue Montaigne", "Paris", "FR", "LVMH", "75008", null }
                });

            migrationBuilder.InsertData(
                table: "brands",
                columns: new[] { "id", "company_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Laphroaig" },
                    { 2, 3, "Ardmore" },
                    { 3, 3, "Auchentoshan" },
                    { 4, 3, "Bowmore" },
                    { 5, 3, "Glen Garioch" },
                    { 6, 3, "McClelland" },
                    { 7, 3, "Connemara" },
                    { 8, 2, "Balcones" },
                    { 9, 3, "Ardbeg" }
                });

            migrationBuilder.InsertData(
                table: "whiskies",
                columns: new[] { "id", "abv", "age", "brand_id", "category_id", "name", "price" },
                values: new object[,]
                {
                    { 1, 40, 10, 1, 1, "Laphroaig 10 Year Old", null },
                    { 2, 46, 10, 9, 1, "Ardbeg 10 Year Old", null },
                    { 3, 40, 12, 7, 8, "Connemara Peated Single Malt", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "GB");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "IE");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "JP");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "NO");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "TW");

            migrationBuilder.DeleteData(
                table: "history",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "history",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "history",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "infinity_bottle",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "whiskies",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "whiskies",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "whiskies",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "brands",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "FR");

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "code",
                keyValue: "US");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "whiskies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "age",
                table: "whiskies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "infinity_bottle",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "infinity_bottle",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "history",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "sub_category",
                table: "category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "region",
                table: "category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
