using Data.Mapping;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Questions> Answer { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Toda tabela nova, se cria o map e chama ele aqui!
            //Depois de criar o mapeamento, chama o método que faz a configuração!
            modelBuilder.Entity<Questions>(new QuestionsMap().Configure);
            modelBuilder.Entity<Questions>(new AnswerMap().Configure);

        }


        /*
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        */
    }
}
