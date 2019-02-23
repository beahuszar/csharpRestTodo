using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestTodo.Migrations
{
    public partial class ass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "assigneeId",
                table: "Todos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_assigneeId",
                table: "Todos",
                column: "assigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_assigneeId",
                table: "Todos",
                column: "assigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_assigneeId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Todos_assigneeId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "assigneeId",
                table: "Todos");
        }
    }
}
