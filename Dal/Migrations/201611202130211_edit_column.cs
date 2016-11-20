namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserName", c => c.String());
            DropColumn("dbo.Order", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "UserName");
        }
    }
}
