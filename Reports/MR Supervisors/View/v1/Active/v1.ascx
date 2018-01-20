<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Supervisors_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# Eval("ReportStat") %></span>
        <span class="report-number"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></span>
    </div>
    <div id="supReport" runat="server">
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
                <th colspan="4">Sign In Slip</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("SignInSlip") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Reception</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Reception") %>                                    
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
                <th colspan="4">Bar</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Bar") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">TAB / Keno</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("TabKeno") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">House Keeping</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("HouseKeeping") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Bistro</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Bistro") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Food Hygiene</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("FoodHygiene") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Events</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Events") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Customer Service</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("CustomerService") %>                                    
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
                <th colspan="4">RSA</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("RSA") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">AML / CTF</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("AMLCTF") %>                                    
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
