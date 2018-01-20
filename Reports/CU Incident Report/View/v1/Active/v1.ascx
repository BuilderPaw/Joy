<%@ Control Language="C#" AutoEventWireup="true" CodeFile="v1.ascx.cs" Inherits="Reports_CU_Incident_Report_View_v1_v1" %>
<div class="body2">
    <div>
        <span style="margin-left: 0%; font-size: 18px; width: 130px;">STATUS: <%# Eval("ReportStat") %></span>
        <span class="report-number"><%# Eval("ReportName") %> ID No. <span style="color: red;"><b><%# Eval("ReportId") %></b></span></span>
    </div>
    <div id="incidentReport" runat="server">
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
        </table>
        <table id="tblPerson1" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 1</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType1" runat="server"><b>Party Type : </b>
                    <%# Eval("TxtPartyType1") %>
                </td>
                <td id="witness1l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness1")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff11l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# Eval("StaffEmpNo1") %>
                </td>
                <td id="member12l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld1")) %>' />
                </td>
                <td id="member11l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu1', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# Eval("MemberNo1") %></asp:LinkButton>
                </td>
                <td id="visitor11l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip1")) %>' />
                </td>
                <td id="visitor12l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# Eval("SignedInBy1") %>
                </td>
            </tr>
            <tr>
                <td id="staff12l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("StaffAddress1") %>
                </td>
                <td id="member13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB1")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# Eval("MemberSince1") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# Eval("MemberAddress1") %>
                </td>
                <td id="member14l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember1" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor13l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB1")) %>
                </td>
                <td id="visitor14l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# Eval("VisitorProofID1") %>
                </td>
            </tr>
            <tr>
                <td id="visitor15l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("VisitorAddress1") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# Eval("FirstName1") %>
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# Eval("LastName1") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# Eval("Alias1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# Eval("Contact1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate1")) %> - <%# Eval("TxtPTimeH1") %>:<%# Eval("TxtPTimeM1") %>
                    <!--<%# Eval("TxtPTimeTC1") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# Eval("Age1") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup1" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1" id="weight1" runat="server">
                    <b>Weight :</b><br />
                    <%# Eval("Weight1") %>
                </td>
                <td colspan="1" id="height1" runat="server">
                    <b>Build/Height :</b><br />
                    <%# Eval("Height1") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="hair1">
                    <b>Hair :</b><br />
                    <%# Eval("Hair1") %>    
                </td>
                <td colspan="1" runat="server" id="clothingTop1">
                    <b>Clothing - Top :</b><br />
                    <%# Eval("ClothingTop1") %>    
                </td>
                <td colspan="1" id="clothingBottom1" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# Eval("ClothingBottom1") %>
                </td>
                <td colspan="1" id="shoes1" runat="server">
                    <b>Shoes :</b><br />
                    <%# Eval("Shoes1") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" id="weapon1" runat="server">
                    <b>Weapon :</b><br />
                    <%# Eval("Weapon1") %>
                </td>
                <td colspan="1">
                    <b>Gender :</b><br />
                    <%# Eval("TxtGender1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist1l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist1" runat="server">
                    <%# Eval("DistFeatures1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc1l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc1" runat="server">
                    <%# Eval("InjuryDesc1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj1l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj1" runat="server">
                    <%# Eval("CauseInjury1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom1l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom1" runat="server">
                    <%# Eval("Comments1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image1l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image1" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson2" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 2</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType2" runat="server"><b>Party Type : </b>
                    <%# Eval("TxtPartyType2") %>
                </td>
                <td id="witness2l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness2")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff21l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# Eval("StaffEmpNo2") %>
                </td>
                <td id="member22l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld2")) %>' />
                </td>
                <td id="member21l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu2', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# Eval("MemberNo2") %></asp:LinkButton>
                </td>
                <td id="visitor21l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip2")) %>' />
                </td>
                <td id="visitor22l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# Eval("SignedInBy2") %>
                </td>
            </tr>
            <tr>
                <td id="staff22l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("StaffAddress2") %>
                </td>
                <td id="member23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB2")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# Eval("MemberSince2") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# Eval("MemberAddress2") %>
                </td>
                <td id="member24l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember2" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor23l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB2")) %>
                </td>
                <td id="visitor24l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# Eval("VisitorProofID2") %>
                </td>
            </tr>
            <tr>
                <td id="visitor25l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("VisitorAddress2") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# Eval("FirstName2") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# Eval("LastName2") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# Eval("Alias2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# Eval("Contact2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate2")) %> - <%# Eval("TxtPTimeH2") %>:<%# Eval("TxtPTimeM2") %>
                    <!--<%# Eval("TxtPTimeTC2") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <%# Eval("Age2") %>    
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <asp:Label ID="lblAgeGroup2" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1" id="weight2" runat="server">
                    <b>Weight :</b><br />
                    <%# Eval("Weight2") %>
                </td>
                <td colspan="1" id="height2" runat="server">
                    <b>Build/Height :</b><br />
                    <%# Eval("Height2") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="hair2">
                    <b>Hair :</b><br />
                    <%# Eval("Hair2") %>    
                </td>
                <td colspan="1" runat="server" id="clothingTop2">
                    <b>Clothing - Top :</b><br />
                    <%# Eval("ClothingTop2") %>    
                </td>
                <td colspan="1" id="clothingBottom2" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# Eval("ClothingBottom2") %>
                </td>
                <td colspan="1" id="shoes2" runat="server">
                    <b>Shoes :</b><br />
                    <%# Eval("Shoes2") %>    
                </td>
            </tr>
            <tr>
                <td colspan="2" id="weapon2" runat="server">
                    <b>Weapon :</b><br />
                    <%# Eval("Weapon2") %>
                </td>
                <td colspan="2">
                    <b>Gender :</b><br />
                    <%# Eval("TxtGender2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist2l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist2" runat="server">
                    <%# Eval("DistFeatures2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc2l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc2" runat="server">
                    <%# Eval("InjuryDesc2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj2l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj2" runat="server">
                    <%# Eval("CauseInjury2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom2l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom2" runat="server">
                    <%# Eval("Comments2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image2l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image2" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson3" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 3</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType3" runat="server"><b>Party Type : </b>
                    <%# Eval("TxtPartyType3") %>  
                </td>
                <td id="witness3l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness3")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff31l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# Eval("StaffEmpNo3") %>
                </td>
                <td id="member32l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld3")) %>' />
                </td>
                <td id="member31l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu3', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# Eval("MemberNo3") %></asp:LinkButton>
                </td>
                <td id="visitor31l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip3")) %>' />
                </td>
                <td id="visitor32l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# Eval("SignedInBy3") %>
                </td>
            </tr>
            <tr>
                <td id="staff32l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("StaffAddress3") %>
                </td>
                <td id="member33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB3")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# Eval("MemberSince3") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# Eval("MemberAddress3") %>
                </td>
                <td id="member34l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember3" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor33l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB3")) %>
                </td>
                <td id="visitor34l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# Eval("VisitorProofID3") %>
                </td>
            </tr>
            <tr>
                <td id="visitor35l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("VisitorAddress3") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# Eval("FirstName3") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# Eval("LastName3") %>                                    
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# Eval("Alias3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# Eval("Contact3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate3")) %> - <%# Eval("TxtPTimeH3") %>:<%# Eval("TxtPTimeM3") %>
                    <!--<%# Eval("TxtPTimeTC3") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age :</b><br />
                    <asp:Label ID="lblAgeGroup3" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1">
                    <b>Age Group :</b><br />
                    <%# Eval("AgeGroup3") %>    
                </td>
                <td colspan="1" id="weight3" runat="server">
                    <b>Weight :</b><br />
                    <%# Eval("Weight3") %>
                </td>
                <td colspan="1" id="height3" runat="server">
                    <b>Build/Height :</b><br />
                    <%# Eval("Height3") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="hair3">
                    <b>Hair :</b><br />
                    <%# Eval("Hair3") %>
                </td>
                <td colspan="1" runat="server" id="clothingTop3">
                    <b>Clothing - Top :</b><br />
                    <%# Eval("ClothingTop3") %>    
                </td>
                <td colspan="1" id="clothingBottom3" runat="server">
                    <b>Clothing - Bottom :</b><br />
                    <%# Eval("ClothingBottom3") %>
                </td>
                <td colspan="1" id="shoes3" runat="server">
                    <b>Shoes :</b><br />
                    <%# Eval("Shoes3") %>    
                </td>
            </tr>
            <tr>
                <td colspan="2" id="weapon3" runat="server">
                    <b>Weapon :</b><br />
                    <%# Eval("Weapon3") %>
                </td>
                <td colspan="2">
                    <b>Gender : </b>
                    <br />
                    <%# Eval("TxtGender3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist3l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist3" runat="server">
                    <%# Eval("DistFeatures3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc3l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc3" runat="server">
                    <%# Eval("InjuryDesc3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj3l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj3" runat="server">
                    <%# Eval("CauseInjury3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom3l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom3" runat="server">
                    <%# Eval("Comments3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image3l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image3" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson4" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 4</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType4" runat="server"><b>Party Type : </b>
                    <%# Eval("TxtPartyType4") %>  
                </td>
                <td id="witness4l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness4")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff41l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# Eval("StaffEmpNo4") %>
                </td>
                <td id="member42l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld4")) %>' />
                </td>
                <td id="member41l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu4', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# Eval("MemberNo4") %></asp:LinkButton>
                </td>
                <td id="visitor41l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip4")) %>' />
                </td>
                <td id="visitor42l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# Eval("SignedInBy4") %>
                </td>
            </tr>
            <tr>
                <td id="staff42l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("StaffAddress4") %>
                </td>
                <td id="member43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB4")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# Eval("MemberSince4") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# Eval("MemberAddress4") %>
                </td>
                <td id="member44l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember4" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor43l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB4")) %>
                </td>
                <td id="visitor44l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# Eval("VisitorProofID4") %>
                </td>
            </tr>
            <tr>
                <td id="visitor45l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("VisitorAddress4") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# Eval("FirstName4") %>                                    
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# Eval("LastName4") %>                
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# Eval("Alias4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# Eval("Contact4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate4")) %> - <%# Eval("TxtPTimeH4") %>:<%# Eval("TxtPTimeM4") %>
                    <!--<%# Eval("TxtPTimeTC4") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age : </b>
                    <br />
                    <%# Eval("Age4") %>    
                </td>
                <td colspan="1">
                    <b>Age Group : </b>
                    <br />
                    <asp:Label ID="lblAgeGroup4" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1" id="weight4" runat="server">
                    <b>Weight : </b>
                    <br />
                    <%# Eval("Weight4") %>
                </td>
                <td colspan="1" id="height4" runat="server">
                    <b>Build/Height : </b>
                    <br />
                    <%# Eval("Height4") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="hair4">
                    <b>Hair : </b>
                    <br />
                    <%# Eval("Hair4") %>    
                </td>
                <td colspan="1" runat="server" id="clothingTop4">
                    <b>Clothing - Top : </b>
                    <br />
                    <%# Eval("ClothingTop4") %>    
                </td>
                <td colspan="1" id="clothingBottom4" runat="server">
                    <b>Clothing - Bottom : </b>
                    <br />
                    <%# Eval("ClothingBottom4") %>
                </td>
                <td colspan="1" id="shoes4" runat="server">
                    <b>Shoes : </b>
                    <br />
                    <%# Eval("Shoes4") %>    
                </td>
            </tr>
            <tr>
                <td colspan="2" id="weapon4" runat="server">
                    <b>Weapon : </b>
                    <br />
                    <%# Eval("Weapon4") %>
                </td>
                <td colspan="2">
                    <b>Gender : </b>
                    <br />
                    <%# Eval("TxtGender4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist4l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist4" runat="server">
                    <%# Eval("DistFeatures4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc4l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc4" runat="server">
                    <%# Eval("InjuryDesc4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj4l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj4" runat="server">
                    <%# Eval("CauseInjury4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom4l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom4" runat="server">
                    <%# Eval("Comments4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image4l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image4" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table id="tblPerson5" class="table-view" runat="server">
            <tr>
                <th colspan="5">Person 5</th>
            </tr>
            <tr>
                <td colspan="1" id="tdPartyType5" runat="server"><b>Party Type : </b>
                    <%# Eval("TxtPartyType5") %>
                </td>
                <td id="witness5l" visible="false" runat="server" colspan="1"><b>Witness : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("Witness5")) %>' />
                </td>
            </tr>
            <tr>
                <td id="staff51l" runat="server" visible="false" colspan="1"><b>Staff Employee No. : </b>
                    <br />
                    <%# Eval("StaffEmpNo5") %>
                </td>
                <td id="member52l" runat="server" visible="false" colspan="1"><b>Card Held : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CardHeld5")) %>' />
                </td>
                <td id="member51l" runat="server" visible="false" colspan="1"><b>Member No : </b>
                    <br />
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClientClick="window.open('/Default.aspx?ReportType=&DateGroup=&ReportStatus=&Keyword=&Staff=&PlayerId=cu5', null, 'channelmode=1, width=1366,height=768,resizable=yes,status=no,toolbar=no,scrollbars=yes,menubar=yes,location=no,left=1,top=1' );return false;" ><%# Eval("MemberNo5") %></asp:LinkButton>
                </td>
                <td id="visitor51l" runat="server" visible="false" colspan="1"><b>Sign In Slip : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("SignInSlip5")) %>' />
                </td>
                <td id="visitor52l" runat="server" visible="false" colspan="1"><b>Signed In By : </b>
                    <br />
                    <%# Eval("SignedInBy5") %>
                </td>
            </tr>
            <tr>
                <td id="staff52l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("StaffAddress5") %>
                </td>
                <td id="member53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("MemberDOB5")) %>
                    <br />
                    <br />
                    <b>Member Since : </b>
                    <br />
                    <%# Eval("MemberSince5") %>
                    <br />
                    <br />
                    <b>Address : </b>
                    <br />
                    <%# Eval("MemberAddress5") %>
                </td>
                <td id="member54l" runat="server" visible="false" colspan="1"><b>Member Photo : </b>
                    <br />
                    <asp:Image ID="imgMember5" Height="110px" Width="140px" runat="server" />
                </td>
                <td id="visitor53l" runat="server" visible="false" colspan="1"><b>Date of Birth : </b>
                    <br />
                    <%# ProcessMyDataItem(Eval("VisitorDOB5")) %>
                </td>
                <td id="visitor54l" runat="server" visible="false" colspan="1"><b>Proof of Identity : </b>
                    <br />
                    <%# Eval("VisitorProofID5") %>
                </td>
            </tr>
            <tr>
                <td id="visitor55l" runat="server" visible="false" colspan="1"><b>Address : </b>
                    <br />
                    <%# Eval("VisitorAddress5") %>
                </td>
            </tr>
            <tr>
                <td colspan="1"><b>First Name : </b>
                    <br />
                    <%# Eval("FirstName5") %>
                </td>
                <td colspan="1"><b>Last Name : </b>
                    <br />
                    <%# Eval("LastName5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Alias : </b>
                    <br />
                    <%# Eval("Alias5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Contact Details : </b>
                    <br />
                    <%# Eval("Contact5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Details of When the Patron Entered the Club</u></b></td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Date & Time : </b><%# ProcessMyDataItem(Eval("PDate5")) %> - <%# Eval("TxtPTimeH5") %>:<%# Eval("TxtPTimeM5") %>
                    <!--<%# Eval("TxtPTimeTC5") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b><u>Physical Factors of Person</u></b></td>
            </tr>
            <tr>
                <td colspan="1">
                    <b>Age : </b>
                    <br />
                    <%# Eval("Age5") %>    
                </td>
                <td colspan="1">
                    <b>Age Group : </b>
                    <br />
                    <asp:Label ID="lblAgeGroup5" runat="server" Text=""></asp:Label>
                </td>
                <td colspan="1" id="weight5" runat="server">
                    <b>Weight : </b>
                    <br />
                    <%# Eval("Weight5") %>
                </td>
                <td colspan="1" id="height5" runat="server">
                    <b>Build/Height : </b>
                    <br />
                    <%# Eval("Height5") %>    
                </td>
            </tr>
            <tr>
                <td colspan="1" runat="server" id="hair5">
                    <b>Hair : </b>
                    <br />
                    <%# Eval("Hair5") %>    
                </td>
                <td colspan="1" runat="server" id="clothingTop5">
                    <b>Clothing - Top : </b>
                    <br />
                    <%# Eval("ClothingTop5") %>    
                </td>
                <td colspan="1" id="clothingBottom5" runat="server">
                    <b>Clothing - Bottom : </b>
                    <br />
                    <%# Eval("ClothingBottom5") %>
                </td>
                <td colspan="1" id="shoes5" runat="server">
                    <b>Shoes : </b>
                    <br />
                    <%# Eval("Shoes5") %>    
                </td>
            </tr>
            <tr>
                <td colspan="2" id="weapon5" runat="server">
                    <b>Weapon : </b>
                    <br />
                    <%# Eval("Weapon5") %>
                </td>
                <td colspan="2">
                    <b>Gender : </b>
                    <br />
                    <%# Eval("TxtGender5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist5l" runat="server">
                    <b>Distinguishing Features : </b>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="dist5" runat="server">
                    <%# Eval("DistFeatures5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc5l" runat="server"><b><u>Injury Description</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="injdesc5" runat="server">
                    <%# Eval("InjuryDesc5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj5l" runat="server"><b><u>Cause of Injury</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="causeinj5" runat="server">
                    <%# Eval("CauseInjury5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="inccom5l" runat="server"><b><u>Incident Comments</u></b></td>
            </tr>
            <tr>
                <td colspan="4" id="inccom5" runat="server">
                    <%# Eval("Comments5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4" id="image5l" runat="server">
                    <b><u>Injury Diagram</u></b>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Image ID="Image5" Height="300px" Width="400px" runat="server" />
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="2">Incident Date and Time</th>
                <th colspan="2">Number of Persons Involved</th>
            </tr>
            <tr>
                <td style="border-right: 1px solid black" colspan="2">
                    <%# Convert.ToDateTime(Eval("Date")).ToString("dddd, dd MMMM yyyy") %> - <%# Eval("TxtTimeH") %>:<%# Eval("TxtTimeM") %>
                    <!--<%# Eval("TxtTimeTC") %>-->
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%# Eval("NoOfPerson") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Location of Incident</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="cblLocation" onclick="return false" readonly="true" Font-Size="8" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <th id="otherLocation" runat="server" visible="false" colspan="4">Other
                </th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("LocationOther") %>     
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam1">
            <tr>
                <th colspan="5">CCTV Camera 1</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc1") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded1")) %>' />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath1") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate1")) %> - <%# Eval("TxtCamSTimeH1") %>:<%# Eval("TxtCamSTimeM1") %>
                    <!--<%# Eval("TxtCamSTimeTC1") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate1")) %> - <%# Eval("TxtCamETimeH1") %>:<%# Eval("TxtCamETimeM1") %>
                    <!--<%# Eval("TxtCamETimeTC1") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam2">
            <tr>
                <th colspan="5">CCTV Camera 2</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc2") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded2")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath2") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate2")) %> - <%# Eval("TxtCamSTimeH2") %>:<%# Eval("TxtCamSTimeM2") %>
                    <!--<%# Eval("TxtCamSTimeTC2") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate2")) %> - <%# Eval("TxtCamETimeH2") %>:<%# Eval("TxtCamETimeM2") %>
                    <!--<%# Eval("TxtCamETimeTC2") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam3">
            <tr>
                <th colspan="5">CCTV Camera 3</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc3") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded3")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath3") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate3")) %> - <%# Eval("TxtCamSTimeH3") %>:<%# Eval("TxtCamSTimeM3") %>
                    <!--<%# Eval("TxtCamSTimeTC3") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate3")) %> - <%# Eval("TxtCamETimeH3") %>:<%# Eval("TxtCamETimeM3") %>
                    <!--<%# Eval("TxtCamETimeTC3") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam4">
            <tr>
                <th colspan="5">CCTV Camera 4</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc4") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded4")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath4") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate4")) %> - <%# Eval("TxtCamSTimeH4") %>:<%# Eval("TxtCamSTimeM4") %>
                    <!--<%# Eval("TxtCamSTimeTC4") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate4")) %> - <%# Eval("TxtCamETimeH4") %>:<%# Eval("TxtCamETimeM4") %>
                    <!--<%# Eval("TxtCamETimeTC4") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam5">
            <tr>
                <th colspan="5">CCTV Camera 5</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc5") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded5")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath5") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate5")) %> - <%# Eval("TxtCamSTimeH5") %>:<%# Eval("TxtCamSTimeM5") %>
                    <!--<%# Eval("TxtCamSTimeTC5") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate5")) %> - <%# Eval("TxtCamETimeH5") %>:<%# Eval("TxtCamETimeM5") %>
                    <!--<%# Eval("TxtCamETimeTC5") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam6">
            <tr>
                <th colspan="5">CCTV Camera 6</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc6") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded6")) %>' />
                </td>

            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath6") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate6")) %> - <%# Eval("TxtCamSTimeH6") %>:<%# Eval("TxtCamSTimeM6") %><!-- <%# Eval("TxtCamSTimeTC6") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate6")) %> - <%# Eval("TxtCamETimeH6") %>:<%# Eval("TxtCamETimeM6") %><!-- <%# Eval("TxtCamETimeTC6") %>-->
                </td>
            </tr>
        </table>
        <table runat="server" class="table-view" id="tblCam7">
            <tr>
                <th colspan="5">CCTV Camera 7</th>
            </tr>
            <tr>
                <td colspan="1" style="width: 100px;">
                    <b>Camera Description : </b><%# Eval("CamDesc7") %>
                </td>
                <td colspan="1" style="width: 130px;">
                    <b>Recorded : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# ProcessCheckBox(Eval("CamRecorded7")) %>' />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <b>File Path : </b><%# Eval("CamFilePath7") %>
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>Start Date & Time : </b><%# ProcessMyDataItem(Eval("CamSDate7")) %> - <%# Eval("TxtCamSTimeH7") %>:<%# Eval("TxtCamSTimeM7") %>
                    <!--<%# Eval("TxtCamSTimeTC7") %>-->
                </td>
            </tr>
            <tr>
                <td colspan="4"><b>End Date & Time : </b><%# ProcessMyDataItem(Eval("CamEDate7")) %> - <%# Eval("TxtCamETimeH7") %>:<%# Eval("TxtCamETimeM7") %>
                    <!--<%# Eval("TxtCamETimeTC7") %>-->
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">What Happened</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="cblWhatHappened1" onclick="return false" Font-Size="8" readonly="true" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="refuseEntryReasons" visible="false" runat="server">
                <th colspan="4">Refuse Entry Reason
                </th>
            </tr>
            <tr id="refuseEntryReasons1" visible="false" runat="server">
                <td colspan="4">
                    <asp:CheckBoxList ID="cblRefuseReason" Font-Size="8" onclick="return false" readonly="true" Visible="false" RepeatLayout="table" RepeatColumns="3" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="additionalDetails" visible="false" runat="server">
                <th colspan="4">Other
                </th>
            </tr>
            <tr id="additionalDetails1" visible="false" runat="server">
                <td colspan="4">
                    <%# Eval("HappenedOther") %>
                </td>
            </tr>
            <tr id="otherSerious" visible="false" runat="server">
                <th colspan="4">Other - Serious
                </th>
            </tr>
            <tr id="otherSerious1" visible="false" runat="server">
                <td colspan="4">
                    <%# Eval("HappenedSerious") %>
                </td>
            </tr>
            <tr id="askedtoLeaveReasons" visible="false" runat="server">
                <th colspan="4">Asked to Leave Reason
                </th>
            </tr>
            <tr id="askedtoLeaveReasons1" visible="false" runat="server">
                <td colspan="4">
                    <asp:CheckBoxList ID="cblAskedToLeave" Font-Size="8" onclick="return false" readonly="true" Visible="false" RepeatLayout="table" RepeatColumns="5" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>           
            <tr>
                <th colspan="4">Full Details of Incident & Injuries</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Details") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Allegation</th>
            </tr>
            <tr>
                <td colspan="4">
                    <%# Eval("Allegation") %>
                </td>
            </tr>
            <tr>
                <th colspan="4">Action Taken / Incident Details</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:CheckBoxList ID="cblActionTaken" Font-Size="11px" onclick="return false" readonly="true" RepeatLayout="table" RepeatColumns="4" RepeatDirection="vertical" runat="server" class="form-control">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr id="actionTakenOther" visible="false" runat="server">
                <th colspan="4">Action Taken - Other
                </th>
            </tr>
            <tr id="actionTakenOther1" visible="false" runat="server">
                <td colspan="4">
                    <%# Eval("ActionTakenOther") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="4">Did Security Attend</th>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Yes/No : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("SecurityAttend") %>' />
                </td>
            </tr>
            <tr>
                <td id="tdSecurity1" runat="server" colspan="4"><b>Name of Security Officer : </b><%# Eval("SecurityName") %>                                    
                </td>
            </tr>
            <tr>
                <th colspan="4">Where Police Notified</th>
            </tr>
            <tr>
                <td colspan="4">
                    <b>Yes/No : </b>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%# Eval("PoliceNotify") %>' />
                </td>
            </tr>
            <tr>
                <td id="tdPolice1" runat="server" colspan="4">
                    <b>Police Station : </b><%# Eval("PoliceStation") %>
                </td>
            </tr>
            <tr>
                <td id="tdPolice2" runat="server" colspan="4">
                    <b>Officer's Name : </b><%# Eval("OfficersName") %>
                </td>
            </tr>
            <tr>
                <td id="tdPolice3" runat="server" colspan="4">
                    <b>Police Action : </b><%# Eval("PoliceAction") %>
                </td>
            </tr>
        </table>
        <table class="table-view">
            <tr>
                <th colspan="5">Comments</th>
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
