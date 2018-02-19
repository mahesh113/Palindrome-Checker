namespace pAPP_Palindrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_PalindromeStrings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PStrings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PStrings");
        }
    }
}
