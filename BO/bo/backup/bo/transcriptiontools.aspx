<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="transcriptiontools.aspx.vb" Inherits="BO_transcriptiontools" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="searchTools">
            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="font-family:Verdana; font-size:12px;padding-bottom:5px;">
                <tr>
                    <td>Keyword</td>
                    <td>Dictator</td>
                    <td>Account</td>
                    <td>From</td>
                    <td>To</td>
                    <td>Sorting</td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtDictation" runat="server" Width="94px"></asp:TextBox></td>
                    <td><asp:DropDownList ID="ddlDictator" runat="server" DataTextField="DictatorName" DataValueField="UId" Height="18px"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlLocation" runat="server" Height="18px"></asp:DropDownList></td>
                    <td><ew:calendarpopup id="CPFrom" runat="server" nullable="True" Width="72px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><ew:calendarpopup id="CpTo" runat="server" nullable="True" width="72px"><CLEARDATESTYLE forecolor="Black" font-size="XX-Small" font-names="Verdana,Helvetica,Tahoma,Arial" backcolor="#ECECEC" /><SELECTEDDATESTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKENDSTYLE BackColor="LightGray" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><GOTOTODAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><DAYHEADERSTYLE BackColor="Orange" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><MONTHHEADERSTYLE BackColor="Yellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><WEEKDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><HOLIDAYSTYLE BackColor="White" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><OFFMONTHSTYLE BackColor="AntiqueWhite" ForeColor="Gray" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /><TODAYDAYSTYLE BackColor="LightGoldenrodYellow" ForeColor="Black" Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" /></ew:calendarpopup></td>
                    <td><asp:DropDownList ID="ddlSorting" runat="server" Height="18px"></asp:DropDownList></td>
                    <td align="right"><asp:Button ID="btnSearch" runat="server" Text="View" Width="70px" /></td>
                </tr>
            </table>
            </td>
        </tr>
                
        <tr>    
        <td>
    
         <asp:GridView ID="gridTranscription" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" DataKeyNames="dicID,traID" GridLines="None">
        <Columns>

            <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridHeadingCenter">
            <ItemTemplate>
            <%#iCounter%>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="gridheadingCenter" ItemStyle-CssClass="tdspacingLeft">
            <ItemTemplate>
                <%#Eval("drId") %>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
                <HeaderStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>


            <asp:BoundField DataField="dicActualName" HeaderText="Name" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                <ItemStyle HorizontalAlign="Left" Width="180px" />
                <HeaderStyle HorizontalAlign="Left" Width="180px" />
            </asp:BoundField>


            <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="gridHeadingCenter">
                <ItemStyle HorizontalAlign="center" Width="80px" />
                <ItemTemplate>
                    <%#Convert.ToDateTime(Eval("dicDate")).ToString("dd/MM/yyyy")%>
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:BoundField DataField="dicDate" HeaderText="Date" HtmlEncode="false" DataFormatString="{0:dd/MMM/yyyy}" HeaderStyle-CssClass="gridheadingCenter">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                <HeaderStyle HorizontalAlign="Center" Width="80px" />
            </asp:BoundField>--%>
            
            
            
            <asp:TemplateField HeaderText="Patient Name" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                <ItemTemplate>
                <%#getPatientName(Eval("fName"), Eval("lName"))%> / <%#Eval("traPatientNo")%>
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                    <HeaderStyle HorizontalAlign="Left" Width="180px" />
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Account" HeaderStyle-CssClass="gridHeadingCenter">
                <ItemStyle HorizontalAlign="center" Width="170px" />
                <ItemTemplate>
                    <%#Eval("dicAccountName")%>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="MT" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblMt" Text='<%#m_sMTName %>' ForeColor='<%#m_cMTColor %>'/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="90px" />
                <HeaderStyle HorizontalAlign="Left" Width="90px" />
            </asp:TemplateField>
            

            <asp:TemplateField HeaderText="QC" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
            <ItemTemplate>
            
            <asp:Label runat="server" ID="lblQc" Text='<%#m_sQCName %>' ForeColor='<%#m_cQCColor %>'/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="90px" />
                <HeaderStyle HorizontalAlign="Left" Width="90px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PR" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
            <ItemTemplate>
            
            <asp:Label runat="server" ID="lblPr" Text='<%#m_sPRName %>' ForeColor='<%#m_cPRColor %>'/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="90px" />
                <HeaderStyle HorizontalAlign="Left" Width="90px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="FR" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
            <ItemTemplate>
            
            <asp:Label runat="server" ID="lblFr" Text='<%#m_sFRName %>' ForeColor='<%#m_cFRColor %>'/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="90px"/>
                <HeaderStyle HorizontalAlign="Left" Width="90px"/>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Options">
                <ItemStyle HorizontalAlign="center" Width="40px" />
                <HeaderStyle HorizontalAlign="center" Width="40px" />
                <ItemTemplate>
                    <%--<asp:ImageButton ID="btnRe" runat="server" ToolTip="Reverse Transcription" ImageUrl="~/images/reverse.gif"/>--%>
                    <asp:ImageButton ID="btnView" runat="server" ToolTip="View Transcription" ImageUrl="~/images/transcriptions.gif"/>
                    <%--<asp:ImageButton ID="btnDel" runat="server" ToolTip="Delete Transcription" ImageUrl="~/images/deleteTranscription.gif"/>--%>
                </ItemTemplate>
            </asp:TemplateField>

       <%-- <asp:TemplateField HeaderText="Reverse Transcription">
            <ItemTemplate>
           <ItemStyle HorizontalAlign="center" Width="32px" />
                <HeaderStyle HorizontalAlign="Left" Width="32px" />
          <asp:ImageButton ID="btnRe" runat="server" ImageUrl="~/images/reverse.gif"/>
         
          
          </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Delete Transcription">
            <ItemTemplate>
            
           <asp:ImageButton ID="btnDel" runat="server" ImageUrl="~/images/deleteTranscription.gif"/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="32px" />
                <HeaderStyle HorizontalAlign="Left" Width="32px" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="View Transcription">
            <ItemTemplate>
            
           <asp:ImageButton ID="btnView" runat="server" ImageUrl="~/images/transcriptions.gif"/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="32px" />
                <HeaderStyle HorizontalAlign="Left" Width="32px" />
            </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Replace Transcription">
            <ItemTemplate>
            
           <asp:ImageButton ID="btnReplace" runat="server" ImageUrl="~/images/replaceTranscription.gif"/>
            
            </ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="32px" />
                <HeaderStyle HorizontalAlign="Left" Width="32px" />
            </asp:TemplateField>--%>
            
        </Columns>
    </asp:GridView>
    </td>
    </tr>
    </table>
</asp:Content>

