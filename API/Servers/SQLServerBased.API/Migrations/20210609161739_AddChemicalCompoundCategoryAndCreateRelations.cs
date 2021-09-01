using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLServerBased.API.Migrations
{
    public partial class AddChemicalCompoundCategoryAndCreateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompoundCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompoundCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compound",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MolecularFormula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompoundCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compound", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compound_CompoundCategory_CompoundCategoryId",
                        column: x => x.CompoundCategoryId,
                        principalTable: "CompoundCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalElementCompound",
                columns: table => new
                {
                    ChemicalElementsId = table.Column<int>(type: "int", nullable: false),
                    CompoundsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalElementCompound", x => new { x.ChemicalElementsId, x.CompoundsId });
                    table.ForeignKey(
                        name: "FK_ChemicalElementCompound_ChemicalElements_ChemicalElementsId",
                        column: x => x.ChemicalElementsId,
                        principalTable: "ChemicalElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChemicalElementCompound_Compound_CompoundsId",
                        column: x => x.CompoundsId,
                        principalTable: "Compound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalElementCompound_CompoundsId",
                table: "ChemicalElementCompound",
                column: "CompoundsId");

            migrationBuilder.CreateIndex(
                name: "IX_Compound_CompoundCategoryId",
                table: "Compound",
                column: "CompoundCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalElementCompound");

            migrationBuilder.DropTable(
                name: "Compound");

            migrationBuilder.DropTable(
                name: "CompoundCategory");
        }
    }
}
