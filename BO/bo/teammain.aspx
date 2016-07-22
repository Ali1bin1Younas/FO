<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="teammain.aspx.vb" Inherits="BO_teammain" Title ="Excel [ Back Office - Admin ]" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="980">
    <tr>
            <td colspan="6" style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Teams</strong></td></tr>
         </table></td>
        </tr>
        <tr>
            <td class="upload" colspan="6" height="100%">
                &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Size="12px" ForeColor="Black"
                    Text="Select Team" Width="169px"></asp:Label>
                <asp:DropDownList ID="cmbTeam" runat="server" Width="185px" AutoPostBack="True">
                </asp:DropDownList>&nbsp;
                <asp:Button ID="btnCreateNew" runat="server" Text="Create New Team" Width="154px" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tdspace" colspan="6" style="height: 2px">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 23px"><img src="../images/spacer.gif" height="20" border="0" /> </td>
        </tr>
        <tr>
            <td valign="top" width="50" rowspan="2">
            </td>
            <td width="280" valign =top rowspan="2" >
                <asp:TreeView ID="tvTeam" runat="server" ExpandImageToolTip="" ExpandDepth="0" ShowLines="True">
                    <ParentNodeStyle HorizontalPadding="10px" Font-Bold="False" Font-Size="12px" ForeColor="#8080FF" />
                    <RootNodeStyle HorizontalPadding="10px" ImageUrl="~/Icon/multiUsers.gif" Font-Bold="False" Font-Size="12px" ForeColor="#0000C0" />
                    <LeafNodeStyle HorizontalPadding="10px" Font-Bold="False" Font-Size="12px" ForeColor="#FF8080" CssClass="nodeClass" />
                </asp:TreeView>
            </td>
            <td class="tdspaceVerticle" rowspan="2" ><img src="../images/spacer.gif" width="1"></td>
            <td valign="top" width="20" rowspan="2"></td>
            <td valign ="top" class="tdborderpaddingBO" >
            <table cellspacing="0" cellpadding="0" border="0">
            <tr><td height="100%">
                <table width="370" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="width: 30px; height: 19px">
                            <asp:Label ID="lblTeamNameMain1" runat="server" Font-Size="12px" ForeColor="Black" Text="Team Name"
                                Width="106px"></asp:Label></td>
                        <td style="width: 3px; height: 19px">
                            <asp:Label ID="lblTeamNameMain" runat="server" Font-Size="12px" ForeColor="Black" Width="157px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 30px; height: 19px;">
                            <asp:Label ID="lblTLone" runat="server" Text="Team Leader" Font-Size="12px" ForeColor="Black" Width="106px"></asp:Label></td>
                        <td style="width: 3px; height: 19px;">
                            <asp:Label ID="lblTL" runat="server" Font-Size="12px" ForeColor="Black"
                                Width="157px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 30px;">
                            <asp:Label ID="lblQCone" runat="server" Font-Size="12px" ForeColor="Black" Text="Quality Controllers"
                                Width="169px"></asp:Label></td>
                        <td style="width: 3px; height: 20px;">
                            <asp:Label ID="lblQC" runat="server" Font-Size="12px" ForeColor="Black"
                                Width="154px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 19px; width: 30px;">
                            <asp:Label ID="lblMTone" runat="server" Font-Size="12px" ForeColor="Black" Text="Medical Transcriptionists"
                                Width="168px"></asp:Label></td>
                        <td style="width: 3px; height: 19px">
                            <asp:Label ID="lblMT" runat="server" Font-Size="12px" ForeColor="Black"
                                Width="153px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" colspan="2">
                            </td>
                    </tr>
                    <tr>
                        <td class="tdspace" colspan="2" style="height: 2px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 30px;">
                            <asp:Label ID="lblCreatedone" runat="server" Font-Size="12px" ForeColor="Black" Text="Created"
                                Width="106px"></asp:Label></td>
                        <td style="width: 3px; height: 20px">
                            <asp:Label ID="lblCreated" runat="server" Font-Size="12px" ForeColor="Black"
                                Width="217px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 30px;">
                            <asp:Label ID="lblModifiedone" runat="server" Font-Size="12px" ForeColor="Black" Text="Modified"
                                Width="106px"></asp:Label></td>
                        <td style="width: 3px; height: 20px">
                            <asp:Label ID="lblModified" runat="server" Font-Size="12px" ForeColor="Black"
                                Width="214px"></asp:Label></td>
                    </tr>
                </table></td></tr>
                </table>                
            </td>
            <td valign="top" width="50" rowspan="2"></td></tr>
        <tr>
            <td valign="top" align="left" style="height: 118px"><table cellpadding="0" cellspacing="0" border="0" style="width: 414px">
             <tr>
                 <td colspan="3">
                     <img src="../images/spacer.gif" height="15" /></td>
            </tr>
             <tr>
            <td style="width: 40px"></td>
                 <td ></td>
                 <td style="width: 40px"></td>
            </tr>
            <tr>
            <td class="heading" colspan="3" style="height: 35px"><br style="line-height:10px;" /><strong>Tasks</strong></td>
               
            </tr>
            <tr>
            <td colspan="3" style="height: 13px">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="11px" ForeColor="Blue">Change Team</asp:LinkButton></td>
                
            </tr>
                <tr>
                    <td colspan="3" style="height: 13px">
                        <asp:LinkButton  ID="lnkDeleteTeam" OnClientClick =" return confirmDeleteTeam();" runat="server" Font-Size="11px" ForeColor="Blue">Delete Team</asp:LinkButton></td>
                </tr>
            <tr>
            <td colspan="3" style="height: 13px">
                </td>
               
            </tr>
                <tr>
                    <td colspan="3" style="height: 13px">
                        </td>
                </tr>
            </table></td>
        </tr>
         <tr>
            <td colspan="6"><img src="../images/spacer.gif" height="20" border="0" /> </td>
        </tr>
    </table>
</asp:Content>

