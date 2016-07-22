<%@ Page Language="VB" MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="teamedit.aspx.vb" Inherits="teamedit" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function QC_Remove()
{
var answer = confirm("Sure you want to remove QC. If yes then all MT also remove?")
if(answer)
{
return true;
}
else
{
return false;
}
}

function MT_Remove()
{
var answer = confirm("Sure you want to remove this MT?")
if(answer)
{
return true;
}
else
{
return false;
}
}
</script>

    <table style="width:100%;">
        <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66; font-family:Verdana; font-size:15pt; vertical-align:text-bottom;">
            &nbsp;Change Team &nbsp;<font style="color:White;">[<%=Session("sTeamName").ToString()%>]</font>
            </td>
        </tr>
        <tr>
            <td style="height:5pt;">
            </td>
        </tr>
        <tr>
        <td>
        <table width="65%" align="center" id="TABLE1" onclick="return TABLE1_onclick()">
            <tr>
                <td align="right">
                    <asp:HyperLink ID="hlBack" runat="server" ForeColor="#404040" NavigateUrl="~/BO/teammain.aspx" CssClass="boProfileright">back</asp:HyperLink>&nbsp;&nbsp;</td>
            </tr>
        <tr>
        <td align="left">
            <asp:Label ID="lblSuccessMessage" runat="server" Visible="False" Font-Bold="False" Font-Size="8pt" ForeColor="Black" Font-Names="Verdana"></asp:Label></td>
        </tr>
        <tr>
        <td align="center">
        <fieldset style="width:80%;">
        <legend style="width:24%; height:100%; font-family:Tahoma; font-size:10pt; font-weight:bold;">
        <%=Session("sTeamName").ToString()%>&nbsp; information
        </legend>
        <table aling="center" width="90%" class="boProfileleft">
        <tr>
        <td align="right" colspan="2">
        <asp:CheckBox ID="chkEnable" runat="server" Text="Enable" /></td>
        </tr>
            <tr>
                <td style="width: 40%; height: 24px;" align="right">
                    Proof Reader (PR)&nbsp;</td>
                <td style="width: 60%; height: 24px;">
                    <asp:DropDownList ID="cmbPR" runat="server" Width="208px" Height="16px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 40%; height: 24px;">
                    Format Reader (FR)&nbsp;</td>
                <td style="width: 60%; height: 24px;">
                <asp:DropDownList ID="cmbFR" runat="server" Width="208px" Height="16px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 40%; height: 15px">
                </td>
                <td align="right" style="width: 60%; height: 15px">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="50px" Height="21px" /></td>
            </tr>
        </table>
        </fieldset>
        </td>
        </tr>
            <tr>
                <td align="center">
                <fieldset style="width:80%;">
                <legend style="width:13%; height:100%; font-family:Tahoma; font-size:10pt; font-weight:bold;">
                Add QC
                </legend>
                <table aling="center" width="100%" class="boProfileleft">
                <tr>
                <td style="width:40%;" align="right">
                    Quality Controlar (QC)&nbsp;</td>
                <td align="right" style="width:60%;">
                    <asp:DropDownList ID="cmbQCMain" runat="server" Width="208px" Height="16px">
                    </asp:DropDownList></td>
                </tr>
                    <tr>
                        <td style="width: 40%">
                        </td>
                        <td align="right" style="width: 60%">
                        <asp:Button ID="btnQCAdd" runat="server" Text="Add" Width="50px" Height="21px" />
                        </td>
                    </tr>
                </table>
                </fieldset>    
                </td>
            </tr>
            <tr>
                <td align="center" >
                <fieldset style="width:80%;">
                <legend style="width:13%; height:100%; font-family:Tahoma; font-size:10pt; font-weight:bold;">
                Add MT
                </legend>
                <table align="center" width="100%" class="boProfileleft">
                <tr>
                <td style="width:40%;" align="right">
                    Select QC&nbsp;</td>
                <td style="width:60%;">
                    <asp:DropDownList ID="cmbQC" runat="server" Width="208px" Height="16px">
                    </asp:DropDownList></td>
                </tr>
                    <tr>
                        <td align="right" style="width: 40%">
                            Medical Transcription (MT)&nbsp;
                        </td>
                        <td style="width: 60%">
                <asp:DropDownList ID="cmbMT" runat="server" Width="208px" Height="16px">
                    </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%; ">
                        </td>
                        <td align="right" style="width: 60%">
                        <asp:Button ID="btnMTAdd" runat="server" Text="Add" Width="50px" Height="21px" /></td>
                    </tr>
                </table>
                </fieldset>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="width:100%;">
                <br />
                <asp:DropDownList ID="ddlChangeQC" runat="server" Width="208px" Height="16px">
                </asp:DropDownList>
                <asp:Button runat="Server" ID="btnChange" Text="Change (QC)" Height="22px" />
                <asp:GridView runat="Server" ID="gvQc" Width="770px" AutoGenerateColumns="false" DataKeyNames="empId">
                <Columns>
                <asp:TemplateField>
                <HeaderTemplate>
                <table width="770px" class="boProfileleft" align="left">                
                </HeaderTemplate>
                <ItemTemplate>
                <tr style="height:25px; color:Black; font-size:9pt; font-weight:bold;">
                <td align="left" style="width:675px; background-color:#ECECEC;">
                &nbsp;<%#Eval("empID") %> &nbsp;&nbsp;<%#Eval("empName") %>&nbsp;[QC]
                </td>
                <td align="center" style="width:95px; background-color:#ECECEC;">
                <asp:HyperLink runat="server" ID="hRemove" Text="Remove" ForeColor="black"></asp:HyperLink>
                </td>
                </tr
                <tr>
                <td colspan="2" style="width:770px;">
                <asp:GridView runat="Server" ID="gvMT" Width="770px" OnRowCreated="gvMT_RowCreated" OnRowDataBound="gvMT_RowDataBound" DataKeyNames="empId" AutoGenerateColumns="false" ShowHeader="false" >
                <Columns>
                <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                <%#Me.index%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="center"  Width="20px" Font-Size="8pt" />
                <HeaderStyle HorizontalAlign="center" Width="20px" CssClass="gridHeadingCenter"  />
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                <asp:CheckBox runat="Server" ID="chkMT" />
                </ItemTemplate>
                <ItemStyle CssClass="boProfilecenter" HorizontalAlign="left"  Width="20px"/>
                <HeaderStyle CssClass="boProfilecenter" HorizontalAlign="left" Width="20px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MT">
                <ItemTemplate>
                <%#Eval("empID") %>
                </ItemTemplate>
                <ItemStyle CssClass="boProfilecenter" HorizontalAlign="center"  Width="100px"/>
                <HeaderStyle CssClass="boProfilecenter" HorizontalAlign="center" Width="100px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                &nbsp;<%#Eval("empName") %>&nbsp;[MT]
                </ItemTemplate>
                <ItemStyle CssClass="boProfileleft" HorizontalAlign="left" Width="535px" />
                <HeaderStyle CssClass="boProfileleft" HorizontalAlign="left" Width="535px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                <asp:HyperLink runat="server" ID="hRemove" Text="Remove" ForeColor="black"></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle CssClass="boProfilecenter" HorizontalAlign="center" Width="95px"/>
                <HeaderStyle CssClass="boProfilecenter" HorizontalAlign="center" Width="95px"/>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </td>
                </tr>
               </ItemTemplate>
               <FooterTemplate>
                </table>
               </FooterTemplate>
               <FooterStyle HorizontalAlign="center" />
               </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="width: 100%">
                    <asp:Button ID="Button1" runat="server" Text="Ok" Width="50px" Height="21px" PostBackUrl="~/BO/teammain.aspx" />
                    </td>
            </tr>
        </table>
            </td>
        </tr>
        
    </table>
    <br />
        
</asp:Content>
   