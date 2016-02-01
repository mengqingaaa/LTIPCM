namespace LTIPCM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateTime = c.DateTime(precision: 0, storeType: "datetime2"),
                        LastModifyTime = c.DateTime(precision: 0, storeType: "datetime2"),
                        ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.CaseID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "ClientID", "dbo.Clients");
            DropIndex("dbo.Cases", new[] { "ClientID" });
            DropTable("dbo.Cases");
        }
    }
}
