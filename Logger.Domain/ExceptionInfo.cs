using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("exception_info")]
    public class ExceptionInfo
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("message")]
        public string Message { get; set; }
        [Column("source")]
        public string Source { get; set; }
        [Column("stack_trace")]
        public string StackTrace { get; set; }
        [Column("type")]
        public string Type { get; set; }
    }
}
