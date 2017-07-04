using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logger.Monitor
{
    public enum OptTypes {
        /// <summary>
        /// 增加
        /// </summary>
        Insert,
        /// <summary>
        /// 物理删除
        /// </summary>
        Delete,
        /// <summary>
        /// 更新
        /// </summary>
        Update=2,
        /// <summary>
        /// 查询
        /// </summary>
        Search,
        /// <summary>
        /// 增加或更新
        /// </summary>
        InsertOrUpdate,
        /// <summary>
        /// 逻辑删除
        /// </summary>
        LogicDelete



    }

    public class LoggerOperation: ActionFilterAttribute
    {
        public OptTypes Type { get; set; }

        public string Remark { get; set; }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var wach = WachFac.GetWach(filterContext, Constant.NAME_KEY_ACTION);
            var m = new OptLogModel()
            {
                uuid = Guid.NewGuid().ToString().Replace("-",""),
                log_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                remark = Remark,
                type = (int)Type,
                logger_request_uuid= wach.current_request_uuid
            };
            var mq = new ActiveMQHelper();
            mq.InitQueueOrTopic(false, Constant.LOGGER_OPT_MQ_NAME);
            mq.SendMessage(JsonConvert.SerializeObject(m));
            mq.ShutDown();
        }

    }
}
