using Microsoft.EntityFrameworkCore.Migrations;

namespace ScienceNewsBlog.Data.Migrations
{
    public partial class AddArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Articles");
        }
    }
}
