using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logger.Monitor
{
    internal class Wach
    {
        /// <summary>
        /// 毫秒
        /// </summary>
        public int milliseconds { get; set; }

        private DateTime start_time { get; set; }
        public string current_request_uuid { get; set; }
        public void Begin() {
            this.start_time = DateTime.Now;
        }
        public int End() {
            var now = DateTime.Now;
            this.milliseconds = ((TimeSpan)(now - start_time)).Milliseconds;
            return this.milliseconds;
        }
    }

    internal class WachFac {
        public static Wach GetWach(ControllerContext context, string name)
        {
            string key = string.Format("{0}{1}", Constant.PREFIX_KEY, name);
            if (context.HttpContext.Items.Contains(key))
            {
                return (Wach)context.HttpContext.Items[key];
            }
            var result = new Wach();
            context.HttpContext.Items[key] = result;
            return result;
        }
    }
}
