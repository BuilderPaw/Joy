<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Duty_Managers_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# Eval("ReportStat") %></span>
        <span class="report-number"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></span>
    </div>
    <div id="dmReport" runat="server">
        <table class="table-view">
            <tr>
                <th colspan="5">Shift Details</th>
            </tr>
            <tr style="border: solid .5px;">
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <%# Eval("StaffName") %>
                </td>
                <td>Entry Details:</td>
                <td><%# Convert.ToDateTime(Eval("EntryDate")).ToString("dd/MM/yyyy HH:mm") %></td>
            </tr>
            <tr>
                <td style="width: 19%">Shift Type: 
                </td>
                <td>
                    <%# Eval("ShiftName") %>
                </td>
                <td>Shift Date:</td>
                <td>
                    <%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dddd, dd MMMM yyyy") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Reception</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Supervisors") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Bar</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Cameras") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Gaming</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Gaming") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Food Hygiene</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("KeySecurity") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">WHS Issues</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Whs") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Cost Savings</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("CostSavings") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Presentation</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("ClubPresent") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Maintenance</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("ClubMaintenance") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Absenteeism</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Absenteeism") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Staff Issues</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("StaffIssues") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("GeneralComments") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Lucky Rewards</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("LuckyRewards") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Compliance</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Compliance") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Comments") %>                  
                </td>
            </tr>
            <tr>
                <th colspan="4">Read By</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("ReadBy") %>                    
                </td>
            </tr>
            <tr>
                <th style="width: 48%" colspan="2">Staff Signature
                </th>
                <th colspan="2">Manager Signature
                </th>
            </tr>
            <tr>
                <td style="border-right: 1px solid black" colspan="2">
                    <%# Eval("StaffSign") %> 
                </td>
                <td colspan="2">
                    <%# Eval("ManagerSign") %> 
                </td>
            </tr>
        </table>
    </div>
</div>
