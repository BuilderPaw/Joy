﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_MR_Responsible_Gaming_Officer_View_v1_Link_v1" %>
<div class="table-link-view">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# (string.IsNullOrWhiteSpace(Eval("ReportStat").ToString())) ? Eval("ReportStat") : (Eval("ReportStat").ToString()).Replace("^", "'") %></span>
        <span class="reportNo">MR RGO Event Report ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>
        <!--<span class="reportNo"><%# (string.IsNullOrWhiteSpace(Eval("ReportName").ToString())) ? Eval("ReportName") : (Eval("ReportName").ToString()).Replace("^", "'") %> ID No. <span style="color: red;"><b><%# (string.IsNullOrWhiteSpace(Eval("ReportId").ToString())) ? Eval("ReportId") : (Eval("ReportId").ToString()).Replace("^", "'") %></b></span></span>-->
    </div>
    <div id="viewReport" runat="server">
        <table class="table-view">
            <tr>
                <th colspan="4">Shift Details</th>
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
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">Event Type</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_EventType" onclick="return false" readonly="true" Font-Size="8" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="form-control">
                        <asp:ListItem Text="Gaming" Value="01"></asp:ListItem>
                        <asp:ListItem Text="Gaming Floor Check" Value="02"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="03"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="treventTypeOther" runat="server" visible="false">
                <th>Other
                </th>
            </tr>
            <tr id="treventTypeOther1" runat="server" visible="false">
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("EventTypeOtherDesc").ToString())) ? Eval("EventTypeOtherDesc") : (Eval("EventTypeOtherDesc").ToString()).Replace("^", "'") %>     
                </td>
            </tr>
            <tr>
                <th colspan="5">Were Patron Details Recorded?</th>
            </tr>
            <tr>
                <td>
                    <b>Yes/No : </b><asp:CheckBox Enabled="false" Checked='<%# Eval("PatronDetailsRecorded") %>' runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson1" class="table-view" runat="server" visible="false">
            <tr>
                <th colspan="4">Patron Details</th>
            </tr>
            <tr>
                <td colspan="2" runat="server" class="form-control"><b>Party Type : </b>
                    <%# (string.IsNullOrWhiteSpace(Eval("TxtPartyType").ToString())) ? Eval("TxtPartyType") : (Eval("TxtPartyType").ToString()).Replace("^", "'") %>
                </td>
                <td id="member11l" runat="server" visible="false" colspan="2" class="form-control"><b>Member No : </b>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=1&RGO=1', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# (string.IsNullOrWhiteSpace(Eval("MemberNo").ToString())) ? Eval("MemberNo") : (Eval("MemberNo").ToString()).Replace("^", "'") %></asp:LinkButton>                       
                </td>
            </tr>
            <tr>
                <td id="visitor11l" runat="server" visible="false" colspan="2"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip")) %>' />
                </td>
                <td id="visitor12l" runat="server" visible="false" colspan="2"><b>Signed In By : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("SignedInBy").ToString())) ? Eval("SignedInBy") : (Eval("SignedInBy").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="member13l" runat="server" visible="false" colspan="2" class="form-control"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberSince").ToString())) ? Eval("MemberSince") : (Eval("MemberSince").ToString()).Replace("^", "'") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("MemberAddress").ToString())) ? Eval("MemberAddress") : (Eval("MemberAddress").ToString()).Replace("^", "'") %>
                </td>
                <td id="member14l" runat="server" visible="false" colspan="2" class="form-control"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor13l" runat="server" visible="false" colspan="2"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB")) %>
                </td>
                <td id="visitor14l" runat="server" visible="false" colspan="2"><b>Proof of Identity : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorProofID").ToString())) ? Eval("VisitorProofID") : (Eval("VisitorProofID").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td id="visitor15l" runat="server" visible="false" colspan="4"><b>Address : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("VisitorAddress").ToString())) ? Eval("VisitorAddress") : (Eval("VisitorAddress").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="2"><b>First Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("FirstName").ToString())) ? Eval("FirstName") : (Eval("FirstName").ToString()).Replace("^", "'") %>
                </td>
                <td colspan="2"><b>Last Name : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("LastName").ToString())) ? Eval("LastName") : (Eval("LastName").ToString()).Replace("^", "'") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Alias").ToString())) ? Eval("Alias") : (Eval("Alias").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# (string.IsNullOrWhiteSpace(Eval("Contact").ToString())) ? Eval("Contact") : (Eval("Contact").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">Event Date and Time</th>
            </tr>
            <tr>
                <td style="border-right: 1px solid black" colspan="4">
                    <%# ProcessMyDataItem(Eval("Date")) %> - <%# (string.IsNullOrWhiteSpace(Eval("TxtTimeH").ToString())) ? Eval("TxtTimeH") : (Eval("TxtTimeH").ToString()).Replace("^", "'") %>:<%# (string.IsNullOrWhiteSpace(Eval("TxtTimeM").ToString())) ? Eval("TxtTimeM") : (Eval("TxtTimeM").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>Location of Event</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_Location" onclick="return false" readonly="true" Font-Size="8" RepeatLayout="table" RepeatColumns="5" RepeatDirection="vertical" runat="server" class="object-default">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="trlocationother" runat="server" visible="false">
                <th>Other location of event</th>
            </tr>
            <tr id="trlocationother1" runat="server" visible="false">
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("LocationOther").ToString())) ? Eval("LocationOther") : (Eval("LocationOther").ToString()).Replace("^", "'") %>
                </td>
            </tr>
            <tr id="trlocationmachine" runat="server" visible="false">
                <th>Gaming Machine No.</th>
            </tr>
            <tr id="trlocationmachine1" runat="server" visible="false">
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("LocationMachine").ToString())) ? Eval("LocationMachine") : (Eval("LocationMachine").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>How the RGO was notified of the event</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_RGONotified" onclick="return false" readonly="true" Font-Size="8" RepeatLayout="table" RepeatColumns="5" RepeatDirection="vertical" runat="server" class="object-default">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="trrgonotifiedother" runat="server" visible="false">
                <th>Other type of RGO event notification</th>
            </tr>
            <tr id="trrgonotifiedother1" runat="server" visible="false">
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("RGONotifiedOther").ToString())) ? Eval("RGONotifiedOther") : (Eval("RGONotifiedOther").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view" id="tbllistofsignsofproblemgambling" runat="server">
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
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_Money" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_GeneralWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
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
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_Money" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Social behaviours</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_ProbableWarningSigns_SocialBehaviours" RepeatLayout="table" RepeatColumns="3" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
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
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_LengthOfPlay" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Money</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_Money" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Behaviour during play</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_BehaviourDuringPlay" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Social behaviours</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronSigns_StrongWarningSigns_SocialBehaviours" RepeatLayout="table" RepeatColumns="2" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="patronsignsother" runat="server" visible="false">
                <th>Other observed signs of at risk gaming behaviour</th>
            </tr>
            <tr id="patronsignsother1" runat="server" visible="false">
                <td>
                    <%# (string.IsNullOrWhiteSpace(Eval("PatronSignsOther").ToString())) ? Eval("PatronSignsOther") : (Eval("PatronSignsOther").ToString()).Replace("^", "'") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>Initial action taken by the RGO</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_InitialAction" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">Clubs Gaming Break Options Explained</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_3hrAlertResponse" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>Patron Response</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_PatronResponse" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>Final Outcome</th>
            </tr>
            <tr>
                <td>
                    <asp:CheckBoxList ID="List_EventOutcome" RepeatLayout="table" RepeatColumns="4" Font-Size="8" RepeatDirection="vertical" runat="server" class="object-default" onclick="return false" readonly="true">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="trfurthercomments" runat="server" visible="false">
                <th>Further Comments</th>
            </tr>
            <tr id="trfurthercomments1" runat="server" visible="false">
                <td><%# (string.IsNullOrWhiteSpace(Eval("EventOutcomeFurtherComments").ToString())) ? Eval("EventOutcomeFurtherComments") : (Eval("EventOutcomeFurtherComments").ToString()).Replace("^", "'") %></td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>Witness Recorded</th>
            </tr>
            <tr>
                <td>
                    <b>Yes/No : </b><asp:CheckBox Enabled="false" Checked='<%# Eval("WitnessRecorded") %>' runat="server" />
                </td>
            </tr>
            <tr id="trwitness" runat="server" visible="false">
                <th>Witness Details</th>
            </tr>
            <tr id="trwitness1" runat="server" visible="false">
                <td><%# (string.IsNullOrWhiteSpace(Eval("WitnessDetails").ToString())) ? Eval("WitnessDetails") : (Eval("WitnessDetails").ToString()).Replace("^", "'") %></td>
            </tr>
            <tr>
                <th>Police Notified</th>
            </tr>
            <tr>
                <td>
                    <b>Yes/No : </b><asp:CheckBox Enabled="false" Checked='<%# Eval("PoliceNotified") %>' runat="server" />
                </td>
            </tr>
            <tr id="trpolice" runat="server" visible="false">
                <th>Police Details</th>
            </tr>
            <tr id="trpolice1" runat="server" visible="false">
                <td><%# (string.IsNullOrWhiteSpace(Eval("PoliceDetails").ToString())) ? Eval("PoliceDetails") : (Eval("PoliceDetails").ToString()).Replace("^", "'") %></td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th>DM or Senior Manager completed an incident report</th>
            </tr>
            <tr>
                <td>
                    <b>Yes/No : </b><asp:CheckBox Enabled="false" Checked='<%# Eval("IncidentReportCompleted") %>' runat="server" />
                </td>
            </tr>
            <tr>
                <th>Assisted in completing the incident report</th>
            </tr>
            <tr>
                <td>
                    <b>Yes/No : </b><asp:CheckBox Enabled="false" Checked='<%# Eval("AssistedCompletingIncidentReport") %>' runat="server" />
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
</div>