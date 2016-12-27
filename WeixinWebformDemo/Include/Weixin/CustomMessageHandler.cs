using System.IO;
using Senparc.Weixin.MP.Agent;
using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Web;
using Senparc.Weixin.MP;
using System.Web.Configuration;
using Senparc.Weixin.MP.Containers;
//using Senparc.Weixin.Entities;

namespace WeixinWebformDemo.Include.Weixin
{
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        public CustomMessageHandler(Stream inputStream, PostModel postModel)
            : base(inputStream, postModel)
        {

        }
        
        //public override void OnExecuting()
        //{
        //    //测试MessageContext.StorageData
        //    if (CurrentMessageContext.StorageData == null)
        //    {
        //        CurrentMessageContext.StorageData = 0;
        //    }
        //    base.OnExecuting();
        //}

        //public override void OnExecuted()
        //{
        //    base.OnExecuted();
        //    CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        //}

        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            //TODO:这里的逻辑可以交给Service处理具体信息，参考OnLocationRequest方法或/Service/LocationSercice.cs
           
            //书中例子
            //if (requestMessage.Content == "你好")
            //{
            //    var responseMessage = base.CreateResponseMessage<ResponseMessageNews>();
            //    var title = "Title";
            //    var description = "Description";
            //    var picUrl = "PicUrl";
            //    var url = "Url";
            //    responseMessage.Articles.Add(new Article()
            //    {
            //        Title = title,
            //        Description = description,
            //        PicUrl = picUrl,
            //        Url = url
            //    });
            //    return responseMessage;
            //}
            //else if (requestMessage.Content == "Senparc")
            //{
            //    //相似处理逻辑
            //}
            //else
            //{
            //    //...
            //}



            //方法一（v0.1），此方法调用太过繁琐，已过时（但仍是所有方法的核心基础），建议使用方法二到四
            //var responseMessage =
            //    ResponseMessageBase.CreateFromRequestMessage(RequestMessage, ResponseMsgType.Text) as
            //    ResponseMessageText;

            //方法二（v0.4）
            //var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(RequestMessage);

            //方法三（v0.4），扩展方法，需要using Senparc.Weixin.MP.Helpers;
            //var responseMessage = RequestMessage.CreateResponseMessage<ResponseMessageText>();

            //方法四（v0.6+），仅适合在HandlerMessage内部使用，本质上是对方法三的封装
            //注意：下面泛型ResponseMessageText即返回给客户端的类型，可以根据自己的需要填写ResponseMessageNews等不同类型。

            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();

            if (requestMessage.Content == "V1001_TEXT")
            {
                //测试
                responseMessage.Content = "大家好，我是超哥。";
            }
            
            else if (requestMessage.Content == "文本")
            {
                //测试
                responseMessage.Content = "这是一条文本的测试程序。";
            }
           
            else if (requestMessage.Content == "单图文")
            {
                var openResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageNews>();
                openResponseMessage.Articles.Add(new Article()
                {
                    Title = "这是一条单图文信息！",
                    Description = "这里是单图文消息的介绍信息",
                    PicUrl = "http://pic9.nipic.com/20100910/668573_164813098586_2.jpg",
                    Url = "http://www.baidu.com"
                });
                return openResponseMessage;
            }
            else if (requestMessage.Content == "多图文")
            {
                var openResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageNews>();
                openResponseMessage.Articles.Add(new Article()
                {
                    Title = "这是多图文的第一条信息！",
                    Description = "",   //多图文描述是不会显示的，所以可以不加这个字段
                    PicUrl = "http://pic9.nipic.com/20100910/668573_164813098586_2.jpg",
                    Url = "http://www.baidu.com"
                });
                openResponseMessage.Articles.Add(new Article()
                {
                    Title = "这是多图文的第二条信息！",
                    Description = "",   //多图文描述是不会显示的，所以可以不加这个字段
                    PicUrl = "http://pic9.nipic.com/20100910/668573_164813098586_2.jpg",
                    Url = "http://www.baidu.com"
                });

                return openResponseMessage;
            }
            else if (requestMessage.Content == "音乐")
            {
                var musicResponseMessage = base.CreateResponseMessage<ResponseMessageMusic>();
                musicResponseMessage.Music.Title = "叶问";
                musicResponseMessage.Music.Description = "不错的音乐";
                musicResponseMessage.Music.MusicUrl = "http://sc.111ttt.com/up/mp3/393143/04EEA01E2D979B1B6CCCC14EBC8B1398.mp3";
                musicResponseMessage.Music.ThumbMediaId = "e_KYnzXAG5emD6QwNXdq4fhc8vBIUPgi9sFEavm1-NM";
                return musicResponseMessage;
            }
            //其他情况
            else
            {
                var strongResponseMessage = base.CreateResponseMessage<ResponseMessageText>();
                responseMessage = strongResponseMessage;
                strongResponseMessage.Content = "暂无信息！";
            }

            return responseMessage;
        }

        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            //菜单点击，需要跟创建菜单时的Key匹配
            switch (requestMessage.EventKey)
            {
                case "V1001_TEXT":
                    {
                        
                        //这个过程实际已经在OnTextOrEventRequest中完成，这里不会执行到。
                        responseMessage = CreateResponseMessage<ResponseMessageText>();
                        //reponseMessage = strongResponseMessage;
                        responseMessage.Content = "您好，欢迎您来到超哥侃大山栏目！！！\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
                        
                    }
                    break;
                case "文本":
                    {
                        responseMessage = CreateResponseMessage<ResponseMessageText>();
                        //reponseMessage = strongResponseMessage;
                        responseMessage.Content = "您点击了子菜单按钮。";
                    }
                    break;
                case "音乐":
                    {
                        var musicResponseMessage = base.CreateResponseMessage<ResponseMessageMusic>();
                        musicResponseMessage.Music.Title = "叶问";
                        musicResponseMessage.Music.Description = "不错的音乐";
                        musicResponseMessage.Music.MusicUrl = "http://sc.111ttt.com/up/mp3/393143/04EEA01E2D979B1B6CCCC14EBC8B1398.mp3";
                        musicResponseMessage.Music.HQMusicUrl= "http://sc.111ttt.com/up/mp3/393143/04EEA01E2D979B1B6CCCC14EBC8B1398.mp3";
                        //musicResponseMessage.Music.ThumbMediaId = "e_KYnzXAG5emD6QwNXdq4fhc8vBIUPgi9sFEavm1-NM";
                        return musicResponseMessage;
                    }
                    //break;
                case "TempClick":
                    {
                        string access_token = AccessTokenContainer.TryGetAccessToken(WebConfigurationManager.AppSettings["WeixinAppId"], WebConfigurationManager.AppSettings["WeixinAppSecret"]);
                        responseMessage = CreateResponseMessage<ResponseMessageText>();
                        Include.Log.MyLog.WriteRunLog("进入模版消息：OPENID是" + requestMessage.FromUserName);
                        Senparc.Weixin.Entities.WxJsonResult res = Senparc.Weixin.MP.AdvancedAPIs.TemplateApi.SendTemplateMessage(access_token, requestMessage.FromUserName, "vcHebp9rkFn2P1VX0ne13vZaWcLbnaaPAZ6w8u2wEqI", "", "");
                        Include.Log.MyLog.WriteRunLog("进入模版消息：错误为" + res.errcode);
                        //reponseMessage = strongResponseMessage;
                        responseMessage.Content = res.errmsg;
                    }
                    break;
                case "ArticleBack":
                    {
                        Include.Log.MyLog.WriteRunLog("返回图文");
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "这是多图文的第一条信息！",
                            Description = "",   //多图文描述是不会显示的，所以可以不加这个字段
                            PicUrl = "http://pic9.nipic.com/20100910/668573_164813098586_2.jpg",
                            Url = "http://www.baidu.com"
                        });
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "这是多图文的第二条信息！",
                            Description = "",   //多图文描述是不会显示的，所以可以不加这个字段
                            PicUrl = "http://pic9.nipic.com/20100910/668573_164813098586_2.jpg",
                            Url = "http://www.baidu.com"
                        });
                        Include.Log.MyLog.WriteRunLog(strongResponseMessage.ArticleCount.ToString());
                        //reponseMessage = strongResponseMessage;
                        return strongResponseMessage;
                    }
                    //break;
                default:
                    {
                        responseMessage = CreateResponseMessage<ResponseMessageText>();
                        responseMessage.Content = "您点击了按钮，EventKey：" + requestMessage.EventKey;
                        //reponseMessage = strongResponseMessage;
                    }
                    break;
            }

            return responseMessage;
        }

        /// <summary>
        /// 处理位置请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        {
            var locationService = new LocationService();
            var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);          
            return responseMessage;
        }
        /// <summary>
        /// 处理扫码
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之扫码推事件";
            return responseMessage;
        }
        /// <summary>
        /// 处理拍照
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_PicPhotoOrAlbumRequest(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "事件之弹出拍照或者相册发图";
            return responseMessage;
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageNews>();
            responseMessage.Articles.Add(new Article()
            {
                Title = "您刚才发送了图片信息",
                Description = "上面是你发送的图片",
                PicUrl = requestMessage.PicUrl,
                Url = "http://www.baidu.com"
            });

            return responseMessage;
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            return responseMessage;
        }

       
    }
}