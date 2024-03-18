using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvidenceKoni.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProcedureWorkerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Procedure");

            migrationBuilder.CreateTable(
                name: "ProcedureWorker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorseId = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureWorker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureWorker_Horse_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureWorker_Procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureWorker_HorseId",
                table: "ProcedureWorker",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureWorker_ProcedureId",
                table: "ProcedureWorker",
                column: "ProcedureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedureWorker");

            migrationBuilder.AddColumn<int>(
                name: "Profession",
                table: "Procedure",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
