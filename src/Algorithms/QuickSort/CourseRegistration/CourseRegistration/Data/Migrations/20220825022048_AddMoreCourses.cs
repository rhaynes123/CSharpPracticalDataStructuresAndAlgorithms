using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseRegistration.Data.Migrations
{
    public partial class AddMoreCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string RawSql = $@"
                    INSERT INTO Courses(`Name`) Values('Women Studies');
                    INSERT INTO Courses(`Name`) Values('Intro to Python');
                    INSERT INTO Courses(`Name`) Values('History of Jazz');
                    INSERT INTO Courses(`Name`) Values('Computer Science 201');";
            migrationBuilder.Sql(RawSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
