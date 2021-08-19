using Data.Mapping;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class MyContext: DbContext
    {

        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public DbSet<Questions> Questions { get; set; }

        public DbSet<Answer> Answer { get; set; }

        public DbSet<Chapter> Chapter { get; set; }

        public DbSet<Product> Products { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_logger)
                          .EnableSensitiveDataLogging()                          
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MinhaAPICore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            base.OnModelCreating(modelBuilder);

            //Toda tabela nova, se cria o map e chama ele aqui!
            //Depois de criar o mapeamento, chama o método que faz a configuração!
            modelBuilder.Entity<Questions>(new QuestionsMap().Configure);
            modelBuilder.Entity<Answer>(new AnswerMap().Configure);
            modelBuilder.Entity<Chapter>(new ChapterMap().Configure);
            modelBuilder.Entity<Product>(new ProductsMap().Configure);

        }


        /*
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        */
    }
}
