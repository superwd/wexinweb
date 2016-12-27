<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceshi.aspx.cs" Inherits="WeixinWebformDemo.ceshi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>微信分享</title>
    
     <script src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js" type="text/javascript"></script>
     <script src="Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
        <script type="text/javascript">
      
            var dataForWeixin = {
                appId: "<%=AppId%>",
                MsgImg: "http://demo.open.weixin.qq.com/jssdk/images/p2166127561.jpg",
                TLImg: "http://demo.open.weixin.qq.com/jssdk/images/p2166127561.jpg",
                url: "http://www.baidu.com",
                title: "用c#开发微信 系列汇总",
                desc: "网上开发微信开发的教程很多，但c#相对较少。这里列出了我所有c#开发微信的文章，方便自己随时查阅。",
                timestamp: '<%=Timestamp%>',
                nonceStr: '<%=NonceStr%>',
                signature: '<%=Signature%>',
                jsApiList: ['onMenuShareTimeline', 'onMenuShareAppMessage', 'onMenuShareQQ', 'onMenuShareWeibo'],
                fakeid: "",
                callback: function () { }
            };
            wx.config({
                debug: false, // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
                appId: dataForWeixin.appId, // 必填，公众号的唯一标识
                timestamp: dataForWeixin.timestamp, // 必填，生成签名的时间戳
                nonceStr: dataForWeixin.nonceStr, // 必填，生成签名的随机串
                signature: dataForWeixin.signature,// 必填，签名，见附录1
                jsApiList: dataForWeixin.jsApiList  // 必填，需要使用的JS接口列表，所有JS接口列表见附录2
            });
            wx.ready(function(){
                wx.ready(function () {
                    //在此输入各种API
                    //分享到朋友圈
                    wx.onMenuShareTimeline({
                        title: dataForWeixin.title, // 分享标题
                        link: dataForWeixin.url, // 分享链接
                        imgUrl: dataForWeixin.MsgImg, // 分享图标
                        success: function () {
                            // 用户确认分享后执行的回调函数
                            alert("你分享了朋友圈");
                        },
                        cancel: function () {
                            // 用户取消分享后执行的回调函数
                            alert("你取消了分享朋友圈");
                        }
                    });
                    //分享给朋友
                    wx.onMenuShareAppMessage({
                        title: dataForWeixin.title, // 分享标题
                        desc: dataForWeixin.desc, // 分享描述
                        link: dataForWeixin.url, // 分享链接
                        imgUrl: dataForWeixin.TLImg, // 分享图标
                        type: '', // 分享类型,music、video或link，不填默认为link
                        dataUrl: '', // 如果type是music或video，则要提供数据链接，默认为空
                        success: function () {
                            // 用户确认分享后执行的回调函数
                            alert("你分享了朋友");
                        },
                        cancel: function () {
                            // 用户取消分享后执行的回调函数
                            alert("你取消了分享朋友");
                        }
                    });
                    //QQ
                    wx.onMenuShareQQ({
                        title: dataForWeixin.title, // 分享标题
                        desc: dataForWeixin.desc, // 分享描述
                        link: dataForWeixin.url, // 分享链接
                        imgUrl: dataForWeixin.MsgImg,// 分享图标
                        success: function () {
                            // 用户确认分享后执行的回调函数
                        },
                        cancel: function () {
                            // 用户取消分享后执行的回调函数
                        }
                    });
                    //QQ微博
                    wx.onMenuShareWeibo({
                        title: dataForWeixin.title, // 分享标题
                        desc: dataForWeixin.desc, // 分享描述
                        link: dataForWeixin.url, // 分享链接
                        imgUrl: dataForWeixin.TLImg, // 分享图标
                        success: function () {
                            // 用户确认分享后执行的回调函数
                        },
                        cancel: function () {
                            // 用户取消分享后执行的回调函数
                        }
                    });
                    // config信息验证后会执行ready方法，所有接口调用都必须在config接口获得结果之后，config是一个客户端的异步操作，
                    //所以如果需要在页面加载时就调用相关接口，则须把相关接口放在ready函数中调用来确保正确执行。对于用户触发时才调用的接口，则可以直接调用，不需要放在ready函数中。
                });
                wx.error(function (res) {
                    //alert(res);
                    // config信息验证失败会执行error函数，如签名过期导致验证失败，具体错误信息可以打开config的debug模式查看，也可以在返回的res参数中查看，对于SPA可以在这里更新签名。
                });
            });

           
       

        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size:xx-large">
    微信分享演示
    </div>
    </form>
</body>
</html>
