using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace Hospital_Data.Models_Data
{
    public class DBApplicationContext : DbContext
    {

        public DbSet<EPatient> Patients { get; set; }
        public DbSet<EDoctor> Doctors { get; set; }
        public DbSet<ENurse> Nurses { get; set; }
        public DbSet<ETreatment> Treatments { get; set; }
        public DbSet<ECleaningServiceManager> CleaningServiceManagers { get; set; }
        public DbSet<ECleaningServiceWorker> CleaningServiceWorkers { get; set; }
        public DbSet<ECleaningServiceTask> CleaningServiceTasks { get; set; }

        public DBApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=123321456654789987;database=hospital_project",
            new MySqlServerVersion(new Version(8, 0, 3)));
        }
    }
}
