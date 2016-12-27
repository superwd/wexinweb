using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeixinWebformDemo
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = OAuthApi.GetAuthorizeUrl(WebConfigurationManager.AppSettings["WeixinAppId"], "http://test.mgdaas.com/WebForm2.aspx", "STATE", OAuthScope.snsapi_base);
                Include.Log.MyLog.WriteRunLog(url);
                //string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + WebConfigurationManager.AppSettings["WeixinAppId"] + "&redirect_uri=" + Uri.EscapeDataString("http://test.mgdaas.com/WebForm1.aspx") + "&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";               
                Response.Redirect(url);
            }
        }
    }
}