using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace testcallLib.Token
{
    public class DB_CTX : DbContext
    {

        public int AddOrUpdate(user_hash data)
        {
            var A = user_hash;
            if (data.IID == 0) A.Add(data); else A.Update(data);
            this.SaveChanges();
            return data.IID;
        }

        public DbSet<user_hash> user_hash { get; set; }
        public DB_CTX(DbContextOptions<DB_CTX> options) : base(options)
        {

        }
        public DB_CTX() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(StringConst.connectionStringHash);
        }
    }
    public class user_hash
    {
        public int IID => hash_id;
        [Key]
        public int hash_id { get; set; }
        public int user_id { get; set; }
        public string hash { get; set; }
        public string phone { get; set; }
        public int state { get; set; }
    }
}
