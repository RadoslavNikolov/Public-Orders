using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace PublicOrders.Data.BisData
{
    using Models;

    public partial class BisDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SecondName).HasMaxLength(100);

                entity.Property(e => e.Speciality).HasMaxLength(10);

                entity.Property(e => e.UIN).HasMaxLength(50);
            });

            modelBuilder.Entity<Examination>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Doctor).WithMany(p => p.Examination).HasForeignKey(d => d.DoctorId).OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Patient).WithMany(p => p.Examination).HasForeignKey(d => d.PatientId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Egn)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SecondName).HasMaxLength(100);
            });
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
    }
}