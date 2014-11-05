<%@ Page Language="C#" AutoEventWireup="true" Inherits="Tc.UI.Danye" %>

<%@ Register Src="~/control/bot.ascx" TagPrefix="uc1" TagName="bot" %>
<%@ Register Src="~/control/ad.ascx" TagPrefix="uc1" TagName="ad" %>
<%@ Register Src="~/control/top.ascx" TagPrefix="uc1" TagName="top" %>
<%@ Register Src="~/control/nav.ascx" TagPrefix="uc1" TagName="nav" %>
<%@ Register Src="~/control/contact.ascx" TagPrefix="uc1" TagName="contact" %>
<%@ Register Src="~/control/about.ascx" TagPrefix="uc1" TagName="about" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=7">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=mdy.Name %>-<%=PB.Get("webname") %></title>
    <link href="<%=Lib.theme %>images/inner.css" rel="stylesheet" type="text/css" />
    <link href="<%=Lib.theme %>images/style1.css" rel="stylesheet" type="text/css" />
    <link href="<%=Lib.theme %>images/common.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=Lib.theme %>js/jquery.min.js"></script>
    <script type="text/javascript" src="<%=Lib.theme %>js/functions.js"></script>
    <script type="text/javascript" src="<%=Lib.theme %>images/iepng/iepngfix_tilebg.js"></script>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=DE84ef52718b953df3b628be2059fcaa"></script>
</head>

<body>
    <div id="wrapper">
        <!--head start-->
        <div id="head">
            <uc1:top runat="server" ID="top" />
            <uc1:nav runat="server" ID="nav" />
        </div>
        <!--head end-->
        <!--body start-->
        <div id="body">
            <!--focus start-->
            <div id="InnerBanner">
            </div>
            <!--foncus end-->
            <div class="HeightTab clearfix"></div>
            <!--inner start -->
            <div class="inner">
                <!--left start-->
                <div class="left">
                    <uc1:about runat="server" ID="about" />
                    <uc1:contact runat="server" ID="contact" />
                </div>
                <!--left end-->
                <!--right start-->
                <div class="right">
                    <div class="Position"><span>你的位置：<a href="/">首页</a> > <a href='/page/<%=mdy.Ename %>.aspx'><%=mdy.Name %></a></span></div>
                    <div class="HeightTab clearfix"></div>
                    <!--main start-->
                    <div class="main">
                        <!--content start-->
                        <div class="content">
                            <div class="maincontent clearfix">
                                <%=mdy.Content %>
                            </div>
                        </div>
                        <!--content end-->
                    </div>
                    <!--main end-->
                </div>
                <!--right end-->
            </div>
            <!--inner end-->

           <script type="text/javascript">

               // 百度地图API功能
               var map = new BMap.Map("l-map");
               var point = new BMap.Point(116.310602, 39.914975);
               map.centerAndZoom(point, 16);
               var marker = new BMap.Marker(point);  // 创建标注
               map.addOverlay(marker);              // 将标注添加到地图中
               marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画


               map.addControl(new BMap.OverviewMapControl());              //添加默认缩略地图控件
               map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_TOP_RIGHT }));   //右上角，打开


               map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
               map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL }));  //右上角，仅包含平移和缩放按钮
               map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN }));  //左下角，仅包含平移按钮
               map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));  //右下角，仅包含缩放按钮

               map.centerAndZoom(point, 17);                   // 初始化地图,设置城市和地图级别。

               map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
               map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用


								</script>	
        </div>
        <!--body end-->

        <uc1:bot runat="server" ID="bot" />
    </div>
</body>
</html>