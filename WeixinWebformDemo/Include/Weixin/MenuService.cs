using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Text;
using Senparc.Weixin.HttpUtility;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.Weixin.MP;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.Entities;

namespace WeixinWebformDemo.Include.Weixin
{
    public class MenuService
    {
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public WxJsonResult CreateMenu(string accessToken)
        {
            ButtonGroup bg = new ButtonGroup();

            //二级菜单
            var subButton1 = new SubButton()
            {
                name = "第一个菜单"
            };
            subButton1.sub_button.Add(new SingleClickButton()
            {
                name = "单击测试",
                key = "V1001_TEXT",

            });
            subButton1.sub_button.Add(new SingleClickButton()
            {
                name = "模版消息",
                key = "TempClick",

            });
            subButton1.sub_button.Add(new SingleClickButton()
            {
                key = "SubClickRoot_PicPhotoOrAlbum",
                name = "微信拍照",
                type = ButtonType.pic_photo_or_album.ToString()

            });
            subButton1.sub_button.Add(new SingleClickButton()
            {
                key = "SubClickRoot_ScancodePush",
                name = "微信扫码",
                type=ButtonType.scancode_push.ToString()
            });
            bg.button.Add(subButton1);

           

            //二级菜单
            var subButton = new SubButton()
            {
                name = "二级菜单"
            };
            subButton.sub_button.Add(new SingleClickButton()
            {
                key = "文本",
                name = "返回文本",
                type = ButtonType.click.ToString()

            });
            subButton.sub_button.Add(new SingleClickButton()
            {
                key = "ArticleBack",
                name = "返回图文"
            });
            subButton.sub_button.Add(new SingleClickButton()
            {
                key = "音乐",
                name = "返回音乐"
            });
            subButton.sub_button.Add(new SingleViewButton()
            {
                url = "http://test.mgdaas.com/test.aspx",
                name = "Url跳转"
            });
            bg.button.Add(subButton);

            //单击
            bg.button.Add(new SingleViewButton()
            {
                url = "http://test.mgdaas.com/ceshi.aspx",
                name = "测试分享"
            });



            var result = Senparc.Weixin.MP.CommonAPIs.CommonApi.CreateMenu(accessToken, bg);
            Include.Log.MyLog.WriteRunLog(accessToken);
            Include.Log.MyLog.WriteRunLog(result.errcode.ToString());
            return result;

        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public WxJsonResult DeleteMenu(string accessToken)
        {
            return Senparc.Weixin.MP.CommonAPIs.CommonApi.DeleteMenu(accessToken);
        }
    }

    
}