using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class summerwellContext : DbContext
    {
        public summerwellContext()
        {
        }

        public summerwellContext(DbContextOptions<summerwellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conference> Conference { get; set; }
        public virtual DbSet<ConferenceAudience> ConferenceAudience { get; set; }
        public virtual DbSet<Demo> Demo { get; set; }
        public virtual DbSet<DictionaryCity> DictionaryCity { get; set; }
        public virtual DbSet<DictionaryConferenceCategory> DictionaryConferenceCategory { get; set; }
        public virtual DbSet<DictionaryConferenceStatus> DictionaryConferenceStatus { get; set; }
        public virtual DbSet<DictionaryConferenceType> DictionaryConferenceType { get; set; }
        public virtual DbSet<DictionaryCountry> DictionaryCountry { get; set; }
        public virtual DbSet<DictionaryCounty> DictionaryCounty { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Speaker> Speaker { get; set; }
        public virtual DbSet<SpeakerxConference> SpeakerxConference { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ts-internship-2019.database.windows.net;Database=summer-well;User Id=usr2020;Password=n39fn0n2_j32-(#;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>(entity =>
            {
                entity.Property(e => e.ConferenceName).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.HostEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConferenceCategory)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.ConferenceCategoryId)
                    .HasConstraintName("FK__Conferenc__Confe__6AEFE058");

                entity.HasOne(d => d.ConferenceType)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.ConferenceTypeId)
                    .HasConstraintName("FK__Conferenc__Confe__690797E6");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Conference)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Conferenc__Locat__69FBBC1F");
            });

            modelBuilder.Entity<ConferenceAudience>(entity =>
            {
                entity.HasIndex(e => e.UniqueParticipantCode)
                    .HasName("UQ__Conferen__755190E3D50298DE")
                    .IsUnique();

                entity.HasIndex(e => new { e.Participant, e.ConferenceId })
                    .HasName("UQ__Conferen__1D22F546424590E0")
                    .IsUnique();

                entity.Property(e => e.Participant).HasMaxLength(255);

                entity.Property(e => e.UniqueParticipantCode)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.ConferenceAudience)
                    .HasForeignKey(d => d.ConferenceId)
                    .HasConstraintName("FK__Conferenc__Confe__7755B73D");

                entity.HasOne(d => d.ConferenceStatus)
                    .WithMany(p => p.ConferenceAudience)
                    .HasForeignKey(d => d.ConferenceStatusId)
                    .HasConstraintName("FK__Conferenc__Confe__7849DB76");
            });

            modelBuilder.Entity<Demo>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DictionaryCity>(entity =>
            {
                entity.HasIndex(e => e.DictionaryCityName)
                    .HasName("UQ__Dictiona__2C48D7A186BF3088")
                    .IsUnique();

                entity.Property(e => e.DictionaryCityCode).HasMaxLength(255);

                entity.Property(e => e.DictionaryCityName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DictionaryCounty)
                    .WithMany(p => p.DictionaryCity)
                    .HasForeignKey(d => d.DictionaryCountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dictionar__Dicti__5D95E53A");
            });

            modelBuilder.Entity<DictionaryConferenceCategory>(entity =>
            {
                entity.HasIndex(e => e.DictionaryConferenceCategoryName)
                    .HasName("UQ__Dictiona__8748FFD6F5DD8B4B")
                    .IsUnique();

                entity.Property(e => e.DictionaryConferenceCategoryId).ValueGeneratedNever();

                entity.Property(e => e.DictionaryConferenceCategoryName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryConferenceStatus>(entity =>
            {
                entity.HasIndex(e => e.DictionaryConferenceStatusName)
                    .HasName("UQ__Dictiona__3FE58FB05280A54E")
                    .IsUnique();

                entity.Property(e => e.DictionaryConferenceStatusId).ValueGeneratedNever();

                entity.Property(e => e.DictionaryConferenceStatusName).HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryConferenceType>(entity =>
            {
                entity.Property(e => e.DictionaryConferenceTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DictionaryCountry>(entity =>
            {
                entity.HasIndex(e => e.DictionaryCountryName)
                    .HasName("UQ__Dictiona__0D65D389E5A94379")
                    .IsUnique();

                entity.Property(e => e.DictionaryCountryCode).HasMaxLength(255);

                entity.Property(e => e.DictionaryCountryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DictionaryCounty>(entity =>
            {
                entity.HasIndex(e => e.DictionaryCountyName)
                    .HasName("UQ__Dictiona__B6C0AD526CCE9F3B")
                    .IsUnique();

                entity.Property(e => e.DictionaryCountyCode).HasMaxLength(255);

                entity.Property(e => e.DictionaryCountyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.DictionaryCountry)
                    .WithMany(p => p.DictionaryCounty)
                    .HasForeignKey(d => d.DictionaryCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Dictionar__Dicti__59C55456");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Latitude).HasMaxLength(100);

                entity.Property(e => e.Longitude).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Location__CityId__6166761E");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.HasIndex(e => e.SpeakerEmail)
                    .HasName("UQ__Speaker__71A44390BBEA9FA6")
                    .IsUnique();

                entity.Property(e => e.Nationality).HasMaxLength(255);

                entity.Property(e => e.Rating).HasMaxLength(1);

                entity.Property(e => e.SpeakerDomain).HasMaxLength(255);

                entity.Property(e => e.SpeakerEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SpeakerImage).IsUnicode(false);

                entity.Property(e => e.SpeakerName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<SpeakerxConference>(entity =>
            {
                entity.HasKey(e => new { e.ConferenceId, e.SpeakerId })
                    .HasName("PK__Speakerx__CD0B80064211BB8F");

                entity.Property(e => e.IsMainSpeaker).HasColumnName("isMainSpeaker");

                entity.HasOne(d => d.Conference)
                    .WithMany(p => p.SpeakerxConference)
                    .HasForeignKey(d => d.ConferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SpeakerxC__Confe__0880433F");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.SpeakerxConference)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SpeakerxC__Speak__09746778");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
