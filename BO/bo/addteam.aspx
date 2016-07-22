<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="addteam.aspx.vb" Inherits="BO_addteam" Theme="BOboLayout"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function onTeamAdd()
{
var val = document.getElementById("<%=Me.txtTeam.ClientID %>").value
if(val=="")
{
alert("Team name is requierd");
return false;
}
{
return true;
}
}
</script>
<table border="0" style="width:100%;">
<tr>
<td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66; font-family:Verdana; font-size:13pt; vertical-align:text:middle; color:White;">
&nbsp;&nbsp;Add New Team
</td>
</tr>
<tr>
<td>
<table border="0" cellpadding="0" cellspacing="0" style="width:60%;" align="center">
<tr>
<td>
<fieldset class="fieldbdr">
<legend style="font-family:Tahoma; font-size:11pt; font-weight:bold; color:#113EE4;" >Team Information:</legend>
<table id="tblTeam" border="0" cellpadding="0" cellspacing="0" align="center" style="width:80%;">
<tr>
<td style="font-family:Tahoma; font-size:9pt; width:40%;" align="right">
    Team Name:<span style="color:Red; vertical-align:middle;">*</span>&nbsp;</td>
<td style="font-family:Tahoma; font-size:9pt; width:60%;" align="left">
    &nbsp;<asp:TextBox runat="Server" ID="txtTeam" Width="95%"></asp:TextBox>
</td>
</tr>
    <tr>
        <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma">
            Team Leader:&nbsp;(PR)&nbsp;
        </td>
        <td align="left" style="font-size: 9pt; width: 60%; font-family: Tahoma">
            &nbsp;<asp:DropDownList ID="ddlPr" runat="server" Width="95%">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma">
            Team Formator:&nbsp;(FR)&nbsp;
        </td>
        <td align="left" style="font-size: 9pt; width: 60%; font-family: Tahoma">
        &nbsp;<asp:DropDownList id="ddlFr" runat="server" Width="95%">
            </asp:DropDownList>
        </td>
    </tr>
</table>
</fieldset>
</td>
</tr>
<tr>
<td>
<fieldset class="fieldbdr">
<legend style="font-family:Tahoma; font-size:11pt; font-weight:bold; color:#113EE4;" >
    Add QC:&nbsp;</legend>
<table id="tblQC" border="0" cellpadding="0" cellspacing="0" align="center" style="width:80%;">
<tr>
<td style="font-family:Tahoma; font-size:9pt; width:40%;" align="right"></td>
<td style="font-family:Tahoma; font-size:9pt; width:60%;" align="left">
&nbsp;<asp:DropDownList id="ddlQC" runat="server" Width="95%">
      </asp:DropDownList>
</td>
</tr>
    <tr>
        <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma">
        </td>
        <td align="right" style="font-size: 9pt; width: 60%; font-family: Tahoma">
        <asp:Button runat="Server" ID="btnAddTeam" Text="Add" OnClientClick="return onTeamAdd();" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
</fieldset>
</td>
</tr>
    <tr>
        <td>
        <fieldset class="fieldbdr">
        <legend style="font-family:Tahoma; font-size:11pt; font-weight:bold; color:#113EE4;" >Add MT:&nbsp;</legend>
        <table id="tblMT" border="0" cellpadding="0" cellspacing="0" align="center" style="width:80%;">
        <tr>
        <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma">
            Select QC:&nbsp;</td>
        <td align="left" style="font-size: 9pt; width: 60%; font-family: Tahoma">
        &nbsp;<asp:DropDownList id="ddlTeamQc" runat="server" Width="95%">
        </asp:DropDownList></td>
        </tr>
            <tr>
                <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma; height: 14px;">
                Medical Transcription:&nbsp;(MT) 
                </td>
                <td align="left" style="font-size: 9pt; width: 60%; font-family: Tahoma; height: 14px;">
                &nbsp;<asp:DropDownList id="ddlMT" runat="server" Width="95%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="font-size: 9pt; width: 40%; font-family: Tahoma; height: 14px">
                </td>
                <td align="right" style="font-size: 9pt; width: 60%; font-family: Tahoma; height: 14px">
                    <asp:Button runat="server" ID="btnAddMT" Text="Add" />&nbsp;&nbsp;</td>
            </tr>
        </table>
        </fieldset>
        </td>
    </tr>
</table>
<div style="width:100%"></div>
<div align="center" style="background-color:White;">
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
               <div></div>
               <div>
               <asp:Button runat="Server" ID="btnOk" Text="Ok" PostBackUrl="~/BO/teammain.aspx" Width="48px" />
               </div>
</div>
</td>
</tr>
</table>
</asp:Content>

