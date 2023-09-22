using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mitre_attack.Models;

public partial class MitreMappingContext : DbContext
{
    public MitreMappingContext()
    {
    }

    public MitreMappingContext(DbContextOptions<MitreMappingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Tactic> Tactics { get; set; }

    public virtual DbSet<Technique> Techniques { get; set; }

    public virtual DbSet<TechniqueEventsWin> TechniqueEventsWins { get; set; }

    public virtual DbSet<TechniquePlatform> TechniquePlatforms { get; set; }

    public virtual DbSet<ViewTechniqueEventsWin> ViewTechniqueEventsWins { get; set; }

    public virtual DbSet<ViewTechniquePlatform> ViewTechniquePlatforms { get; set; }

    public virtual DbSet<WindowsEvent> WindowsEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=comp6002.mysql.database.azure.com;database=mitre_mapping;user id=comp6002;password=MITREMapping6002", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.PlatformId).HasName("PRIMARY");

            entity.ToTable("platforms");

            entity.Property(e => e.PlatformId).HasColumnName("PlatformID");
            entity.Property(e => e.PlatformName).HasMaxLength(64);
        });

        modelBuilder.Entity<Tactic>(entity =>
        {
            entity.HasKey(e => e.TacticId).HasName("PRIMARY");

            entity.ToTable("tactics");

            entity.Property(e => e.TacticId)
                .HasMaxLength(8)
                .HasColumnName("TacticID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TacticName).HasMaxLength(64);
        });

        modelBuilder.Entity<Technique>(entity =>
        {
            entity.HasKey(e => e.TechniqueId).HasName("PRIMARY");

            entity.ToTable("techniques");

            entity.Property(e => e.TechniqueId)
                .HasMaxLength(16)
                .HasColumnName("TechniqueID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.SubTechniqueOf).HasMaxLength(8);
            entity.Property(e => e.TacticId)
                .HasMaxLength(8)
                .HasColumnName("TacticID");
            entity.Property(e => e.TechniqueName).HasMaxLength(64);
        });

        modelBuilder.Entity<TechniqueEventsWin>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.TechniqueId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("technique_events_win");

            entity.Property(e => e.EventId)
                .HasMaxLength(8)
                .HasColumnName("EventID");
            entity.Property(e => e.TechniqueId)
                .HasMaxLength(8)
                .HasColumnName("TechniqueID");
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<TechniquePlatform>(entity =>
        {
            entity.HasKey(e => new { e.PlatformId, e.TechniqueId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("technique_platforms");

            entity.Property(e => e.PlatformId).HasColumnName("PlatformID");
            entity.Property(e => e.TechniqueId)
                .HasMaxLength(8)
                .HasColumnName("TechniqueID");
        });

        modelBuilder.Entity<ViewTechniqueEventsWin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_technique_events_win");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EventDescription).HasColumnType("text");
            entity.Property(e => e.EventId)
                .HasMaxLength(8)
                .HasColumnName("EventID");
            entity.Property(e => e.EventName).HasMaxLength(64);
            entity.Property(e => e.TacticId)
                .HasMaxLength(8)
                .HasColumnName("TacticID");
            entity.Property(e => e.TacticName).HasMaxLength(64);
            entity.Property(e => e.TechniqueId)
                .HasMaxLength(16)
                .HasColumnName("TechniqueID");
            entity.Property(e => e.TechniqueName).HasMaxLength(64);
        });

        modelBuilder.Entity<ViewTechniquePlatform>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_technique_platforms");

            entity.Property(e => e.PlatformId).HasColumnName("PlatformID");
            entity.Property(e => e.PlatformName).HasMaxLength(64);
            entity.Property(e => e.TacticId)
                .HasMaxLength(8)
                .HasColumnName("TacticID");
            entity.Property(e => e.TacticName).HasMaxLength(64);
            entity.Property(e => e.TechniqueId)
                .HasMaxLength(16)
                .HasColumnName("TechniqueID");
            entity.Property(e => e.TechniqueName).HasMaxLength(64);
        });

        modelBuilder.Entity<WindowsEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PRIMARY");

            entity.ToTable("windows_events");

            entity.Property(e => e.EventId)
                .HasMaxLength(6)
                .HasColumnName("EventID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EventName).HasMaxLength(64);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
