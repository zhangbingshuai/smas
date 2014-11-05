﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="info.aspx.cs" ValidateRequest="false" Inherits="Tc.Web.Admin.chanpin.info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品信息</title>
    <link href="../css/base.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.1.min.js"></script>
    <script src="../js/uploadfy/jquery.uploadify.min.js"></script>
    <link href="../js/uploadfy/uploadify.css" rel="stylesheet" />
    <link href="/admin/ueditor/themes/default/ueditor.css" rel="stylesheet" />
    <script>
        window.UEDITOR_HOME_URL = "/admin/ueditor/";
    </script>
    <script src="/admin/ueditor/editor_config.js"></script>
    <script src="/admin/ueditor/editor_all_min.js"></script>
</head>
<body topmargin="8">
    <form id="form1" runat="server">
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="60%" height="30">
                    <img height="14" src="../images/book1.gif" width="20">&nbsp;<a href="list.aspx?types=<%=types %>"><u>产品列表</u></a> &gt;&gt; 产品信息</td>
                <td width="30%" align='right'>&nbsp; </td>
            </tr>
        </table>

        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#FBFCE2" id="getone" style="display: none">
        </table>
        <table width="98%" border="0" align="center" cellpadding="2" cellspacing="2" id="needset" style="border: 1px solid #cfcfcf; background: #ffffff;">
            <tr>
                <td height="24" colspan="5" class="bline">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="90">&nbsp;产品标题：</td>
                            <td>
                                <asp:TextBox ID="txt_title" runat="server" Style="width: 388px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" 必填" ControlToValidate="txt_title"></asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="24" colspan="5" class="bline">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="90">&nbsp;产品分类：</td>
                            <td>
                                <span id='typeidct'>
                                    <asp:DropDownList ID="ddl_fenlei" runat="server" Style="width: 240px"></asp:DropDownList></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="24" colspan="5" class="bline">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="90">&nbsp;产品属性<br />
                                （每行一个）：</td>
                            <td width="449">
                                <asp:TextBox ID="txt_jianyao" runat="server" Style="width: 388px; height: 100px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td width="261">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="24" colspan="5" class="bline">
                    <table width="800" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="90">&nbsp;产品封面图片：</td>
                            <td width="449">
                                <input type="file" name="uploadify" id="uploadify" /><span id="fileQueue"></span>
                                <img id="img_logo" src="<%=tupianurl %>" style="<%=dp%>" />
                                <input type="hidden" runat="server" id="hd_tupian" />
                                <div>
                                    <input type="button" onclick="$('#hd_tupian').val(''); $('#img_logo').hide()" value="删除图片" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="28" colspan="2" bgcolor="#F9FCEF" class="bline2">
                    <div style='float: left; line-height: 28px;'>&nbsp;<strong>产品说明：</strong></div>
                </td>
            </tr>
            <tr>
                <td width="100%" id="arcBody">
                    <textarea id="txt_content" name="txt_content" rows="8" cols="60"><%=content %></textarea>
                </td>
            </tr>
        </table>
        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center" bgcolor="#F9FCEF" style="border: 1px solid #cfcfcf; border-top: none;">
            <tr height="35">
                <td width="17%">&nbsp;</td>
                <td width="83%">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/Admin/images/button_save.gif" runat="server" OnClick="ImageButton1_Click" />
                    <img src="../images/button_reset.gif" width="60" height="22" border="0" onclick="location.reload();" style="cursor: pointer;" />
                </td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">

        var editor = new UE.ui.Editor({
            minFrameHeight: 150, imagePath: ""
        });
        editor.render("txt_content");
        $(document).ready(function () {
            $("#uploadify").uploadify({
                swf: '../js/uploadfy/uploadify.swf',
                uploader: '../handler/tupian.aspx?wh=<%=LibCache.get_theme_config("product_"+types+"_tp_wh")%>',
                queueID: 'fileQueue',
                auto: true,
                multi: false,
                buttonText: '上传图片',
                removeTimeout: 1,
                fileTypeExts: "*.jpg;*.gif;*.png;*.jpeg",
                onUploadSuccess: function (file, data, response) {
                    var rs = eval("(" + data + ")");
                    if (rs.res == "1") {
                        $("#img_logo").show().attr("src", rs.viewname);
                        $("#<%=hd_tupian.ClientID%>").val(rs.rukuname);
                    }
                    else {
                        alert("上传失败");
                    }
                }
            });
        });
    </script>
</body>
</html>