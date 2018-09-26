using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ImagingTaskSchedule.Shared.Models {
    public partial class KOFAXContext : DbContext {
        public KOFAXContext () { }

        public KOFAXContext (DbContextOptions<KOFAXContext> options) : base (options) { }

        public virtual DbSet<ImagingJobdetails> ImagingJobdetails { get; set; }
        public virtual DbSet<ImagingScheduleJob> ImagingScheduleJob { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= ukcsd01rap035\\SQLExpress;Database=KOFAX;user id=KOFAX;password=KOFAX;Trusted_Connection=True;MultipleActiveResultSets=true");
             
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<ImagingJobdetails> (entity => {
                entity.ToTable ("Imaging_JOBdetails");

                entity.Property (e => e.Id).HasColumnName ("id");

                entity.Property (e => e.EmailNotificationAddress).HasMaxLength (254);

                entity.Property (e => e.Extra1).HasMaxLength (254);

                entity.Property (e => e.Extra2).HasMaxLength (254);

                entity.Property (e => e.Extra3).HasMaxLength (254);

                entity.Property (e => e.Extra4).HasMaxLength (254);

                entity.Property (e => e.Extra5).HasMaxLength (254);

                entity.Property (e => e.JobdetailsType)
                    .HasColumnName ("JOBDetailsType")
                    .HasMaxLength (254);

                entity.Property (e => e.Jobid).HasColumnName ("JOBid");

                entity.Property (e => e.Jobname)
                    .HasColumnName ("JOBName")
                    .HasMaxLength (200);

                entity.Property (e => e.PaswordsFtp)
                    .HasColumnName ("PaswordsFTP")
                    .HasMaxLength (50);

                entity.Property (e => e.SFtpdownloadFrom)
                    .HasColumnName ("sFTPDownloadFrom")
                    .HasMaxLength (200);

                entity.Property (e => e.SFtpdownloadTo)
                    .HasColumnName ("sFTPDownloadTo")
                    .HasMaxLength (200);

                entity.Property (e => e.SFtphost)
                    .HasColumnName ("sFTPHOST")
                    .HasMaxLength (200);

                entity.Property (e => e.SFtpuploadFrom)
                    .HasColumnName ("sFTPUploadFrom")
                    .HasMaxLength (200);

                entity.Property (e => e.SFtpuploadto)
                    .HasColumnName ("sFTPUploadto")
                    .HasMaxLength (200);

                entity.Property (e => e.SshfingerPrint)
                    .HasColumnName ("SSHFingerPrint")
                    .HasMaxLength (100);

                entity.Property (e => e.UsernamesFtp)
                    .HasColumnName ("UsernamesFTP")
                    .HasMaxLength (50);
            });

            modelBuilder.Entity<ImagingScheduleJob> (entity => {
                entity.Property (e => e.Id).HasColumnName ("id");

                entity.Property (e => e.IsActive)
                    .IsRequired ()
                    .HasMaxLength (10);

                entity.Property (e => e.Jobname).IsRequired ();

                entity.Property (e => e.ScheduleTime)
                    .HasColumnName ("scheduleTIME")
                    .HasMaxLength (50);
            });
        }
    }
}