using Senparc.Weixin.MP.Entities;

namespace WeixinWebformDemo.Include.Weixin
{
    public partial class CustomMessageHandler
    {
        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = "欢迎关注微信公众平台！！！";
            return responseMessage;
        }
    }
}