namespace DXCWebapplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        patid = c.Int(nullable: false),
                        docid = c.Int(nullable: false),
                        time = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docid, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.patid, cascadeDelete: true)
                .Index(t => t.patid)
                .Index(t => t.docid);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        speciality = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        allergies = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sch = c.String(),
                        docid = c.Int(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docid, cascadeDelete: true)
                .Index(t => t.docid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "docid", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "patid", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "docid", "dbo.Doctors");
            DropIndex("dbo.Schedules", new[] { "docid" });
            DropIndex("dbo.Appointments", new[] { "docid" });
            DropIndex("dbo.Appointments", new[] { "patid" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
