using testcallLib.DBtestcall;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class DBtestcall_Context : DbContext
{
  
    public client GET_client(int id) => client.Where(z => z.cli_id == id).FirstOrDefault();
  
    public category GET_category(int id) => category.Where(z => z.cat_id == id).FirstOrDefault();
  

 
    public int AddOrUpdate(client data)
    {
        var A = client;
        if (data.cli_id == 0) A.Add(data); else A.Update(data);
        this.SaveChanges();
        return data.IID;

    }
  
    public int AddOrUpdate(category data)
    {
        var A = category;
        if (data.cat_id == 0) A.Add(data); else A.Update(data);
        this.SaveChanges();
        return data.IID;

    }
  
    public DbSet<client> client { get; set; }
  
    public DbSet<category> category { get; set; }
  


    internal DBtestcall_Context(DbContextOptions<DBtestcall_Context> options) : base(options)
    {

    }
  
}