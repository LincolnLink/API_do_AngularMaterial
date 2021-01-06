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
            var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbApiAangular;User Id=sa;Password=root123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
             
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
