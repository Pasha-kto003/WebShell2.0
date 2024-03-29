﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebShell2._0.DB
{
    public partial class WebShell_DBContext : DbContext
    {
        public WebShell_DBContext()
        {
        }

        public WebShell_DBContext(DbContextOptions<WebShell_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Command> Commands { get; set; } = null!;
        public virtual DbSet<CommandHistory> CommandHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("db1");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-2KIP198\\SQLEXPRESS;Initial Catalog=WebShell_DB;Trusted_Connection=True; User=dbo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>(entity =>
            {
                entity.ToTable("Command");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommandName).IsUnicode(false);

                entity.Property(e => e.CommandParametr)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommandHistory>(entity =>
            {
                entity.ToTable("CommandHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommandAnswer).HasColumnType("text");

                entity.Property(e => e.DateUsing).HasColumnType("datetime");

                entity.HasOne(d => d.Command)
                    .WithMany(p => p.CommandHistories)
                    .HasForeignKey(d => d.CommandId)
                    .HasConstraintName("FK_CommandHistory_Command");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
