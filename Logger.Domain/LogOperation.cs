using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("log_operation")]
    public class LogOperation
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("operation_uuid")]
        public string OperationUuid { get; set; }
        [Column("log_time")]
        public DateTime LogTime { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
        [Column("log_request_uuid")]
        public string LogRequestUuid { get; set; }
    }
}
