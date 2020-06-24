using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace testcallLib.Token
{
    public class HashFactoryContext : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<DB_CTX>
    {
        public DB_CTX CreateDbContext()
        {
            return CreateDbContext(null);
        }
        public DB_CTX CreateDbContext(string[] _)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DB_CTX>();
            optionsBuilder.UseSqlServer(StringConst.connectionStringHash);
            return new DB_CTX(optionsBuilder.Options);
        }
    }
}
