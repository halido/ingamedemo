using Microsoft.EntityFrameworkCore.Migrations;

namespace InGame.BestPractice.Migrations
{
    public partial class Recursive_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            var sp = @"-- =============================================
-- Author:		Halit Muslu
-- Create date: 2018-06-27
-- Description:	Category Tree
-- =============================================
CREATE PROCEDURE GetCategoryTree 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
WITH CategoryTree (Id, Name,Description, ParentCat, Level)
AS
(
-- Anchor member definition
SELECT Id, Name,Description,ParentCategoryId , 0 AS Level
FROM Categories (NOLOCK)
WHERE ParentCategoryId IS NULL
UNION ALL
-- Recursive member definition
SELECT c.Id, c.Name,c.Description,c.ParentCategoryId, Level + 1
FROM Categories c
INNER JOIN CategoryTree ct
ON c.ParentCategoryId = ct.Id
)
Select * from CategoryTree;
    -- Insert statements for procedure here
END
GO
";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Categories");
            migrationBuilder.Sql("DROP PROCEDURE dbo.HelloWorld ");
        }
    }
}
