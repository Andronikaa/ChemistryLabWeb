using Microsoft.EntityFrameworkCore.Migrations;

namespace SQLServerBased.API.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalElementCompound_Compound_CompoundsId",
                table: "ChemicalElementCompound");

            migrationBuilder.DropForeignKey(
                name: "FK_Compound_CompoundCategory_CompoundCategoryId",
                table: "Compound");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompoundCategory",
                table: "CompoundCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compound",
                table: "Compound");

            migrationBuilder.RenameTable(
                name: "CompoundCategory",
                newName: "CompoundCategories");

            migrationBuilder.RenameTable(
                name: "Compound",
                newName: "Compounds");

            migrationBuilder.RenameIndex(
                name: "IX_Compound_CompoundCategoryId",
                table: "Compounds",
                newName: "IX_Compounds_CompoundCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompoundCategories",
                table: "CompoundCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compounds",
                table: "Compounds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalElementCompound_Compounds_CompoundsId",
                table: "ChemicalElementCompound",
                column: "CompoundsId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compounds_CompoundCategories_CompoundCategoryId",
                table: "Compounds",
                column: "CompoundCategoryId",
                principalTable: "CompoundCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChemicalElementCompound_Compounds_CompoundsId",
                table: "ChemicalElementCompound");

            migrationBuilder.DropForeignKey(
                name: "FK_Compounds_CompoundCategories_CompoundCategoryId",
                table: "Compounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compounds",
                table: "Compounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompoundCategories",
                table: "CompoundCategories");

            migrationBuilder.RenameTable(
                name: "Compounds",
                newName: "Compound");

            migrationBuilder.RenameTable(
                name: "CompoundCategories",
                newName: "CompoundCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Compounds_CompoundCategoryId",
                table: "Compound",
                newName: "IX_Compound_CompoundCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compound",
                table: "Compound",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompoundCategory",
                table: "CompoundCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChemicalElementCompound_Compound_CompoundsId",
                table: "ChemicalElementCompound",
                column: "CompoundsId",
                principalTable: "Compound",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compound_CompoundCategory_CompoundCategoryId",
                table: "Compound",
                column: "CompoundCategoryId",
                principalTable: "CompoundCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
