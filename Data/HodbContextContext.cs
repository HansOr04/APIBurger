﻿using System;
using System.Collections.Generic;
using APIBurger.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBurger.Data;

public partial class HodbContextContext : DbContext
{
    public HodbContextContext()
    {
    }

    public HodbContextContext(DbContextOptions<HodbContextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burger> Burgers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HODbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger>(entity =>
        {
            entity.ToTable("Burger");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurgerId, "IX_Promo_BurgerID");

            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");

            entity.HasOne(d => d.Burger).WithMany(p => p.Promos).HasForeignKey(d => d.BurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
