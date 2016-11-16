namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoyageId = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Voyage", t => t.VoyageId, cascadeDelete: true)
                .Index(t => t.VoyageId);
            
            CreateTable(
                "dbo.Voyage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArrivalDateTime = c.DateTime(nullable: false),
                        TravelTime = c.Time(nullable: false, precision: 7),
                        VoyageNumber = c.Int(nullable: false),
                        VoyageName = c.String(nullable: false),
                        NumberOfSeets = c.String(nullable: false),
                        TicketCost = c.Int(nullable: false),
                        DepartureStopId = c.Int(nullable: false),
                        ArivalStopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stop", t => t.ArivalStopId, cascadeDelete: false)
                .ForeignKey("dbo.Stop", t => t.DepartureStopId, cascadeDelete: true)
                .Index(t => t.DepartureStopId)
                .Index(t => t.ArivalStopId);
            
            //CreateTable(
            //    "dbo.Stop",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Description = c.String(nullable: false),
            //            Status = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        PassengerName = c.String(nullable: false),
                        PassengerDocumentNumber = c.String(nullable: false),
                        SeetNumber = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "VoyageId", "dbo.Voyage");
            DropForeignKey("dbo.Voyage", "DepartureStopId", "dbo.Stop");
            DropForeignKey("dbo.Voyage", "ArivalStopId", "dbo.Stop");
            DropIndex("dbo.Ticket", new[] { "OrderId" });
            DropIndex("dbo.Voyage", new[] { "ArivalStopId" });
            DropIndex("dbo.Voyage", new[] { "DepartureStopId" });
            DropIndex("dbo.Order", new[] { "VoyageId" });
            DropTable("dbo.Ticket");
            DropTable("dbo.Stop");
            DropTable("dbo.Voyage");
            DropTable("dbo.Order");
        }
    }
}
