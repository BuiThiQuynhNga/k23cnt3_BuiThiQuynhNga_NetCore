using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BuiThiQuynhNga_2310900075.Models;

public partial class BuiThiQuynhNga2310900075Context : DbContext
{
    public BuiThiQuynhNga2310900075Context()
    {
    }

    public BuiThiQuynhNga2310900075Context(DbContextOptions<BuiThiQuynhNga2310900075Context> options)
        : base(options)
    {
    }

    public virtual DbSet<BtqnEmployee> BtqnEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ADMIN-PC\\SUA;Database=BuiThiQuynhNga_2310900075;Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BtqnEmployee>(entity =>
        {
            entity.HasKey(e => e.BtqnEmpld).HasName("PK__BtqnEmpl__13925453EA5C8F6B");

            entity.ToTable("BtqnEmployee");

            entity.Property(e => e.BtqnEmpld).HasColumnName("btqnEmpld");
            entity.Property(e => e.BtqnEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("btqnEmpLevel");
            entity.Property(e => e.BtqnEmpName)
                .HasMaxLength(100)
                .HasColumnName("btqnEmpName");
            entity.Property(e => e.BtqnEmpStartDate).HasColumnName("btqnEmpStartDate");
            entity.Property(e => e.BtqnEmpStatus).HasColumnName("btqnEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
