<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Reception_View_v1_v1" %>
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
            <th colspan="4">Incidents</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("SignInSlip") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Refusals</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("Refusals") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Events</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# Eval("EventsField") %>                                    
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
