using System.ComponentModel.DataAnnotations;
using System;
namespace testcallLib.DBtestcall
{
    internal interface baser { int IID { get; } }
  
    public class client : baser
    {
        public int IID => cli_id;
        [Key]
        public int cli_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public DateTime reg_date { get; set; }
        public int balace { get; set; }
        public bool active { get; set; }

        public bool avatar { get; set; }

        public string voxid { get; set; }
        public string voxpass { get; set; }
    }
    
    public class category : baser
    {
        public int IID => cat_id;
        [Key]
        public int cat_id { get; set; }
        public int parent { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public bool active { get; set; }
    }

}