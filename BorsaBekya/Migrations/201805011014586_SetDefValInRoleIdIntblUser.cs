namespace BorsaBekya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDefValInRoleIdIntblUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("tblUser", "RoleId", c => c.Int(nullable: false, defaultValue: 2));

        }

        public override void Down()
        {
        }
    }
}
