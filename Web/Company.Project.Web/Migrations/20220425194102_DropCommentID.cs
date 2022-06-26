using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class DropCommentID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "CommentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentID",
                table: "Comments",
                newName: "CommentId");
        }
    }
}
