<%@ Page Title="" Language="C#" MasterPageFile="~/Master/SchoolMain.Master" AutoEventWireup="true" CodeBehind="RTEReport.aspx.cs" Inherits="GEB_School.ReportUI.RTEReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function calendarShown(sender, args) {
			sender._popupBehavior._element.style.zIndex = 10005;
		}
		$(function () {
			$(document.getElementById('<%= tabs.ClientID %>')).tabs();;
		});
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divCurrenTabSelected" class="hidden" visible="false">div1</div>
	<div id="divMain" style="width: 100%; text-align: left; padding-top: 5px;">
		<div id="divTitle" class="pageTitle" style="width: 100%;">
		    RTE Reports      
      	</div>

        <div>
        
        <div id="divContent" style="height: 100%; font-family: Verdana;">
			<div id="divContent1" style="width: 10%; float: left; height: 100%; color: white;">1</div>
			<div id="divContent2" style="width: 80%; float: left; height: 100%;">
				<div style="text-align: center; width: 100%;">
					<asp:Label ID="lblMsg" runat="server" CssClass="message" Visible="false"></asp:Label>
				</div>
				<div id="tabs" runat="server" class="style-tabs" style="width: 100%;">
					<ul>
						<li><a id="tabClassDetails" href="#tabs-1">Result Reports</a></li>
					</ul>
					<div id="tabs-1" style="padding: 10px 10px 10px 10px;" class="gradientBoxesWithOuterShadows">
						<div style="width: 100%;">
							<div id="divResultReports" runat="server" style="width: 100%">
								<fieldset>
									<legend>RTE Reports
									</legend>
									<div style="width: 100%;" class="divclasswithfloat">
									
										<div style="text-align: left; width: 25%; float: left;" class="label">
											<div style="text-align: left; width: 15%; float: left;" class="label">
												<img src="../Images/checked.gif" />
											</div>
											<div style="text-align: left; width: 85%; float: left;" class="label">
												<a style="text-decoration: none; color: black" href="../RTE/StudentNameWise.aspx">Student Name Wise RTE Report</a>
											</div>
										</div>
										<div style="text-align: left; width: 25%; float: left;" class="label">
											<div style="text-align: left; width: 15%; float: left;" class="label">
												<img src="../Images/checked.gif" />
											</div>
											<div style="text-align: left; width: 85%; float: left;" class="label">
												<a style="text-decoration: none; color: black" href="../RTE/StdWise.aspx">STD Wise RTE Report</a>
											</div>
										</div>
                                        <div style="text-align: left; width: 25%; float: left;" class="label">
											<div style="text-align: left; width: 15%; float: left;" class="label">
												<img src="../Images/checked.gif" />
											</div>
											<div style="text-align: left; width: 85%; float: left;" class="label">
												<a style="text-decoration: none; color: black" href="../RTE/DivWise.aspx">Div Wise RTE Report</a>
											</div>
										</div>
                                        <div style="text-align: left; width: 25%; float: left;" class="label">
											<div style="text-align: left; width: 15%; float: left;" class="label">
												<img src="../Images/checked.gif" />
											</div>
											<div style="text-align: left; width: 85%; float: left;" class="label">
												<a style="text-decoration: none; color: black" href="../RTE/Gr_NoWise.aspx">Gr_No Wise RTE Report</a>
											</div>
										</div>

                            <br><br>
                          <div style="text-align: left; width: 25%; float: left;" class="label">
											<div style="text-align: left; width: 15%; float: left;" class="label">
												<img src="../Images/checked.gif" />
											</div>
											<div style="text-align: left; width: 85%; float: left;" class="label">
												<a style="text-decoration: none; color: black" href="../RTE/YearWise.aspx">Year Wise RTE Report</a>
											</div>
										</div>


                                       
                                      
									</div>
								</fieldset>
							</div>
						</div>
					</div>
				</div>
				<div id="divContent3" style="width: 10%; float: right; height: 14px;"></div>
			</div>
		</div>
    </div>






    

</asp:Content>