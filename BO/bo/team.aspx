<%@ Page Language="VB" MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="team.aspx.vb" Inherits="team" Title ="Excel [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <table width="980" border="0" cellspacing="0" cellpadding="0">
   <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Add Team</strong></td></tr>
         </table></td>
        </tr>
    <tr>
        <td align="right" class="tdPageLinkText" colspan="7"><a class="pageLink"
            href="teammain.aspx">Back</a>&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td class="tdspace">
        </td>
        </tr>
            <tr>
                <td align="center">
            </td>
            </tr>
            <tr>
                <td><img src="../images/spacer.gif" height="15" /></td>
            </tr>
            <tr>
                <td align="center">
            <asp:Label ID="lblSuccessMessage" runat="server" Visible="False" Font-Bold="False" Font-Size="8pt" ForeColor="Black" Font-Names="Verdana"></asp:Label></td>
            </tr>
            <tr>
                <td>
                <table align="center" width="600" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Team Information&nbsp;</strong></font></legend>
	<table width="570" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="10" /></td>
	
  </tr>
  <tr>
    <td class="boProfilerightLrg"><font style="color:Red">*</font>&nbsp;<asp:Label ID="Label5" runat="server" Text="Team Name"></asp:Label></td>
    <td class="divide">&nbsp;</td>
    <td class="boProfileleft"><asp:TextBox ID="txtTeamName" runat="server" CssClass="bee1" Width="210px"></asp:TextBox><%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTeamName"
                        ErrorMessage="*"></asp:RequiredFieldValidator>--%><asp:CheckBox ID="chkEnable" runat="server" Text="Enable" /></td>
  </tr>
        <tr>
            <td class="boProfilerightLrg">
                    <asp:Label ID="Label1" runat="server" Text="Team Leader  (PR)"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                    <asp:DropDownList ID="cmbPR" runat="server" Width="210px" Height="17px">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="boProfilerightLrg">
                    <asp:Label ID="Label6" runat="server" Text="Team Formator (FR)"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                    <asp:DropDownList ID="cmbFR" runat="server" Width="210px" Height="17px">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td class="boProfilerightLrg">
                    <asp:Label ID="Label2" runat="server" Text="Quality Controllers (QCs)" Width="155px"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                    <asp:DropDownList ID="cmbQCMain" runat="server" Width="210px" Height="17px">
                    </asp:DropDownList>
                    <asp:Button ID="btnQCAdd" runat="server" Text="Add" Width="50px" Height="22px" /></td>
        </tr>
        <tr>
            <td colspan="3"><img src="../images/spacer.gif" height="10" /></td>
        </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
                </td>
            </tr>
            <tr>
                <td><img src="../images/spacer.gif" height="10" /></td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="lnkRemoveUpper" runat="server" Font-Bold="True" Visible="False" CssClass="gHeading">Remove</asp:LinkButton>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdUpper" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" 
                        GridLines="None" PageSize="1" DataKeyNames="ID">
                       <%-- <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />--%>
                        <Columns>
                            <asp:TemplateField>
                                
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkUpper" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                                <HeaderStyle Width="35px" HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="empID" HeaderText="Employee ID">
                                <ItemStyle HorizontalAlign="center" Width="85px" />
                                <HeaderStyle HorizontalAlign="center" Width="85px" />
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Name">
                               
                                <ItemStyle Width="499px" CssClass="tdSpacingleft" HorizontalAlign="Left" />
                                <ItemTemplate>
                                  <%#Eval("empFirstName") %>,&nbsp;<%#Eval("empLastName")%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" CssClass="tdSpacingleft" Width="499px" />
                            </asp:TemplateField>
                            
                            <asp:BoundField HeaderText="Date Added" DataField="DateAdded" >
                                <ItemStyle Width="150px" HorizontalAlign="center" />
                                <HeaderStyle Width="150px" HorizontalAlign="center" />
                            </asp:BoundField>
                        </Columns>
                        
                    </asp:GridView>
                </td>
            </tr>
            <tr>
      <td class="tdspace"></td>
    </tr>
            <tr>
                <td><img src="../images/spacer.gif" height="15" /></td>
            </tr>
            <tr>
                <td>
                <table align="center" width="600" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
	<fieldset>
	<legend><font class="blackSubtext"><strong>Transcriptionist Information&nbsp;</strong></font></legend>
	<table width="570" align="center" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="3"><img src="../images/spacer.gif" height="6" /></td>
	
  </tr>
  <tr>
    <td class="boProfilerightLrg">
                    <asp:Label ID="Label3" runat="server" Text="Transcriptionist (MTs)" Font-Size="12px" ForeColor="Black" Font-Bold="False"></asp:Label></td>
    <td class="divide">&nbsp;</td>
    <td class="boProfileleft"><asp:DropDownList ID="cmbMT" runat="server" Width="210px" Height="17px">
                    </asp:DropDownList></td>
  </tr>
        <tr>
            <td class="boProfilerightLrg">
                    <asp:Label ID="Label4" runat="server" Text="Assign To" Font-Size="12px" ForeColor="Black" Font-Bold="False"></asp:Label></td>
            <td class="divide">
            </td>
            <td class="boProfileleft">
                    <asp:DropDownList ID="cmbQC" runat="server" Width="210px" Height="17px">
                    </asp:DropDownList>
                    <asp:Button ID="btnMTAdd" runat="server" Text="Add" Width="50px" Height="22px" /></td>
        </tr>
        <tr>
            <td colspan="3"><img src="../images/spacer.gif" height="10" /></td>
        </tr>
</table>

	</fieldset>
	</td>
  </tr>
</table>
                </td>
            </tr>
            <tr>
                <td><img src="../images/spacer.gif" height="10" /></td>
            </tr>
                
            <tr>
                <td style="height: 19px" >
                    <asp:LinkButton ID="lnkRemoveLower" runat="server" Font-Bold="True" Visible="False" CssClass="gHeading">Remove</asp:LinkButton></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdLower" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False"
                        GridLines="None" PageSize="1" DataKeyNames="ID">
                        <%--<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />--%>
                        <Columns>
                            <asp:TemplateField>
                                
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkLower" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="35px" HorizontalAlign="center" />
                                <HeaderStyle Width="35px" HorizontalAlign="center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Employee ID" DataField="empID" >
                                <ItemStyle HorizontalAlign="center" Width="85px" />
                                <HeaderStyle HorizontalAlign="center" Width="85px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Name">
                               <ItemStyle Width="220px" CssClass="tdSpacingleft" HorizontalAlign="left" />
                                <HeaderStyle Width="220px" CssClass="tdSpacingleft" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <%#Eval("empLastName")%>&nbsp;<%#Eval("empFirstName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="QC Name">
                                <ItemStyle Width="219px" CssClass="tdSpacingleft" HorizontalAlign="left" />
                                <HeaderStyle Width="219px" CssClass="tdSpacingleft" HorizontalAlign="left" />
                                <ItemTemplate>
                                   <%#getQCName(Eval("QC")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="QC" HeaderText="QC ID">
                                <ItemStyle Width="60px" HorizontalAlign="center" />
                                <HeaderStyle Width="60px" HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Date Added" DataField="DateAdded" >
                                <ItemStyle Width="150px" HorizontalAlign="center" />
                                <HeaderStyle Width="150px" HorizontalAlign="center" />
                            </asp:BoundField>
                        </Columns>
                        
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="tdspace">
                </td>
                </tr>
            <tr>
                <td style="height: 30px; text-align: center"><asp:Button ID="btnSaveTeam" runat="server" Text="Save" Width="64px" /></td>
            </tr>
        </table>
</asp:Content>
   