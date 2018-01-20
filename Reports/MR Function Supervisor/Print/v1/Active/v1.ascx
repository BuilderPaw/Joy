﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Function_Supervisor_Print_v1_Active_v1" %>
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
    <h4 style="margin-left: 48.4%; font-family: Arial"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></h4>
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
            <th colspan="4">Function Name & Type</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("FunctionName") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Number of Guests</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("NumberOfGuests") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Setup</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("Setup") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Menu Feedback</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("MenuFeedback") %>                                    
            </td>
        </tr>
        <tr>
            <th colspan="4">Bar Feedback</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("BarFeedback") %>                                    
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
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td style="font-size: 12.5px;" colspan="4">
                <%# Eval("GeneralComments") %>                                    
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
