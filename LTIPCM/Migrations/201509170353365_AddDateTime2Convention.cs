namespace LTIPCM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime2Convention : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "CreateTime", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Clients", "LastModifyTime", c => c.DateTime(precision: 0, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "LastModifyTime", c => c.DateTime());
            AlterColumn("dbo.Clients", "CreateTime", c => c.DateTime());
        }
    }
}
