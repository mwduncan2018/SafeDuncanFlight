namespace DemoWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_RegisteredUsers_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        RegisteredUserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.RegisteredUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisteredUsers");
        }
    }
}
