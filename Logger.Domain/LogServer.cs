using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("log_server")]
    public class LogServer
    {
        [Column(IsPrimaryKey = true, Name = "uuid")]
        public string Uuid { get; set; }
        [Column("cpu")]
        public double Cpu { get; set; }
        [Column("net")]
        public double Net { get; set; }
        [Column("memory")]
        public double Memory { get; set; }
        [Column("process_num")]
        public int ProcessNum { get; set; }
        [Column("cpu_top1")]
        public string CpuTop1 { get; set; }
        [Column("cpu_top2")]
        public string CpuTop2 { get; set; }
        [Column("cpu_top3")]
        public string CpuTop3 { get; set; }
        [Column("network_top1")]
        public string NetWorkTop1 { get; set; }
        [Column("network_top2")]
        public string NetWorkTop2 { get; set; }
        [Column("network_top3")]
        public string NetWorkTop3 { get; set; }
        [Column("memory_top1")]
        public string MemoryTop1 { get; set; }
        [Column("memory_top2")]
        public string MemoryTop2 { get; set; }
        [Column("memory_top3")]
        public string MemoryTop3 { get; set; }
        [Column("log_time")]
        public DateTime LogTime { get; set; }
        [Column("create_time")]
        public DateTime CreateTime { get; set; }

    }
}
