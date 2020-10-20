<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="v1.aspx.cs" Inherits="Reports_MR_Covid_Marshall_Create_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" CssClass="spell-button" />
    <div class="body">
        <br />
        <h4 style="margin-left: 8%;">MR Covid Marshall Report</h4>
        <table class="table-create-report">
            <tr>
                <th colspan="4">Shift Details</th>
            </tr>
            <tr>
                <td>Staff Name:</td>
                <td style="width: 285px">
                    <asp:TextBox ID="txtStaffName" runat="server" ReadOnly="true" Style="background-color: white;" CssClass="object-default" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 19%">Shift Type: 
                </td>
                <td>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="object-default">
                        <asp:ListItem Enabled="true" Text="Select Shift" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Morning" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Afternoon" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Evening" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Night" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Shift Date:                   
                    <asp:RequiredFieldValidator ID="rfvDatePicker" runat="server" ControlToValidate="txtDatePicker"
                        Font-Bold="True" Font-Size="27px" ForeColor="Red" ValidationGroup="Submit">*</asp:RequiredFieldValidator></td>
                <td>
                    <asp:TextBox ID="txtDatePicker" onkeypress="return CancelReturnKey(event)" runat="server" Width="220px" class="object-default" autocomplete="off"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDatePicker" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <th colspan="4">General Comments</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtGeneralComments" class="object-default" runat="server" Height="80px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="margin-bottom: 35px;width: 86%; border-collapse:collapse;">
            <tr>
                <th colspan="6" style="border:1px solid black; border-collapse:collapse;">CLEANING PERFORMED DURING DAY</th>
            </tr>
            <tr>
                <th style="border:1px solid black; border-collapse:collapse;text-align:left;">AREA</th>
                <th style="width:65px;border:1px solid black; border-collapse:collapse;">CHECKLIST ALLOCATED</th>
                <th style="width:65px;border:1px solid black; border-collapse:collapse;">CLEANING COMPLETED</th>
                <th style="width:65px;border:1px solid black; border-collapse:collapse;">CHECKLIST COMPLETED BY STAFF</th>
                <th style="width:65px;border:1px solid black; border-collapse:collapse;">CHECKLIST COMPLETED BY COVID MARSHALL</th>
                <th style="border:1px solid black; border-collapse:collapse;">COMMENT</th>
            </tr>
            <tr>
                <td style="border:1px solid black; border-collapse:collapse;text-align:left;">BELMONT LOUNGE</td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox321" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox322" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox323" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox324" runat="server" /></td>
                <td style="border:1px solid black; border-collapse:collapse;"><asp:TextBox ID="TextBox325" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">SPINNERS</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox326" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox327" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox328" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox329" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox330" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">BLUEYS</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox331" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox332" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox333" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox334" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox335" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">CASHIER</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox336" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox337" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox338" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox339" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox340" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">AR CLEANING</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox341" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox342" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox343" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox344" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox345" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">GAMING CLEANING</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox346" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox347" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox348" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox349" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox350" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">HOUSEKEEPING CLEANING</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox351" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox352" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox353" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox354" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox355" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
        </table>
        <table style="margin-bottom: 35px;width: 86%; border-collapse:collapse;">
            <tr>
                <th colspan="10" style="border:1px solid black; border-collapse:collapse;">WALK THROUGH</th>
            </tr>
            <tr>
                <th style="border:1px solid black">Designated Area / Time</th>
                <th style="border:1px solid black">10:00</th>
                <th style="border:1px solid black">11:00</th>
                <th style="border:1px solid black">12:00</th>
                <th style="border:1px solid black">13:00</th>
                <th style="border:1px solid black">14:00</th>
                <th style="border:1px solid black">15:00</th>
                <th style="border:1px solid black">16:00</th>
                <th style="border:1px solid black">17:00</th>
                <th style="border:1px solid black">18:00</th>
            </tr>
            <tr>
                <th style="border:1px solid black">Auditorium</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox1" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox2" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox3" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox4" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox5" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox6" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox7" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox8" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox9" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Belmont Lounge</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox10" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox11" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox12" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox13" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox14" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox15" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox16" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox17" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox18" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Betty Cuthbert Sports</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox19" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox20" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox21" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox22" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox23" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox24" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox25" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox26" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox27" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Bluey's Bar and Lounge</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox28" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox29" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox30" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox31" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox32" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox33" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox34" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox35" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox36" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Eyes Down Room</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox37" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox38" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox39" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox40" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox41" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox42" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox43" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox44" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox45" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Family Lounge kids area</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox46" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox47" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox48" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox49" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox50" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox51" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox52" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox53" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox54" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Furphy's cafe</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox55" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox56" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox57" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox58" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox59" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox60" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox61" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox62" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox63" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Alfresco (65 machines)</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox64" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox65" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox66" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox67" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox68" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox69" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox70" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox71" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox72" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Ariah</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox73" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox74" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox75" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox76" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox77" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox78" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox79" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox80" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox81" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Northern Indoor</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox82" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox83" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox84" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox85" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox86" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox87" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox88" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox89" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox90" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Southern Indoor</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox91" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox92" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox93" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox94" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox95" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox96" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox97" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox98" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox99" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Heritage House</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox100" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox101" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox102" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox103" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox104" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox105" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox106" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox107" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox108" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Reception Miller</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox109" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox110" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox111" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox112" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox113" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox114" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox115" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox116" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox117" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Reception Miller waiting</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox118" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox119" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox120" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox121" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox122" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox123" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox124" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox125" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox126" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Sage 2160</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox127" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox128" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox129" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox130" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox131" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox132" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox133" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox134" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox135" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Signatures Buffet</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox136" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox137" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox138" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox139" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox140" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox141" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox142" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox143" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox144" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Terrace 2160</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox145" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox146" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox147" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox148" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox149" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox150" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox151" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox152" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox153" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Designated Area / Time</th>
                <th style="border:1px solid black">19:00</th>
                <th style="border:1px solid black">20:00</th>
                <th style="border:1px solid black">21:00</th>
                <th style="border:1px solid black">22:00</th>
                <th style="border:1px solid black">23:00</th>
                <th style="border:1px solid black">00:00</th>
                <th style="border:1px solid black">01:00</th>
                <th style="border:1px solid black">02:00</th>
                <th style="border:1px solid black">03:00</th>
            </tr>
            <tr>
                <th style="border:1px solid black">Auditorium</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox154" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox155" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox156" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox157" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox158" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox159" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox160" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox161" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox162" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Belmont Lounge</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox163" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox164" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox165" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox166" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox167" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox168" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox169" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox170" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox171" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Betty Cuthbert Sports</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox172" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox173" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox174" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox175" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox176" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox177" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox178" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox179" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox180" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Bluey's Bar and Lounge</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox181" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox182" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox183" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox184" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox185" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox186" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox187" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox188" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox189" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Eyes Down Room</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox190" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox191" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox192" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox193" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox194" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox195" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox196" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox197" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox198" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Family Lounge kids area</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox199" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox200" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox201" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox202" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox203" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox204" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox205" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox206" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox207" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Furphy's cafe</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox208" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox209" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox210" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox211" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox212" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox213" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox214" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox215" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox216" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Alfresco (65 machines)</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox217" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox218" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox219" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox220" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox221" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox222" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox223" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox224" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox225" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Ariah</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox226" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox227" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox228" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox229" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox230" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox231" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox232" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox233" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox234" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Northern Indoor</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox235" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox236" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox237" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox238" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox239" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox240" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox241" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox242" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox243" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Gaming Southern Indoor</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox244" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox245" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox246" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox247" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox248" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox249" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox250" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox251" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox252" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Heritage House</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox253" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox254" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox255" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox256" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox257" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox258" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox259" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox260" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox261" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Reception Miller</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox262" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox263" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox264" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox265" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox266" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox267" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox268" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox269" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox270" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Reception Miller waiting</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox271" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox272" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox273" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox274" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox275" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox276" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox277" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox278" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox279" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Sage 2160</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox280" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox281" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox282" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox283" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox284" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox285" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox286" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox287" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox288" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Signatures Buffet</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox289" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox290" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox291" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox292" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox293" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox294" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox295" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox296" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox297" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Terrace 2160</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox298" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox299" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox300" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox301" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox302" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox303" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox304" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox305" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox306" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
        </table>
        <table style="margin-bottom: 35px;width: 86%; border-collapse:collapse;">
            <tr>
                <th colspan="2" style="border:1px solid black; border-collapse:collapse;">COMPLIANCE CHECKS PERFORMED DURING DAY</th>
            </tr>
            <tr>
                <th style="border:1px solid black; border-collapse:collapse;text-align:left;">COMPLIANCE CUSTOMERS</th>
                <th style="width:65px;border:1px solid black; border-collapse:collapse;">COVID MARSHALL</th>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
                <td  align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox307" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox308" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that patrons are practicing physical distancing between groups.</td>
                <td  align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox309" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that all patrons are seated whether drinking or not.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox310" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox311" runat="server" /></td>
            </tr>
            <tr>
                <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that the venue displaying the required signage.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox312" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox313" runat="server" /></td>
            </tr>
            <tr>
                <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox314" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox315" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure staff wear gloves when cleaning.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox316" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox317" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox318" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that Back of House areas are kept clean.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox319" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox320" runat="server" /></td>
            </tr>
        </table>
        <table style="margin-bottom: 35px;width: 86%;">
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" Style="float: right; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Submit Form" OnClick="btnSubmit_Click" ValidationGroup="Submit" />
                    <asp:Button ID="btnReset" Style="float: right; margin: 3px;" class="btn btn-primary btn-large" runat="server" Text="Clear Form" OnClick="btnReset_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
