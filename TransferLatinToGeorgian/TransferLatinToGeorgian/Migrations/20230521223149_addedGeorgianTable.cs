using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransferLatinToGeorgian.Migrations
{
    /// <inheritdoc />
    public partial class addedGeorgianTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reestriGeos",
                columns: table => new
                {
                    piradi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gvari = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saxeli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mamisSaxeli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sqesi = table.Column<double>(type: "float", nullable: true),
                    dabWeli = table.Column<DateTime>(type: "datetime2", nullable: true),
                    regTariRi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DMONAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mocmobisNomeri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quCa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REGMDAT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reestriGeos", x => x.piradi);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reestriGeos");
        }
    }
}
