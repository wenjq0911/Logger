using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("operation_info")]
    public class OperationInfo
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("remark")]
        public string Remark { get; set; }
    }
}
