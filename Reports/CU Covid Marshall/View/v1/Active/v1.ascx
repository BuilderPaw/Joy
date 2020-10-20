<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Covid_Marshall_View_v1_Active_v1" %>
<div class="body2">
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
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">DM OFFICE</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("175") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("176") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("177") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("178") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <%# (string.IsNullOrWhiteSpace(Eval("179").ToString())) ? Eval("179") : (Eval("179").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">RECEPTION</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("180") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("181") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("182") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("183") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <%# (string.IsNullOrWhiteSpace(Eval("184").ToString())) ? Eval("184") : (Eval("184").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">COVID CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("185") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("186") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("187") %>' /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("188") %>' /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <%# (string.IsNullOrWhiteSpace(Eval("189").ToString())) ? Eval("189") : (Eval("189").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Main Lounge</th>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">TAB</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("9").ToString())) ? Eval("9") : (Eval("9").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Inside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("17").ToString())) ? Eval("17") : (Eval("17").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("18").ToString())) ? Eval("18") : (Eval("18").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Outside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("25").ToString())) ? Eval("25") : (Eval("25").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("26").ToString())) ? Eval("26") : (Eval("26").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("27").ToString())) ? Eval("27") : (Eval("27").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Audi</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("33").ToString())) ? Eval("33") : (Eval("33").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("34").ToString())) ? Eval("34") : (Eval("34").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("35").ToString())) ? Eval("35") : (Eval("35").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("36").ToString())) ? Eval("36") : (Eval("36").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("37").ToString())) ? Eval("37") : (Eval("37").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("38").ToString())) ? Eval("38") : (Eval("38").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("39").ToString())) ? Eval("39") : (Eval("39").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("40").ToString())) ? Eval("40") : (Eval("40").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bistro</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("46").ToString())) ? Eval("46") : (Eval("46").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("47").ToString())) ? Eval("47") : (Eval("47").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("48").ToString())) ? Eval("48") : (Eval("48").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Smoker Deck</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("55").ToString())) ? Eval("55") : (Eval("55").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("56").ToString())) ? Eval("56") : (Eval("56").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Greens</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("64").ToString())) ? Eval("64") : (Eval("64").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">S/Deck & P/Deck</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("65") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("66") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("67") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("68") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("69") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("70") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("71") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("72") %>' />
        </tr>
        <tr>
            <th style="border: 1px solid black">Toilet checks</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("73") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("74") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("75") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("76") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("77") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("78") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("79") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("80") %>' />
        </tr>
        <tr>
            <th style="border: 1px solid black">Designated Area / Time</th>
            <th style="border: 1px solid black">18:00</th>
            <th style="border: 1px solid black">19:00</th>
            <th style="border: 1px solid black">20:00</th>
            <th style="border: 1px solid black">21:00</th>
            <th style="border: 1px solid black">22:00</th>
            <th style="border: 1px solid black">23:00</th>
            <th style="border: 1px solid black">00:00</th>
            <th style="border: 1px solid black">01:00</th>
        </tr>
        <tr>
            <th style="border: 1px solid black">Main Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("81").ToString())) ? Eval("81") : (Eval("81").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">TAB</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("89").ToString())) ? Eval("89") : (Eval("89").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("90").ToString())) ? Eval("90") : (Eval("90").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Inside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("97").ToString())) ? Eval("97") : (Eval("97").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("98").ToString())) ? Eval("98") : (Eval("98").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("99").ToString())) ? Eval("99") : (Eval("99").ToString()).Replace("^", "'") %></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">O/side Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("105").ToString())) ? Eval("105") : (Eval("105").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("106").ToString())) ? Eval("106") : (Eval("106").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("107").ToString())) ? Eval("107") : (Eval("107").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("108").ToString())) ? Eval("108") : (Eval("108").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("109").ToString())) ? Eval("109") : (Eval("109").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("110").ToString())) ? Eval("110") : (Eval("110").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("111").ToString())) ? Eval("111") : (Eval("111").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("112").ToString())) ? Eval("112") : (Eval("112").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Audi</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("118").ToString())) ? Eval("118") : (Eval("118").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("119").ToString())) ? Eval("119") : (Eval("119").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("120").ToString())) ? Eval("120") : (Eval("120").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bistro</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("127").ToString())) ? Eval("127") : (Eval("127").ToString()).Replace("^", "'") %></td>
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("128").ToString())) ? Eval("128") : (Eval("128").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Smoker Deck</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <%# (string.IsNullOrWhiteSpace(Eval("136").ToString())) ? Eval("136") : (Eval("136").ToString()).Replace("^", "'") %></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Greens</th>
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
            <th style="border: 1px solid black">S/Deck & P/Deck</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("145") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("146") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("147") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("148") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("149") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("150") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("151") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("152") %>' />
        </tr>
        <tr>
            <th style="border: 1px solid black">Toilet checks</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("153") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("154") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("155") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("156") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("157") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("158") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("159") %>' />
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("160") %>' />
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
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("161") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("162") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that patrons are practicing physical distancing between groups.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("163") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons are seated whether drinking or not.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("164") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("165") %>' /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that the venue displaying the required signage.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("166") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("167") %>' /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("168") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("169") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff wear gloves when cleaning.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("170") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("171") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("172") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that Back of House areas are kept clean.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("173") %>' /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("174") %>' />
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
