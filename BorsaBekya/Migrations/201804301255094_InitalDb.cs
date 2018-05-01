namespace BorsaBekya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.tblCity",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCountry", t => t.CountryId, cascadeDelete: true);
            
            CreateTable(
                "dbo.tblCountry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.tblRegion",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCity", t => t.CityId, cascadeDelete: true);
            
            CreateTable(
                "dbo.tblRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.tblUser",
                    c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Image = c.String(),
                        RoleId = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        AuthKey = c.Guid(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRole", t => t.RoleId, cascadeDelete: true);

            CreateTable(
                    "dbo.tblUser_meta",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ColName = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUser_meta", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblUser", "RoleId", "dbo.tblRole");
            DropForeignKey("dbo.tblRegion", "CityId", "dbo.tblCity");
            DropForeignKey("dbo.tblCity", "CountryId", "dbo.tblCountry");
            DropTable("dbo.tblUser_meta");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblRole");
            DropTable("dbo.tblRegion");
            DropTable("dbo.tblCountry");
            DropTable("dbo.tblCity");
        }
    }
}
