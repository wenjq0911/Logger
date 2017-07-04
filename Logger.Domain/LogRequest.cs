using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("log_request")]
    public class LogRequest
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("host_uuid")]
        public string HostUuid { get; set; }
        [Column("request_uuid")]
        public string RequestUuid { get; set; }
        [Column("action_ms")]
        public int ActionMS { get; set; }
        [Column("render_ms")]
        public int RenderMS { get; set; }
        [Column("is_exception")]
        public int IsException { get; set; }
        [Column("log_time")]
        public DateTime LogTime { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }
        [Column("browser")]
        public string Browser { get; set; }
        [Column("version")]
        public string Version { get; set; }
    }
}
