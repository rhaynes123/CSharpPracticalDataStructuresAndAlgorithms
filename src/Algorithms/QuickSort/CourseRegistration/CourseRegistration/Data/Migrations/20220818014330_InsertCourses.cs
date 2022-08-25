using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseRegistration.Data.Migrations
{
    public partial class InsertCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string RawSql = $@"
                    INSERT INTO Courses(`Name`) Values('Religious Studies');
                    INSERT INTO Courses(`Name`) Values('Physics I');
                    INSERT INTO Courses(`Name`) Values('Physics II');
                    INSERT INTO Courses(`Name`) Values('Computer Science 101');";
            migrationBuilder.Sql(RawSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
