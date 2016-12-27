using System.Web;
using System.Web.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using WeixinWebformDemo.Include.Weixin;

namespace WeixinWebformDemo
{
    /// <summary>
    /// Weixin 的摘要说明
    /// </summary>
    public class Weixin : IHttpHandler
    {
        public static readonly string Token = WebConfigurationManager.AppSettings["WeixinToken"];//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAesKey = WebConfigurationManager.AppSettings["WeixinEncodingAESKey"];//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = WebConfigurationManager.AppSettings["WeixinAppId"];//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = WebConfigurationManager.AppSettings["WeixinAppSecret"];

        public void ProcessRequest(HttpContext context)
        {
            string signature = context.Request["signature"];
            string timestamp = context.Request["timestamp"];
            string nonce = context.Request["nonce"];
            string echostr = context.Request["echostr"];

            if (context.Request.HttpMethod == "GET")
            {
                Include.Log.MyLog.WriteRunLog("进入GET");
                if (CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    context.Response.Output.Write(echostr);//返回随机字符串则表示验证通过
                }
                else
                {
                    context.Response.Output.Write("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
                }
            }
            else
            {
                Include.Log.MyLog.WriteRunLog("进入POST");
                if (!CheckSignature.Check(signature, timestamp, nonce, Token))
                {
                    context.Response.Output.Write("参数错误！");
                }

                //post method - 当有用户想公众账号发送消息时触发
                var postModel = new PostModel()
                {
                    Signature = signature,
                    Msg_Signature = context.Request.QueryString["msg_signature"],
                    Timestamp = timestamp,
                    Nonce = nonce,
                    //以下保密信息不会（不应该）在网络上传播，请注意
                    Token = Token,
                    EncodingAESKey = EncodingAesKey,
                    AppId = AppId
                };

                //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(context.Request.InputStream, postModel);               
                //执行微信处理过程
                messageHandler.Execute();
                context.Response.Output.Write(messageHandler.ResponseDocument.ToString());
                Include.Log.MyLog.WriteRunLog(messageHandler.ResponseDocument.ToString());
               
                //context.Response.Output.Write(menuInfo.ToString());
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}