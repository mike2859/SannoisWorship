using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SannoisWorship.Core.Entities;
using System;

namespace SannoisWorship.Infrastructure.Data;

public class SannoisWorshipDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public SannoisWorshipDbContext(DbContextOptions<SannoisWorshipDbContext> options) : base(options) { }
    // Gestion des chants
    public DbSet<Chant> Chants { get; set; }

    // Gestion des partitions (au format ChordPro)
    public DbSet<Partition> Partitions { get; set; }
    public DbSet<Accord> Accords { get; set; }

    // Annotation des chants (exemple : notes personnelles)
    //public DbSet<PartitionAnnotation> Annotations { get; set; }


    // Instruments de musique
    //public DbSet<Instrument> Instruments { get; set; }

    // Chants associés à plusieurs instruments
    //public DbSet<ChantInstrument> ChantInstruments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        // Relation One-to-One : Chant → Partition
        modelBuilder.Entity<Partition>()
            .HasOne(p => p.Chant)
            .WithOne(c => c.Partition)
            .HasForeignKey<Partition>(p => p.ChantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relation One-to-Many : Partition → Accord
        modelBuilder.Entity<Accord>()
            .HasOne(a => a.Partition)
            .WithMany(p => p.Accords)
            .HasForeignKey(a => a.PartitionId)
            .OnDelete(DeleteBehavior.Cascade);




        //// Configuration de la relation Chant-Instrument (Many-to-Many)
        //modelBuilder.Entity<ChantInstrument>()
        //    .HasKey(ci => new { ci.ChantId, ci.InstrumentId });

        //modelBuilder.Entity<ChantInstrument>()
        //    .HasOne(ci => ci.Chant)
        //    .WithMany(c => c.ChantInstruments)
        //    .HasForeignKey(ci => ci.ChantId);

        //modelBuilder.Entity<ChantInstrument>()
        //    .HasOne(ci => ci.Instrument)
        //    .WithMany(i => i.ChantInstruments)
        //    .HasForeignKey(ci => ci.InstrumentId);




        //// Configuration de la relation Chant-Membre (One-to-Many)
        //modelBuilder.Entity<Chant>()
        //    .HasOne(c => c.CreatedBy)
        //    .WithMany(m => m.CreatedChants)
        //    .HasForeignKey(c => c.CreatedById)
        //    .OnDelete(DeleteBehavior.Restrict); // Pour éviter les suppressions en cascade, optionnel

        //modelBuilder.Entity<Chant>()
        //    .HasOne(c => c.ModifiedBy)
        //    .WithMany(m => m.ModifiedChants)
        //    .HasForeignKey(c => c.ModifiedById)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Configuration de la relation Membre-Rôle (One-to-Many)
        //modelBuilder.Entity<Membre>()
        //    .HasOne(m => m.Role)
        //    .WithMany(r => r.Membres)
        //    .HasForeignKey(m => m.RoleId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //// Configuration des annotations de Chant
        //modelBuilder.Entity<PartitionAnnotation>()
        //    .HasOne(a => a.Chant)
        //    .WithMany(c => c.PartitionAnnotations)
        //    .HasForeignKey(a => a.ChantId);

        //// Configuration des accords de Chant
        //modelBuilder.Entity<Accord>()
        //    .HasOne(a => a.Chant)
        //    .WithMany(c => c.Accords)
        //    .HasForeignKey(a => a.ChantId);



        //// Configuration de la relation Chant-Instrument (Many-to-Many)
        //modelBuilder.Entity<ChantInstrument>()
        //    .HasKey(ci => new { ci.ChantId, ci.InstrumentId });

        //modelBuilder.Entity<ChantInstrument>()
        //    .HasOne(ci => ci.Chant)
        //    .WithMany(c => c.ChantInstruments)
        //    .HasForeignKey(ci => ci.ChantId);

        //modelBuilder.Entity<ChantInstrument>()
        //    .HasOne(ci => ci.Instrument)
        //    .WithMany(i => i.ChantInstruments)
        //    .HasForeignKey(ci => ci.InstrumentId);




        /*
         * 
         * 
         * var chant = dbContext.Chants
        .Include(c => c.Partition)
        .ThenInclude(p => p.Accords)
        .FirstOrDefault(c => c.Id == chantId);


                var partition = dbContext.Partitions
            .Include(p => p.Accords)
            .FirstOrDefault(p => p.Id == partitionId);

        partition.Accords.Add(new Accord { Nom = "D/F#", Bass = "F#", Frets = 3, Position = "x03210" });
        dbContext.SaveChanges();

                */
    }
}
