using System.Collections.Generic;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.BaiduMap;
using Senparc.Weixin.MP.Entities.GoogleMap;
using Senparc.Weixin.MP.Helpers;

namespace WeixinWebformDemo.Include.Weixin
{
    public class LocationService
    {
        public ResponseMessageNews GetResponseMessage(RequestMessageLocation requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageNews>(requestMessage);

            var markersList = new List<BaiduMarkers>();
            markersList.Add(new BaiduMarkers()
            {
                Longitude = requestMessage.Location_X,
                Latitude = requestMessage.Location_Y,
                Color = "red",
                Label = "S",
                Size = BaiduMarkerSize.Default,
            });
            var mapSize = "480x600";
            
            var mapUrl = BaiduMapHelper.GetBaiduStaticMap(requestMessage.Location_X,requestMessage.Location_Y,1,18,markersList);
            responseMessage.Articles.Add(new Article()
            {
                Description = string.Format("您刚才发送了地理位置信息。Location_X：{0}，Location_Y：{1}，Scale：{2}，标签：{3}",
                              requestMessage.Location_X, requestMessage.Location_Y,
                              requestMessage.Scale, requestMessage.Label),
                PicUrl = mapUrl,
                Title = "定位地点周边地图",
                Url = mapUrl
            });

            return responseMessage;
        }
    }
}