using Microsoft.EntityFrameworkCore.Migrations;

namespace ScienceNewsBlog.Data.Migrations
{
    public partial class AddArticlesImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Articles");
        }
    }
}
