using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Lib.Migrations
{
    /// <inheritdoc />
    public partial class Courses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    LikesInProcent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumbersOfLikes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDigital = table.Column<bool>(type: "bit", nullable: false),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BigImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            // Seed Categories
            migrationBuilder.Sql(
                @"INSERT INTO Categories (CategoryName) VALUES
                ('Frontend Development'),
                ('App Development'),
                ('Python'),
                ('HTML & CSS'),
                ('Game Development');"
            );

            // Seed Courses
            migrationBuilder.Sql(
                @"INSERT INTO Courses (Id, Title, Author, OriginalPrice, Hours, IsDigital, IsBestSeller, Created, LastUpdated, ImageUrl, BigImageUrl, CategoryId) VALUES
                (NEWID(), 'Fullstack Web Developer Course from Scratch', 'Robert Fox', 12.50, 220, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_1.svg', '~/images/courses/course_1_big.svg', 1),
                (NEWID(), 'HTML, CSS, JavaScript Web Developer', 'Jenny Wilson & Marvin McKinney', 15.99, 160, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_2.svg', NULL, 1),
                (NEWID(), 'The Complete Front-End Web Development Course', 'Albert Flores', 44.99, 100, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_3.svg', NULL, 1),
                (NEWID(), 'iOS & Swift - The Complete iOS App Development Course', 'Marvin McKinney', 15.99, 160, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_4.svg', NULL, 2),
                (NEWID(), 'Data Science & Machine Learning with Python', 'Esther Howard', 11.20, 160, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_5.svg', NULL, 3),
                (NEWID(), 'Creative CSS Drawing Course: Make Art With CSS', 'Robert Fox', 10.50, 220, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_6.svg', NULL, 4),
                (NEWID(), 'Blender Character Creator v2.0 for Video Games Design', 'Ralph Edwards', 18.99, 160, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_7.svg', NULL, 5),
                (NEWID(), 'The Ultimate Guide to 2D Mobile Game Development with Unity', 'Albert Flores', 44.99, 100, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_8.svg', NULL, 5),
                (NEWID(), 'Learn JMETER from Scratch on Live Apps-Performance Testing', 'Jenny Wilson', 14.50, 160, 1, 0, GETDATE(), GETDATE(), '~/images/courses/course_9.svg', NULL, 2);"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
