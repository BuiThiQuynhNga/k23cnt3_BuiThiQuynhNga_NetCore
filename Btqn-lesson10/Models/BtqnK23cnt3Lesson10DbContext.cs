using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Btqn_lesson10.Models;

public partial class BtqnK23cnt3Lesson10DbContext : DbContext
{
    public BtqnK23cnt3Lesson10DbContext()
    {
    }

    public BtqnK23cnt3Lesson10DbContext(DbContextOptions<BtqnK23cnt3Lesson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BtqnCategory> BtqnCategories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ADMIN-PC\\SUA;Database=Btqn_K23CNT3_lesson10_db;Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True");






















































































































































    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BtqnCategory>(entity =>
        {
            entity.HasKey(e => e.BtqnId);

            entity.ToTable("BtqnCategory");

            entity.Property(e => e.BtqnId)
                .ValueGeneratedNever()
                .HasColumnName("btqnId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
