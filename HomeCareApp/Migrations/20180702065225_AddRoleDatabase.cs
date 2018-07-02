using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCareApp.Migrations
{
    public partial class AddRoleDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Role ([NAME],NormalizedName,Description) VALUES ('Admin','ADMIN','Administrator')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
