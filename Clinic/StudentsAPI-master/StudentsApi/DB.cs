namespace StudentsApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Secretary> Secretaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultation>()
                .Property(e => e.Consult)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Disponibility)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Doctor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Login>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Doctors)
                .WithOptional(e => e.Login)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Secretaries)
                .WithOptional(e => e.Login)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Patient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.CardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.CNP)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Consultations)
                .WithOptional(e => e.Patient)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Secretary>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
