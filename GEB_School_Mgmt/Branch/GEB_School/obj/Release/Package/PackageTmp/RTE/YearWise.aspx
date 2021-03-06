﻿<%@ Page Language="C#" MasterPageFile="~/Master/SchoolMain.Master" AutoEventWireup="true" CodeBehind="YearWise.aspx.cs" Inherits="GEB_School.RTE.YearWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	 <link href="../CSS/TabPanel.css" rel="stylesheet" />
    <link href="../CSS/screen.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <div id="divCurrenTabSelected" class="hidden" visible="false">div1</div>
    <div id="divMain" style="width: 100%; text-align: left; padding-top: 5px;">
        <div id="divTitle" class="pageTitle" style="width: 100%;">
            Student Year Wise RTE Report
            <asp:Button ID="btnPrintDetail" runat="server" CssClass="btn-blue btn-blue-medium" Text="Print Detail" OnClientClick="getPrint('divContent');" />
                   
             <%--<asp:Button ID="btnBack" runat="server" CssClass="btn-blue btn-blue-medium Detach" Text="Cancel" OnClick="btnBack_Click"/>
              
             <asp:Button ID="btnReport" runat="server" CssClass="btn-blue btn-blue-medium Detach" Text="Back To Menu" OnClick="btnReport_Click"/>--%>
        </div>


           <div id="divContent" style="height: 100%; font-family: Verdana;">
            <div id="divContent1" style="width: 10%; float: left; height: 100%; color: white;">1</div>
            <div id="divContent2" style="width: 80%; float: left; height: 100%;">
                <div style="text-align: center; width: 100%;">
                    <%--<asp:Label ID="lblMsg" runat="server" CssClass="message" Visible="false"></asp:Label>--%>
                </div>

                <div id="tabs" runat="server" class="style-tabs" visible="true" style="width: 100%;">

                    <div id="tabs-1" style="min-height: 150px;">

                        <asp:Panel ID="pnlEmployeeInfo" runat="server" GroupingText="RTE Student Details">
                          
                                <div style="width: 100%; float: left;" class="label">
                                        <div style="padding: 10px;">
                                            <div style="float: left; width: 15%;">
                                                Year :<span style="color: red">*</span>
                                            </div>
                                            <div style="float: left; width: 65%;">
                                                <asp:DropDownList ID="dllYear" runat="server" CssClass="validate[required] TextBox mytext" Width="50%" Height="100%">
                                                <asp:ListItem Value="-1">-Select-</asp:ListItem>
                                                <asp:ListItem Value="1">2018-19</asp:ListItem>
                                                <asp:ListItem Value="2">2017-18</asp:ListItem>
                                                <asp:ListItem Value="3">2016-17</asp:ListItem>
                                                <asp:ListItem Value="4">2015-16</asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<input type="text" class="autosuggest" />--%>
                                               <asp:HiddenField runat="server" ID="hfEmployeeMID" />
                                                <asp:HiddenField runat="server" ID="hfEmployeeCodeName" />
                                            </div>
                                            <div style="float: left; width: 20%;">
                                                 <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn-blue-new btn-blue-medium Attach" OnClick="btnGo_Click" />
                                            </div>
                                        </div>
                                    </div>

                            <div style="width: 100%; float: left; padding-top: 0px;" class="label">
                                <div style="padding: 10px; padding-right: 30px;">
                                   <%-- <div style="float: left; text-align: right; width: 100%; padding-bottom: 10px;">
                                        <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn-blue-new btn-blue-medium Attach" OnClick="btnGo_Click" />
                                    </div>--%>
                                </div>
                            </div>
                        </asp:Panel>
                        
                      
                            
                        </div>
                    

                </div>
                <div id="divContent3" style="width: 10%; float: right; height: 100%;"></div>
            </div>
        </div>
        <div style="width: 100%; float: left; padding-top: 0px;" class="label">
            <div style="padding: 10px; padding-right: 30px;">
                <div style="float: left; text-align: right; width: 100%; padding-bottom: 10px;">
                </div>
            </div>
        </div>
    </div>

       
     
    <script type="text/javascript">
		jQuery("#aspnetForm").validationEngine('attach', {
			promptPosition: "bottomRight",
			validationEventTrigger: "submit",
			validateNonVisibleFields: false,
			updatePromptsPosition: true
		});


		$('.Detach').click(function () {
			$("#aspnetForm").validationEngine('detach');
		});

	</script>
</asp:Content>
