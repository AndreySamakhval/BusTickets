namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voyage", "VoyageNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Voyage", "NumberOfSeets", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voyage", "NumberOfSeets", c => c.String(nullable: false));
            AlterColumn("dbo.Voyage", "VoyageNumber", c => c.Int(nullable: false));
        }
    }
}
