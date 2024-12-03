using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SannoisWorship.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChantAccordPartitionRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accord_Chants_ChantId",
                table: "Accord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accord",
                table: "Accord");

            migrationBuilder.DropIndex(
                name: "IX_Accord_ChantId",
                table: "Accord");

            migrationBuilder.RenameTable(
                name: "Accord",
                newName: "Accords");

            migrationBuilder.RenameColumn(
                name: "ChantId",
                table: "Accords",
                newName: "Frets");

            migrationBuilder.AddColumn<string>(
                name: "Bass",
                table: "Accords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PartitionId",
                table: "Accords",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accords",
                table: "Accords",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Partitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partitions_Chants_ChantId",
                        column: x => x.ChantId,
                        principalTable: "Chants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accords_PartitionId",
                table: "Accords",
                column: "PartitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Partitions_ChantId",
                table: "Partitions",
                column: "ChantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accords_Partitions_PartitionId",
                table: "Accords",
                column: "PartitionId",
                principalTable: "Partitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accords_Partitions_PartitionId",
                table: "Accords");

            migrationBuilder.DropTable(
                name: "Partitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accords",
                table: "Accords");

            migrationBuilder.DropIndex(
                name: "IX_Accords_PartitionId",
                table: "Accords");

            migrationBuilder.DropColumn(
                name: "Bass",
                table: "Accords");

            migrationBuilder.DropColumn(
                name: "PartitionId",
                table: "Accords");

            migrationBuilder.RenameTable(
                name: "Accords",
                newName: "Accord");

            migrationBuilder.RenameColumn(
                name: "Frets",
                table: "Accord",
                newName: "ChantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accord",
                table: "Accord",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accord_ChantId",
                table: "Accord",
                column: "ChantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accord_Chants_ChantId",
                table: "Accord",
                column: "ChantId",
                principalTable: "Chants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
