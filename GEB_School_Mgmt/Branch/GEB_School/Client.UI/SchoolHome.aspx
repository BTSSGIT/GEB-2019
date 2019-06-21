﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolHome.aspx.cs" MasterPageFile="~/Master/SchoolMain.Master" Inherits="GEB_School.Client.UI.SchoolHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img.watermark
        {
            filter: alpha(opacity=25);
            opacity: .25;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCurrenTabSelected" class="hidden" visible="false">div1</div>
    <div id="divMain" style="width: 100%; padding-top: 5px;">
        <div id="divTitle" class="pageTitle" style="width: 100%;">
           <%-- School Home--%>
            <asp:Label runat="server" ID="lblSchoolName"></asp:Label>
           <%-- <%# Eval("SchoolNameEng")%>--%>
        </div>
        <div runat="server" id="CollegeDashboard" class="water-img" width="100%" style="text-align:center;">
            <asp:Image class="watermark" ID="logowaterimg" runat="server" Width="500px" Height="400px"
                ImageUrl="~/Images/GEB LOGO school logo in english.jpg" />
        </div>
    </div>
</asp:Content>
