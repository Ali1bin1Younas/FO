<%@ Page Language="VB" MasterPageFile="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatorbilling.aspx.vb" Inherits="FO_dictatorbilling" Theme="BOboLayout" Title ="AccessTek [ Back Office - Admin ]" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="980" border="0" cellspacing="0" cellpadding="0">
    <tr>
            <td style ="background-image:url(../images/BOadminHeadingBG.jpg); width :980; height :66;"><table width="980" height="66" align="right" border="0" cellpadding="0" cellspacing="0">
            <tr><td align="left" class="headingLrg"><br style="line-height:20px;"/><strong>Billing Options</strong></td></tr>
         </table></td>
    </tr>
     <tr>
         <td class="upload">
             <asp:DropDownList ID="cmbFoLoad" runat="server" DataTextField="foName" DataValueField="foID" Width="200" AutoPostBack="True">
             </asp:DropDownList>&nbsp;</td>
     </tr>
   <tr><td>
    <asp:GridView ID="gridbilling" runat="server"  SkinId="gridviewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="#">
                
                <ItemTemplate>
                  <%#getcounter()%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="drID" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Name">
               
                <ItemTemplate>
                   <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>&nbsp;<%#Eval("drLastName")%> 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="left" CssClass="tdspacingLeft" Width="440" />
                <HeaderStyle HorizontalAlign="left" CssClass="tdspacingLeft" Width="440" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Rate">
                
                <ItemTemplate>
                    <asp:TextBox ID="Rate" Text='<%# Bind("drRate") %>' runat="server" CssClass="fieldBdr" Width="90" Height="20"></asp:TextBox>
                   <%-- <asp:Label ID="Label7" runat="server" Text='<%# Bind("cliRate") %>'></asp:Label>--%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110"/>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CHR/Line">
               
                <ItemTemplate>
                 <asp:TextBox ID="Line" runat="server" Text='<%# Bind("drCharacterPerLine") %>' CssClass="fieldBdr" Width="90" Height="20"></asp:TextBox>
               </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110"/>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="110"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Space">
               
                <ItemTemplate>
                 <asp:CheckBox ID="Space"  Checked='<%# Bind("drCountSpace") %>' runat="server" />
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bold">
                <EditItemTemplate>
                   
                    
                </EditItemTemplate>
                <ItemTemplate>
                 <asp:CheckBox ID="Bold"  Checked='<%# Bind("drCountBold") %>' runat="server" />
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Italic">
               
                <ItemTemplate>
                <asp:CheckBox ID="Italic"  Checked='<%# Bind("drCountItalic") %>' runat="server" />
                 
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="U-Line">
               
                <ItemTemplate>
                <asp:CheckBox ID="Underline"  Checked='<%# Bind("drCountUnderLine") %>' runat="server" />
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Update">
                
                <ItemTemplate>
                    <%--<asp:Button ID="Submit" runat="server" Text="Update"  CommandName="Submit" Width="60" Height="22" />--%>
                    <asp:ImageButton ID="Submit" runat="server"  ImageUrl="~/images/update.gif" CommandName="Submit"/>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50"/>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </td></tr>
    <tr><td classs="tdspace" height="2"></td></tr>
    <tr><td><img src="../images/spacer.gif" height="5" /></td></tr>
    </table>
    
</asp:Content>

