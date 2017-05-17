namespace StudentsApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseDB : DbContext
    {
        public DatabaseDB()
            : base("name=DatabaseDB")
        {
        }

        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Secretary> Secretaries { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Doctors)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Secretaries)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }

        public System.Data.Entity.DbSet<StudentsApi.ModelsUse.LoginSecretary> LoginSecretaries { get; set; }

        public System.Data.Entity.DbSet<StudentsApi.ModelsUse.LoginDoctor> LoginDoctors { get; set; }

        

        public System.Data.Entity.DbSet<StudentsApi.ModelsUse.LoginAdmin> LoginAdmins { get; set; }
    }
}
