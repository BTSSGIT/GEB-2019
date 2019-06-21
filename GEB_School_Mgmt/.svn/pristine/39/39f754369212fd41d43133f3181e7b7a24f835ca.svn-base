<%@ Page EnableEventValidation="false" Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/SchoolMain.Master" CodeBehind="FeeCollection1.aspx.cs" Inherits="GEB_School.Client.UI.FeeCollection1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/TabPanel.css" rel="stylesheet" />
    <link href="../CSS/screen.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCurrenTabSelected" class="hidden" visible="false">div1</div>

    <div id="divMain" style="width: 100%; text-align: left; padding-top: 5px;">
        <div id="divTitle" class="pageTitle" style="width: 100%;">
            Class Fee Template
        </div>

        <div id="tabs" runat="server" class="style-tabs" visible="true" style="width: 100%;">
            <div style="width: 100%;">
                <div style="width: 100%;" class="divclasswithfloat">
                    <div style="text-align: left; width: 19%; float: left;" class="label">
                        Class :<span style="color: red">*</span>
                    </div>
                    <div style="text-align: left; width: 81%; float: left;">
                        <asp:DropDownList runat="server" ID="ddlClass" Width="150px">
                            <asp:ListItem>--Select Class--</asp:ListItem>
                            <asp:ListItem>SKG</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div style="width: 100%;" class="divclasswithfloat">
                    <div style="text-align: left; width: 19%; float: left;" class="label">
                        Division :<span style="color: red">*</span>
                    </div>
                    <div style="text-align: left; width: 81%; float: left;">
                        <asp:DropDownList runat="server" ID="ddldivision" Width="150px">
                            <asp:ListItem>--Select Division--</asp:ListItem>
                            <asp:ListItem>A</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="width: 100%;" class="divclasswithfloat">
                    <div style="text-align: left; width: 19%; float: left;" class="label">
                        Academic Year :<span style="color: red">*</span>
                    </div>
                    <div style="text-align: left; width: 81%; float: left;">
                        <asp:DropDownList runat="server" ID="ddlyear" Width="150px">
                            <asp:ListItem>--Select Year--</asp:ListItem>
                            <asp:ListItem>18-19</asp:ListItem>
                            <asp:ListItem>17-18</asp:ListItem>
                            <asp:ListItem>16-17</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="clear"></div>
                <div style="margin-top: 10px; width: 100%;" class="divclasswithoutfloat">
                    <asp:GridView ID="gvfc" runat="server" AutoGenerateColumns="False"
                        BorderColor="#3B5998" BorderWidth="3px" BorderStyle="Solid" CellPadding="4"
                        Font-Names="verdana" Font-Size="12px" Width="101%" BackColor="White" ShowHeaderWhenEmpty="True">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <RowStyle BackColor="White" Height="20px" ForeColor="#333333" />
                        <Columns>
                               <asp:TemplateField HeaderText="Reprint">
                                            <HeaderTemplate>

                                                <asp:CheckBox ID="chkHeader" runat="server" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <%--<input type="checkbox" id="chkChild" />--%>
                                                <asp:CheckBox ID="chkChild" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="Print">
                                            <HeaderTemplate>

                                                <asp:CheckBox ID="chkHeader" runat="server" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <%--<input type="checkbox" id="chkChild" />--%>
                                                <asp:CheckBox ID="chkChild" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                            <asp:BoundField DataField="SrNO" HeaderText="SrNO">
                                <HeaderStyle Width="300px" HorizontalAlign="left" VerticalAlign="Top" CssClass="hidden" />
                                <ItemStyle HorizontalAlign="left" Width="80%" VerticalAlign="Top" Wrap="true" CssClass="hidden" />
                            </asp:BoundField>

                            <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                <HeaderStyle Width="100px" HorizontalAlign="left" VerticalAlign="Top" />
                                <ItemStyle HorizontalAlign="left" Width="40%" VerticalAlign="Top" Wrap="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GRNo" HeaderText="GRNo">
                                <HeaderStyle Width="100px" HorizontalAlign="left" VerticalAlign="Top" />
                                <ItemStyle HorizontalAlign="left" Width="40%" VerticalAlign="Top" Wrap="true" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Receipt NO.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtReceiptNo" runat="server" Width="150px" CssClass="validate[custom[onlyNumberSp]] TextBox" onblur="howManyDecimals(this.id,'#FFDFDF')" onkeypress="return NumericKeyPressFraction(event)" Style="text-align: right;">0</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Admission Fees.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAdmissionFees" runat="server" Width="150px" CssClass="validate[custom[onlyNumberSp]] TextBox" onblur="howManyDecimals(this.id,'#FFDFDF')" onkeypress="return NumericKeyPressFraction(event)" Style="text-align: right;">0</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Term Fees.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTermFees" runat="server" Width="150px" CssClass="validate[custom[onlyNumberSp]] TextBox" onblur="howManyDecimals(this.id,'#FFDFDF')" onkeypress="return NumericKeyPressFraction(event)" Style="text-align: right;">0</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tuition Fees.">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTuitionfees" runat="server" Width="150px" CssClass="validate[custom[onlyNumberSp]] TextBox" onblur="howManyDecimals(this.id,'#FFDFDF')" onkeypress="return NumericKeyPressFraction(event)" Style="text-align: right;">0</asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Payment Done">
                                            <HeaderTemplate>

                                                <asp:CheckBox ID="chkHeader" runat="server" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <%--<input type="checkbox" id="chkChild" />--%>
                                                <asp:CheckBox ID="chkChild" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#3B5998" Font-Bold="True" Font-Names="Verdana" Font-Size="12px" />
                        <PagerStyle BackColor="#3B5998" ForeColor="White" HorizontalAlign="center" />
                        <SelectedRowStyle BackColor="#2B558E" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#3B5998" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>

                </div>


                <div style="text-align: right; height: 63px;" class="divclasswithoutfloat">
                    <%-- &nbsp;&nbsp;--%>
                    <asp:Button runat="server" ID="btnSave1" Text="Save" CssClass="btn-blue-new btn-blue-medium Detach" />
                     <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn-blue-new btn-blue-medium Detach" />
                </div>
                


            </div>
        </div>
    </div>
</asp:Content>
