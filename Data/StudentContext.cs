using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement21A2.Models;
using StudentManagement21A2.ViewModels;

namespace StudentManagement21A2.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
          : base(options)
        {
        }

   

        public DbSet<StudentManagement21A2.Models.Car> Car { get; set; }

        public DbSet<StudentManagement21A2.Models.Prize> Prizes { get; set; }

        public DbSet<StudentManagement21A2.Models.CopyCar> CopyCars { get; set; }

        public DbSet<StudentManagement21A2.Models.Client> Clients { get; set; }

        public DbSet<StudentManagement21A2.Models.Rent> Rents { get; set; }
        public DbSet<StudentManagement21A2.ViewModels.RegisterViewModel> RegisterViewModels { get; set; }
       
        public DbSet<All_Cars_Rent> All_Cars_Rent { get; set; }
        
        public DbSet<All_Car> All_Car { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<All_Cars_Rent>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("wypozyczenia_wszystkie");
                        eb.Property(v => v.Nazwisko).HasColumnName("Nazwisko");
                    });
            modelBuilder
                .Entity<All_Car>
                (
                 eb =>
                 {
                     eb.HasNoKey();
                     eb.ToView("samochody_wszystkie");
             
                 });

        }
        public DbSet<StudentManagement21A2.ViewModels.LoginViewModel> LoginViewModel { get; set; }

    }


}
