using Chloe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Domain
{
    [Table("request_info")]
    public class RequestInfo
    {
        [Column(IsPrimaryKey =true,Name ="uuid")]
        public string Uuid { get; set; }
        [Column(Name = "action")]
        public string Action { get; set; }
        [Column(Name = "controller")]
        public string Controller { get; set; }
        [Column(Name = "area")]
        public string Area { get; set; }
        [Column(Name = "other")]
        public string Other { get; set; }
        [Column(Name = "type")]
        public string Type { get; set; }
        [Column(Name = "param_url")]
        public string ParamUrl { get; set; }
        [Column(Name = "param_body")]
        public string ParamBody { get; set; }
        [Column(Name = "param_form")]
        public string ParamForm { get; set; }
    }
}
