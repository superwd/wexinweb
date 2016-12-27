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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Include.Log.MyLog.WriteRunLog("web进入");
                if (Request.QueryString["code"] != null)
                {

                    Include.Log.MyLog.WriteRunLog(Request.QueryString["code"]);
                    OAuthAccessTokenResult result = null;

                    //通过，用code换取access_token
                    try
                    {
                        result = OAuthApi.GetAccessToken(WebConfigurationManager.AppSettings["WeixinAppId"], WebConfigurationManager.AppSettings["WeixinAppSecret"], Request.QueryString["code"]);
                    }
                    catch (Exception ex)
                    {
                        Include.Log.MyLog.WriteRunLog(result.errmsg);
                    }
                    OAuthUserInfo userInfo = null;
                    Include.Log.MyLog.WriteRunLog(result.access_token + "---------------------------------------");
                    //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
                    try
                    {
                        userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                        Include.Log.MyLog.WriteRunLog(userInfo.openid + "*********************************");
                        Include.Log.MyLog.WriteRunLog(userInfo.nickname + "*********************************");
                        Label1.Text = "您的信息：昵称：" + userInfo.nickname + ",openId：" + userInfo.openid;
                        Image1.ImageUrl = userInfo.headimgurl;
                    }
                    catch (Exception ex)
                    {
                        Include.Log.MyLog.WriteRunLog("用户已授权，授权Token：" + result);
                    }

                }
                else
                {
                    Response.Write("您拒绝了授权");
                }
            }
        }
    }
}