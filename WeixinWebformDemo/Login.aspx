<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WeixinWebformDemo.Login" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
        //        $(function () {
        //            if ($.browser.msie !=undefined   ) {
        //                if ($.browser.msie != "")
        //                $("#msg").html("您正在使用msie浏览器使用本系统，请更换Chrome浏览器访问本系统。");
        //            }
        //            else if ($.browser.safari != undefined  ) {
        //                if ($.browser.safari != "")
        //                $("#msg").html("您正在使用safari浏览器使用本系统，请更换Chrome浏览器访问本系统。");
        //            }
        //            else if ($.browser.mozilla != undefined) {
        //                if ($.browser.mozilla != "")
        //                $("#msg").html("您正在使用mozilla浏览器使用本系统，请更换Chrome浏览器访问本系统。");
        //            }
        //            else if ($.browser.opera != undefined) {
        //                if ($.browser.opera != "")
        //                $("#msg").html("您正在使用opera浏览器使用本系统，请更换Chrome浏览器访问本系统。");
        //            }
        //            else if ($.browser.chrome != undefined) {
        //               
        //            }
        //            else {
        //                alert("i don't konw!");
        //                $("#msg").html("您正在使用未知浏览器使用本系统，请更换Chrome浏览器访问本系统。");
        //            }
        //        });
</script>
    <style type="text/css">
        .shurukz td {
            padding: 3px 0;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <body  >

<div class="topbar" style="height:10px;">
</div>


<div class="logobar-2">
	<div class="logocontent">
    	<div style="float:left; margin-top:18px;" ><a href=""><img id="imglogo" runat="server" src="Images/login/top_5logo.png"/></a></div>
        <div style="float:left; margin-top:32px; margin-left:326px;"><img id="imgcall" runat="server" src="Images/login/top_8.png"/></div>
        <div style="float:left; margin-top:25px; margin-left:24px;" id="gf" runat="server"><a href="http://www.weibiz.cn/index.html"><img src="Images/login/top_7.png"/></a></div>
    </div>
</div>

<!--banner开始-->
<div style="height:415px; background:url(Images/login/1e.png);">
    <div style="width:1600px; height:415px; margin:0 auto; margin-top:1px; margin-bottom:1px; background:url(Images/login/index-banner.png) -150px 0 no-repeat;"></div>
</div>
<div style="height:15px; width:1020px; margin:0 auto;">
   <div style="float:left; height:395px;width:662px; margin-top:-385px; "></div>
   <div style="float:left; width:300px; height:343px; margin-top:-400px; padding-left:20px; background:url(Images/login/top_1_3_1.png) no-repeat;">
            <form action="" method="post">
            
            	<table class="shurukz">
                	<tr>
                   	  <td class="text" >
                        账&nbsp;&nbsp;号：
                        </td>
                        
                    	<td >
                        
                      <input name="txtUserName" type="text" id="txtUserName" tabindex="1" class="textbox" runat="server" />
                        </td>
                       
                    </tr>
                    <tr>
                     <td class="text">
                        密&nbsp;&nbsp;码：
                        </td>
                        
                    	<td>
                     
                      <input name="txtUserPwd" type="password" maxlength="16" id="txtUserPwd" runat="server" tabindex="2" class="textbox" />
                        </td>
                    </tr>
                      <tr>
                     <td class="text" style="padding-bottom: 31px;">
                        验证码：
                        </td>
                        
                    	<td>
                          
                          
                          <asp:TextBox  ID="txtSigncode" runat="server"    placeholder="验证码" class="textbox"  style="width:85px"  
                                maxlength="16" tabindex="2"  />


                          <div style="float:right;width: 80px;margin-right:7px;">
                          	 <img id="imgcode" style="cursor: hand;margin-top:2px;height:32px;"   onclick="javascript:document.getElementById  

('imgcode').src='ValidNums.aspx?'+Math.random();"
                    title="看不清楚,点击更换" src="ValidNums.aspx" align="absMiddle" name="imgcode"   height="32px"/>
                          	 <br/>
                          		 
                          		<a href="#" style="font-size: 11px;">&nbsp;</a>
                          </div>
                          <div style="clear:both"></div>
                        </td>
                    </tr>
                    <tr>
                    	 
                        <td colspan="2">
                        	 
                           <asp:Button ID="login_button" runat="server" Text="123" tabindex="5"  OnClick="login_button_Click" />
                             
                        </td>
                    </tr>
                </table>
              <!--  <div class="shurukz">
                    <div class="mingchengzo"></div>
                    <div class="shurukz2"></div>
                </div>-->
            </form>
   </div>
</div>
<!--banner结束-->
<span id="msg" style=" color:Red;  float:right;"></span>

</body>
    </form>
</body>
</html>
