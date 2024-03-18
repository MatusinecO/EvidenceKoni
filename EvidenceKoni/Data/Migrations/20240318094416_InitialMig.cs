using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidenceKoni.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Horse_HorseId",
                table: "Procedure");

            migrationBuilder.DropTable(
                name: "ProcedureWorker");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "Procedure",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Procedure",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedure_WorkerId",
                table: "Procedure",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Horse_HorseId",
                table: "Procedure",
                column: "HorseId",
                principalTable: "Horse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Worker_WorkerId",
                table: "Procedure",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Horse_HorseId",
                table: "Procedure");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Worker_WorkerId",
                table: "Procedure");

            migrationBuilder.DropIndex(
                name: "IX_Procedure_WorkerId",
                table: "Procedure");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Procedure");

            migrationBuilder.AlterColumn<int>(
                name: "HorseId",
                table: "Procedure",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProcedureWorker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureWorker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureWorker_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProcedureWorker_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureWorker_ProcedureId",
                table: "ProcedureWorker",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureWorker_WorkerId",
                table: "ProcedureWorker",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Horse_HorseId",
                table: "Procedure",
                column: "HorseId",
                principalTable: "Horse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
