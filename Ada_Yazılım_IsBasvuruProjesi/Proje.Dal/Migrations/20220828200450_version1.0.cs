using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Dal.Migrations
{
    public partial class version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trenler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    RezervasyonYapilacakKisiSayisi = table.Column<int>(nullable: false),
                    KisilerFarkliVagonlaraYerlestirilebilir = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vagonlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<bool>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Kapasite = table.Column<int>(nullable: false),
                    DoluKoltukAdet = table.Column<int>(nullable: false),
                    TrenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagonlar_Trenler_TrenId",
                        column: x => x.TrenId,
                        principalTable: "Trenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vagonlar_TrenId",
                table: "Vagonlar",
                column: "TrenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vagonlar");

            migrationBuilder.DropTable(
                name: "Trenler");
        }
    }
}
