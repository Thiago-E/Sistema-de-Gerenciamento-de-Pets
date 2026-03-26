using System;
using System.Collections.Generic;
using GerenciamentoDePets.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePets.BdContextGerenciamentoDePetsContext;

public partial class GerenciamentoDePetsContext : DbContext
{
    public GerenciamentoDePetsContext()
    {
    }

    public GerenciamentoDePetsContext(DbContextOptions<GerenciamentoDePetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Responsavel> Responsavels { get; set; }

    public virtual DbSet<TipoPet> TipoPets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GerenciamentoDePets;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.IdPet).HasName("PK__Pet__2ACE59B74D1B9EDC");

            entity.Property(e => e.IdPet).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdResponsavelNavigation).WithMany(p => p.Pets).HasConstraintName("FK__Pet__IdResponsav__6383C8BA");

            entity.HasOne(d => d.IdTipoPetNavigation).WithMany(p => p.Pets).HasConstraintName("FK__Pet__IdTipoPet__6477ECF3");
        });

        modelBuilder.Entity<Responsavel>(entity =>
        {
            entity.HasKey(e => e.IdResponsavel).HasName("PK__Responsa__CDF1DCADD7B65FDA");

            entity.Property(e => e.IdResponsavel).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<TipoPet>(entity =>
        {
            entity.HasKey(e => e.IdTipoPet).HasName("PK__TipoPet__232B1D5062CC7730");

            entity.Property(e => e.IdTipoPet).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
