<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogViewer.aspx.cs" EnableEventValidation="false" Inherits="Web_Forms_LogViewer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log Viewer</title>
    <link rel="stylesheet" href="/CSS/MasterStyle.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div style="width: 20%; float: left; background: rgb(0,144,202); width: 20%; height: 100%; position: fixed; top: 0px; margin: 0px; padding: 0px; z-index: 3;">
                <img src="/Images/logo-MRSLGROUP.png" id="ImageButton1" runat="server" style="width: 80%; margin-left: 6%; margin-top: 5px;" />
                <div style="margin-left: 18%; margin-top: 10%;">
                    <asp:Label runat="server" ID="lblStaffNameH" Text="Staff Name :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlStaffName" Width="200" runat="server" class="object-default1"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblStartDateH" Text="Start Date :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtStartDate" class="object-default1" Width="110" Height="30" Text="" Placeholder="Start" runat="server" ValidationGroup="Search"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="refvStartDate" runat="server" ControlToValidate="txtStartDate"
                        InitialValue="" Font-Bold="True" Font-Size="30px" ForeColor="Red" ValidationGroup="Search">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExStartDate" runat="server"
                        Font-Bold="True" Font-Size="20px" ForeColor="Red" ValidationGroup="Search"
                        ErrorMessage="Check"
                        ControlToValidate="txtStartDate"
                        ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" />
                    <br />
                    <br />
                    <asp:DropDownList ID="ddlStartTimeHour" runat="server" class="object-default1" Width="80px">
                        <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="00" Value="1"></asp:ListItem>
                        <asp:ListItem Text="01" Value="2"></asp:ListItem>
                        <asp:ListItem Text="02" Value="3"></asp:ListItem>
                        <asp:ListItem Text="03" Value="4"></asp:ListItem>
                        <asp:ListItem Text="04" Value="5"></asp:ListItem>
                        <asp:ListItem Text="05" Value="6"></asp:ListItem>
                        <asp:ListItem Text="06" Value="7"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="07" Value="8"></asp:ListItem>
                        <asp:ListItem Text="08" Value="9"></asp:ListItem>
                        <asp:ListItem Text="09" Value="10"></asp:ListItem>
                        <asp:ListItem Text="10" Value="11"></asp:ListItem>
                        <asp:ListItem Text="11" Value="12"></asp:ListItem>
                        <asp:ListItem Text="12" Value="13"></asp:ListItem>
                        <asp:ListItem Text="13" Value="14"></asp:ListItem>
                        <asp:ListItem Text="14" Value="15"></asp:ListItem>
                        <asp:ListItem Text="15" Value="16"></asp:ListItem>
                        <asp:ListItem Text="16" Value="17"></asp:ListItem>
                        <asp:ListItem Text="17" Value="18"></asp:ListItem>
                        <asp:ListItem Text="18" Value="19"></asp:ListItem>
                        <asp:ListItem Text="19" Value="20"></asp:ListItem>
                        <asp:ListItem Text="20" Value="21"></asp:ListItem>
                        <asp:ListItem Text="21" Value="22"></asp:ListItem>
                        <asp:ListItem Text="22" Value="23"></asp:ListItem>
                        <asp:ListItem Text="23" Value="24"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlStartTimeMinute" runat="server" class="object-default1" Width="80px">
                        <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="00" Value="1"></asp:ListItem>
                        <asp:ListItem Text="01" Value="2"></asp:ListItem>
                        <asp:ListItem Text="02" Value="3"></asp:ListItem>
                        <asp:ListItem Text="03" Value="4"></asp:ListItem>
                        <asp:ListItem Text="04" Value="5"></asp:ListItem>
                        <asp:ListItem Text="05" Value="6"></asp:ListItem>
                        <asp:ListItem Text="06" Value="7"></asp:ListItem>
                        <asp:ListItem Text="07" Value="8"></asp:ListItem>
                        <asp:ListItem Text="08" Value="9"></asp:ListItem>
                        <asp:ListItem Text="09" Value="10"></asp:ListItem>
                        <asp:ListItem Text="10" Value="11"></asp:ListItem>
                        <asp:ListItem Text="11" Value="12"></asp:ListItem>
                        <asp:ListItem Text="12" Value="13"></asp:ListItem>
                        <asp:ListItem Text="13" Value="14"></asp:ListItem>
                        <asp:ListItem Text="14" Value="15"></asp:ListItem>
                        <asp:ListItem Text="15" Value="16"></asp:ListItem>
                        <asp:ListItem Text="16" Value="17"></asp:ListItem>
                        <asp:ListItem Text="17" Value="18"></asp:ListItem>
                        <asp:ListItem Text="18" Value="19"></asp:ListItem>
                        <asp:ListItem Text="19" Value="20"></asp:ListItem>
                        <asp:ListItem Text="20" Value="21"></asp:ListItem>
                        <asp:ListItem Text="21" Value="22"></asp:ListItem>
                        <asp:ListItem Text="22" Value="23"></asp:ListItem>
                        <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        <asp:ListItem Text="24" Value="25"></asp:ListItem>
                        <asp:ListItem Text="25" Value="26"></asp:ListItem>
                        <asp:ListItem Text="26" Value="27"></asp:ListItem>
                        <asp:ListItem Text="27" Value="28"></asp:ListItem>
                        <asp:ListItem Text="28" Value="29"></asp:ListItem>
                        <asp:ListItem Text="29" Value="30"></asp:ListItem>
                        <asp:ListItem Text="30" Value="31"></asp:ListItem>
                        <asp:ListItem Text="31" Value="32"></asp:ListItem>
                        <asp:ListItem Text="32" Value="33"></asp:ListItem>
                        <asp:ListItem Text="33" Value="34"></asp:ListItem>
                        <asp:ListItem Text="34" Value="35"></asp:ListItem>
                        <asp:ListItem Text="35" Value="36"></asp:ListItem>
                        <asp:ListItem Text="36" Value="37"></asp:ListItem>
                        <asp:ListItem Text="37" Value="38"></asp:ListItem>
                        <asp:ListItem Text="38" Value="39"></asp:ListItem>
                        <asp:ListItem Text="39" Value="40"></asp:ListItem>
                        <asp:ListItem Text="40" Value="41"></asp:ListItem>
                        <asp:ListItem Text="41" Value="42"></asp:ListItem>
                        <asp:ListItem Text="42" Value="43"></asp:ListItem>
                        <asp:ListItem Text="43" Value="44"></asp:ListItem>
                        <asp:ListItem Text="44" Value="45"></asp:ListItem>
                        <asp:ListItem Text="45" Value="46"></asp:ListItem>
                        <asp:ListItem Text="46" Value="47"></asp:ListItem>
                        <asp:ListItem Text="47" Value="48"></asp:ListItem>
                        <asp:ListItem Text="48" Value="49"></asp:ListItem>
                        <asp:ListItem Text="49" Value="50"></asp:ListItem>
                        <asp:ListItem Text="50" Value="51"></asp:ListItem>
                        <asp:ListItem Text="51" Value="52"></asp:ListItem>
                        <asp:ListItem Text="52" Value="53"></asp:ListItem>
                        <asp:ListItem Text="53" Value="54"></asp:ListItem>
                        <asp:ListItem Text="54" Value="55"></asp:ListItem>
                        <asp:ListItem Text="55" Value="56"></asp:ListItem>
                        <asp:ListItem Text="56" Value="57"></asp:ListItem>
                        <asp:ListItem Text="57" Value="58"></asp:ListItem>
                        <asp:ListItem Text="58" Value="59"></asp:ListItem>
                        <asp:ListItem Text="59" Value="60"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblEndDateH" Text="End Date :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtEndDate" class="object-default1" Width="110" Height="30" Text="" Placeholder="End" runat="server" ValidationGroup="Search"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="refvEndDate" runat="server" ControlToValidate="txtEndDate"
                        InitialValue="" Font-Bold="True" Font-Size="30px" ForeColor="Red" ValidationGroup="Search">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExEndDate" runat="server"
                        Font-Bold="True" Font-Size="20px" ForeColor="Red" ValidationGroup="Search"
                        ErrorMessage="Check"
                        ControlToValidate="txtEndDate"
                        ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="dd/MM/yyyy" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    <br />
                    <br />
                    <asp:DropDownList ID="ddlEndTimeHour" runat="server" class="object-default1" Width="80px">
                        <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="00" Value="1"></asp:ListItem>
                        <asp:ListItem Text="01" Value="2"></asp:ListItem>
                        <asp:ListItem Text="02" Value="3"></asp:ListItem>
                        <asp:ListItem Text="03" Value="4"></asp:ListItem>
                        <asp:ListItem Text="04" Value="5"></asp:ListItem>
                        <asp:ListItem Text="05" Value="6"></asp:ListItem>
                        <asp:ListItem Text="06" Value="7"></asp:ListItem>
                        <asp:ListItem Text="07" Value="8"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="08" Value="9"></asp:ListItem>
                        <asp:ListItem Text="09" Value="10"></asp:ListItem>
                        <asp:ListItem Text="10" Value="11"></asp:ListItem>
                        <asp:ListItem Text="11" Value="12"></asp:ListItem>
                        <asp:ListItem Text="12" Value="13"></asp:ListItem>
                        <asp:ListItem Text="13" Value="14"></asp:ListItem>
                        <asp:ListItem Text="14" Value="15"></asp:ListItem>
                        <asp:ListItem Text="15" Value="16"></asp:ListItem>
                        <asp:ListItem Text="16" Value="17"></asp:ListItem>
                        <asp:ListItem Text="17" Value="18"></asp:ListItem>
                        <asp:ListItem Text="18" Value="19"></asp:ListItem>
                        <asp:ListItem Text="19" Value="20"></asp:ListItem>
                        <asp:ListItem Text="20" Value="21"></asp:ListItem>
                        <asp:ListItem Text="21" Value="22"></asp:ListItem>
                        <asp:ListItem Text="22" Value="23"></asp:ListItem>
                        <asp:ListItem Text="23" Value="24"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlEndTimeMinute" runat="server" class="object-default1" Width="80px">
                        <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                        <asp:ListItem Selected="True" Text="00" Value="1"></asp:ListItem>
                        <asp:ListItem Text="01" Value="2"></asp:ListItem>
                        <asp:ListItem Text="02" Value="3"></asp:ListItem>
                        <asp:ListItem Text="03" Value="4"></asp:ListItem>
                        <asp:ListItem Text="04" Value="5"></asp:ListItem>
                        <asp:ListItem Text="05" Value="6"></asp:ListItem>
                        <asp:ListItem Text="06" Value="7"></asp:ListItem>
                        <asp:ListItem Text="07" Value="8"></asp:ListItem>
                        <asp:ListItem Text="08" Value="9"></asp:ListItem>
                        <asp:ListItem Text="09" Value="10"></asp:ListItem>
                        <asp:ListItem Text="10" Value="11"></asp:ListItem>
                        <asp:ListItem Text="11" Value="12"></asp:ListItem>
                        <asp:ListItem Text="12" Value="13"></asp:ListItem>
                        <asp:ListItem Text="13" Value="14"></asp:ListItem>
                        <asp:ListItem Text="14" Value="15"></asp:ListItem>
                        <asp:ListItem Text="15" Value="16"></asp:ListItem>
                        <asp:ListItem Text="16" Value="17"></asp:ListItem>
                        <asp:ListItem Text="17" Value="18"></asp:ListItem>
                        <asp:ListItem Text="18" Value="19"></asp:ListItem>
                        <asp:ListItem Text="19" Value="20"></asp:ListItem>
                        <asp:ListItem Text="20" Value="21"></asp:ListItem>
                        <asp:ListItem Text="21" Value="22"></asp:ListItem>
                        <asp:ListItem Text="22" Value="23"></asp:ListItem>
                        <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        <asp:ListItem Text="24" Value="25"></asp:ListItem>
                        <asp:ListItem Text="25" Value="26"></asp:ListItem>
                        <asp:ListItem Text="26" Value="27"></asp:ListItem>
                        <asp:ListItem Text="27" Value="28"></asp:ListItem>
                        <asp:ListItem Text="28" Value="29"></asp:ListItem>
                        <asp:ListItem Text="29" Value="30"></asp:ListItem>
                        <asp:ListItem Text="30" Value="31"></asp:ListItem>
                        <asp:ListItem Text="31" Value="32"></asp:ListItem>
                        <asp:ListItem Text="32" Value="33"></asp:ListItem>
                        <asp:ListItem Text="33" Value="34"></asp:ListItem>
                        <asp:ListItem Text="34" Value="35"></asp:ListItem>
                        <asp:ListItem Text="35" Value="36"></asp:ListItem>
                        <asp:ListItem Text="36" Value="37"></asp:ListItem>
                        <asp:ListItem Text="37" Value="38"></asp:ListItem>
                        <asp:ListItem Text="38" Value="39"></asp:ListItem>
                        <asp:ListItem Text="39" Value="40"></asp:ListItem>
                        <asp:ListItem Text="40" Value="41"></asp:ListItem>
                        <asp:ListItem Text="41" Value="42"></asp:ListItem>
                        <asp:ListItem Text="42" Value="43"></asp:ListItem>
                        <asp:ListItem Text="43" Value="44"></asp:ListItem>
                        <asp:ListItem Text="44" Value="45"></asp:ListItem>
                        <asp:ListItem Text="45" Value="46"></asp:ListItem>
                        <asp:ListItem Text="46" Value="47"></asp:ListItem>
                        <asp:ListItem Text="47" Value="48"></asp:ListItem>
                        <asp:ListItem Text="48" Value="49"></asp:ListItem>
                        <asp:ListItem Text="49" Value="50"></asp:ListItem>
                        <asp:ListItem Text="50" Value="51"></asp:ListItem>
                        <asp:ListItem Text="51" Value="52"></asp:ListItem>
                        <asp:ListItem Text="52" Value="53"></asp:ListItem>
                        <asp:ListItem Text="53" Value="54"></asp:ListItem>
                        <asp:ListItem Text="54" Value="55"></asp:ListItem>
                        <asp:ListItem Text="55" Value="56"></asp:ListItem>
                        <asp:ListItem Text="56" Value="57"></asp:ListItem>
                        <asp:ListItem Text="57" Value="58"></asp:ListItem>
                        <asp:ListItem Text="58" Value="59"></asp:ListItem>
                        <asp:ListItem Text="59" Value="60"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cmpValue" ControlToCompare="txtStartDate"
                        ControlToValidate="txtEndDate" Type="Date" Operator="GreaterThanEqual" Font-Bold="True" Font-Size="23px" ForeColor="Red" ValidationGroup="Search"
                        ErrorMessage="Check Dates" runat="server"></asp:CompareValidator>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblLogTypeH" Text="Log Type :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlLogType" Width="200" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLogType_SelectedIndexChanged" class="object-default1"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblReportIdH" Text="Report ID :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtReportId" class="object-default1" Width="175" Height="30" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblReportNameH" Text="Report Name :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlReport" Width="200" runat="server" class="object-default1">
                        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label runat="server" ID="lblReportAuthorH" Text="Report Author :" ForeColor="White"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlReportAuthor" Width="200" runat="server" class="object-default1"></asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" BorderColor="White" class="btn btn-primary" Width="200" OnClick="btnSubmit_Click" Text="Display Logs" ValidationGroup="Search" />
                    <br />
                    <br />
                    <asp:Button ID="btnPrint" runat="server" BorderColor="White" class="btn btn-primary" Width="200" OnClick="btnPrint_Click" Text="Export Logs" ValidationGroup="Search" />
                </div>
            </div>
            <div style="width: 78%; float: right">
                <asp:GridView ID="gvLogViewer" runat="server" AutoGenerateColumns="False" DataKeyNames="LogID" HeaderStyle-CssClass="gvHeader" EmptyDataText="There are no logs to display."
                    Width="95%" Font-Size="14px" PageSize="25" AllowPaging="True" OnPageIndexChanging="gvLogViewer_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Log ID" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="LogID">
                            <ItemTemplate>
                                <asp:Label ID="lblLogID" runat="server" Text='<%# Bind("LogID") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Log Type" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="LogType">
                            <ItemTemplate>
                                <asp:Label ID="lblLogType" runat="server" Text='<%# Bind("LogType") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Stamp" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="DateStamp">
                            <ItemTemplate>
                                <asp:Label ID="lblDateStamp" runat="server" Text='<%# Bind("DateStamp") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="200" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report ID" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="ReportID">
                            <ItemTemplate>
                                <asp:Label ID="lblReportID" runat="server" Text='<%# Bind("ReportID") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Report">
                            <ItemTemplate>
                                <asp:Label ID="lblReport" runat="server" Text='<%# Bind("Report") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Author" HeaderStyle-BackColor="#555555" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Report Author">
                            <ItemTemplate>
                                <asp:Label ID="lblReportAuthor" runat="server" Text='<%# Bind("ReportAuthor") %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblSortDisplay" runat="server" Visible="false" Text="Set" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalDb %>"
                    SelectCommand="SELECT TOP (25) * FROM [View_Log] order by datestamp desc"></asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>
