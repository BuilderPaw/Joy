<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Duty_Managers_Print_v1_Link_v1" %>
<div style="font-family: Arial">
    <style type="text/css">
        th {
            border-bottom: solid 1px black;
            border-top: solid 1px black;
            background-color: #e0dede !important;
            color: #1e1e1e;
        }

        td {
            vertical-align: middle;
        }
    </style>
    <div id="dmReport" runat="server">
        <h4 style="margin-left: 56%; font-family: Arial"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></h4>
        <table style="width: 100%; font-family: Arial; border: solid 1px black !important;">
            <tr>
                <th colspan="5">Shift Details</th>
            </tr>
            <tr style="border: solid .5px;">
                <td style="font-size: 12.5px">Staff Name:</td>
                <td style="font-size: 12.5px; width: 189.8px;">
                    <%# Eval("StaffName") %>
                </td>
                <td style="font-size: 12.5px">Entry Details:</td>
                <td style="font-size: 12.5px"><%# Convert.ToDateTime(Eval("EntryDate")).ToString("dd/MM/yyyy HH:mm") %></td>
            </tr>
            <tr>
                <td style="font-size: 12.5px; width: 19%">Shift Type: 
                </td>
                <td style="font-size: 12.5px;">
                    <%# Eval("ShiftName") %>
                </td>
                <td style="font-size: 12.5px;">Shift Date:</td>
                <td style="font-size: 12.5px;">
                    <%# Convert.ToDateTime(Eval("ShiftDate")).ToString("dddd, dd MMMM yyyy") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Supervisors</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Supervisors") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">WHS Issues</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Whs") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Cost Savings</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("CostSavings") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Presentation</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("ClubPresent") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Club Maintenance</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("ClubMaintenance") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Absenteeism</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Absenteeism") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Staff Issues</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("StaffIssues") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Gaming</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Gaming") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Key Security</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("KeySecurity") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Cameras</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Cameras") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("GeneralComments") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Promotions and Events</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("LuckyRewards") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Compliance</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Compliance") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Comments</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
                    <%# Eval("Comments") %>                  
                </td>
            </tr>
            <tr>
                <th colspan="4">Read By</th>
            </tr>
            <tr>
                <td style="font-size: 12.5px;" colspan="4">
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
                <td style="font-size: 12.5px; border-right: 1px solid black" colspan="2">
                    <%# Eval("StaffSign") %> 
                </td>
                <td style="font-size: 12.5px;" colspan="2">
                    <%# Eval("ManagerSign") %> 
                </td>
            </tr>
        </table>
    </div>
</div>
