using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Project.Web.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "Events",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "organiser",
                table: "Events",
                newName: "Organiser");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "invitees",
                table: "Events",
                newName: "Invitees");

            migrationBuilder.RenameColumn(
                name: "eventType",
                table: "Events",
                newName: "EventType");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Events",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Events",
                newName: "Date");

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
                name: "Title",
                table: "Events",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Events",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "Organiser",
                table: "Events",
                newName: "organiser");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Invitees",
                table: "Events",
                newName: "invitees");

            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "Events",
                newName: "eventType");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Events",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Events",
                newName: "date");

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
