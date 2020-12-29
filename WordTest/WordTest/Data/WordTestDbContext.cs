using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WordTest.Models;

namespace WordTest.Data
{
    public class WordTestDbContext:DbContext
    {
        public WordTestDbContext(DbContextOptions<WordTestDbContext> options):base(options)
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var UserConversion =new ValueConverter<Gender, string>(t=>t.ToString(), t=>(Gender)Enum.Parse(typeof(Gender),t));
            var taskConversion = new ValueConverter<WordTest.Models.TaskStatus, string>(t => t.ToString(), t => (WordTest.Models.TaskStatus)Enum.Parse(typeof(WordTest.Models.TaskStatus), t));
            modelBuilder.Entity<User>().Property(m => m.Gender).HasConversion(UserConversion);
            modelBuilder.Entity<WordTest.Models.Task>().Property(m => m.Status).HasConversion(taskConversion);
            base.OnModelCreating(modelBuilder);
        }

        public  DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AppPage> AppPage { get; set; }
        public DbSet<RolePage> RolePage { get; set; }
        public DbSet<EnglishBook> EnglishBook { get; set; }
        public DbSet<EnglishBookUnit> EnglishBookUnit { get; set; }
        public DbSet<UnitWord> UnitWord { get; set; }
        public DbSet<Models.Task> Task { get; set; }
        public DbSet<TaskWord> TaskWord { get; set; }






    }
}
