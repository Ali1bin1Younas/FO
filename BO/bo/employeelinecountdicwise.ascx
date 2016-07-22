<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeelinecountdicwise.ascx.vb" Inherits="BO_employeelinecountdicwise" %>

<table border ="0" width="100%" cellpadding="0" cellspacing="0" ><tr><td width="5px;"></td><td align="left" width="100%" >

<asp:GridView ID="gridDicWise" runat="server"
 AutoGenerateColumns="false" ShowHeader="true" SkinID="gridviewSkinSmaller">
    <Columns>
        <asp:TemplateField HeaderText="#">
        <ItemTemplate>
        <%#RowCounter%>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="30px" />
        <HeaderStyle HorizontalAlign="center" Width="30px" />
        </asp:TemplateField>
        
        <%--<asp:BoundField DataField="DicDate" HeaderText="Date" />--%>
        
        <asp:TemplateField HeaderText="Dictator Id">
            <ItemTemplate>
                <%#Eval("foId")%>-<%#Eval("drId") %>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="70px" />
            <HeaderStyle HorizontalAlign="center" Width="70px" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Dictator Name">
            <ItemTemplate>
                <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="100px" />
            <HeaderStyle HorizontalAlign="center" Width="100" />
        </asp:TemplateField>
        
        <asp:BoundField DataField="Dictations" HeaderText="Dictations">
        <ItemStyle HorizontalAlign="center" Width="80px" />
        <HeaderStyle HorizontalAlign="center" Width="80px" />
        </asp:BoundField >
        <asp:TemplateField HeaderText="Minutes">
        <ItemTemplate>
        <%#getmin(Eval("Minutes"))%>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="50px" />
        <HeaderStyle HorizontalAlign="center" Width="50px" />
        </asp:TemplateField>
        
        <asp:BoundField DataField="Transcriptions" HeaderText="Transcriptions">
        <ItemStyle HorizontalAlign="center" Width="80px" />
        <HeaderStyle HorizontalAlign="center" Width="80px" />
        </asp:BoundField >
        
        <asp:BoundField DataField="Lines" HeaderText="Lines">
        <ItemStyle HorizontalAlign="center" Width="50px" />
        <HeaderStyle HorizontalAlign="center" Width="50px" />
        </asp:BoundField >
        
        <asp:TemplateField HeaderText="Lines / Minute">
        <ItemTemplate>
        <%#Line_Per_Minutes(Eval("Minutes"), Eval("Lines"))%>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="100px" />
        <HeaderStyle HorizontalAlign="center" Width="" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Lines / Transcription">
        <ItemStyle HorizontalAlign="center" Width="168px" />
        <HeaderStyle HorizontalAlign="center" Width="168px" />
        <ItemTemplate>
        <%#Line_Per_Transcriptions(Eval("Transcriptions"), Eval("Lines"))%>
        </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</td>
</tr>
</table>
