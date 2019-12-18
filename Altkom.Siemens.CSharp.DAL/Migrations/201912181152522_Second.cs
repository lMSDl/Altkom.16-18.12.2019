namespace Altkom.Siemens.CSharp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instructors", "Specialization", c => c.String(maxLength: 32));
            AlterColumn("dbo.Instructors", "FirstName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Instructors", "LastName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Instructors", "LastName", c => c.String());
            AlterColumn("dbo.Instructors", "FirstName", c => c.String());
            AlterColumn("dbo.Instructors", "Specialization", c => c.String());
        }
    }
}
