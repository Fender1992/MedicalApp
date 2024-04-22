using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class StoreGenderAsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        UPDATE Users 
        SET Gender = CASE 
            WHEN Gender = 0 THEN 'Male' 
            WHEN Gender = 1 THEN 'Female' 
            ELSE 'Other' 
        END");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
