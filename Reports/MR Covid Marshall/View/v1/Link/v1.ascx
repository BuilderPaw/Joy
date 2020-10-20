<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Covid_Marshall_View_v1_Link_v1" %>
<div class="table-link-view">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="report-number"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
    </div>
    <table class="table-view" style="margin-bottom: 35px;">
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
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <%# (string.IsNullOrWhiteSpace(Eval("GeneralComments").ToString())) ? Eval("GeneralComments") : (Eval("GeneralComments").ToString()).Replace("^", "'") %>                                    
            </td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 100%; border-collapse: collapse;">
        <tr>
            <th colspan="6" style="border: 1px solid black; border-collapse: collapse;">CLEANING PERFORMED DURING DAY</th>
        </tr>
        <tr>
            <th style="border: 1px solid black; border-collapse: collapse; text-align: left;">AREA</th>
            <th style="width: 65px; border: 1px solid black; border-collapse: collapse;">CHECKLIST ALLOCATED</th>
            <th style="width: 65px; border: 1px solid black; border-collapse: collapse;">CLEANING COMPLETED</th>
            <th style="width: 65px; border: 1px solid black; border-collapse: collapse;">CHECKLIST COMPLETED BY STAFF</th>
            <th style="width: 65px; border: 1px solid black; border-collapse: collapse;">CHECKLIST COMPLETED BY COVID MARSHALL</th>
            <th style="border: 1px solid black; border-collapse: collapse;">COMMENT</th>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">BELMONT LOUNGE</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("321") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("322") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("323") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("324") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("325").ToString())) ? Eval("325") : (Eval("325").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">SPINNERS</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("326") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("327") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("328") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("329") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("330").ToString())) ? Eval("330") : (Eval("330").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">BLUEYS</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("331") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("332") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("333") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("334") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("335").ToString())) ? Eval("335") : (Eval("335").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">CASHIER</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("336") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("337") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("338") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("339") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("340").ToString())) ? Eval("340") : (Eval("340").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">AR CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("341") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("342") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("343") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("344") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("345").ToString())) ? Eval("345") : (Eval("345").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">GAMING CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("346") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("347") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("348") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("349") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("350").ToString())) ? Eval("350") : (Eval("350").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">HOUSEKEEPING CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("351") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("352") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("353") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("354") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                 <%# (string.IsNullOrWhiteSpace(Eval("355").ToString())) ? Eval("355") : (Eval("355").ToString()).Replace("^", "'") %></td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 100%; border-collapse: collapse;">
        <tr>
            <th colspan="10" style="border: 1px solid black; border-collapse: collapse;">WALK THROUGH</th>
        </tr>
        <tr>
            <th style="border: 1px solid black">Designated Area / Time</th>
            <th style="border: 1px solid black">10:00</th>
            <th style="border: 1px solid black">11:00</th>
            <th style="border: 1px solid black">12:00</th>
            <th style="border: 1px solid black">13:00</th>
            <th style="border: 1px solid black">14:00</th>
            <th style="border: 1px solid black">15:00</th>
            <th style="border: 1px solid black">16:00</th>
            <th style="border: 1px solid black">17:00</th>
            <th style="border: 1px solid black">18:00</th>
        </tr>
        <tr>
            <th style="border: 1px solid black">Auditorium</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("1").ToString())) ? Eval("1") : (Eval("1").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("2").ToString())) ? Eval("2") : (Eval("2").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("3").ToString())) ? Eval("3") : (Eval("3").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("4").ToString())) ? Eval("4") : (Eval("4").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("5").ToString())) ? Eval("5") : (Eval("5").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("6").ToString())) ? Eval("6") : (Eval("6").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("7").ToString())) ? Eval("7") : (Eval("7").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("8").ToString())) ? Eval("8") : (Eval("8").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("9").ToString())) ? Eval("9") : (Eval("9").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Belmont Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("10").ToString())) ? Eval("10") : (Eval("10").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("11").ToString())) ? Eval("11") : (Eval("11").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("12").ToString())) ? Eval("12") : (Eval("12").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("13").ToString())) ? Eval("13") : (Eval("13").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("14").ToString())) ? Eval("14") : (Eval("14").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("15").ToString())) ? Eval("15") : (Eval("15").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("16").ToString())) ? Eval("16") : (Eval("16").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("17").ToString())) ? Eval("17") : (Eval("17").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("18").ToString())) ? Eval("18") : (Eval("18").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Betty Cuthbert Sports</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("19").ToString())) ? Eval("19") : (Eval("19").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("20").ToString())) ? Eval("20") : (Eval("20").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("21").ToString())) ? Eval("21") : (Eval("21").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("22").ToString())) ? Eval("22") : (Eval("22").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("23").ToString())) ? Eval("23") : (Eval("23").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("24").ToString())) ? Eval("24") : (Eval("24").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("25").ToString())) ? Eval("25") : (Eval("25").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("26").ToString())) ? Eval("26") : (Eval("26").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("27").ToString())) ? Eval("27") : (Eval("27").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bluey's Bar and Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("28").ToString())) ? Eval("28") : (Eval("28").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("29").ToString())) ? Eval("29") : (Eval("29").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("30").ToString())) ? Eval("30") : (Eval("30").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("31").ToString())) ? Eval("31") : (Eval("31").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("32").ToString())) ? Eval("32") : (Eval("32").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("33").ToString())) ? Eval("33") : (Eval("33").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("34").ToString())) ? Eval("34") : (Eval("34").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("35").ToString())) ? Eval("35") : (Eval("35").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("36").ToString())) ? Eval("36") : (Eval("36").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Eyes Down Room</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("37").ToString())) ? Eval("37") : (Eval("37").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("38").ToString())) ? Eval("38") : (Eval("38").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("39").ToString())) ? Eval("39") : (Eval("39").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("40").ToString())) ? Eval("40") : (Eval("40").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("41").ToString())) ? Eval("41") : (Eval("41").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("42").ToString())) ? Eval("42") : (Eval("42").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("43").ToString())) ? Eval("43") : (Eval("43").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("44").ToString())) ? Eval("44") : (Eval("44").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("45").ToString())) ? Eval("45") : (Eval("45").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Family Lounge kids area</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("46").ToString())) ? Eval("46") : (Eval("46").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("47").ToString())) ? Eval("47") : (Eval("47").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("48").ToString())) ? Eval("48") : (Eval("48").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("49").ToString())) ? Eval("49") : (Eval("49").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("50").ToString())) ? Eval("50") : (Eval("50").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("51").ToString())) ? Eval("51") : (Eval("51").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("52").ToString())) ? Eval("52") : (Eval("52").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("53").ToString())) ? Eval("53") : (Eval("53").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("54").ToString())) ? Eval("54") : (Eval("54").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Furphy's cafe</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("55").ToString())) ? Eval("55") : (Eval("55").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("56").ToString())) ? Eval("56") : (Eval("56").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("57").ToString())) ? Eval("57") : (Eval("57").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("58").ToString())) ? Eval("58") : (Eval("58").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("59").ToString())) ? Eval("59") : (Eval("59").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("60").ToString())) ? Eval("60") : (Eval("60").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("61").ToString())) ? Eval("61") : (Eval("61").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("62").ToString())) ? Eval("62") : (Eval("62").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("63").ToString())) ? Eval("63") : (Eval("63").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Alfresco (65 machines)</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("64").ToString())) ? Eval("64") : (Eval("64").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("65").ToString())) ? Eval("65") : (Eval("65").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("66").ToString())) ? Eval("66") : (Eval("66").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("67").ToString())) ? Eval("67") : (Eval("67").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("68").ToString())) ? Eval("68") : (Eval("68").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("69").ToString())) ? Eval("69") : (Eval("69").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("70").ToString())) ? Eval("70") : (Eval("70").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("71").ToString())) ? Eval("71") : (Eval("71").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("72").ToString())) ? Eval("72") : (Eval("72").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Ariah</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("73").ToString())) ? Eval("73") : (Eval("73").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("74").ToString())) ? Eval("74") : (Eval("74").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("75").ToString())) ? Eval("75") : (Eval("75").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("76").ToString())) ? Eval("76") : (Eval("76").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("77").ToString())) ? Eval("77") : (Eval("77").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("78").ToString())) ? Eval("78") : (Eval("78").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("79").ToString())) ? Eval("79") : (Eval("79").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("80").ToString())) ? Eval("80") : (Eval("80").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("81").ToString())) ? Eval("81") : (Eval("81").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Northern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("82").ToString())) ? Eval("82") : (Eval("82").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("83").ToString())) ? Eval("83") : (Eval("83").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("84").ToString())) ? Eval("84") : (Eval("84").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("85").ToString())) ? Eval("85") : (Eval("85").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("86").ToString())) ? Eval("86") : (Eval("86").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("87").ToString())) ? Eval("87") : (Eval("87").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("88").ToString())) ? Eval("88") : (Eval("88").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("89").ToString())) ? Eval("89") : (Eval("89").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("90").ToString())) ? Eval("90") : (Eval("90").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Southern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("91").ToString())) ? Eval("91") : (Eval("91").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("92").ToString())) ? Eval("92") : (Eval("92").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("93").ToString())) ? Eval("93") : (Eval("93").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("94").ToString())) ? Eval("94") : (Eval("94").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("95").ToString())) ? Eval("95") : (Eval("95").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("96").ToString())) ? Eval("96") : (Eval("96").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("97").ToString())) ? Eval("97") : (Eval("97").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("98").ToString())) ? Eval("98") : (Eval("98").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("99").ToString())) ? Eval("99") : (Eval("99").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Heritage House</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("100").ToString())) ? Eval("100") : (Eval("100").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("101").ToString())) ? Eval("101") : (Eval("101").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("102").ToString())) ? Eval("102") : (Eval("102").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("103").ToString())) ? Eval("103") : (Eval("103").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("104").ToString())) ? Eval("104") : (Eval("104").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("105").ToString())) ? Eval("105") : (Eval("105").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("106").ToString())) ? Eval("106") : (Eval("106").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("107").ToString())) ? Eval("107") : (Eval("107").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("108").ToString())) ? Eval("108") : (Eval("108").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("109").ToString())) ? Eval("109") : (Eval("109").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("110").ToString())) ? Eval("110") : (Eval("110").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("111").ToString())) ? Eval("111") : (Eval("111").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("112").ToString())) ? Eval("112") : (Eval("112").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("113").ToString())) ? Eval("113") : (Eval("113").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("114").ToString())) ? Eval("114") : (Eval("114").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("115").ToString())) ? Eval("115") : (Eval("115").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("116").ToString())) ? Eval("116") : (Eval("116").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("117").ToString())) ? Eval("117") : (Eval("117").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller waiting</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("118").ToString())) ? Eval("118") : (Eval("118").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("119").ToString())) ? Eval("119") : (Eval("119").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("120").ToString())) ? Eval("120") : (Eval("120").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("121").ToString())) ? Eval("121") : (Eval("121").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("122").ToString())) ? Eval("122") : (Eval("122").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("123").ToString())) ? Eval("123") : (Eval("123").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("124").ToString())) ? Eval("124") : (Eval("124").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("125").ToString())) ? Eval("125") : (Eval("125").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("126").ToString())) ? Eval("126") : (Eval("126").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Sage 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("127").ToString())) ? Eval("127") : (Eval("127").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("128").ToString())) ? Eval("128") : (Eval("128").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("129").ToString())) ? Eval("129") : (Eval("129").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("130").ToString())) ? Eval("130") : (Eval("130").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("131").ToString())) ? Eval("131") : (Eval("131").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("132").ToString())) ? Eval("132") : (Eval("132").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("133").ToString())) ? Eval("133") : (Eval("133").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("134").ToString())) ? Eval("134") : (Eval("134").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("135").ToString())) ? Eval("135") : (Eval("135").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Signatures Buffet</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("136").ToString())) ? Eval("136") : (Eval("136").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("137").ToString())) ? Eval("137") : (Eval("137").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("138").ToString())) ? Eval("138") : (Eval("138").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("139").ToString())) ? Eval("139") : (Eval("139").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("140").ToString())) ? Eval("140") : (Eval("140").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("141").ToString())) ? Eval("141") : (Eval("141").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("142").ToString())) ? Eval("142") : (Eval("142").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("143").ToString())) ? Eval("143") : (Eval("143").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("144").ToString())) ? Eval("144") : (Eval("144").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Terrace 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("145").ToString())) ? Eval("145") : (Eval("145").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("146").ToString())) ? Eval("146") : (Eval("146").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("147").ToString())) ? Eval("147") : (Eval("147").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("148").ToString())) ? Eval("148") : (Eval("148").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("149").ToString())) ? Eval("149") : (Eval("149").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("150").ToString())) ? Eval("150") : (Eval("150").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("151").ToString())) ? Eval("151") : (Eval("151").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("152").ToString())) ? Eval("152") : (Eval("152").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("153").ToString())) ? Eval("153") : (Eval("153").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Designated Area / Time</th>
            <th style="border: 1px solid black">19:00</th>
            <th style="border: 1px solid black">20:00</th>
            <th style="border: 1px solid black">21:00</th>
            <th style="border: 1px solid black">22:00</th>
            <th style="border: 1px solid black">23:00</th>
            <th style="border: 1px solid black">00:00</th>
            <th style="border: 1px solid black">01:00</th>
            <th style="border: 1px solid black">02:00</th>
            <th style="border: 1px solid black">03:00</th>
        </tr>
        <tr>
            <th style="border: 1px solid black">Auditorium</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("154").ToString())) ? Eval("154") : (Eval("154").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("155").ToString())) ? Eval("155") : (Eval("155").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("156").ToString())) ? Eval("156") : (Eval("156").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("157").ToString())) ? Eval("157") : (Eval("157").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("158").ToString())) ? Eval("158") : (Eval("158").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("159").ToString())) ? Eval("159") : (Eval("159").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("160").ToString())) ? Eval("160") : (Eval("160").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("161").ToString())) ? Eval("161") : (Eval("161").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("162").ToString())) ? Eval("162") : (Eval("162").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Belmont Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("163").ToString())) ? Eval("163") : (Eval("163").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("164").ToString())) ? Eval("164") : (Eval("164").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("165").ToString())) ? Eval("165") : (Eval("165").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("166").ToString())) ? Eval("166") : (Eval("166").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("167").ToString())) ? Eval("167") : (Eval("167").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("168").ToString())) ? Eval("168") : (Eval("168").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("169").ToString())) ? Eval("169") : (Eval("169").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("170").ToString())) ? Eval("170") : (Eval("170").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("171").ToString())) ? Eval("171") : (Eval("171").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Betty Cuthbert Sports</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("172").ToString())) ? Eval("172") : (Eval("172").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("173").ToString())) ? Eval("173") : (Eval("173").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("174").ToString())) ? Eval("174") : (Eval("174").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("175").ToString())) ? Eval("175") : (Eval("175").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("176").ToString())) ? Eval("176") : (Eval("176").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("177").ToString())) ? Eval("177") : (Eval("177").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("178").ToString())) ? Eval("178") : (Eval("178").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("179").ToString())) ? Eval("179") : (Eval("179").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("180").ToString())) ? Eval("180") : (Eval("180").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bluey's Bar and Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("181").ToString())) ? Eval("181") : (Eval("181").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("182").ToString())) ? Eval("182") : (Eval("182").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("183").ToString())) ? Eval("183") : (Eval("183").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("184").ToString())) ? Eval("184") : (Eval("184").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("185").ToString())) ? Eval("185") : (Eval("185").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("186").ToString())) ? Eval("186") : (Eval("186").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("187").ToString())) ? Eval("187") : (Eval("187").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("188").ToString())) ? Eval("188") : (Eval("188").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("189").ToString())) ? Eval("189") : (Eval("189").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Eyes Down Room</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("190").ToString())) ? Eval("190") : (Eval("190").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("191").ToString())) ? Eval("191") : (Eval("191").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("192").ToString())) ? Eval("192") : (Eval("192").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("193").ToString())) ? Eval("193") : (Eval("193").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("194").ToString())) ? Eval("194") : (Eval("194").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("195").ToString())) ? Eval("195") : (Eval("195").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("196").ToString())) ? Eval("196") : (Eval("196").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("197").ToString())) ? Eval("197") : (Eval("197").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("198").ToString())) ? Eval("198") : (Eval("198").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Family Lounge kids area</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("199").ToString())) ? Eval("199") : (Eval("199").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("200").ToString())) ? Eval("200") : (Eval("200").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("201").ToString())) ? Eval("201") : (Eval("201").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("202").ToString())) ? Eval("202") : (Eval("202").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("203").ToString())) ? Eval("203") : (Eval("203").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("204").ToString())) ? Eval("204") : (Eval("204").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("205").ToString())) ? Eval("205") : (Eval("205").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("206").ToString())) ? Eval("206") : (Eval("206").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("207").ToString())) ? Eval("207") : (Eval("207").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Furphy's cafe</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("208").ToString())) ? Eval("208") : (Eval("208").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("209").ToString())) ? Eval("209") : (Eval("209").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("210").ToString())) ? Eval("210") : (Eval("210").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("211").ToString())) ? Eval("211") : (Eval("211").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("212").ToString())) ? Eval("212") : (Eval("212").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("213").ToString())) ? Eval("213") : (Eval("213").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("214").ToString())) ? Eval("214") : (Eval("214").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("215").ToString())) ? Eval("215") : (Eval("215").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("216").ToString())) ? Eval("216") : (Eval("216").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Alfresco (65 machines)</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("217").ToString())) ? Eval("217") : (Eval("217").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("218").ToString())) ? Eval("218") : (Eval("218").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("219").ToString())) ? Eval("219") : (Eval("219").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("220").ToString())) ? Eval("220") : (Eval("220").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("221").ToString())) ? Eval("221") : (Eval("221").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("222").ToString())) ? Eval("222") : (Eval("222").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("223").ToString())) ? Eval("223") : (Eval("223").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("224").ToString())) ? Eval("224") : (Eval("224").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("225").ToString())) ? Eval("225") : (Eval("225").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Ariah</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("226").ToString())) ? Eval("226") : (Eval("226").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("227").ToString())) ? Eval("227") : (Eval("227").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("228").ToString())) ? Eval("228") : (Eval("228").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("229").ToString())) ? Eval("229") : (Eval("229").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("230").ToString())) ? Eval("230") : (Eval("230").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("231").ToString())) ? Eval("231") : (Eval("231").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("232").ToString())) ? Eval("232") : (Eval("232").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("233").ToString())) ? Eval("233") : (Eval("233").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("234").ToString())) ? Eval("234") : (Eval("234").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Northern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("235").ToString())) ? Eval("235") : (Eval("235").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("236").ToString())) ? Eval("236") : (Eval("236").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("237").ToString())) ? Eval("237") : (Eval("237").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("238").ToString())) ? Eval("238") : (Eval("238").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("239").ToString())) ? Eval("239") : (Eval("239").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("240").ToString())) ? Eval("240") : (Eval("240").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("241").ToString())) ? Eval("241") : (Eval("241").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("242").ToString())) ? Eval("242") : (Eval("242").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("243").ToString())) ? Eval("243") : (Eval("243").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Southern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("244").ToString())) ? Eval("244") : (Eval("244").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("245").ToString())) ? Eval("245") : (Eval("245").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("246").ToString())) ? Eval("246") : (Eval("246").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("247").ToString())) ? Eval("247") : (Eval("247").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("248").ToString())) ? Eval("248") : (Eval("248").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("249").ToString())) ? Eval("249") : (Eval("249").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("250").ToString())) ? Eval("250") : (Eval("250").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("251").ToString())) ? Eval("251") : (Eval("251").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("252").ToString())) ? Eval("252") : (Eval("252").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Heritage House</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("253").ToString())) ? Eval("253") : (Eval("253").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("254").ToString())) ? Eval("254") : (Eval("254").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("255").ToString())) ? Eval("255") : (Eval("255").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("256").ToString())) ? Eval("256") : (Eval("256").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("257").ToString())) ? Eval("257") : (Eval("257").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("258").ToString())) ? Eval("258") : (Eval("258").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("259").ToString())) ? Eval("259") : (Eval("259").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("260").ToString())) ? Eval("260") : (Eval("260").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("261").ToString())) ? Eval("261") : (Eval("261").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("262").ToString())) ? Eval("262") : (Eval("262").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("263").ToString())) ? Eval("263") : (Eval("263").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("264").ToString())) ? Eval("264") : (Eval("264").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("265").ToString())) ? Eval("265") : (Eval("265").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("266").ToString())) ? Eval("266") : (Eval("266").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("267").ToString())) ? Eval("267") : (Eval("267").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("268").ToString())) ? Eval("268") : (Eval("268").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("269").ToString())) ? Eval("269") : (Eval("269").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("270").ToString())) ? Eval("270") : (Eval("270").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller waiting</th>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("271").ToString())) ? Eval("271") : (Eval("271").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("272").ToString())) ? Eval("272") : (Eval("272").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("273").ToString())) ? Eval("273") : (Eval("273").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("274").ToString())) ? Eval("274") : (Eval("274").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("275").ToString())) ? Eval("275") : (Eval("275").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("276").ToString())) ? Eval("276") : (Eval("276").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("277").ToString())) ? Eval("277") : (Eval("277").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("278").ToString())) ? Eval("278") : (Eval("278").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("279").ToString())) ? Eval("279") : (Eval("279").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Sage 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("280").ToString())) ? Eval("280") : (Eval("280").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("281").ToString())) ? Eval("281") : (Eval("281").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("282").ToString())) ? Eval("282") : (Eval("282").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("283").ToString())) ? Eval("283") : (Eval("283").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("284").ToString())) ? Eval("284") : (Eval("284").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("285").ToString())) ? Eval("285") : (Eval("285").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("286").ToString())) ? Eval("286") : (Eval("286").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("287").ToString())) ? Eval("287") : (Eval("287").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("288").ToString())) ? Eval("288") : (Eval("288").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Signatures Buffet</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("289").ToString())) ? Eval("289") : (Eval("289").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("290").ToString())) ? Eval("290") : (Eval("290").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("291").ToString())) ? Eval("291") : (Eval("291").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("292").ToString())) ? Eval("292") : (Eval("292").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("293").ToString())) ? Eval("293") : (Eval("293").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("294").ToString())) ? Eval("294") : (Eval("294").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("295").ToString())) ? Eval("295") : (Eval("295").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("296").ToString())) ? Eval("296") : (Eval("296").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("297").ToString())) ? Eval("297") : (Eval("297").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Terrace 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("298").ToString())) ? Eval("298") : (Eval("298").ToString()).Replace("^", "'") %></td>
                        <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("299").ToString())) ? Eval("299") : (Eval("299").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("300").ToString())) ? Eval("300") : (Eval("300").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("301").ToString())) ? Eval("301") : (Eval("301").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("302").ToString())) ? Eval("302") : (Eval("302").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("303").ToString())) ? Eval("303") : (Eval("303").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("304").ToString())) ? Eval("304") : (Eval("304").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("305").ToString())) ? Eval("305") : (Eval("305").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
               <%# (string.IsNullOrWhiteSpace(Eval("306").ToString())) ? Eval("306") : (Eval("306").ToString()).Replace("^", "'") %></td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 100%; border-collapse: collapse;">
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse;">COMPLIANCE CHECKS PERFORMED DURING DAY</th>
        </tr>
        <tr>
            <th style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE CUSTOMERS</th>
            <th style="width: 65px; border: 1px solid black; border-collapse: collapse;">COVID MARSHALL</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("307") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("308") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that patrons are practicing physical distancing between groups.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("309") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons are seated whether drinking or not.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("310") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("311") %>' /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that the venue displaying the required signage.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("312") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("313") %>' /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("314") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("315") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff wear gloves when cleaning.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("316") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("317") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("318") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that Back of House areas are kept clean.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("319") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("320") %>' />
        </td>
        </tr>
    </table>
    <table class="table-view">
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
