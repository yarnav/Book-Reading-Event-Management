using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class renameCommentmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "timeStamp",
                table: "Comment",
                newName: "TimeStamp");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Comment",
                newName: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Comment",
                newName: "timeStamp");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Comment",
                newName: "comment");
        }
    }
}
