namespace LTIPCM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "CreateTime", c => c.DateTime());
            AlterColumn("dbo.Clients", "LastModifyTime", c => c.DateTime());
            AlterColumn("dbo.Clients", "Enable", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Enable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Clients", "LastModifyTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
