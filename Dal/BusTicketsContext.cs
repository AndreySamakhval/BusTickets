namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BusTicketsContext : DbContext
    {
        public BusTicketsContext()
            : base("name=BusTicketsContext")
        {
        }

        public virtual DbSet<Stop> Stops { get; set; }
        public virtual DbSet<Voyage> Voyages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
