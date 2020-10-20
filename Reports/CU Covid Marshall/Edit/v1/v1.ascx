<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Covid_Marshall_Edit_v1_v1" %>
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
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">DM OFFICE</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox175" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox176" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox177" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox178" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox179" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">RECEPTION</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox180" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox181" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox182" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox183" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox184" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">COVID CLEANING</td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox185" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox186" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox187" runat="server" /></td>
            <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox188" runat="server" /></td>
            <td style="border: 1px solid black; border-collapse: collapse;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox189" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Main Lounge</th>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">TAB</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox9" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Inside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox17" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox18" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Outside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox25" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox26" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox27" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Audi</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox33" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox34" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox35" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox36" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox37" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox38" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox39" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox40" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bistro</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox46" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox47" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox48" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Smoker Deck</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox55" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox56" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Greens</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox64" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">S/Deck & P/Deck</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox65" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox66" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox67" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox68" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox69" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox70" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox71" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox72" runat="server"></asp:CheckBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Toilet checks</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox73" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox74" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox75" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox76" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox77" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox78" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox79" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox80" runat="server"></asp:CheckBox></td>
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
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox81" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">TAB</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox89" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox90" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">Inside Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox97" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox98" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox99" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
        </tr>
        <tr>
            <th style="border: 1px solid black">O/side Pokies</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox105" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox106" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox107" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox108" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox109" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox110" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox111" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox112" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Audi</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox118" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox119" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox120" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Bistro</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox127" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox128" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Smoker Deck</th>
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
            <td style="width: 85px; border: solid 1px black;">
                <asp:TextBox OnTextChanged="TextChanged_TextChanged" ID="TextBox136" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Greens</th>
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
            <th style="border: 1px solid black">S/Deck & P/Deck</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox145" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox146" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox147" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox148" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox149" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox150" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox151" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox152" runat="server"></asp:CheckBox></td>
        </tr>
        <tr>
            <th style="border: 1px solid black">Toilet checks</th>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox153" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox154" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox155" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox156" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox157" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox158" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox159" runat="server"></asp:CheckBox></td>
            <td style="width: 85px; border: solid 1px black;">
                <asp:CheckBox OnCheckChanged="CheckChanged_CheckedChanged" ID="CheckBox160" runat="server"></asp:CheckBox></td>
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
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox161" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox162" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that patrons are practicing physical distancing between groups.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox163" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that all patrons are seated whether drinking or not.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox164" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox165" runat="server" /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check that the venue displaying the required signage.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox166" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox167" runat="server" /></td>
        </tr>
        <tr>
            <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox168" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox169" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff wear gloves when cleaning.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox170" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox171" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox172" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure that Back of House areas are kept clean.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox173" runat="server" /></td>
        </tr>
        <tr>
            <td style="border: 1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
            <td align="center" style="width: 65px; border: 1px solid black">
                <asp:CheckBox OnCheckedChanged="CheckChanged_CheckedChanged" ID="CheckBox174" runat="server" /></td>
        </tr>
    </table>
</div>
