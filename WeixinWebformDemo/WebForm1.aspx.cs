using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeixinWebformDemo.Include.Weixin;

namespace WeixinWebformDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           string access_token= AccessTokenContainer.TryGetAccessToken(WebConfigurationManager.AppSettings["WeixinAppId"], WebConfigurationManager.AppSettings["WeixinAppSecret"]);

           MenuService ms = new MenuService();
           var delInfo = ms.DeleteMenu(access_token);
           var menuInfo = ms.CreateMenu(access_token);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/shinidie.mp3");
            string access_token = AccessTokenContainer.TryGetAccessToken(WebConfigurationManager.AppSettings["WeixinAppId"], WebConfigurationManager.AppSettings["WeixinAppSecret"]);
            UploadForeverMediaResult res = MediaApi.UploadForeverMedia(access_token, path);
            Response.Write(res.media_id+".......");
        }
    }
}