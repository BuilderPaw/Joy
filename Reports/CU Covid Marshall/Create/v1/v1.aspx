<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="v1.aspx.cs" Inherits="Reports_CU_Covid_Marshall_Create_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ASPNetSpell:SpellButton ID="SpellButton1" runat="server" DictionaryLanguage="English (Australia)" CssClass="spell-button" />
    <div class="body">
        <br />
        <h4 style="margin-left: 8%;">CU Covid Marshall Report</h4>
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
                <td style="border:1px solid black; border-collapse:collapse;text-align:left;">DM OFFICE</td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox175" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox176" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox177" runat="server" /></td>
                <td align="center" style="width:65px;border:1px solid black; border-collapse:collapse;"><asp:CheckBox ID="CheckBox178" runat="server" /></td>
                <td style="border:1px solid black; border-collapse:collapse;"><asp:TextBox ID="TextBox179" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">RECEPTION</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox180" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox181" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox182" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox183" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox184" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="border: 1px solid black; border-collapse: collapse; text-align: left;">COVID CLEANING</td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox185" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox186" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox187" runat="server" /></td>
                <td align="center" style="width: 65px; border: 1px solid black; border-collapse: collapse;">
                    <asp:CheckBox ID="CheckBox188" runat="server" /></td>
                <td style="border: 1px solid black; border-collapse: collapse;">
                    <asp:TextBox ID="TextBox189" class="object-default" runat="server" Height="60px" TextMode="MultiLine" Style="resize: none;"></asp:TextBox></td>
            </tr>
        </table>
        <table style="margin-bottom: 35px;width: 86%; border-collapse:collapse;">
            <tr>
                <th colspan="9" style="border:1px solid black; border-collapse:collapse;">WALK THROUGH</th>
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
            </tr>
            <tr>
                <th style="border:1px solid black">Main Lounge</th>
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
            </tr>
            <tr>
                <th style="border:1px solid black">TAB</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox9" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
            </tr>
            <tr>
                <th style="border:1px solid black">Inside Pokies</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox17" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox18" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
            </tr>
            <tr>
                <th style="border:1px solid black">Outside Pokies</th>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox25" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox26" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox27" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox28" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox29" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox30" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox31" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox32" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Audi</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox33" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox34" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox35" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox36" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox37" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox38" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox39" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox40" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Bistro</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox46" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox47" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox48" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Smoker Deck</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox55" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox56" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Greens</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox64" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">S/Deck & P/Deck</th>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox65" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox66" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox67" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox68" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox69" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox70" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox71" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox72" runat="server"></asp:CheckBox></td>
            </tr>
            <tr>
                <th style="border: 1px solid black">Toilet checks</th>
                <td align="center" style="width: 85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox73" runat="server"></asp:CheckBox></td>
                <td align="center" style="width: 85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox74" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox75" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox76" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox77" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox78" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox79" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox80" runat="server"></asp:CheckBox></td>
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
                    <asp:TextBox ID="TextBox81" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox82" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox83" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox84" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox85" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox86" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox87" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox88" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border: 1px solid black">TAB</th>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox89" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox90" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox91" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox92" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox93" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox94" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox95" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox96" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Inside Pokies</th>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox97" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox98" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width: 85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox99" class="object-default" Text="0" onkeypress="return isNumberKey(event)" runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
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
            </tr>
            <tr>
                <th style="border:1px solid black">O/side Pokies</th>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox105" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox106" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox107" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox108" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox109" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox110" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox111" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox112" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Audi</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox118" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox119" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox120" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Bistro</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox127" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox128" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Smoker Deck</th>
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
                <td style="width:85px; border: solid 1px black;">
                    <asp:TextBox ID="TextBox136" class="object-default" Text="0" onkeypress="return isNumberKey(event)"  runat="server" Height="30px" Style="resize: none;"></asp:TextBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Greens</th>
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
                <th style="border:1px solid black">S/Deck & P/Deck</th>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox145" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox146" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox147" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox148" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox149" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox150" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox151" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox152" runat="server"></asp:CheckBox></td>
            </tr>
            <tr>
                <th style="border:1px solid black">Toilet Checks</th>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox153" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox154" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox155" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox156" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox157" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox158" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox159" runat="server"></asp:CheckBox></td>
                <td align="center" style="width:85px; border: solid 1px black;">
                    <asp:CheckBox ID="CheckBox160" runat="server"></asp:CheckBox></td>
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
                <td  align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox161" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that all patrons have entered their details upon entry for Contact Tracing.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox162" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that patrons are practicing physical distancing between groups.</td>
                <td  align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox163" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that all patrons are seated whether drinking or not.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox164" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Advise Manager on Duty if a patron isolation is required, e.g. Patron coughing or appearing unwell (use a mask before approaching patron or maintain 1.5m distance).</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox165" runat="server" /></td>
            </tr>
            <tr>
                <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE VENUE</th>
            </tr>
            <tr>
                <td style="border:1px solid black">Check that the venue displaying the required signage.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox166" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Check having hand sanitisers are available upon entry and within the venue.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox167" runat="server" /></td>
            </tr>
            <tr>
                <th colspan="2" style="border: 1px solid black; border-collapse: collapse; text-align: left;">COMPLIANCE STAFF</th>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that staff maintain good hand hygiene and remind to sanitise as required.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox168" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Remind staff not to mill in breach of physical distancing where possible.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox169" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure staff wear gloves when cleaning.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox170" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that staff are aware not to attend if feeling unwell.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox171" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensuring that all floor markings and signage relating to physical distancing is in place and is being obeyed.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox172" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure that Back of House areas are kept clean.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox173" runat="server" /></td>
            </tr>
            <tr>
                <td style="border:1px solid black">Ensure staff are aware of the benefits of the COVID safe App.</td>
                <td align="center" style="width:65px;border:1px solid black"><asp:CheckBox ID="CheckBox174" runat="server" /></td>
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
