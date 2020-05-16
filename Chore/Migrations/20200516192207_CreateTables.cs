using Microsoft.EntityFrameworkCore.Migrations;

namespace ChoreServiceBusHost.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chores_ChoreSprints_ChoreSprintId",
                table: "Chores");

            migrationBuilder.DropForeignKey(
                name: "FK_Chores_Partners_PartnerId",
                table: "Chores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partners",
                table: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreSprints",
                table: "ChoreSprints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chores",
                table: "Chores");

            migrationBuilder.RenameTable(
                name: "Partners",
                newName: "Partner");

            migrationBuilder.RenameTable(
                name: "ChoreSprints",
                newName: "ChoreSpring");

            migrationBuilder.RenameTable(
                name: "Chores",
                newName: "Chore");

            migrationBuilder.RenameIndex(
                name: "IX_Chores_PartnerId",
                table: "Chore",
                newName: "IX_Chore_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Chores_ChoreSprintId",
                table: "Chore",
                newName: "IX_Chore_ChoreSprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partner",
                table: "Partner",
                column: "PartnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreSpring",
                table: "ChoreSpring",
                column: "ChoreSprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chore",
                table: "Chore",
                column: "ChoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_ChoreSpring_ChoreSprintId",
                table: "Chore",
                column: "ChoreSprintId",
                principalTable: "ChoreSpring",
                principalColumn: "ChoreSprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chore_Partner_PartnerId",
                table: "Chore",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "PartnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chore_ChoreSpring_ChoreSprintId",
                table: "Chore");

            migrationBuilder.DropForeignKey(
                name: "FK_Chore_Partner_PartnerId",
                table: "Chore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partner",
                table: "Partner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreSpring",
                table: "ChoreSpring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chore",
                table: "Chore");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partners");

            migrationBuilder.RenameTable(
                name: "ChoreSpring",
                newName: "ChoreSprints");

            migrationBuilder.RenameTable(
                name: "Chore",
                newName: "Chores");

            migrationBuilder.RenameIndex(
                name: "IX_Chore_PartnerId",
                table: "Chores",
                newName: "IX_Chores_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Chore_ChoreSprintId",
                table: "Chores",
                newName: "IX_Chores_ChoreSprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partners",
                table: "Partners",
                column: "PartnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreSprints",
                table: "ChoreSprints",
                column: "ChoreSprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chores",
                table: "Chores",
                column: "ChoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_ChoreSprints_ChoreSprintId",
                table: "Chores",
                column: "ChoreSprintId",
                principalTable: "ChoreSprints",
                principalColumn: "ChoreSprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chores_Partners_PartnerId",
                table: "Chores",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "PartnerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
