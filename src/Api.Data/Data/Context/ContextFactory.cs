using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ContextFactory: IDesignTimeDbContextFactory<MyContext>
    {      
        public MyContext CreateDbContext(string[] args)
        {
            //SqlServer
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=MinhaAPICore;Trusted_Connection=True;MultipleActiveResultSets=true";



            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
             
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
