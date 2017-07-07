namespace DaysProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theater : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Theaters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        City = c.String(),
                        Class = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Theaters");
        }
    }
}
