using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_2_0.Migrations
{
    /// <inheritdoc />
    public partial class initialdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false),
                    CrsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrsResults",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResults", x => new { x.CrsId, x.TraineeId });
                    table.ForeignKey(
                        name: "FK_CrsResults_Courses_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrsResults_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Mr. Farag", "Software" },
                    { 2, "Ms. Salma", "Networks" },
                    { 3, "Dr. Hanaa", "AI" },
                    { 4, "Eng. Karim", "Security" },
                    { 5, "Dr. Mona", "Bioinformatics" },
                    { 6, "Eng. Omar", "Embedded" },
                    { 7, "Dr. Amina", "Data Science" },
                    { 8, "Ms. Layla", "Cloud" },
                    { 9, "Mr. Hatem", "Robotics" },
                    { 10, "Ms. Nour", "Design" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Degree", "DeptId", "Hours", "MinDegree", "Name" },
                values: new object[,]
                {
                    { 1, 100, 1, 30, 50, "C#" },
                    { 2, 100, 2, 25, 60, "SQL" },
                    { 3, 100, 3, 40, 55, "AI Basics" },
                    { 4, 100, 4, 35, 65, "Ethical Hacking" },
                    { 5, 100, 5, 45, 60, "Genomics" },
                    { 6, 100, 6, 20, 50, "Microcontrollers" },
                    { 7, 100, 7, 50, 70, "ML with Python" },
                    { 8, 100, 8, 30, 60, "AWS" },
                    { 9, 100, 9, 28, 60, "Arduino" },
                    { 10, 100, 10, 32, 50, "UX Design" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Address", "DeptId", "Grade", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "City 1", 1, "B", "trainee1.png", "Trainee 1" },
                    { 2, "City 2", 2, "A", "trainee2.png", "Trainee 2" },
                    { 3, "City 3", 3, "B", "trainee3.png", "Trainee 3" },
                    { 4, "City 4", 4, "A", "trainee4.png", "Trainee 4" },
                    { 5, "City 5", 5, "B", "trainee5.png", "Trainee 5" },
                    { 6, "City 6", 6, "A", "trainee6.png", "Trainee 6" },
                    { 7, "City 7", 7, "B", "trainee7.png", "Trainee 7" },
                    { 8, "City 8", 8, "A", "trainee8.png", "Trainee 8" },
                    { 9, "City 9", 9, "B", "trainee9.png", "Trainee 9" },
                    { 10, "City 10", 10, "A", "trainee10.png", "Trainee 10" }
                });

            migrationBuilder.InsertData(
                table: "CrsResults",
                columns: new[] { "CrsId", "TraineeId", "Degree", "Id" },
                values: new object[,]
                {
                    { 1, 1, 61, 0 },
                    { 2, 2, 62, 0 },
                    { 3, 3, 63, 0 },
                    { 4, 4, 64, 0 },
                    { 5, 5, 65, 0 },
                    { 6, 6, 66, 0 },
                    { 7, 7, 67, 0 },
                    { 8, 8, 68, 0 },
                    { 9, 9, 69, 0 },
                    { 10, 10, 70, 0 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "CrsId", "DeptId", "ImageUrl", "Name", "Salary" },
                values: new object[,]
                {
                    { 1, "Town 1", 1, 1, "instructor1.png", "Instructor 1", 5100m },
                    { 2, "Town 2", 2, 2, "instructor2.png", "Instructor 2", 5200m },
                    { 3, "Town 3", 3, 3, "instructor3.png", "Instructor 3", 5300m },
                    { 4, "Town 4", 4, 4, "instructor4.png", "Instructor 4", 5400m },
                    { 5, "Town 5", 5, 5, "instructor5.png", "Instructor 5", 5500m },
                    { 6, "Town 6", 6, 6, "instructor6.png", "Instructor 6", 5600m },
                    { 7, "Town 7", 7, 7, "instructor7.png", "Instructor 7", 5700m },
                    { 8, "Town 8", 8, 8, "instructor8.png", "Instructor 8", 5800m },
                    { 9, "Town 9", 9, 9, "instructor9.png", "Instructor 9", 5900m },
                    { 10, "Town 10", 10, 10, "instructor10.png", "Instructor 10", 6000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_TraineeId",
                table: "CrsResults",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CrsId",
                table: "Instructors",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DeptId",
                table: "Instructors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DeptId",
                table: "Trainees",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
