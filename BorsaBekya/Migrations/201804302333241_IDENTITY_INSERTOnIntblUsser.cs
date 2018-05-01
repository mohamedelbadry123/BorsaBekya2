namespace BorsaBekya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDENTITY_INSERTOnIntblUsser : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [tblUser] On");
        }
        
        public override void Down()
        {
        }
    }
}
