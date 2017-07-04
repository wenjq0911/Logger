using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("host_info")]
    public class HostInfo
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("ip")]
        public string IP { get; set; }
        [Column("country")]
        public string County { get; set; }
        [Column("province")]
        public string Province { get; set; }
        [Column("city")]
        public string City { get; set; }
    }
}
