namespace Altkom.Siemens.CSharp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Instructor_InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorId, cascadeDelete: true)
                .Index(t => t.Instructor_InstructorId);
            
            CreateTable(
                "dbo.ClassStudents",
                c => new
                    {
                        Class_ClassId = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Class_ClassId, t.Student_StudentId })
                .ForeignKey("dbo.Classes", t => t.Class_ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Class_ClassId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.ClassStudents", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "Instructor_InstructorId", "dbo.Instructors");
            DropIndex("dbo.ClassStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.ClassStudents", new[] { "Class_ClassId" });
            DropIndex("dbo.Classes", new[] { "Instructor_InstructorId" });
            DropTable("dbo.ClassStudents");
            DropTable("dbo.Classes");
        }
    }
}
