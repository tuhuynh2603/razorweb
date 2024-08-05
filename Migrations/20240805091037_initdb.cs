using System;
using Bogus;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using razorweb.models;

#nullable disable

namespace razorweb.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a =>a.Title, f=>f.Lorem.Sentence(5,5));
            fakerArticle.RuleFor(a => a.Create, f => f.Date.Recent(365));
            fakerArticle.RuleFor(a => a.Content,  f=>f.Lorem.Paragraphs(1,4));
            for(int i = 0; i < 200; i++)
            {
                Article article =  fakerArticle.Generate();
                migrationBuilder.InsertData(
                table:"articles",
                columns: new[] {"Title", "Create", "Content"},
                values: new object[]
                {
                    article.Title,
                    article.Create,
                    article.Content
                } );
            }
            // migrationBuilder.InsertData(
            //     table:"articles",
            //     columns: new[] {"Title", "Create", "Content"},
            //     values: new object[]
            //     {
            //         "Bai viet 2",
            //         new DateTime(2022, 9, 1),
            //         "Noi dung 2"
            //     }
            // );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
