using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampsitesApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    SiteName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    HasWater = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasElectricalHookup = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsLakeFront = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
