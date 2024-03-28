using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBYTest.Models;

public partial class DemirbasYonetimiContext : DbContext
{
    public DemirbasYonetimiContext()
    {
    }

    public DemirbasYonetimiContext(DbContextOptions<DemirbasYonetimiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDebitEnter> TblDebitEnters { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDebitEnter>(entity =>
        {
            entity.ToTable("tbl_DebitEnter");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama).HasMaxLength(50);
            entity.Property(e => e.BarkodNo).HasMaxLength(50);
            entity.Property(e => e.Capex).HasMaxLength(50);
            entity.Property(e => e.Creadate).HasColumnType("smalldatetime");
            entity.Property(e => e.DemirbasDurumu).HasMaxLength(50);
            entity.Property(e => e.DemirbasTuru).HasMaxLength(50);
            entity.Property(e => e.DuranVarlik).HasMaxLength(50);
            entity.Property(e => e.EkDemirbas).HasMaxLength(50);
            entity.Property(e => e.FaturaTarihi).HasMaxLength(50);
            entity.Property(e => e.FaturaTutari).HasMaxLength(50);
            entity.Property(e => e.GarantiBitisTarihi).HasMaxLength(50);
            entity.Property(e => e.Imeino)
                .HasMaxLength(50)
                .HasColumnName("IMEINo");
            entity.Property(e => e.LisansEtiketi).HasMaxLength(50);
            entity.Property(e => e.Lokasyon).HasMaxLength(50);
            entity.Property(e => e.Macadres1)
                .HasMaxLength(50)
                .HasColumnName("MACAdres1");
            entity.Property(e => e.Macadres2)
                .HasMaxLength(50)
                .HasColumnName("MACAdres2");
            entity.Property(e => e.Marka).HasMaxLength(50);
            entity.Property(e => e.Model2).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Opex).HasMaxLength(50);
            entity.Property(e => e.Owner).HasMaxLength(50);
            entity.Property(e => e.RafSiraNo).HasMaxLength(50);
            entity.Property(e => e.ServisHizmeti).HasMaxLength(50);
            entity.Property(e => e.SiparisNo).HasMaxLength(50);
            entity.Property(e => e.SonKullanmaTarihi).HasMaxLength(50);
            entity.Property(e => e.TedarikciFirma).HasMaxLength(50);
            entity.Property(e => e.TeminTarihi).HasMaxLength(50);
            entity.Property(e => e.UrunSeriNo).HasMaxLength(50);
            entity.Property(e => e.Yatirim).HasMaxLength(50);
            entity.Property(e => e.YazilimSistem).HasMaxLength(50);
            entity.Property(e => e.ZimmetliPersonel).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("tbl_Users");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
