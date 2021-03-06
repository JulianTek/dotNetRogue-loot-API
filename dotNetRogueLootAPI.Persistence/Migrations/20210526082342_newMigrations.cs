using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNetRogueLootAPI.Persistence.Migrations
{
    public partial class newMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effects",
                columns: table => new
                {
                    EffectName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeaponNameFix = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BonusDamage = table.Column<int>(type: "int", nullable: false),
                    BonusHealing = table.Column<int>(type: "int", nullable: false),
                    ExtraHits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effects", x => x.EffectName);
                });

            migrationBuilder.CreateTable(
                name: "WeaponRarities",
                columns: table => new
                {
                    RarityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppearChance = table.Column<int>(type: "int", nullable: false),
                    StatModMul = table.Column<double>(type: "float", nullable: false),
                    AmountOfEffects = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponRarities", x => x.RarityName);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DodgeChance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Effects");

            migrationBuilder.DropTable(
                name: "WeaponRarities");

            migrationBuilder.DropTable(
                name: "WeaponTypes");
        }
    }
}
