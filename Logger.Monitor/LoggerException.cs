using log4net;
using Logger.Monitor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logger.Monitor
{
    public class LoggerException: HandleErrorAttribute
    {
        private ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {
            try {
                //记录请求信息
                var action_wach = WachFac.GetWach(filterContext, Constant.NAME_KEY_ACTION);
                var area = filterContext.RouteData.Values["area"];
                var action = filterContext.RouteData.Values["action"];
                var controller = filterContext.RouteData.Values["controller"];
                var request = new RequestLogModel()
                {
                    uuid = action_wach.current_request_uuid,
                    area = area == null ? "" : area.ToString(),
                    action = action == null ? "" : action.ToString(),
                    controller = controller == null ? "" : controller.ToString(),
                    ip = filterContext.HttpContext.Request.UserHostAddress,
                    type = filterContext.HttpContext.Request.RequestType,
                    param_body = Util.ConvertNameValueCollection(filterContext.HttpContext.Request.Params),
                    param_url = Util.ConvertNameValueCollection(filterContext.HttpContext.Request.QueryString),
                    param_form = Util.ConvertNameValueCollection(filterContext.HttpContext.Request.Form),
                    action_ms = action_wach.milliseconds,
                    logger_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    is_exception = 1
                };
                var mq = new ActiveMQHelper();
                mq.InitQueueOrTopic(false, Constant.LOGGER_REQUEST_MQ_NAME);
                mq.SendMessage(JsonConvert.SerializeObject(request));
                Exception exception = filterContext.Exception;
                var ex = new ExceptionLog()
                {
                    log_request_uuid = request.uuid,
                    uuid = Guid.NewGuid().ToString().Replace("-", ""),
                    log_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    message = exception.Message,
                    source = exception.Source,
                    stack_trace = exception.StackTrace,
                    type = exception.GetType().FullName
                };
                //记录异常信息
                mq.InitQueueOrTopic(false, Constant.LOGGER_EXCEPTION_MQ_NAME);
                mq.SendMessage(JsonConvert.SerializeObject(ex));
                mq.ShutDown();
            }
            catch (Exception ex) {
                log.Error(ex);
            }
            base.OnException(filterContext);
        }
    }
}
