namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_userId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "UserId");
        }
    }
}
