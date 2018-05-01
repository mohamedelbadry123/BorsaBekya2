namespace BorsaBekya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityToUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUser_meta", "UserId", "dbo.tblUser");
            DropPrimaryKey("dbo.tblUser");
            AlterColumn("dbo.tblUser", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblUser", "Id");
            AddForeignKey("dbo.tblUser_meta", "UserId", "dbo.tblUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUser_meta", "UserId", "dbo.tblUser");
            DropPrimaryKey("dbo.tblUser");
            AlterColumn("dbo.tblUser", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tblUser", "Id");
            AddForeignKey("dbo.tblUser_meta", "UserId", "dbo.tblUser", "Id", cascadeDelete: true);
        }
    }
}
