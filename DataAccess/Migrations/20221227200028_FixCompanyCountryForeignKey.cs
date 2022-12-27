using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCompanyCountryForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_country_CountryId",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_CountryId",
                table: "company");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "company");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "company",
                type: "varchar(2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_country",
                table: "company",
                column: "country");

            migrationBuilder.AddForeignKey(
                name: "FK_company_country_country",
                table: "company",
                column: "country",
                principalTable: "country",
                principalColumn: "code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_company_country_country",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_country",
                table: "company");

            migrationBuilder.AlterColumn<string>(
                name: "country",
                table: "company",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "company",
                type: "varchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_CountryId",
                table: "company",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_company_country_CountryId",
                table: "company",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "code");
        }
    }
}
