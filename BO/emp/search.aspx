<%@ Page Language="VB" MasterPageFile="~/emp/MasterPage.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="fo_search" Title =" AccessTek [ Back Office - Employee ]" Theme="default" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td style="background-image:url(../images/BOEmpBanner.jpg); width:980; height:66;">
                <table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblCompleteName" runat="server" CssClass="empName"></asp:Label><br style="line-height:10px;"/><br style="line-height:3px;"/><asp:Label ID="heading" runat="server" CssClass="empTitle">Search</asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        <tr>
            <td valign="bottom" align="right">&nbsp;&nbsp;</td>
        </tr>
        
        <tr>
            <td class="tdspace" height="2px;">
            </td>
        </tr>
        
        <tr>
            <td>
                <img src="../images/spacer.gif" height="15">
            </td>
        </tr>
        
        <tr>
            <td>
                <center>
                <table align="center" width="500" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
    
	                        <fieldset>
	                            <legend>
	                                <font class="blackSubtext"><strong> Search Criteria&nbsp;</strong></font>
	                            </legend>
	                        <table width="450" align="center" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="3">
                                        <img src="../images/spacer.gif" height="6">
                                    </td>
	
                                </tr>
                                
                                <tr>
                                    <td class="boProfileright">
                                        <asp:Label ID="Label4" runat="server" ForeColor="ControlText" Height="10px" 
                                                   Text="Keyword"></asp:Label>
                                    </td>
                                    
                                    <td class="divide">
                                    </td>
                                    
                                    <td class="boProfileleft">
                                        <asp:TextBox ID="txtDictation" runat="server" Width="250px" CssClass="fieldbdr"></asp:TextBox>
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="boProfileright">
                                        <asp:Label ID="Label6" runat="server" ForeColor="ControlText" Height="10px" Text="Dictator">
                                        </asp:Label>
                                    </td>
                                    
                                    <td class="divide">
                                    </td>
            
                                    <td class="boProfileleft">
                                        <asp:DropDownList ID="ddlDictator" DataTextField="DictatorName" DataValueField="UId" runat="server" Width="250px" Style="position: notset;" Height="18px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="boProfileright">
                                        <asp:Label ID="Label5" runat="server" Style="position: notset; top: 474px" Text="Account"
                                                   ForeColor="ControlText" Height="10px">
                                        </asp:Label>
                                    </td>
                                        
                                    <td class="divide">
                                    </td>
                                    
                                    <td class="boProfileleft">
                                        <asp:DropDownList ID="ddlLocation" runat="server" Width="250px" Style="position:notset;" Height="18px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>   
                                
                                <tr>
                                    <td class="boProfileright">
                                        <asp:Label ID="Label2" runat="server" Style="position: notset;" Text="From" ForeColor="ControlText" Height="10px">
                                        </asp:Label>
                                    </td>
                                
                                    <td>
                                    </td>
                                    
                                    <td class="boProfileleft" >
                                        <ew:CalendarPopup id="CPFrom" runat="server" Width="150px" style="position: notset; top:0px" Nullable="True">
                                            <cleardatestyle backcolor="#ECECEC" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small" forecolor="Black" />
                                        </ew:CalendarPopup>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="boProfileright">
                                        <asp:Label ID="Label3" runat="server" Style="position: notset;" Text="To" ForeColor="ControlText" Height="10px">
                                        </asp:Label>
                                    </td>
                                    
                                    <td class="divide" style="height: 20px">
                                    </td>
                                    
                                    <td class="boProfileleft">
                                        <ew:CalendarPopup id="CpTo" runat="server" Width="150px" style="position: notset;" Nullable="True">
                                            <cleardatestyle backcolor="#ECECEC" font-names="Verdana,Helvetica,Tahoma,Arial" font-size="XX-Small"  forecolor="Black" />
                                        </ew:CalendarPopup>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="3">
                                        <img src="../images/spacer.gif" height="6">
                                    </td>
                                </tr>
                            </table>

	                    </fieldset>
	                    
                    </td>
                </tr>
            </table>    
            </center>
        </td>
    </tr>
    
    <tr>
        <td>
            <img src="../images/spacer.gif" height="3">
        </td>
    </tr>
    
    <tr>
        <td align="center">
            <asp:Button ID="btnSearch" runat="server" Text="Search" Height="25px" Width="65px" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Reset" Height="25px" Width="65px" />
        </td>
    </tr>
    
    <tr>
        <td>
            <img src="../images/spacer.gif" height="5" />
        </td>
    </tr>
    
    <tr>
        <td>
            <asp:GridView ID="gridTranscription" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" DataKeyNames="traID,foID,drID" GridLines="None">
                <Columns>
                
                    <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridHeadingCenter">
                        <ItemTemplate>
                            <%#iCounter%>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="gridheadingCenter" ItemStyle-CssClass="tdspacingLeft">
                        <ItemTemplate>
                            <%#Eval("foId")%>-<%#Eval("drId") %>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                    </asp:TemplateField>
                    
                    
                    <asp:BoundField DataField="dicActualName" HeaderText="Name" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                        <HeaderStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    
                    
                    <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                        <ItemStyle HorizontalAlign="center" Width="100px" />
                        <ItemTemplate>
                            <%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    
                    
                    <asp:TemplateField HeaderText="Patient Name" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                        <ItemTemplate>
                            <%#getPatientName(Eval("fName"), Eval("lName"))%>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                        <HeaderStyle HorizontalAlign="Left" Width="200px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="Patient No" DataField="traPatientNo" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                        <HeaderStyle HorizontalAlign="Left" Width="200px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Options">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnView" runat="server" ToolTip="View fields" ImageUrl="~/images/transcriptions.gif"/>&nbsp;&nbsp;
                            <a href="../data/<%#Eval("foId")%><%#Eval("drId")%>/transcriptions/<%#Eval("traName")%>" title="View document"><img src="../Icon/Nview.gif" /></a>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="center" Width="70px" />
                        <HeaderStyle HorizontalAlign="center" Width="70px" />
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </td>
    </tr>
   
</table>
</asp:Content>
