namespace LTIPCM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        NameEng = c.String(),
                        NameChn = c.String(),
                        Address1Eng = c.String(),
                        Address2Eng = c.String(),
                        Address1Chn = c.String(),
                        Address2Chn = c.String(),
                        Zip = c.String(),
                        Tel1 = c.String(),
                        Tel2 = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Homepage = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        LastModifyTime = c.DateTime(nullable: false),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
