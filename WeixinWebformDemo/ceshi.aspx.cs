
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeixinWebformDemo
{
    public partial class ceshi : System.Web.UI.Page
    {
        private string appId = ConfigurationManager.AppSettings["WeixinAppId"];
        private string secret = ConfigurationManager.AppSettings["WeixinAppSecret"];
        public string AppId = "";
        public string NonceStr = "";
        public string Signature = "";
        public string Timestamp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var jssdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, secret, Request.Url.AbsoluteUri);
                AppId = jssdkUiPackage.AppId;
                NonceStr = jssdkUiPackage.NonceStr;
                Signature = jssdkUiPackage.Signature;
                Timestamp = jssdkUiPackage.Timestamp;
                
            }
            
        }
    }
}