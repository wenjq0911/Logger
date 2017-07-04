using Apache.NMS;
using log4net;
using Logger.Domain;
using Logger.IService;
using Logger.Monitor;
using Logger.Monitor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Logger.App_Start
{
    public class Monitor
    {
        private ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public ILogRequestService LogRequestService = DependencyResolver.Current.GetService<ILogRequestService>();
        public ILogExceptionService LogExceptionService = DependencyResolver.Current.GetService<ILogExceptionService>();
        public ILogOperationService LogOperationService = DependencyResolver.Current.GetService<ILogOperationService>();
        public void BeginMonitor()
        {
            try
            {
                ActiveMQHelper mq = new ActiveMQHelper();
                mq.InitQueueOrTopic(false, Logger.Monitor.Constant.LOGGER_REQUEST_MQ_NAME, false);
                mq.Listener(listener_request);
                mq.InitQueueOrTopic(false, Logger.Monitor.Constant.LOGGER_EXCEPTION_MQ_NAME, false);
                mq.Listener(listenrt_exception);
                mq.InitQueueOrTopic(false, Logger.Monitor.Constant.LOGGER_OPT_MQ_NAME, false);
                mq.Listener(listenrt_opt);
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        void listener_request(IMessage message)
        {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                var json_text = msg.Text;
                RequestLogModel model = JsonConvert.DeserializeObject<RequestLogModel>(json_text);
                RequestInfo requestInfo = new RequestInfo()
                {
                    Action = model.action,
                    Area = model.area,
                    Controller = model.controller,
                    ParamBody = model.param_body,
                    ParamForm = model.param_form,
                    ParamUrl = model.param_url,
                    Type = model.type,
                    Uuid = Guid.NewGuid().ToString().Replace("-", "")
                };
                HostInfo hostInfo = new HostInfo()
                {
                    IP = model.ip,
                    Uuid = Guid.NewGuid().ToString().Replace("-", "")
                };
                LogRequest log = new LogRequest()
                {
                    ActionMS = model.action_ms,
                    CreateTime = DateTime.Now,
                    HostUuid = hostInfo.Uuid,
                    Uuid = model.uuid,
                    IsException = model.is_exception,
                    LogTime = DateTime.Parse(model.logger_time),
                    RenderMS = model.render_ms,
                    RequestUuid = requestInfo.Uuid,
                    Browser = model.browser,
                    Version = model.version
                };

                LogRequestService.SaveAll(log, requestInfo, hostInfo);
            }
            catch (System.Exception e)
            {
                log.Error(e);
            }
        }
        void listenrt_exception(IMessage message) {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                var json_text = msg.Text;
                ExceptionLog model = JsonConvert.DeserializeObject<ExceptionLog>(json_text);
                ExceptionInfo exception_info = new ExceptionInfo() {
                     Message=model.message,
                      Source=model.source,
                       StackTrace=model.stack_trace,
                        Type=model.type,
                         Uuid=Guid.NewGuid().ToString().Replace("-","")
                };
                LogException logException = new LogException() {
                     CreateTime=DateTime.Now,
                      LogRequestUuid=model.log_request_uuid,
                       LogTime=DateTime.Parse(model.log_time),
                        Uuid=model.uuid,
                         ExceptionUuid= exception_info.Uuid
                };
                LogExceptionService.Save(logException, exception_info);

            }
            catch (System.Exception e)
            {
                log.Error(e);
            }
        }
        void listenrt_opt(IMessage message) {
            try
            {
                ITextMessage msg = (ITextMessage)message;
                var json_text = msg.Text;
                OptLogModel model = JsonConvert.DeserializeObject<OptLogModel>(json_text);
                OperationInfo operation_info = new OperationInfo() {
                     Uuid = Guid.NewGuid().ToString().Replace("-",""),
                      Remark=model.remark,
                       Type=model.type
                };
                LogOperation log_opt = new LogOperation() {
                     CreateTime=DateTime.Now,
                      OperationUuid=operation_info.Uuid,
                       LogTime=DateTime.Parse(model.log_time),
                        LogRequestUuid=model.logger_request_uuid,
                         Uuid=model.uuid
                };

                LogOperationService.Save(operation_info, log_opt);
            }
            catch (System.Exception e)
            {
                log.Error(e);
            }
        }



    }


}