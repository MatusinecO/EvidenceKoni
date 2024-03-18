using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidenceKoni.Data.Migrations
{
    /// <inheritdoc />
    public partial class PWMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Horse_HorseId",
                table: "ProcedureWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureId",
                table: "ProcedureWorker");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "ProcedureWorker",
                newName: "ProcedureID");

            migrationBuilder.RenameColumn(
                name: "HorseId",
                table: "ProcedureWorker",
                newName: "HorseID");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_ProcedureId",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_ProcedureID");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_HorseId",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_HorseID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Horse_HorseID",
                table: "ProcedureWorker",
                column: "HorseID",
                principalTable: "Horse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureID",
                table: "ProcedureWorker",
                column: "ProcedureID",
                principalTable: "Procedure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Horse_HorseID",
                table: "ProcedureWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureID",
                table: "ProcedureWorker");

            migrationBuilder.RenameColumn(
                name: "ProcedureID",
                table: "ProcedureWorker",
                newName: "ProcedureId");

            migrationBuilder.RenameColumn(
                name: "HorseID",
                table: "ProcedureWorker",
                newName: "HorseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_ProcedureID",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_HorseID",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_HorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Horse_HorseId",
                table: "ProcedureWorker",
                column: "HorseId",
                principalTable: "Horse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureId",
                table: "ProcedureWorker",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
