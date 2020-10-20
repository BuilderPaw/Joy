<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Covid_Marshall_Edit_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div class="body3">
    <h4 style="margin-left: 57.5%">
        <asp:Label ID="lblReportName" runat="server" Text=""></asp:Label>
        Report ID No.
        <b>
            <asp:Label ID="lblReportId" Style="color: red;" runat="server" Text=""></asp:Label></b>
    </h4>
    <table class="table-incident" style="margin-bottom: 35px;">
        <tr>
            <th colspan="5">Shift Details</th>
        </tr>
        <tr style="border: solid .5px;">
            <td>Staff Name:</td>
            <td style="width: 285px">
                <asp:Label ID="lblStaffName" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">Entry Details:</td>
            <td>
                <asp:Label ID="lblEntryDetails" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 19%">Shift Type: 
            </td>
            <td>
                <asp:DropDownList ID="ddlShift" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" runat="server" CssClass="object-default">
                    <asp:ListItem Enabled="true" Text="Select Shift" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Morning" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Afternoon" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Evening" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Night" Value="4"></asp:ListItem>
                </asp:DropDownList></td>
            <td style="text-align: right;">Shift Date:                 
                    <asp:RequiredFieldValidator ID="rfvDatePicker" runat="server" ControlToValidate="txtDatePicker"
                        Font-Bold="True" Font-Size="27px" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator></td>
            <td>
                <asp:TextBox ID="txtDatePicker" onkeypress="return CancelReturnKey(event)" OnTextChanged="TextChanged_TextChanged" runat="server" Width="220px" class="object-default" autocomplete="off"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDatePicker" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <th colspan="4">General Comments</th>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="txtGeneralComments" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="80px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 86%; border-collapse: collapse;">
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
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox321" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox322" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox323" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox324" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox325" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">SPINNERS</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox326" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox327" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox328" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox329" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox330" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">BLUEYS</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox331" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox332" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox333" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox334" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox335" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">CASHIER</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox336" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox337" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox338" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox339" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox340" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">AR CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox341" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox342" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox343" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox344" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox345" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">GAMING CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox346" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox347" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox348" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox349" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox350" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">HOUSEKEEPING CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox351" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox352" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox353" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox354" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox355" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 86%; border-collapse: collapse;">
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
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox1" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox2" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox3" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox4" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox5" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox6" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox7" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox8" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox9" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Belmont Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox10" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox11" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox12" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox13" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox14" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox15" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox16" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox17" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox18" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Betty Cuthbert Sports</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox19" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox20" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox21" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox22" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox23" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox24" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox25" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox26" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox27" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bluey's Bar and Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox28" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox29" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox30" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox31" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox32" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox33" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox34" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox35" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox36" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Eyes Down Room</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox37" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox38" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox39" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox40" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox41" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox42" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox43" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox44" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox45" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Family Lounge kids area</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox46" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox47" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox48" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox49" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox50" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox51" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox52" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox53" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox54" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Furphy's cafe</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox55" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox56" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox57" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox58" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox59" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox60" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox61" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox62" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox63" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Alfresco (65 machines)</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox64" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox65" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox66" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox67" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox68" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox69" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox70" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox71" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox72" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Ariah</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox73" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox74" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox75" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox76" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox77" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox78" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox79" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox80" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox81" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Northern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox82" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox83" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox84" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox85" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox86" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox87" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox88" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox89" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox90" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Southern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox91" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox92" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox93" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox94" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox95" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox96" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox97" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox98" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox99" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Heritage House</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox100" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox101" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox102" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox103" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox104" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox105" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox106" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox107" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox108" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox109" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox110" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox111" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox112" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox113" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox114" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox115" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox116" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox117" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller waiting</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox118" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox119" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox120" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox121" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox122" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox123" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox124" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox125" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox126" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Sage 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox127" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox128" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox129" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox130" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox131" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox132" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox133" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox134" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox135" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Signatures Buffet</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox136" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox137" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox138" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox139" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox140" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox141" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox142" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox143" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox144" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Terrace 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox145" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox146" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox147" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox148" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox149" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox150" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox151" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox152" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox153" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox154" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox155" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox156" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox157" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox158" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox159" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox160" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox161" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox162" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Belmont Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox163" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox164" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox165" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox166" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox167" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox168" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox169" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox170" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox171" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Betty Cuthbert Sports</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox172" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox173" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox174" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox175" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox176" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox177" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox178" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox179" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox180" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bluey's Bar and Lounge</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox181" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox182" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox183" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox184" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox185" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox186" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox187" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox188" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox189" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Eyes Down Room</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox190" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox191" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox192" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox193" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox194" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox195" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox196" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox197" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox198" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Family Lounge kids area</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox199" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox200" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox201" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox202" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox203" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox204" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox205" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox206" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox207" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Furphy's cafe</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox208" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox209" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox210" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox211" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox212" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox213" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox214" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox215" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox216" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Alfresco (65 machines)</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox217" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox218" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox219" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox220" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox221" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox222" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox223" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox224" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox225" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Ariah</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox226" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox227" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox228" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox229" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox230" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox231" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox232" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox233" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox234" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Northern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox235" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox236" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox237" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox238" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox239" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox240" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox241" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox242" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox243" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Gaming Southern Indoor</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox244" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox245" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox246" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox247" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox248" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox249" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox250" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox251" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox252" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Heritage House</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox253" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox254" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox255" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox256" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox257" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox258" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox259" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox260" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox261" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox262" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox263" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox264" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox265" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox266" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox267" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox268" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox269" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox270" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Reception Miller waiting</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox271" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox272" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox273" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox274" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox275" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox276" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox277" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox278" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox279" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Sage 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox280" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox281" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox282" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox283" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox284" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox285" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox286" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox287" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox288" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Signatures Buffet</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox289" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox290" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox291" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox292" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox293" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox294" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox295" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox296" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox297" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Terrace 2160</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox298" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox299" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox300" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox301" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox302" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox303" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox304" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox305" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox306" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
    </table>
    <table style="margin-bottom: 35px; width: 86%; border-collapse: collapse;">
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
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox307" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox308" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that patrons are practicing physical distancing between groups.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox309" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons are seated whether drinking or not.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox310" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox311" runat="server" /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that the venue displaying the required signage.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox312" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox313" runat="server" /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox314" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox315" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff wear gloves when cleaning.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox316" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox317" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox318" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that Back of House areas are kept clean.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox319" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox320" runat="server" /></td>
        </tr>
    </table>
</div>
