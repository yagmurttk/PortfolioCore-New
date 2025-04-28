using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioCore.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatureImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");
        }
    }
}
