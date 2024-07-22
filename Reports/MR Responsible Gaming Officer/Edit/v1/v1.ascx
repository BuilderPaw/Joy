<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Responsible_Gaming_Officer_Edit_v1_v1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <div class="body3">
            <h4 style="margin-left: 57.5%">
                <asp:Label ID="lblReportName" runat="server" Text="MR RGO Event"></asp:Label>
                Report ID No.
                <b><asp:Label ID="lblReportId" Style="color: red;" runat="server" Text=""></asp:Label></b>
            </h4>
            <table class="table-incident">
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
                        <asp:DropDownList ID="ddlShift" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" runat="server" CssClass="object-default">
                            <asp:ListItem Enabled="true" Text="Select Shift" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Morning" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Afternoon" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Evening" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Night" Value="4"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="text-align: right;">Shift Date:</td>
                    <td>
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtDatePicker" OnTextChanged="TextChanged_TextChanged" runat="server" Width="245px" class="object-default" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDatePicker" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="5">Event Type</th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="List_EventType" RepeatLayout="table" RepeatColumns="5" Font-Size="8" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="List_EventType_SelectedIndexChanged" runat="server" class="object-default">
                            <asp:ListItem Text="Gaming" Value="01"></asp:ListItem>
                            <asp:ListItem Text="Gaming Floor Check" Value="02"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="03"></asp:ListItem>
                        </asp:CheckBoxList>
                </tr>
                <tr id="treventTypeOther" visible="false" runat="server">
                    <th colspan="4">Other
                    </th>
                </tr>
                <tr id="treventTypeOther1" visible="false" runat="server">
                    <td colspan="4">
                        <asp:TextBox ID="txtEventOthers" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="50px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="5">Were Patron Details Recorded?</th>
                </tr>
                <tr>
                    <td>
                        <b>Yes/No : </b><asp:CheckBox ID="cbPatronDetailsRecorded" AutoPostBack="true" OnCheckedChanged="cbPatronDetailsRecorded_CheckedChanged" runat="server" />
                    </td>
                </tr>
            </table>
            <table id="tblPerson1" class="table-incident" runat="server" visible="false">
                <tr>
                    <td colspan="1"><b>Party Type : </b>
                    </td>
                    <td colspan="1">
                        <asp:DropDownList ID="ddlPartyType" AutoPostBack="true" OnSelectedIndexChanged="ddlPartyType_SelectedIndexChanged" runat="server" CssClass="object-default" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Type" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Member" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Visitor" Value="2"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td id="member11l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    </td>
                    <td id="member11" runat="server" visible="false" colspan="1">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtMemberNo" OnTextChanged="MemberNo_TextChanged" AutoPostBack="true" class="object-default" runat="server" Style="resize: none;"></asp:TextBox>
                        <!--<asp:LinkButton ID="LinkButton" runat="server" Visible="false" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=mr1', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;">Look for Previous Incidents</asp:LinkButton>-->
                    </td>
                </tr>
                <tr>
                    <td id="visitor11l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    </td>
                    <td id="visitor11" runat="server" visible="false" colspan="1">
                        <asp:CheckBox ID="cbSignInSlip" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                    <td id="visitor12l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    </td>
                    <td id="visitor12" runat="server" visible="false" colspan="1">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtSignInBy" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="member13l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                        <br />
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtDOB" Enabled="false" runat="server" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender22" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOB" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                        <br />
                        <br />
                        <b>Member Since : </b>
                        <br />
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtMemberSince" Enabled="false" runat="server" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                        <br />
                        <br />
                        <b>Address : </b>
                        <br />
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtAddress" runat="server" Width="100%" Style="resize: none;" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                    </td>
                    <td id="member14l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                        <br />
                        <asp:Image ID="imgMember" Height="110px" Width="140px" runat="server" />
                    </td>
                    <td id="visitor13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    </td>
                    <td id="visitor13" runat="server" visible="false" colspan="1">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtDOBv" runat="server" Placeholder="Select Date" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender23" runat="server" Format='dd MMMM yyyy' TargetControlID="txtDOBv" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td id="visitor14l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    </td>
                    <td id="visitor14" runat="server" visible="false" colspan="1">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtIDProof" runat="server" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td id="visitor15l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    </td>
                    <td id="visitor15" runat="server" visible="false" colspan="3">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtAddressv" runat="server" Style="resize: none;" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><b>First Name : </b>
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtFirstName" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Width="100%" Height="35px" Style="resize: none;"></asp:TextBox>
                    </td>
                    <td colspan="2"><b>Last Name : </b>
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtLastName" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"><b>Alias : </b></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtAlias" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4"><b>Contact Details: (Could be Mobile No., Home No., and Email Address)</b></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtContact" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="35px" Style="resize: none;"></asp:TextBox></td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="5">Date and Time Recorded</th>
                </tr>
                <tr style="display: inline-block;">
                    <td style="width: 173px">
                        <asp:TextBox onkeypress="return CancelReturnKey(event)" ID="txtDate" runat="server" Width="220px" Placeholder="Select Date" class="object-default" OnTextChanged="TextChanged_TextChanged" autocomplete="off"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format='dddd, dd MMMM yyyy' TargetControlID="txtDate" TodaysDateFormat="dd/MM/yyyy"></asp:CalendarExtender>
                    </td>
                    <td colspan="1" style="width: 8px">
                        <asp:DropDownList ID="ddlHour" runat="server" CssClass="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" Height="30px" Width="150px">
                            <asp:ListItem Enabled="true" Text="Select Hour" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 2px">
                        <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged" Height="30px" Width="180px">
                            <asp:ListItem Enabled="true" Text="Select Minute" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="00" Value="1"></asp:ListItem>
                            <asp:ListItem Text="01" Value="2"></asp:ListItem>
                            <asp:ListItem Text="02" Value="3"></asp:ListItem>
                            <asp:ListItem Text="03" Value="4"></asp:ListItem>
                            <asp:ListItem Text="04" Value="5"></asp:ListItem>
                            <asp:ListItem Text="05" Value="6"></asp:ListItem>
                            <asp:ListItem Text="06" Value="7"></asp:ListItem>
                            <asp:ListItem Text="07" Value="8"></asp:ListItem>
                            <asp:ListItem Text="08" Value="9"></asp:ListItem>
                            <asp:ListItem Text="09" Value="10"></asp:ListItem>
                            <asp:ListItem Text="10" Value="11"></asp:ListItem>
                            <asp:ListItem Text="11" Value="12"></asp:ListItem>
                            <asp:ListItem Text="12" Value="13"></asp:ListItem>
                            <asp:ListItem Text="13" Value="14"></asp:ListItem>
                            <asp:ListItem Text="14" Value="15"></asp:ListItem>
                            <asp:ListItem Text="15" Value="16"></asp:ListItem>
                            <asp:ListItem Text="16" Value="17"></asp:ListItem>
                            <asp:ListItem Text="17" Value="18"></asp:ListItem>
                            <asp:ListItem Text="18" Value="19"></asp:ListItem>
                            <asp:ListItem Text="19" Value="20"></asp:ListItem>
                            <asp:ListItem Text="20" Value="21"></asp:ListItem>
                            <asp:ListItem Text="21" Value="22"></asp:ListItem>
                            <asp:ListItem Text="22" Value="23"></asp:ListItem>
                            <asp:ListItem Text="23" Value="24"></asp:ListItem>
                            <asp:ListItem Text="24" Value="25"></asp:ListItem>
                            <asp:ListItem Text="25" Value="26"></asp:ListItem>
                            <asp:ListItem Text="26" Value="27"></asp:ListItem>
                            <asp:ListItem Text="27" Value="28"></asp:ListItem>
                            <asp:ListItem Text="28" Value="29"></asp:ListItem>
                            <asp:ListItem Text="29" Value="30"></asp:ListItem>
                            <asp:ListItem Text="30" Value="31"></asp:ListItem>
                            <asp:ListItem Text="31" Value="32"></asp:ListItem>
                            <asp:ListItem Text="32" Value="33"></asp:ListItem>
                            <asp:ListItem Text="33" Value="34"></asp:ListItem>
                            <asp:ListItem Text="34" Value="35"></asp:ListItem>
                            <asp:ListItem Text="35" Value="36"></asp:ListItem>
                            <asp:ListItem Text="36" Value="37"></asp:ListItem>
                            <asp:ListItem Text="37" Value="38"></asp:ListItem>
                            <asp:ListItem Text="38" Value="39"></asp:ListItem>
                            <asp:ListItem Text="39" Value="40"></asp:ListItem>
                            <asp:ListItem Text="40" Value="41"></asp:ListItem>
                            <asp:ListItem Text="41" Value="42"></asp:ListItem>
                            <asp:ListItem Text="42" Value="43"></asp:ListItem>
                            <asp:ListItem Text="43" Value="44"></asp:ListItem>
                            <asp:ListItem Text="44" Value="45"></asp:ListItem>
                            <asp:ListItem Text="45" Value="46"></asp:ListItem>
                            <asp:ListItem Text="46" Value="47"></asp:ListItem>
                            <asp:ListItem Text="47" Value="48"></asp:ListItem>
                            <asp:ListItem Text="48" Value="49"></asp:ListItem>
                            <asp:ListItem Text="49" Value="50"></asp:ListItem>
                            <asp:ListItem Text="50" Value="51"></asp:ListItem>
                            <asp:ListItem Text="51" Value="52"></asp:ListItem>
                            <asp:ListItem Text="52" Value="53"></asp:ListItem>
                            <asp:ListItem Text="53" Value="54"></asp:ListItem>
                            <asp:ListItem Text="54" Value="55"></asp:ListItem>
                            <asp:ListItem Text="55" Value="56"></asp:ListItem>
                            <asp:ListItem Text="56" Value="57"></asp:ListItem>
                            <asp:ListItem Text="57" Value="58"></asp:ListItem>
                            <asp:ListItem Text="58" Value="59"></asp:ListItem>
                            <asp:ListItem Text="59" Value="60"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <!--<td colspan="1" rowspan="1">    // Time Convention - AM/PM
                            <asp:DropDownList ID="ddlTimeCon" runat="server" CssClass="object-default" Height="30px" Width="200px">
                                <asp:ListItem Enabled="true" Text="Select Time Convention" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="1"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>-->
                </tr>
            </table>
            <table class="table-incident">
                    <tr>
                        <th colspan="4">Location of Event</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <b>(must be precise and include details of lighting, floor conditions etc. where applicable)</b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBoxList ID="List_Location" RepeatLayout="table" RepeatColumns="5" Font-Size="8" RepeatDirection="vertical" AutoPostBack="true" OnSelectedIndexChanged="List_Location_SelectedIndexChanged" runat="server" class="object-default">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th id="otherLocation" runat="server" visible="false" colspan="4">Other location of event
                        </th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtLocationOther" Visible="false" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" Height="40px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="4">Gaming machine no.</th>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:TextBox ID="txtLocationMachine" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">How was RGO notified of the event?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_RGONotified" RepeatLayout="table" RepeatColumns="5" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr id="rgnonotifiedother" runat="server">
                    <th colspan="4">Other type of RGO event notification</th>
                </tr>
                <tr id="rgnonotifiedother1" runat="server">
                    <td colspan="4">
                        <asp:TextBox ID="txtRGONotifiedOther" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident" id="tbllistofsignsofproblemgambling" runat="server">
                <tr>
                    <th colspan="5">What were the observed signs of at risk gaming behaviour?</th>
                </tr>
                <tr>
                    <th>General Warning Signs</th>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Length of play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_Money" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th>Probable Warning Signs</th>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Length of play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_Money" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Social behaviours</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_SocialBehaviours" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th>Strong Warning Signs</th>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Length of play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_Money" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Social behaviours</b>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_SocialBehaviours" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th>Other observed signs of at risk gaming behaviour</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtPatronSignsOther"  OnTextChanged="TextChanged_TextChanged" class="object-default" runat="server" Height="70px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">What was the initial action taken by the RGO (select all that apply)?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_InitialAction" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">Which of the clubs gaming break options did you explained?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_3hrAlertResponse" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">How did the patron respond?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_PatronResponse" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">What was the final outcome?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBoxList ID="List_EventOutcome" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" OnSelectedIndexChanged="SelectedIndexChanged_SelectedIndexChanged">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <th>Further Comments</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtFurtherComments" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">Were there witness in the event?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>Yes/No : </b><asp:CheckBox ID="cbWitnessRecorded" AutoPostBack="true" OnCheckedChanged="cbWitnessRecorded_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr id="witness" runat="server" visible="false">
                    <th>Witness Details</th>
                </tr>
                <tr id="witness1" runat="server" visible="false">
                    <td colspan="4">
                        <asp:TextBox ID="txtWitnessDetails" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">Were police notified in the event?</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>Yes/No : </b><asp:CheckBox ID="cbPoliceRecorded" AutoPostBack="true" OnCheckedChanged="cbPoliceRecorded_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr id="police" runat="server" visible="false">
                    <th>Police Details</th>
                </tr>
                <tr id="police1" runat="server" visible="false">
                    <td colspan="4">
                        <asp:TextBox ID="txtPoliceDetails" class="object-default" OnTextChanged="TextChanged_TextChanged" runat="server" Height="130px" Style="resize: none;" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="table-incident">
                <tr>
                    <th colspan="4">DM or Senior Manager intervened and incident report completed</th>
                </tr>
                <tr>
                    <td colspan="4">
                        <b>Yes/No : </b><asp:CheckBox ID="cbIncidentReportCompleted" AutoPostBack="true" OnCheckedChanged="cbIncidentReportCompleted_CheckedChanged" runat="server" />
                    </td>
                </tr>
                <tr id="trassistedcompletingincidentreport" runat="server" visible="false">
                    <th colspan="4">Confirm you have assisted the Duty Manager or Senior Manager in completing incident report</th>
                </tr>
                <tr id="trassistedcompletingincidentreport1" runat="server" visible="false">
                    <td colspan="4">
                        <b>Yes/No : </b><asp:CheckBox ID="cbAssistedCompletingIncidentReport" OnCheckedChanged="CheckChanged_CheckedChanged" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>