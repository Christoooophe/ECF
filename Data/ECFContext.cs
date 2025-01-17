using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECF.Models;

namespace ECF.Data
{
    public class ECFContext : DbContext
    {
        public ECFContext (DbContextOptions<ECFContext> options)
            : base(options)
        {
        }
        public DbSet<ECF.Models.Evenement> Evenement { get; set; } = default!;
        public DbSet<ECF.Models.Participant> Participant { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvenementParticipant>()
                .HasKey(pe => new { pe.ParticipantId, pe.EvenementId });

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(pe => pe.Participant)
                .WithMany(p => p.Evenements)
                .HasForeignKey(pe => pe.ParticipantId);

            modelBuilder.Entity<EvenementParticipant>()
                .HasOne(pe => pe.Evenement)
                .WithMany(e => e.Participants)
                .HasForeignKey(pe => pe.EvenementId);
        }
    }
}
