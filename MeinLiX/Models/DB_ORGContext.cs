using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeinLiX
{
    public partial class DB_ORGContext : DbContext
    {
        public DB_ORGContext()
        {
        }

        public DB_ORGContext(DbContextOptions<DB_ORGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContractEvent> ContractEvent { get; set; }
        public virtual DbSet<ContractOrganisation> ContractOrganisation { get; set; }
        public virtual DbSet<ContractPlayer> ContractPlayer { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }
        public virtual DbSet<Subdivision> Subdivision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-SSNKG8D\\SQLEXPRESS;Database=DB_ORG; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractEvent>(entity =>
            {
                entity.HasKey(e => e.IdContract);

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.ContractBalance)
                    .HasColumnName("contract_balance")
                    .HasColumnType("money");

                entity.Property(e => e.ContractValidUntil)
                    .HasColumnName("contract_valid_until")
                    .HasColumnType("date");

                entity.Property(e => e.IdEvent).HasColumnName("id_event");

                entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");

                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.ContractEvent)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractEvent_Event");

                entity.HasOne(d => d.IdSponsorNavigation)
                    .WithMany(p => p.ContractEvent)
                    .HasForeignKey(d => d.IdSponsor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractEvent_Sponsor");
            });

            modelBuilder.Entity<ContractOrganisation>(entity =>
            {
                entity.HasKey(e => e.IdContract);

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.ContractBalance)
                    .HasColumnName("contract_balance")
                    .HasColumnType("money");

                entity.Property(e => e.ContractValidUntil)
                    .HasColumnName("contract_valid_until")
                    .HasColumnType("date");

                entity.Property(e => e.IdOrganisation).HasColumnName("id_organisation");

                entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");

                entity.HasOne(d => d.IdOrganisationNavigation)
                    .WithMany(p => p.ContractOrganisation)
                    .HasForeignKey(d => d.IdOrganisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractOrganisation_Organisation");

                entity.HasOne(d => d.IdSponsorNavigation)
                    .WithMany(p => p.ContractOrganisation)
                    .HasForeignKey(d => d.IdSponsor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractOrganisation_Sponsor");
            });

            modelBuilder.Entity<ContractPlayer>(entity =>
            {
                entity.HasKey(e => e.IdContract);

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.ContractBalance)
                    .HasColumnName("contract_balance")
                    .HasColumnType("money");

                entity.Property(e => e.ContractValidUntil)
                    .HasColumnName("contract_valid_until")
                    .HasColumnType("date");

                entity.Property(e => e.IdPlayer).HasColumnName("id_player");

                entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.ContractPlayer)
                    .HasForeignKey(d => d.IdPlayer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractPlayer_Player");

                entity.HasOne(d => d.IdSponsorNavigation)
                    .WithMany(p => p.ContractPlayer)
                    .HasForeignKey(d => d.IdSponsor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractPlayer_Sponsor");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.IdEvent)
                    .HasName("PK_Tournament");

                entity.Property(e => e.IdEvent).HasColumnName("id_event");

                entity.Property(e => e.EventLocation)
                    .HasColumnName("event_location")
                    .HasMaxLength(50);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("event_name")
                    .HasMaxLength(50);

                entity.Property(e => e.EventPrizeFund).HasColumnName("event_prize_fund");

                entity.Property(e => e.EventStartDate)
                    .HasColumnName("event_start_date")
                    .HasColumnType("date");

                entity.Property(e => e.EventWebpage)
                    .HasColumnName("event_webpage")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.IdGame);

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasColumnName("game_name")
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.IdRegion);

                entity.Property(e => e.IdRegion).HasColumnName("id_region");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasColumnName("region_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.HasKey(e => e.IdOrganisation);

                entity.Property(e => e.IdOrganisation).HasColumnName("id_organisation");

                entity.Property(e => e.IdRegion).HasColumnName("id_region");

                entity.Property(e => e.OrganisationFoundation)
                    .HasColumnName("organisation_foundation")
                    .HasColumnType("date");

                entity.Property(e => e.OrganisationName)
                    .IsRequired()
                    .HasColumnName("organisation_name")
                    .HasMaxLength(50);

                entity.Property(e => e.OrganisationWebpage)
                    .HasColumnName("organisation_webpage")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdRegionNavigation)
                    .WithMany(p => p.Organisation)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organisation_Region");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer);

                entity.Property(e => e.IdPlayer).HasColumnName("id_player");

                entity.Property(e => e.IdSubdivision).HasColumnName("id_subdivision");

                entity.Property(e => e.PlayerBirth)
                    .HasColumnName("player_birth")
                    .HasColumnType("date");

                entity.Property(e => e.PlayerJoin)
                    .HasColumnName("player_join")
                    .HasColumnType("date");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("player_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PlayerNickname)
                    .IsRequired()
                    .HasColumnName("player_nickname")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdSubdivisionNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.IdSubdivision)
                    .HasConstraintName("FK_Player_Subdivision");
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.IdSponsor);

                entity.Property(e => e.IdSponsor).HasColumnName("id_sponsor");

                entity.Property(e => e.SponsorFoundation)
                    .HasColumnName("sponsor_foundation")
                    .HasColumnType("date");

                entity.Property(e => e.SponsorName)
                    .IsRequired()
                    .HasColumnName("sponsor_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SponsorWebpage)
                    .HasColumnName("sponsor_webpage")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subdivision>(entity =>
            {
                entity.HasKey(e => e.IdSubdivision);

                entity.Property(e => e.IdSubdivision).HasColumnName("id_subdivision");

                entity.Property(e => e.IdGame).HasColumnName("id_game");

                entity.Property(e => e.IdOrganisation).HasColumnName("id_organisation");

                entity.Property(e => e.SubdivisionFoundation)
                    .HasColumnName("subdivision_foundation")
                    .HasColumnType("date");

                entity.Property(e => e.SubdivisionName)
                    .IsRequired()
                    .HasColumnName("subdivision_name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.Subdivision)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdivision_Game");

                entity.HasOne(d => d.IdOrganisationNavigation)
                    .WithMany(p => p.Subdivision)
                    .HasForeignKey(d => d.IdOrganisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subdivision_Organisation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
