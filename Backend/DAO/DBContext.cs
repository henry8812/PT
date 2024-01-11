using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PTSeleccion.Backend.Models
{

    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        

        

        // Constructor sin parámetros
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }


        //public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        // DbSet para tus entidades
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Process> Processes { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicantProcess> ApplicantProcess { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Puedes definir configuraciones de modelos aquí si es necesario

            // Configurar las relaciones de Identity


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-N6M1J20\\MSSQLSERVER01;Database=PT01;User Id=admindb;Password=swordfish;");
            }
        }
    }
}
