using InterManagement.Domain.Entities;  // ← une seule ligne
using Microsoft.EntityFrameworkCore;

namespace InternManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }


        // ======================================================
        // PROPRIÉTÉS DbSet = REPRÉSENTATION DES TABLES EN SQL
        // Chaque DbSet<T> correspond à UNE table en base de données
        // ======================================================

        // ── Tables ───────────────────────────────
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Mentor> Mentors { get; set; }

        // Table "trainees" : contient les stagiaires
        // Propriétés spécifiques : University, Specialite, Theme, StartDate, EndDate, Statut

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Phase> Phases { get; set; }

        // public DbSet<Assignment> Assignments { get; set; }
        // public DbSet<WeeklyFollowUp> WeeklyFollowUps { get; set; }
        // public DbSet<Feedback> Feedbacks { get; set; }
        // public DbSet<InternFile> Files { get; set; }


        // ======================================================
        // MÉTHODE OnModelCreating
        // S'appelle UNE SEULE FOIS au démarrage de l'application
        // Sert à configurer COMMENT les classes C# sont transformées en tables SQL
        // ======================================================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==================================================
            // CONFIGURATION TPT (TABLE PER TYPE)
            // Chaque classe a SA PROPRE table
            // C'est la stratégie d'héritage pour User → Admin/Mentor/Trainee
            // ==================================================

            // ── TPT : héritage User ───────────────
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Admin>().ToTable("admins");
            modelBuilder.Entity<Mentor>().ToTable("mentors");
            modelBuilder.Entity<Trainee>().ToTable("trainees");
            modelBuilder.Entity<Phase>().ToTable("phases");

            // ── Autres tables ─────────────────────

            // modelBuilder.Entity<Assignment>().ToTable("assignments");
            // modelBuilder.Entity<WeeklyFollowUp>().ToTable("weekly_follow_ups");
            // modelBuilder.Entity<Feedback>().ToTable("feedbacks");
            // modelBuilder.Entity<InternFile>().ToTable("files");


            // ── Soft delete global ────────────────
            //modelBuilder.Entity<Trainee>()
                //.HasQueryFilter(t => !t.IsDeleted);

            //modelBuilder.Entity<Mentor>()
                //.HasQueryFilter(m => !m.IsDeleted);
            
            modelBuilder.Entity<User>()
                 .HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Phase>()
                .HasQueryFilter(p => !p.IsDeleted);

            // modelBuilder.Entity<Assignment>()
            //    .HasQueryFilter(a => !a.IsDeleted);

            // modelBuilder.Entity<WeeklyFollowUp>()
            //    .HasQueryFilter(w => !w.IsDeleted);
        }
    }
}

