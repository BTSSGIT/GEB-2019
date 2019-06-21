<%@ Page Language="C#" MasterPageFile="~/Master/SchoolMain.Master" AutoEventWireup="true" CodeBehind="Gr_NoWise.aspx.cs" Inherits="GEB_School.RTE.Gr_NoWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	 <link href="../CSS/TabPanel.css" rel="stylesheet" />
    <link href="../CSS/screen.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	 <div id="divCurrenTabSelected" class="hidden" visible="false">div1</div>
    <div id="divMain" style="width: 100%; text-align: left; padding-top: 5px;">
        <div id="divTitle" runat="server" class="pageTitle" style="width: 100%;">
            GR No Wise RTE Report
            <%--<asp:Button ID="btnPrintDetail" runat="server" CssClass="btn-blue btn-blue-medium" Text="Print Detail" OnClientClick="getPrint('divContent');" />--%>
                   
              
            <%-- <asp:Button ID="btnReport" runat="server" CssClass="btn-blue btn-blue-medium Detach" Text="Back To Menu" OnClick="btnReport_Click"/>--%>
        </div>


           <div id="divContent" style="height: 100%; font-family: Verdana;">
            <div id="divContent1" style="width: 10%; float: left; height: 100%; color: white;">1</div>
            <div id="divContent2" style="width: 80%; float: left; height: 100%;">
                <div style="text-align: center; width: 100%;">
                    <%--<asp:Label ID="lblMsg" runat="server" CssClass="message" Visible="false"></asp:Label>--%>
                </div>

                <div id="tabs" runat="server" class="style-tabs" visible="true" style="width: 100%;">

                    <div id="tabs-1" style="min-height: 150px;">

                        <asp:Panel ID="pnlStudentInfo" runat="server" GroupingText="RTE Student Details">
                          
                                <div style="width: 100%; float: left;" class="label">
                                        <div style="padding: 10px;">
                                            <div style="float: left; width: 15%;">
                                                GR No :<span style="color: red">*</span>
                                            </div>
                                            <div id="divStudent"style="float: left; width: 65%;">
                                                <asp:TextBox ID="txtGRNo" runat="server" CssClass="validate[required] TextBox mytext" Width="50%" Height="100%"></asp:TextBox>
                                                <%--<input type="text" class="autosuggest" />--%>
                                               <asp:HiddenField runat="server" ID="hfStudentMID" />
                                                <asp:HiddenField runat="server" ID="hfStudentFirstName" />
                                            </div>
                                            <div style="float: left; width: 20%;">
                                                 <%--<asp:Button runat="server" ID="btnGo1" Text="Go" CssClass="btn-blue-new btn-blue-medium Attach" OnClick="btnGo_Click" />--%>
                                            </div>
                                        </div>
                                    </div>

                            <div style="width: 100%; float: left; padding-top: 0px;" class="label">
                                <div style="padding: 10px; padding-right: 30px;">
                                    
                                </div>
                            </div>
                        </asp:Panel>
            
                        </div>                   
                </div>

                      <div style="width: 100%; float: left; padding-top: 0px;" class="label">
                                <div style="padding: 10px; padding-right: 30px;">
                                   <div class="row" style="overflow: scroll;">
                    <asp:GridView runat="server" ID="gvRTEReport" CssClass="table table-hover table-striped" AutoGenerateColumns="False"
                        HeaderStyle-Wrap="false" ShowHeaderWhenEmpty="True" Visible="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="StudentMID" HeaderText="StudentMID" />
                            <asp:BoundField DataField="StudentFirstNameEng" HeaderText="Student First Name" />
                            <asp:BoundField DataField="StudentMiddleNameEng" HeaderText="Student Middle Name" />
                            <asp:BoundField DataField="StudentLastNameEng" HeaderText="Student Last Name" />
                            <asp:BoundField DataField="FatherFirstNameEng" HeaderText="Father First Name" />
                            <asp:BoundField DataField="FatherMiddleNameEng" HeaderText="Father Middle Name" />
                            <asp:BoundField DataField="FatherLastNameEng" HeaderText="Father Last Name" />
                            <asp:BoundField DataField="MotherFirstNameEng" HeaderText="Mother First Name" />
                            <asp:BoundField DataField="MotherMiddleNameEng" HeaderText="Mother Middle Name" />
                            <asp:BoundField DataField="MotherLastNameEng" HeaderText="Mother Last Name" />
                            <asp:BoundField DataField="GenderEng" HeaderText="Gender" />
                            <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" />
                            <asp:BoundField DataField="CurrentYear" HeaderText="Current Year" />
                            <asp:BoundField DataField="CurrentSectionID" HeaderText="SectionID" />
                            <asp:BoundField DataField="CurrentGrNo" HeaderText="Current Gr No" />                           
                            <asp:BoundField DataField="CategoryEng" HeaderText="Category" />
                            <asp:BoundField DataField="SubCategory" HeaderText="Sub Category" />
                            <asp:BoundField DataField="ISRTE" HeaderText="RTE Student" />
                             
                             
                            

                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />

<HeaderStyle Wrap="False" BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
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