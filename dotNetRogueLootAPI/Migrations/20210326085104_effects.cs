using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetRogueLootAPI.Migrations
{
    public partial class effects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    EffectName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeaponNameFix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BonusDamage = table.Column<int>(type: "int", nullable: false),
                    BonusHealing = table.Column<int>(type: "int", nullable: false),
                    ExtraHits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.EffectName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effects");
        }
    }
}
