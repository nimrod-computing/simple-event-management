using Nimrod.Events.DomainModel;
using Nimrod.Events.DomainModel.Metadata;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Nimrod.Events.DataAccess.EF
{
    public class EventsDb : DbContext
    {
        public EventsDb() : base("Events")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EventsDb>());
            Database.Log = Log;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Attendee>()
                .HasMany<Session>(s => s.Sessions)
                .WithMany(c => c.Attendees)
                .Map(cs =>
                {
                    cs.MapLeftKey("AttendeeId");
                    cs.MapRightKey("SessionId");
                    cs.ToTable("SessionAttendee");
                });

            modelBuilder.Entity<Speaker>()
                .HasMany<Session>(s => s.Sessions)
                .WithMany(c => c.Speakers)
                .Map(cs =>
                {
                    cs.MapLeftKey("ContactId");
                    cs.MapRightKey("SessionId");
                    cs.ToTable("SessionSpeaker");
                });

        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();

            foreach (var changedEntity in changedEntities)
            {
                Entity record = changedEntity.Entity as Entity;
                if (record != null)
                {
                    DateTime now = DateTime.UtcNow;

                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            record.CreatedAt = now;
                            record.UpdatedAt = now;
                            break;

                        case EntityState.Modified:
                            record.UpdatedAt = now;
                            break;

                    }

                }
            }
            return base.SaveChanges();
        }

        private void Log(string line)
        {
            Console.WriteLine(line);
        }

    }
}
