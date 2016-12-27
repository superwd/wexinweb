using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeixinWebformDemo
{
    public partial class T_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Request.QueryString["ReturnUrl"]);
            string test = Request.QueryString["ReturnUrl"];
            if (Request.QueryString["ReturnUrl"].IndexOf("/User/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/Activity/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/AccountGroup/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/BaseInfo/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/Data/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/PricePickup/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/ProductOrder/") < 0
                || Request.QueryString["ReturnUrl"].IndexOf("/Shop/") < 0)
            {
                Response.Redirect("Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.QueryString["ReturnUrl"]));
            }

        }
    }
}