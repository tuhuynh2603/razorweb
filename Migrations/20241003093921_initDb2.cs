using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");


            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a =>a.Title, f=>f.Lorem.Sentence(5,5));
            fakerArticle.RuleFor(a => a.Create, f => f.Date.Recent(365));
            fakerArticle.RuleFor(a => a.Content,  f=>f.Lorem.Paragraphs(1,4));
            for(int i = 0; i < 200; i++)
            {
                Article article =  fakerArticle.Generate();
                migrationBuilder.InsertData(
                table:"Articles",
                columns: new[] {"Title", "Create", "Content"},
                values: new object[]
                {
                    article.Title,
                    article.Create,
                    article.Content
                } );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Content",
                keyValue: null,
                column: "Content",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
