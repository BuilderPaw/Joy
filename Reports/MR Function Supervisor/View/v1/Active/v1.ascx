﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Function_Supervisor_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="report-number"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
    </div>
    <table class="table-view">
        <tr>
            <th colspan="5">Shift Details</th>
        </tr>
        <tr style="border: solid .5px;">
            <td>Staff Name:</td>
            <td style="width: 285px">
                <%# (string.IsNullOrWhiteSpace(Eval("StaffName").ToString())) ? Eval("StaffName") : (Eval("StaffName").ToString()).Replace("^", "'") %>
            </td>
            <td>Entry Details:</td>
            <td><%# Convert.ToDateTime(Eval("EntryDate")).ToString("dd/MM/yyyy HH:mm") %></td>
        </tr>
        <tr>
            <td style="width: 19%">Shift Type: 
            </td>
            <td>
                <%# (string.IsNullOrWhiteSpace(Eval("ShiftName").ToString())) ? Eval("ShiftName") : (Eval("ShiftName").ToString()).Replace("^", "'") %>
            </td>
            <td>Shift Date:</td>
            <td>
                <%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dddd, dd MMMM yyyy") %>
            </td>
        </tr>
        <tr>
            <th colspan="4">Function Name & Type</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("FunctionName").ToString())) ? Eval("FunctionName") : (Eval("FunctionName").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Number of Guests</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("NumberOfGuests").ToString())) ? Eval("NumberOfGuests") : (Eval("NumberOfGuests").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Setup</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("Setup").ToString())) ? Eval("Setup") : (Eval("Setup").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Menu Feedback</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("MenuFeedback").ToString())) ? Eval("MenuFeedback") : (Eval("MenuFeedback").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Bar Feedback</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("BarFeedback").ToString())) ? Eval("BarFeedback") : (Eval("BarFeedback").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Staff Issues</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("StaffIssues").ToString())) ? Eval("StaffIssues") : (Eval("StaffIssues").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("GeneralComments").ToString())) ? Eval("GeneralComments") : (Eval("GeneralComments").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("Comments").ToString())) ? Eval("Comments") : (Eval("Comments").ToString()).Replace("^", "'") %>                  
            </td>
        </tr>
        <tr>
            <th colspan="4">Read By</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("ReadBy").ToString())) ? Eval("ReadBy") : (Eval("ReadBy").ToString()).Replace("^", "'") %>
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
                <%# (string.IsNullOrWhiteSpace(Eval("StaffSign").ToString())) ? Eval("StaffSign") : (Eval("StaffSign").ToString()).Replace("^", "'") %> 
            </td>
            <td colspan="2">
                <%# (string.IsNullOrWhiteSpace(Eval("ManagerSign").ToString())) ? Eval("ManagerSign") : (Eval("ManagerSign").ToString()).Replace("^", "'") %> 
            </td>
        </tr>
    </table>
</div>
