using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeixinWebformDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            string UserId = txtUserName.Value.Trim();
            string UserPwd = txtUserPwd.Value.Trim();
            string valid = this.txtSigncode.Text.Trim();

            try
            {
 
                //var userinfo = nj.sys_user.FirstOrDefault(u => u.USERNAME == UserId && u.PASSWORD == UserPwd);
                //if (Session["ValidNums"] == null)
                //{
                //    Page.RegisterStartupScript("", " <script language='javascript'>OpenWinAlert('验证码失效','txtCardTitle'); </script>");
                //    return;
                //}
                //if (Session["ValidNums"].ToString().ToLower() != valid.ToLower())
                //{
                //    Page.RegisterStartupScript("", " <script language='javascript'>OpenWinAlert('验证码错误','txtCardTitle'); </script>");
                //    return;
                //}
                string list = "";
                string resUrl = "User/User.aspx";
                if (UserId != null)
                {
                    //string Id = ds.Tables[0].Rows[0]["AccountId"].ToString();
                    list = "1";
                }
                else
                {
                    //用户名或密码错误！
                    Page.RegisterStartupScript("", " <script language='javascript'>alert('用户名或密码错误！'); </script>");
                    return;
                }
            
                
                //建立身份验证票对象
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, list, DateTime.Now, DateTime.Now.AddMinutes(60), false, "1");
                //加密序列化验证票为字符串
                string hashTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
                HttpContext.Current.Response.Cookies.Add(userCookie);
                if (Request.QueryString["ReturnUrl"] != null )
                {
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                }
                else
                {
                    //Common.WriteLog("1", "Role:" + role + "登录", "商家:" + UserId + "登录系统.成功!", (int)System.Net.IPAddress.Parse(Request.UserHostAddress).Address);
                    Response.Redirect(resUrl);
                }
            }
            catch (Exception ex)
            {
                //账号已冻结！请联系管理员...
                Page.RegisterStartupScript("", " <script language='javascript'>alert('登录失败，" + ex.Message + "'); </script>");
            }
        }
    }
}