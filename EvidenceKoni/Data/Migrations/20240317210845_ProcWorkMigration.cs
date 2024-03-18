using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidenceKoni.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcWorkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_ProcedureID",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_ProcedureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_HorseID",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_WorkerId");

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureId",
                table: "ProcedureWorker",
                column: "ProcedureId",
                principalTable: "Procedure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureWorker_Worker_WorkerId",
                table: "ProcedureWorker",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Procedure_ProcedureId",
                table: "ProcedureWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureWorker_Worker_WorkerId",
                table: "ProcedureWorker");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.RenameColumn(
                name: "ProcedureId",
                table: "ProcedureWorker",
                newName: "ProcedureID");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "ProcedureWorker",
                newName: "HorseID");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_ProcedureId",
                table: "ProcedureWorker",
                newName: "IX_ProcedureWorker_ProcedureID");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureWorker_WorkerId",
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
    }
}
