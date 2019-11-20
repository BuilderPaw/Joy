<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="Scripts/jsHumanBody.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript">
        function ToAttachedFiles(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divAttachedFiles").offset().top
            }, 1000);
        }

        function ToLinkedReports(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divLinkedReports").offset().top
            }, 1000);
        }

        function ToPendingActions(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divPendingActions").offset().top
            }, 1000);
        }

        function ToCommentSection(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divComment").offset().top
            }, 1000);
        }
    </script>

    <div id="body" runat="server" class="body">
        <div id="navigation" runat="server">
            <table class="navigation-table">
                <tr>
                    <td>
                        <asp:Button ID="btnNavHome" runat="server" CssClass="btn" Width="100%" BackColor="#285e8e" OnClick="btnNavHome_Click" Text="Home" />
                    </td>
                    <td>
                        <div class="navigation-div">
                            <div>
                                <asp:Button ID="btnNavActionsAssigned" runat="server" CssClass="btn" Width="100%" OnClick="btnNavActionsAssigned_Click" Text="Actions Assigned" />
                            </div>
                            <div class="navigation-notification-div">
                                <asp:Label ID="lblNotifyAssigned" runat="server" CssClass="navigation-notification-label" Text="1"></asp:Label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="navigation-div">
                            <div>
                                <asp:Button ID="btnNavReportActions" runat="server" CssClass="btn" Width="100%" OnClick="btnNavReportActions_Click" Text="Report Actions" />
                            </div>
                            <div class="navigation-notification-div">
                                <asp:Label ID="lblNotifyActions" runat="server" CssClass="navigation-notification-label" Text="2"></asp:Label>
                            </div>
                        </div>
                    </td>
                    <td id="tdManagerSign" runat="server">
                        <div class="navigation-div">
                            <div>
                                <asp:Button ID="btnNavManagerSign" runat="server" CssClass="btn" Width="100%" OnClick="btnNavManagerSign_Click" Text="Manager Sign-off Required" />
                            </div>
                            <div class="navigation-notification-div">
                                <asp:Label ID="lblNotifyManSign" runat="server" CssClass="navigation-notification-label" Text="3"></asp:Label>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:SqlDataSource ID="sdsUserReports" runat="server"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT [ReportId], [ReportName], [StaffId], [StaffName], [ShiftName], [ShiftDate], [ShiftDOW], [Report_Table],
                          [Report_Version], [ReportStat], [AuditVersion], [RowNum]
                          FROM [View_Reports]
                          ORDER BY [ShiftDate] DESC, [ShiftId] DESC, RowNum"></asp:SqlDataSource>
        <asp:GridView ID="gvUserReports" runat="server" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row"
            SortedAscendingHeaderStyle-CssClass="one" SortedDescendingHeaderStyle-CssClass="one"
            DataKeyNames="ReportId" DataSourceID="sdsUserReports" AutoGenerateColumns="False" PageSize="10" AllowPaging="True" AllowSorting="true"
            OnRowCommand="SelectedReport" OnRowCreated="gvUserReports_RowCreated" OnPageIndexChanging="gvUserReports_PageIndexChanging" OnSorting="gvUserReports_Sorting" EmptyDataText="There are no reports to display.">
            <Columns>
               <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="#555555" >
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" runat="server" />
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="#555555" >
                    <HeaderTemplate>
                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                            style="width: 100%; height: 100%; padding: 6px 12px; font-size: 14px; line-height: 1.428571429; color: #555555; vertical-align: middle; 
                            background-color: #ffffff; border: 1px solid #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); 
                            box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; 
                            transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;">
                            <asp:ListItem Value="10" Text="10" />
                            <asp:ListItem Value="20" Text="20" />
                        </asp:DropDownList>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" CssClass="btn" CommandName="Select" Text="View" />
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report ID" HeaderStyle-BackColor="#555555" SortExpression="ReportId">
                    <ItemTemplate>
                        <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff ID" Visible="false" SortExpression="StaffID">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffID" runat="server" Text='<%# Bind("StaffId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff Name" HeaderStyle-BackColor="#555555" SortExpression="StaffName">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shift" HeaderStyle-BackColor="#555555" SortExpression="ShiftName">
                    <ItemTemplate>
                        <asp:Label ID="lblShiftName" runat="server" Text='<%# Bind("ShiftName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOW" HeaderStyle-BackColor="#555555" SortExpression="ShiftDOW">
                    <ItemTemplate>
                        <asp:Label ID="lblDOW" runat="server" Text='<%# Bind("ShiftDOW") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shift Date" HeaderStyle-BackColor="#555555" SortExpression="ShiftDate">
                    <ItemTemplate>
                        <asp:Label ID="lblShiftDate" runat="server" Text='<%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dd/MM/yyyy") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Type" HeaderStyle-BackColor="#555555" SortExpression="ReportName">
                    <ItemTemplate>
                        <asp:Label ID="lblReportType" runat="server" Text='<%# Bind("ReportName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#555555" SortExpression="ReportStat">
                    <ItemTemplate>
                        <asp:Label ID="lblReportStat" runat="server" Text='<%# Bind("ReportStat") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Audit Version" Visible="false" SortExpression="AuditVersion">
                    <ItemTemplate>
                        <asp:Label ID="lblAuditVersion" runat="server" Text='<%# Bind("AuditVersion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Table" Visible="false" SortExpression="Report_Table">
                    <ItemTemplate>
                        <asp:Label ID="lblReportTable" runat="server" Text='<%# Bind("Report_Table") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Version" Visible="false" SortExpression="Report_Version">
                    <ItemTemplate>
                        <asp:Label ID="lblReportVersion" runat="server" Text='<%# Bind("Report_Version") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RowNum" Visible="false" SortExpression="RowNum">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNum" runat="server" Text='<%# Bind("RowNum") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnMarkAsRead" OnClientClick="ShowProgress()" Visible="false" style="width:120px; height:55px; margin-top:2%; margin-left:5%;" runat="server" CssClass="btn" Text="Mark as Read" OnClick="btnMarkAsRead_Click" />        
        <asp:Button ID="btnSignAsManager" Visible="false" style="width:130px; height:55px; margin-top:2%; margin-left:5%;" runat="server" CssClass="btn" Text="Sign as Manager" OnClick="btnSignAsManager_Click" />
        <asp:SqlDataSource ID="sdsActionReports" runat="server"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT [ReportId], [Report_Table], [Version], [AuditVersion], [ReportName], [ReportStat], [StaffAuthor], [StaffSelected], [StaffId], [StaffName], [Description], [SubmittedTo], [SubmittedBy], [SubmittedDate], [Completed], [CompletedDate], ROW_NUMBER() OVER (ORDER BY [SubmittedDate] DESC) AS [RowNum] FROM [ActionRequired]"></asp:SqlDataSource>
        <asp:GridView ID="gvActionReports" runat="server" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row"
            DataKeyNames="ReportId" DataSourceID="sdsActionReports" AutoGenerateColumns="False" PageSize="10" AllowPaging="True" AllowSorting="True" Visible="false"
            OnRowCommand="SelectedReport" OnPageIndexChanging="gvActionReports_PageIndexChanging" OnSorting="gvActionReports_Sorting"  EmptyDataText="There are no reports to display." >
            <Columns>
                <asp:TemplateField HeaderText=" " HeaderStyle-BackColor="#555555">
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" CssClass="btn" CommandName="Select" Text="View" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report ID" HeaderStyle-BackColor="#555555" SortExpression="ReportId">
                    <ItemTemplate>
                        <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Type" HeaderStyle-BackColor="#555555" SortExpression="ReportName">
                    <ItemTemplate>
                        <asp:Label ID="lblReportType" runat="server" Text='<%# Bind("ReportName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff ID" Visible="false" SortExpression="StaffId">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffID" runat="server" Text='<%# Bind("StaffAuthor") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff Name" Visible="false" SortExpression="StaffName">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Staff Name" Visible="false" SortExpression="StaffSelected">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffName1" runat="server" Text='<%# Bind("StaffSelected") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="ReportStat">
                    <ItemTemplate>
                        <asp:Label ID="lblReportStat" runat="server" Text='<%# Bind("ReportStat") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Audit Version" Visible="false" SortExpression="AuditVersion">
                    <ItemTemplate>
                        <asp:Label ID="lblAuditVersion" runat="server" Text='<%# Bind("AuditVersion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Table" Visible="false" SortExpression="Report_Table">
                    <ItemTemplate>
                        <asp:Label ID="lblReportTable" runat="server" Text='<%# Bind("Report_Table") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Report Version" Visible="false" SortExpression="Version">
                    <ItemTemplate>
                        <asp:Label ID="lblReportVersion" runat="server" Text='<%# Bind("Version") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" HeaderStyle-BackColor="#555555" ItemStyle-Width="260px" SortExpression="Description">
                    <ItemTemplate>
                        <%# (string.IsNullOrWhiteSpace(Eval("Description").ToString())) ? Eval("Description") : (Eval("Description").ToString()).Replace("^", "'") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Submitted To" HeaderStyle-BackColor="#555555" ItemStyle-Width="260px" SortExpression="SubmittedTo">
                    <ItemTemplate>
                        <%# Eval("SubmittedTo") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Submitted By" HeaderStyle-BackColor="#555555" SortExpression="SubmittedBy">
                    <ItemTemplate>
                        <%# Eval("SubmittedBy") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Submitted Date" HeaderStyle-BackColor="#555555" SortExpression="SubmittedDate">
                    <ItemTemplate>
                        <%# ConvertDateTime(Eval("SubmittedDate")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Completed" HeaderStyle-BackColor="#555555" SortExpression="Completed">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbCompleted" runat="server" Checked='<%# Eval("Completed") %>' Enabled="false"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Completed Date" HeaderStyle-BackColor="#555555" SortExpression="CompletedDate">
                    <ItemTemplate>
                        <asp:Label ID="lblCompletedDate" runat="server" Text='<%# ConvertDateTime(Eval("CompletedDate")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RowNum" Visible="false" SortExpression="RowNum">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNum" runat="server" Text='<%# Bind("RowNum") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="sdsViewReport"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            OnSelecting="OnSelecting"
            SelectCommand="SELECT rt.StaffName, st.ShiftName, c.ReportName, *
                       FROM Report_MerrylandsRSLIncident rt, [Staff] s, [Shift] st, [Category] c
                       WHERE rt.StaffId = s.StaffId AND rt.ShiftId = st.ShiftId AND c.RCatId = rt.RCatId AND rt.ReportId = @ReportId">
            <SelectParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:FormView runat="server" ID="fvReport" DataKeyNames="ReportId" DataSourceID="sdsViewReport" Visible="false">
            <ItemTemplate>
            </ItemTemplate>
            <EditItemTemplate>
            </EditItemTemplate>
        </asp:FormView>
        <asp:PlaceHolder runat="server" ID="phUserControl" />
        <asp:ImageButton ID="imgPreviousReport" runat="server" OnClick="PreviousReport" Visible="false" class="arrow-left" ImageUrl="~/Images/arrow-left.png" />
        <asp:ImageButton ID="imgReadLeft" runat="server" OnClick="ReadAndGoToPreviousReport" Visible="false" class="arrow-left-up" ImageUrl="~/Images/read-icon.png" />
        <asp:ImageButton ID="imgNextReport" runat="server" OnClick="NextReport" Visible="false" class="arrow-right" ImageUrl="~/Images/arrow-right.png" />
        <asp:ImageButton ID="imgReadRight" runat="server" OnClick="ReadAndGoToNextReport" Visible="false" class="arrow-right-up" ImageUrl="~/Images/read-icon.png" />
        <asp:ImageButton ID="imgTopScreen" runat="server" OnClientClick="ToTopOfPage(); return false;" Visible="false" class="arrow-up" ImageUrl="~/Images/arrow-up.png" />
        <asp:ImageButton ID="imgBottomScreen" runat="server" OnClientClick="ToBottomOfPage(); return false;" Visible="false" class="arrow-down" ImageUrl="~/Images/arrow-down.png" />
        <asp:Button ID="btnLinkAttachedFiles" runat="server" OnClientClick="ToAttachedFiles(); return false;" Visible="false" class="link-attached-files" Text="Attached &#010; Files" />
        <asp:Button ID="btnLinkLinkedReports" runat="server" OnClientClick="ToLinkedReports(); return false;" Visible="false" class="link-linked-reports" Text="Linked &#010; Reports" />
        <asp:Button ID="btnLinkPendingActions" runat="server" OnClientClick="ToPendingActions(); return false;" Visible="false" class="link-pending-actions" Text="Pending &#010; Actions" />
        <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" Visible="false" CssClass="spell-button" />
        <div id="divAttachedFiles">
            <asp:Label ID="lblAttachedFiles" runat="server" Style="position: relative; top: 15px; left: 90px;" Visible="false" Font-Bold="true" Text="Attached Files"></asp:Label>
            <br />
            <asp:GridView ID="gvAttachedFiles" runat="server" ShowHeaderWhenEmpty="true" HeaderStyle-CssClass="report-gridview-row" RowStyle-CssClass="report-gridview-row"
                Style="position: relative; top: 15px; margin-bottom: 40px;" Width="84%" AutoGenerateColumns="False" AllowPaging="True"
                Visible="false" Font-Size="14px" EmptyDataText="There are No Data Records to Display." OnRowCommand="gvAttachedFiles_RowCommand" OnRowDataBound="gvAttachedFiles_RowDataBound"
                OnRowDeleted="OnRowDeleted" OnRowDeleting="gvAttachedFiles_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Font-Size="X-Small" CssClass="btn" CommandArgument='<%# Eval("File") %>'
                                CausesValidation="false" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server"
                                CausesValidation="False"
                                CommandArgument='<%# Eval("File") %>'
                                CommandName="DownloadFile" Text='<%# Eval("File") %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Type" HeaderText="File Type" />
                </Columns>
            </asp:GridView>
            <asp:FileUpload ID="fuUpload" runat="server" Style="position: relative; top: -15px; left: 100px;" Visible="false" AllowMultiple="true" />
            <asp:Button ID="btnUpload" runat="server" Style="position: relative; top: -15px; left: 100px;" class="btn" OnClick="btnUpload_Click" Visible="false" Text="Upload" />
        </div>
        <asp:SqlDataSource runat="server" ID="sdsLinkedReports"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT * FROM [LinkedReports]"
            DeleteCommand="DELETE FROM [LinkedReports] WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="sdsLinkReports"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT [ReportId]
                              ,[ReportName]
                              ,[StaffId]
                              ,[StaffName]
                              ,[ShiftName]
                              ,[ShiftDate]
                              ,[ShiftDOW]
                              ,[Report_Table]
                              ,[Report_Version]
                              ,[ReportStat]
                              ,[AuditVersion]
                              ,[RowNum]
                          FROM [dbo].[View_Reports]
                          ORDER BY [ShiftDate] DESC, [ShiftId] DESC"></asp:SqlDataSource>
        <div id="divLinkedReports">
            <asp:Label ID="lblLinkedReports" runat="server" Style="position: relative; top: 15px; left: 90px;" Visible="false" Font-Bold="true" Text="Linked Reports"></asp:Label>
            <asp:GridView ID="gvLinkedReports" runat="server" HeaderStyle-CssClass="report-gridview-row" RowStyle-CssClass="report-gridview-row"
                Style="position: relative; top: 15px; margin-bottom: 40px;" Width="84%" DataSourceID="sdsLinkedReports" AutoGenerateColumns="False" AllowPaging="True"
                Visible="false" Font-Size="14px" EmptyDataText="There are No Data Records to Display." ShowFooter="true"
                OnRowCommand="gvLinkedReports_RowCommand" OnRowDeleted="OnRowDeleted" OnRowDataBound="gvLinkedReports_RowDataBound">
                <EmptyDataTemplate>
                    <tr>
                        <th>
                            <asp:Label ID="lblDescriptionHead" runat="server" Text="Action" />
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnInsert1" runat="server" Font-Size="X-Small" CssClass="btn" CommandName="EmptyDataTemplateInsert" Text="Link a Report" />
                        </td>
                    </tr>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField ItemStyle-Width="12%">
                        <ItemTemplate>
                            <asp:Button ID="btnView" runat="server" Font-Size="X-Small" CssClass="btn" CausesValidation="false" CommandName="View" Text="View" />
                            <asp:Button ID="btnSelect" runat="server" Font-Size="X-Small" CssClass="btn" CausesValidation="false" CommandName="Select" Text="Preview" />
                            <asp:Button ID="btnDelete1" runat="server" Font-Size="X-Small" CssClass="btn" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" Text="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnInsert" Font-Size="X-Small" CssClass="btn" runat="server" CommandName="FooterInsert" Text="Link a Report" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="id">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Report ID">
                        <ItemTemplate>
                            <asp:Label ID="lblReportId" runat="server" Text='<%# Eval("RId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Report Name">
                        <ItemTemplate>
                            <asp:Label ID="lblReportType" runat="server" Text='<%# Eval("ReportName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Staff ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffId" runat="server" Text='<%# Eval("StaffId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Linked By">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("StaffName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Report Table">
                        <ItemTemplate>
                            <asp:Label ID="lblReportTable" runat="server" Text='<%# Eval("ReportTable") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Version">
                        <ItemTemplate>
                            <asp:Label ID="lblReportVersion" runat="server" Text='<%# Eval("Version") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="divLinkReports" runat="server" visible="false" style="position: relative; left: 8%; width: 84%; margin-top: -1.9%; margin-bottom: 7%">
            <div style="border: 0.5px solid; width: 85%; float: right;">
                <asp:GridView ID="gvLinkReports" runat="server" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row"
                    Font-Size="10px" Width="100%"
                    DataKeyNames="ReportId" DataSourceID="sdsLinkReports" AutoGenerateColumns="False" PageSize="4" AllowPaging="True" AllowSorting="True"
                    OnRowCommand="gvLinkReports_RowCommand" OnPageIndexChanging="gvLinkReports_PageIndexChanging" OnSorting="gvLinkReports_Sorting"
                    OnSelectedIndexChanged="gvLinkReports_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText=" "  HeaderStyle-BackColor="#555555">
                            <ItemTemplate>
                                <asp:Button ID="btnSelect" OnClientClick="return confirm ('Are you sure you want to create a link to this report?')" Font-Size="X-Small" runat="server" CssClass="btn btn-primary" CommandName="Select" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report ID" HeaderStyle-BackColor="#555555" SortExpression="ReportId">
                            <ItemTemplate>
                                <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff ID" Visible="false" SortExpression="StaffId">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Staff Name" HeaderStyle-BackColor="#555555" SortExpression="StaffName">
                            <ItemTemplate>
                                <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift" HeaderStyle-BackColor="#555555" SortExpression="ShiftName">
                            <ItemTemplate>
                                <asp:Label ID="lblShiftName" runat="server" Text='<%# Bind("ShiftName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOW" HeaderStyle-BackColor="#555555" SortExpression="ShiftDOW">
                            <ItemTemplate>
                                <asp:Label ID="lblDOW" runat="server" Text='<%# Bind("ShiftDOW") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shift Date" HeaderStyle-BackColor="#555555" SortExpression="ShiftDate">
                            <ItemTemplate>
                                <asp:Label ID="lblShiftDate" runat="server" Text='<%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dd/MM/yyyy") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Type" HeaderStyle-BackColor="#555555" SortExpression="ReportName">
                            <ItemTemplate>
                                <asp:Label ID="lblReportType" runat="server" Text='<%# Bind("ReportName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-BackColor="#555555" ItemStyle-Width="200" SortExpression="ReportStat">
                            <ItemTemplate>
                                <asp:Label ID="lblReportStat" runat="server" Text='<%# Bind("ReportStat") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Audit Version" Visible="false" SortExpression="AuditVersion">
                            <ItemTemplate>
                                <asp:Label ID="lblAuditVersion" runat="server" Text='<%# Bind("AuditVersion") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Table" Visible="false" SortExpression="Report_Table">
                            <ItemTemplate>
                                <asp:Label ID="lblReportTable" runat="server" Text='<%# Bind("Report_Table") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Report Version" Visible="false" SortExpression="Report_Version">
                            <ItemTemplate>
                                <asp:Label ID="lblReportVersion" runat="server" Text='<%# Bind("Report_Version") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RowNum" Visible="false" SortExpression="RowNum">
                            <ItemTemplate>
                                <asp:Label ID="lblRowNum" runat="server" Text='<%# Bind("RowNum") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="border: 0.5px solid; width: 15%; float: right;">
                <div class="link-reports">
                    <asp:Label ID="lblReportType" Style="margin-left: 16%;" Font-Size="100%" runat="server">Report Type</asp:Label><br />
                    <asp:RequiredFieldValidator ID="rfvReportType" Style="margin-left: 4.9%;" runat="server" ControlToValidate="ddlReportType" InitialValue="-1" Font-Bold="True" Font-Size="12px" ForeColor="Red" ValidationGroup="Search1">Select Report Type</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlReportType" Style="width: 90%; margin-left: 4.9%; font-size: 10.5px;" runat="server" CssClass="object-default" ValidationGroup="Search1">
                        <asp:ListItem Enabled="true" Text="Select Report" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Label ID="lblDateGroup" Style="margin-left: 16%;" Font-Size="100%" runat="server">Date Group</asp:Label>
                    <br />
                    <asp:RequiredFieldValidator ID="refvDateGroup" Style="margin-left: 4.9%;" runat="server" ControlToValidate="ddlDateGroup" InitialValue="-1" Font-Bold="True" Font-Size="12px" ForeColor="Red" ValidationGroup="Search1">Select Date Group</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlDateGroup" runat="server" Style="width: 90%; margin-left: 4.9%; font-size: 10.5px;" CssClass="object-default" ValidationGroup="Search1">
                        <asp:ListItem Enabled="true" Text="Select Date Group" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Yesterday" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Last 7 Days" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Last 14 Days" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Last Month" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Last Year" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="link-reports">
                        <asp:Button ID="btnFilter" OnClick="btnFilter_Click" class="btn btn-primary" Style="float: right; width: 98%; position: relative; top: -3px; right: 1.38px;" runat="server" Text="Search" ValidationGroup="Search1" />
                    </div>
                </div>
            </div>
        </div>
        <asp:SqlDataSource runat="server" ID="sdsPendingActions"
            OnSelecting="OnSelecting"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT * FROM ActionRequired WHERE ReportId=@ReportId"
            DeleteCommand="DELETE FROM [ActionRequired] WHERE [ReportId] = @ReportId"
            UpdateCommand="UPDATE [ActionRequired] SET [ReportId] = @ReportId, [Description] = @Description, [SubmittedBy] = @SubmittedBy, [SubmittedDate] = @SubmittedDate, [Completed] = @Completed, [CompletedDate] = @CompletedDate, [Comments] = @Comments WHERE [ReportId] = @ReportId"
            InsertCommand="INSERT INTO [ActionRequired] ([ReportId], [Report_Table], [Version], [AuditVersion], [ReportName], [ReportStat], [StaffAuthor], [StaffName], [StaffId], [StaffSelected], [StaffPersonID], [StaffPerson], [StaffGroup], [Description], [SubmittedBy], [SubmittedTo], [SubmittedDate], [Completed], [CompletedDate], [Comments], [ToPerson]) VALUES (@ReportId, @Report_Table, @Version, @AuditVersion, @ReportName, @ReportStat, @StaffAuthor,  @StaffName, @StaffId, @StaffSelected, @StaffPersonId, @StaffPerson, @StaffGroup, @Description, @SubmittedBy, @SubmittedTo, @SubmittedDate, @Completed, @CompletedDate, @Comments, @ToPerson)"
            OnInserted="sdsPendingActions_Inserted">
            <SelectParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
                <asp:Parameter Name="Report_Table" Type="String" />
                <asp:Parameter Name="Version" Type="Int32" />
                <asp:Parameter Name="AuditVersion" Type="Int32" />
                <asp:Parameter Name="ReportName" Type="String" />
                <asp:Parameter Name="ReportStat" Type="String" />
                <asp:Parameter Name="StaffAuthor" Type="Int32" />
                <asp:Parameter Name="StaffName" Type="String" />
                <asp:Parameter Name="StaffId" Type="Int32" />
                <asp:Parameter Name="StaffSelected" Type="String" />
                <asp:Parameter Name="StaffPersonId" Type="Int32" />
                <asp:Parameter Name="StaffPerson" Type="String" />
                <asp:Parameter Name="StaffGroup" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="SubmittedBy" Type="String" />
                <asp:Parameter Name="SubmittedTo" Type="String" />
                <asp:Parameter Name="SubmittedDate" Type="DateTime" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="CompletedDate" Type="DateTime" />
                <asp:Parameter Name="Comments" Type="String" />
                <asp:Parameter Name="ToPerson" Type="Boolean" />
            </InsertParameters>
            <DeleteParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="SubmittedBy" Type="String" />
                <asp:Parameter Name="SubmittedDate" Type="DateTime" />
                <asp:Parameter Name="Completed" Type="Boolean" />
                <asp:Parameter Name="CompletedDate" Type="DateTime" />
                <asp:Parameter Name="Comments" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div id="divPendingActions">
            <asp:Label ID="lblAddAction" runat="server" Style="position: relative; top: 15px; left: 91px;" Visible="false" Font-Bold="true" Text="Pending Actions"></asp:Label>
            <asp:GridView runat="server" Visible="false" ID="gvPendingActions" Style="position: relative; top: 15px; margin-bottom: 40px;" HeaderStyle-CssClass="report-gridview-header" Width="84%"
                RowStyle-CssClass="report-gridview-row" Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsPendingActions" EmptyDataText="There are No Data Records to Display."
                OnRowCommand="gvPendingActions_RowCommand" OnRowDeleted="gvPendingActions_RowDeleted" OnRowUpdated="gvPendingActions_RowUpdated"
                OnRowDataBound="gvPendingActions_RowDataBound" OnPreRender="gvPendingActions_PreRender" ShowFooter="true">
                <EmptyDataTemplate>
                    <tr>
                        <th></th>
                        <th>
                            <asp:Label ID="lblDescriptionHead" runat="server" Text="Description" />
                        </th>
                        <th>
                            <asp:Label ID="lblToPerson" runat="server" Text="To Person" />
                        </th>
                        <th>
                            <asp:Label ID="lblGroup" runat="server" Text="Group" />
                        </th>
                        <th>
                            <asp:Label ID="lblPerson" runat="server" Text="Person" />
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnInsert1" runat="server" Font-Size="X-Small" CssClass="btn" CommandName="EmptyDataTemplateInsert" Text="Add Action" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription1" class="object-default" runat="server" TextMode="MultiLine" Height="50" />
                        </td>
                        <td>
                            <asp:CheckBox ID="cbToPerson" AutoPostBack="true" OnCheckedChanged="cbPersonPendingActions_CheckedChanged" Checked="false" runat="server" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGroup" Font-Size="11px" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupPendingActions_SelectedIndexChanged" class="object-default" runat="server" />
                            <asp:CheckBoxList ID="cblGroup" runat="server" class="object-default" Font-Size="10px" Visible="false" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPerson" Enabled="false" Style="display: block; width: 100%; height: 100%; padding: 6px 12px; font-size: 14px; line-height: 1.428571429; color: #555555; vertical-align: middle; background-color: #eeeeee; border: 1px solid #cccccc; border-radius: 4px; -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075); -webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s; transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;"
                                runat="server" />
                        </td>
                    </tr>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Font-Size="X-Small" Width="56px" CssClass="btn" CausesValidation="false" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="btnDelete" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" Text="Delete" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="btnCancel" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnInsert" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="FooterInsert" Text="Add Action" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" Visible="false" SortExpression="id">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Staff ID" Visible="false" SortExpression="StaffId">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Staff Person ID" Visible="false" SortExpression="StaffPersonId">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffPersonId" runat="server" Text='<%# Bind("StaffPersonId") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Staff Who Assigned the Action">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffSelected" runat="server" Text='<%# Bind("StaffSelected") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Staff Who Owns the Report">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("StaffName") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Staff Who Was Assigned For Action">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffPerson" runat="server" Text='<%# Bind("StaffPerson") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false" HeaderText="Staff Group Who Was Assigned For Action">
                        <ItemTemplate>
                            <asp:Label ID="lblStaffGroup" runat="server" Text='<%# Bind("StaffGroup") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" ItemStyle-Width="250px">
                        <ItemTemplate>
                            <%# (string.IsNullOrWhiteSpace(Eval("Description").ToString())) ? Eval("Description") : (Eval("Description").ToString()).Replace("^", "'") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescription" class="object-default" TextMode="MultiLine" Height="50" Width="250" runat="server" Text='<%# RemoveBreakLine(Eval("Description")) %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <table style="width: 100%; border: none; text-align: center;">
                                <tr>
                                    <td>
                                        <u><b>
                                            <asp:Label ID="lblDescription" runat="server" Font-Size="11px" Text="DESCRIPTION"></asp:Label></b></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDescription" class="object-default" TextMode="MultiLine" Height="50" Width="250" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submitted To" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblSubmittedTo" runat="server" Text='<%# Bind("SubmittedTo") %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <table style="width: 100%; border: none; text-align: center;">
                                <tr>
                                    <td>
                                        <u><b>
                                            <asp:Label ID="lblToPerson" runat="server" Font-Size="11px" Text="TO PERSON"></asp:Label></b></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbToPerson" AutoPostBack="true" OnCheckedChanged="cbPersonPendingActions_CheckedChanged" Checked="false" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submitted By" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <%# Eval("SubmittedBy") %>
                        </ItemTemplate>
                        <FooterTemplate>
                            <table style="width: 100%; border: none; text-align: left;">
                                <tr>
                                    <td>
                                        <u><b>
                                            <asp:Label ID="lblGroup" runat="server" Font-Size="11px" Text="GROUP"></asp:Label></b></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlGroup" runat="server" class="object-default" Font-Size="10px" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupPendingActions_SelectedIndexChanged" />
                                        <asp:CheckBoxList ID="cblGroup" runat="server" class="object-default" Font-Size="10px" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Submitted Date" ItemStyle-Width="200px">
                        <ItemTemplate>
                            <%# ConvertDateTime(Eval("SubmittedDate")) %>
                        </ItemTemplate>
                        <FooterTemplate>
                            <table style="width: 100%; border: none; text-align: center;">
                                <tr>
                                    <td>
                                        <u><b>
                                            <asp:Label ID="lblPerson" runat="server" Font-Size="11px" Text="PERSON"></asp:Label></b></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlPerson" runat="server" Enabled="false" CssClass="action-assign-person-list" />
                                    </td>
                                </tr>
                            </table>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Completed">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbCompleted" runat="server" Checked='<%# Eval("Completed") %>' Enabled="false"></asp:CheckBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbCompleted" Checked='<%# Bind("Completed") %>' runat="server"></asp:CheckBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Completed Date">
                        <ItemTemplate>
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# ConvertDateTime(Eval("CompletedDate")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action Notes" ItemStyle-Width="250px" >
                        <ItemTemplate>
                            <%# (string.IsNullOrWhiteSpace(Eval("Comments").ToString())) ? Eval("Comments") : (Eval("Comments").ToString()).Replace("^", "'") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtComments" class="object-default" TextMode="MultiLine" Width="250" runat="server" Text='<%# RemoveBreakLine(Eval("Comments")) %>' />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtComments" Visible="false" class="object-default" TextMode="MultiLine" Style="overflow: hidden;" Height="50" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:SqlDataSource runat="server" ID="sdsRecommendation_Allegation"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_Allegation] WHERE ReportId=@ReportId"
            DeleteCommand="DELETE FROM [Recommendation_Allegation] WHERE [id] = @id"
            UpdateCommand="UPDATE [Recommendation_Allegation] SET [Statement] = @Statement WHERE [id] = @id"
            InsertCommand="INSERT INTO [Recommendation_Allegation] ([ReportId], [StaffId], [Name], [Statement], [DateEntered]) VALUES (@ReportId, @StaffId, @Name, @Statement, @DateEntered)"
            OnInserted="OnInserted_JudiciaryRecord"
            OnSelecting="OnSelecting">
            <SelectParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Statement" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
                <asp:Parameter Name="StaffId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Statement" Type="String" />
                <asp:Parameter Name="DateEntered" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="sdsRecommendation_DisciplinaryAction"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT id, StaffId, Name, Statement, DateEntered, ReportId FROM [Recommendation_DisciplinaryAction] WHERE ReportId=@ReportId"
            DeleteCommand="DELETE FROM [Recommendation_DisciplinaryAction] WHERE [id] = @id"
            UpdateCommand="UPDATE [Recommendation_DisciplinaryAction] SET [Statement] = @Statement WHERE [id] = @id"
            InsertCommand="INSERT INTO [Recommendation_DisciplinaryAction] ([ReportId], [StaffId], [Name], [Statement], [DateEntered]) VALUES (@ReportId, @StaffId, @Name, @Statement, @DateEntered)"
            OnInserted="OnInserted_JudiciaryRecord"
            OnSelecting="OnSelecting">
            <SelectParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Statement" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
                <asp:Parameter Name="StaffId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Statement" Type="String" />
                <asp:Parameter Name="DateEntered" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="sdsRecommendation_Judiciary"
            ConnectionString="<%$ ConnectionStrings:LocalDb %>"
            SelectCommand="SELECT id, StaffId, Name, Decision, Date, ReportId, StartDate, EndDate FROM [Recommendation_Judiciary] WHERE ReportId=@ReportId"
            UpdateCommand="UPDATE [Recommendation_Judiciary] SET [StaffId] = @StaffId, [Name] = @Name, [Decision] = @Decision, [Date] = @Date, [StartDate] = @StartDate, [EndDate] = @EndDate WHERE [id] = @id"
            InsertCommand="INSERT INTO [Recommendation_Judiciary] ([ReportId], [StaffId], [Name], [Decision], [Date], [StartDate], [EndDate]) VALUES (@ReportId, @StaffId, @Name, @Decision, @Date, @StartDate, @EndDate)"
            OnInserted="OnInserted_JudiciaryRecord"
            OnSelecting="OnSelecting">
            <SelectParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="StaffId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Decision" Type="String" />
                <asp:Parameter Name="Date" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ReportId" Type="Int32" />
                <asp:Parameter Name="StaffId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Decision" Type="String" />
                <asp:Parameter Name="Date" Type="DateTime" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
        <table id="tblRecords" runat="server" style="width: 84%;" visible="false">
            <tr>
                <th style="text-align: right;">RECOMMENDATION FOR DISCIPLINARY ACTION</th>
                <th>
                    <asp:Label ID="lblIncidentNo" runat="server" Style="position: relative; left: 50px;" ForeColor="red" Font-Bold="true" Text="Incident No. "></asp:Label>
                </th>
            </tr>
            <tr>
                <th colspan="2" style="text-align: center; border-top: solid 1px White; border-bottom: solid 1px White;">Allegation</th>
            </tr>
            <tr>
                <td colspan="2" style="background-color: #A0A0A0;">
                    <asp:GridView runat="server" ID="gvRecommendation_Allegation" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row" Style="table-layout: fixed; border: none;" Width="100%" DataKeyNames="id"
                        Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_Allegation" EmptyDataText="No data to display."
                        OnRowCommand="gvRecommendation_Allegation_RowCommand" OnRowDeleted="OnRowDeleted" OnRowUpdated="OnRowUpdated_JudiciaryRecord"
                        OnRowDataBound="OnRowDataBound_JudiciaryRecord" ShowFooter="true">
                        <EmptyDataTemplate>
                            <table style="table-layout: fixed; width: 100%;">
                                <tr>
                                    <th colspan="8">
                                        <asp:Label ID="lblStatement1" runat="server" Text="Statement" />
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnInsert1" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CommandName="EmptyDataTemplateInsert" Text="Add Statement" />
                                    </td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txtStatement1" class="object-default" runat="server" TextMode="MultiLine" Height="50" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Font-Size="X-Small" Width="56px" CssClass="btn btn-primary" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                    <asp:Button ID="btnDelete" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" Text="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="Update" Text="Update" />
                                    <asp:Button ID="btnCancel" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="FooterInsert" Text="Add Statement" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table style="width: 100%; border: none; text-align: center;">
                                        <tr>
                                            <td>
                                                <u><b>
                                                    <asp:Label ID="lblStatement" runat="server" Font-Size="11px" Text="STATEMENT"></asp:Label></b></u>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtStatement" class="object-default" TextMode="MultiLine" Height="50" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Statement" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# (string.IsNullOrWhiteSpace(Eval("Statement").ToString())) ? Eval("Statement") : (Eval("Statement").ToString()).Replace("^", "'") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStatement" class="object-default" TextMode="MultiLine" Height="50" runat="server" Text='<%# Bind("Statement") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Entered" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertDateTime(Eval("DateEntered")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="text-align: center; border-top: solid 1px White; border-bottom: solid 1px White;">Disciplinary Action</th>
            </tr>
            <tr>
                <td colspan="2" style="background-color: #A0A0A0;">
                    <asp:GridView runat="server" ID="gvRecommendation_DisciplinaryAction" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row" Style="table-layout: fixed; border: none;" Width="100%" DataKeyNames="id"
                        Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_DisciplinaryAction" EmptyDataText="No data to Display."
                        OnRowCommand="gvRecommendation_DisciplinaryAction_RowCommand" OnRowDeleted="OnRowDeleted" OnRowUpdated="OnRowUpdated_JudiciaryRecord"
                        OnRowDataBound="OnRowDataBound_JudiciaryRecord" ShowFooter="true">
                        <EmptyDataTemplate>
                            <table style="table-layout: fixed; width: 100%;">
                                <tr>
                                    <th colspan="8">
                                        <asp:Label ID="lblStatement1" runat="server" Text="Statement" />
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnInsert1" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CommandName="EmptyDataTemplateInsert" Text="Add Statement" />
                                    </td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txtStatement1" class="object-default" runat="server" TextMode="MultiLine" Height="50" />
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Font-Size="X-Small" Width="56px" CssClass="btn btn-primary" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                    <asp:Button ID="btnDelete" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm ('Are you sure you want to delete this record?')" Text="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="Update" Text="Update" />
                                    <asp:Button ID="btnCancel" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="FooterInsert" Text="Add Statement" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table style="width: 100%; border: none; text-align: center;">
                                        <tr>
                                            <td>
                                                <u><b>
                                                    <asp:Label ID="lblStatement" runat="server" Font-Size="11px" Text="STATEMENT"></asp:Label></b></u>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtStatement" class="object-default" TextMode="MultiLine" Height="50" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Statement" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# (string.IsNullOrWhiteSpace(Eval("Statement").ToString())) ? Eval("Statement") : (Eval("Statement").ToString()).Replace("^", "'") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStatement" class="object-default" TextMode="MultiLine" Height="50" runat="server" Text='<%# Bind("Statement") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Entered" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertDateTime(Eval("DateEntered")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="text-align: center; border-top: solid 1px White; border-bottom: solid 1px White;">Judiciary Committee/Board Decision</th>
            </tr>
            <tr>
                <td colspan="2" style="background-color: #A0A0A0;">
                    <asp:GridView runat="server" ID="gvRecommendation_Judiciary" HeaderStyle-CssClass="report-gridview-header" RowStyle-CssClass="report-gridview-row" Style="table-layout: fixed; border: none;" Width="100%" DataKeyNames="id"
                        Font-Size="14px" AutoGenerateColumns="False" DataSourceID="sdsRecommendation_Judiciary" EmptyDataText="There are No Data Records to Display."
                        OnRowCommand="gvRecommendation_Judiciary_RowCommand" OnRowUpdated="OnRowUpdated_JudiciaryRecord"
                        OnRowDataBound="gvRecommendation_Judiciary_RowDataBound">
                        <EmptyDataTemplate>
                            <table style="table-layout: fixed; width: 100%;">
                                <tr>
                                    <th colspan="1"></th>
                                    <th colspan="2">
                                        <asp:Label ID="lblDecision1" runat="server" Text="Decision" />
                                    </th>
                                    <th colspan="1">
                                        <asp:Label ID="lblDate1" runat="server" Text="Date" />
                                    </th>
                                    <th colspan="1">
                                        <asp:Label ID="lblStartDate1" runat="server" Text="Start Date" />
                                    </th>
                                    <th colspan="1">
                                        <asp:Label ID="lblEndDate1" runat="server" Text="End Date" />
                                    </th>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        <asp:Button ID="btnInsert1" runat="server" Font-Size="X-Small" CssClass="btn btn-primary" CommandName="EmptyDataTemplateInsert" Text="Add Statement" />
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtDecision1" class="object-default" runat="server" TextMode="MultiLine" Height="50" />
                                    </td>
                                    <td colspan="1">
                                        <asp:TextBox ID="txtDate1" class="object-default" runat="server" />
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" Format='dd/MM/yyyy' TargetControlID="txtDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1">
                                        <asp:TextBox ID="txtStartDate1" class="object-default" runat="server" />
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" Format='dd/MM/yyyy' TargetControlID="txtStartDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                    <td colspan="1">
                                        <asp:TextBox ID="txtEndDate1" class="object-default" runat="server" />
                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" Format='dd/MM/yyyy' TargetControlID="txtEndDate1" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="120px" HeaderStyle-Width="120px" FooterStyle-Width="120px">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Font-Size="X-Small" Width="56px" CssClass="btn btn-primary" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CommandName="Update" Text="Update" />
                                    <asp:Button ID="btnCancel" Font-Size="X-Small" CssClass="btn btn-primary" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="id">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Report Id" HeaderStyle-HorizontalAlign="Center" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="ReportId">
                                <ItemTemplate>
                                    <asp:Label ID="lblReportId" runat="server" Text='<%# Bind("ReportId") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Staff ID" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="StaffId">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffId" runat="server" Text='<%# Bind("StaffId") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" Visible="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblStaffName" runat="server" Text='<%# Bind("Name") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Decision" ItemStyle-Width="500" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# (string.IsNullOrWhiteSpace(Eval("Decision").ToString())) ? Eval("Decision") : (Eval("Decision").ToString()).Replace("^", "'") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDecision" class="object-default" TextMode="MultiLine" Height="50" runat="server" Text='<%# Bind("Decision") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertDate(Eval("Date")) %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDate" class="object-default" runat="server" Text='<%# Bind("Date") %>' />
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dd/MM/yyyy' TargetControlID="txtDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertDate(Eval("StartDate")) %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStartDate" class="object-default" runat="server" Text='<%# Bind("StartDate") %>' />
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format='dd/MM/yyyy' TargetControlID="txtStartDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="End Date" HeaderStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# ConvertDate(Eval("EndDate")) %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEndDate" class="object-default" runat="server" Text='<%# Bind("EndDate") %>' />
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" Format='dd/MM/yyyy' TargetControlID="txtEndDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <div id="divComment">
            <table id="tblComment" runat="server" style="border: none; position: relative; top: 15px;" visible="false">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblComment" runat="server" Font-Bold="true" Text="Add Comment"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtComment" runat="server" CssClass="object-default textbox-no-resize" Height="130px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnComment" runat="server" CssClass="btn" OnClick="btnComment_Click" Text="Add Comment" />
                    </td>
                </tr>
            </table>
        </div>
        <table id="tblReportObjects" runat="server" class="report-objects" visible="false">
            <tr id="trUser" runat="server" visible="false">
                <td>
                    <asp:Button ID="btnEdit" runat="server" CssClass="btn" OnClick="btnEdit_Click" Text="Edit Report" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn" OnClick="btnUpdate_Click" Text="Update Report" />
                </td>
                <td>
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn" OnClick="btnPrint_Click" Text="Print Report" />
                    <asp:Button ID="btnShowReport" runat="server" CssClass="btn" OnClick="btnShowReport_Click" Text="Cancel" />
                </td>
                <td>
                    <asp:Button ID="btnShowComment" runat="server" CssClass="btn" OnClick="btnShowComment_Click" Text="Show Comment" />
                </td>
            </tr>
            <tr id="trManager" runat="server" visible="false">
                <td>
                    <asp:Button ID="btnShowList1" runat="server" CssClass="btn" OnClick="btnShowList_Click" Text="Return to List" />
                    <asp:Button ID="btnShowManagerSign" runat="server" CssClass="btn" OnClick="btnShowManagerSign_Click" Text="Manager Approval" />
                </td>
                <td>
                    <asp:Button ID="btnPrint1" runat="server" OnClick="btnPrint_Click" class="btn" Text="Print Report" />
                </td>
                <td>
                    <asp:Button ID="btnShowComment1" runat="server" CssClass="btn" OnClick="btnShowComment_Click" Text="Show Comment" />
                </td>
            </tr>
            <tr id="trSign" runat="server" visible="false">
                <td>
                    <asp:Button ID="btnShowUserSign" runat="server" CssClass="btn" OnClick="btnShowUserSign_Click" Text="Sign Report" />
                    <asp:Button ID="btnShowList" runat="server" CssClass="btn" OnClick="btnShowList_Click" Text="Return to List" />
                </td>
                <td>
                    <asp:Button ID="btnReadReport" runat="server" CssClass="btn" OnClick="btnReadReport_Click" Text="Mark as Read" />
                </td>
                <td>
                    <asp:Button ID="btnShowActions" runat="server" CssClass="btn" OnClick="btnShowActions_Click" Text="Show Actions Pending" /></td>
            </tr>
            <tr id="trLinked" runat="server" visible="false">
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnShowLinked" runat="server" CssClass="btn" OnClick="btnShowLinked_Click" Text="Show Linked Reports" />
                </td>
            </tr>
            <tr id="trAttachedFiles" runat="server" visible="false">
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="btnShowAttachedFiles" runat="server" CssClass="btn" OnClick="btnShowAttachedFiles_Click" Text="Show Attached Files" />
                </td>
            </tr>
        </table>
        <div id="userSign" class="digital-signature" visible="false" runat="server">
            <asp:CheckBox ID="cbUserSign" runat="server" CssClass="digital-signature-checkbox" />
            <p class="digital-signature-paragraph">I have reviewed the incident report and all other relevant material available and I am satisfied as to its accuracy</p>
            <br />
            <br />
            <asp:Button ID="btnUserSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnUserSign_Click" Text="Accept" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelUserSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnCancelUserSign_Click" Text="Cancel" />
        </div>
        <div id="managerSign" class="digital-signature" visible="false" runat="server">
            <asp:CheckBox ID="cbManagerSign" runat="server" CssClass="digital-signature-checkbox" />
            <p class="digital-signature-paragraph">I have reviewed the incident report and all other relevant material available and I am satisfied as to its accuracy</p>
            <br />
            <br />
            <asp:Button ID="btnManagerSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnManagerSign_Click" Text="Accept" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelManagerSign" runat="server" CssClass="btn digital-signature-button" OnClick="btnCancelManagerSign_Click" Text="Cancel" />
        </div>
        <div id="signAsManager" class="digital-signature" visible="false" runat="server">
            <asp:CheckBox ID="cbSignAsManager" runat="server" AutoPostBack="true" OnCheckedChanged="cbSignAsManager_CheckedChanged" CssClass="digital-signature-checkbox" />
            <p class="digital-signature-paragraph">By ticking the checkbox, you agree that all reports have been reviewed and you are satisfied as to its accuracy</p>
            <br />
            <br />
            <asp:Button ID="btnSignAsManagerBox" runat="server" CssClass="btn digital-signature-button" OnClick="btnSignAsManagerBox_Click" Text="Accept" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelAsManager" runat="server" CssClass="btn digital-signature-button" OnClick="btnCancelAsManager_Click" Text="Cancel" />
        </div>
        <div class="loading">
            <asp:Image ID="imgLoading" runat="server" ImageUrl="~/Images/loading.gif" />
        </div>
    </div>
</asp:Content>
