using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IninitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    region = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    subcategory = table.Column<string>(name: "sub_category", type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    infinitybottleid = table.Column<int>(name: "infinity_bottle_id", type: "integer", nullable: false),
                    whiskyid = table.Column<int>(name: "whisky_id", type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "infinity_bottle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bottlename = table.Column<string>(name: "bottle_name", type: "text", nullable: false),
                    bottlesize = table.Column<int>(name: "bottle_size", type: "integer", nullable: false),
                    numberofbottles = table.Column<int>(name: "number_of_bottles", type: "integer", nullable: false),
                    startdate = table.Column<DateTime>(name: "start_date", type: "timestamp with time zone", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infinity_bottle", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<string>(type: "varchar(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    companyid = table.Column<int>(name: "company_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                    table.ForeignKey(
                        name: "FK_brands_company_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "whiskies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    brandid = table.Column<int>(name: "brand_id", type: "integer", nullable: false),
                    categoryid = table.Column<int>(name: "category_id", type: "integer", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    abv = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_whiskies", x => x.id);
                    table.ForeignKey(
                        name: "FK_whiskies_brands_brand_id",
                        column: x => x.brandid,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_whiskies_category_category_id",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brands_company_id",
                table: "brands",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_brands_name",
                table: "brands",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_category_name",
                table: "category",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_category_region",
                table: "category",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "IX_category_sub_category",
                table: "category",
                column: "sub_category");

            migrationBuilder.CreateIndex(
                name: "IX_company_CountryId",
                table: "company",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_company_name",
                table: "company",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_country_code",
                table: "country",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_country_name",
                table: "country",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_history_date",
                table: "history",
                column: "date");

            migrationBuilder.CreateIndex(
                name: "IX_infinity_bottle_bottle_name",
                table: "infinity_bottle",
                column: "bottle_name");

            migrationBuilder.CreateIndex(
                name: "IX_whiskies_brand_id",
                table: "whiskies",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_whiskies_category_id",
                table: "whiskies",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_whiskies_name",
                table: "whiskies",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "history");

            migrationBuilder.DropTable(
                name: "infinity_bottle");

            migrationBuilder.DropTable(
                name: "whiskies");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
