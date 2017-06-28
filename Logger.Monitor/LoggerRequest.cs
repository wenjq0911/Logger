using Logger.Monitor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Logger.Monitor
{
    public class LoggerRequest:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var wach = WachFac.GetWach(filterContext,Constant.NAME_KEY_ACTION);
            wach.Begin();
            wach.current_request_uuid = Guid.NewGuid().ToString().Replace("-","");
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WachFac.GetWach(filterContext, Constant.NAME_KEY_ACTION).End();
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            WachFac.GetWach(filterContext, Constant.NAME_KEY_RENDER).End();
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var render = WachFac.GetWach(filterContext, Constant.NAME_KEY_RENDER);
            render.End();
            var action_wach = WachFac.GetWach(filterContext, Constant.NAME_KEY_ACTION);
            var area = filterContext.RouteData.Values["area"];
            var action = filterContext.RouteData.Values["action"];
            var controller = filterContext.RouteData.Values["controller"];

            var request = new RequestLogModel()
            {
                uuid = action_wach.current_request_uuid,
                area = area==null?"":area.ToString(),
                action = action == null ? "" : action.ToString(),
                controller= controller == null ? "" : controller.ToString(),
                ip = filterContext.HttpContext.Request.UserHostAddress,
                type= filterContext.HttpContext.Request.RequestType,
                param_body=  Util.ConvertNameValueCollection(filterContext.HttpContext.Request.Params),
                param_url= Util.ConvertNameValueCollection(filterContext.HttpContext.Request.QueryString),
                param_form= Util.ConvertNameValueCollection(filterContext.HttpContext.Request.Form),
                action_ms= action_wach.milliseconds,
                render_ms= render.milliseconds,
                logger_time= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            var mq = new ActiveMQHelper();
            mq.InitQueueOrTopic(false, Constant.LOGGER_REQUEST_MQ_NAME);
            mq.SendMessage(JsonConvert.SerializeObject(request));
            mq.ShutDown();
            base.OnResultExecuted(filterContext);
        }
    }
}
