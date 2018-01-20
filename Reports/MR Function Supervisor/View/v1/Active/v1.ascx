<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Function_Supervisor_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# Eval("ReportStat") %></span>
        <span class="report-number"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></span>
    </div>
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
            <th colspan="4">Function Name & Type</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("FunctionName") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Number of Guests</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("NumberOfGuests") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Setup</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("Setup") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Menu Feedback</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("MenuFeedback") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Bar Feedback</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("BarFeedback") %>                                    
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
