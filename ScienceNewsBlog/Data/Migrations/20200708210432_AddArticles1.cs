using Microsoft.EntityFrameworkCore.Migrations;

namespace ScienceNewsBlog.Data.Migrations
{
    public partial class AddArticles1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
