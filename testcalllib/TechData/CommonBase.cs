using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace testcallLib
{
    public class kukurma
    {
        public string first { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<kukurma> kukurma { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///host=95.163.180.83 dbname=<DATABASE> user=<USERNAME> password=<PASSWORD>"
            optionsBuilder.UseNpgsql("Host=95.163.180.83;Port=5432;Database=JetPostgreSQL;Username=dreka21;Password=roma1613");
        }
    }

    public abstract class CommonBase
    {

        protected Entity.Client CreateClient()
        {
            var c =new Entity.Client();
            
           return new Entity.Client() { User = User };
           
        }

        public ClaimsPrincipal User;

        public DBtestcall_Context GetDB => new PrimaryContext().CreateDbContext();



     
    }
    public static class StringConst
    {
        public static Microsoft.Extensions.Configuration.IConfiguration Configuration;
        public static string connectionStringHash => Configuration["hashsql"];

        public static string connectionString => Configuration["mainsql"];
        public static int MAX_CONSULTANT_FILE_SIZE=> Configuration["MAX_CONSULTANT_FILE_SIZE"].ToInt();
    }
    public class PrimaryContext : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<DBtestcall_Context>
    {
        public DBtestcall_Context CreateDbContext()
        {
            return CreateDbContext(null);
        }
        public DBtestcall_Context CreateDbContext(string[] _)
        {
            //removed
           return null;
        }
    }
}
