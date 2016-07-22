<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="dictatormain.aspx.vb" Inherits="dictatormain" Theme="BOboLayout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
      
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
   
    
    <tr>
    <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img src="../images/spacer.gif" height="22" /></td>
        </tr>
      </table></td>
  </tr>
    <tr>
    <td>
        <asp:GridView ID="grdDictator" SkinId="gridviewSkin" runat="server" AutoGenerateColumns="False" OnRowCreated="grdDictator_RowCreated" GridLines="None" DataKeyNames="drDifficulty" PageSize="1">
            <%--<FooterStyle BackColor="#CCCCCC" ForeColor="Black" />--%>
            <Columns>
                <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gridheadingCenter">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemTemplate>
                    <%#getCounter()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="gridheadingCenter" ItemStyle-CssClass="tdspacingLeft">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("drID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate>
                    <%#Eval("foID")%>-<%#Eval("drID")%><%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("drID") %>'></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:BoundField DataField="foID" HeaderText="FO ID">
                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" />
                </asp:BoundField>--%>

                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="gridHeadingCenter">
                    <ItemStyle HorizontalAlign="Center" Width="125px" VerticalAlign="Middle"/>
                    <HeaderStyle HorizontalAlign="Center" Width="125px" VerticalAlign="Middle"/>
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Difficulty Level"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="Difficult"  Font-Bold="false"></asp:Label>
                        -
                        <asp:Label ID="Label4" runat="server" Text="Medium"  Font-Bold="false"></asp:Label>
                        -
                        <asp:Label ID="Label5" runat="server" Text="Easy" Font-Bold="false"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a style="cursor:pointer;" title="Difficult" OnClick="set_dificulty_chk('D','chkD',this,this.childNodes[0].checked,<%#Eval("drID") %>);" ><input type="checkbox" class="chkD" runat="server" id="chkD" Enabled="" /></a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text="       "></asp:Label>
                        <a style="cursor:pointer;" title="Medium" OnClick="set_dificulty_chk('M','chkM',this,this.childNodes[0].checked,<%#Eval("drID") %>);" ><input type="checkbox" class="chkM" runat="server" id="chkM" Enabled="" /></a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="        "></asp:Label>
                        <a style="cursor:pointer;margin-left:5px;" title="Easy" OnClick="set_dificulty_chk('E','chkE',this,this.childNodes[0].checked,<%#Eval("drID") %>);" ><input type="checkbox" class="chkE" runat="server" id="chkE" Enabled="" /></a>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                    <ItemStyle HorizontalAlign="Left" Width="340px" />
                    <HeaderStyle HorizontalAlign="Left" Width="340px" />
                    <ItemTemplate>
                        <%#Eval("drLastName")%>,&nbsp;<%#Eval("drFirstName")%>&nbsp;<%#Eval("drMiddleName")%>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Specialty" HeaderStyle-CssClass="gridheadingLeft" ItemStyle-CssClass="tdspacingLeft">
                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                    <HeaderStyle HorizontalAlign="Left" Width="240px" />
                    <ItemTemplate>
                        <%#Eval("drSpecialty")%>
                    </ItemTemplate>
                </asp:TemplateField>

               <%-- <asp:BoundField DataField="drCellNo" HeaderText="Phone No">
                    <ItemStyle HorizontalAlign="Left" Width="400px" />
                    <HeaderStyle HorizontalAlign="Left" Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="drEmail" HeaderText="Email">
                    <ItemStyle HorizontalAlign="Left" Width="600px" />
                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                </asp:BoundField>--%>

                <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="gridHeadingCenter">
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    <ItemTemplate>
                        <a href='dictatorview.aspx?drID=<%#DataBinder.Eval(Container.DataItem,"drID")%>&foID=<%#Eval("foID") %>' title="view">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Icon/Nview.gif" /></a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            
        </asp:GridView>
        
 </td>
</tr>
<tr><td class="tdspace"></td></tr> 
<%--<tr><td><img src="../images/spacer.gif" height="10" /></td></tr>--%>           
     </table>
<style type="text/css">
    #overlay
    {
        position: absolute;
        left: 0;
        top: 0;
        bottom: 0;
        right: 0;
        background: #fff;
        opacity: 0.8;
        filter: alpha(opacity=80);
    }
        
    #loading {
        left: 50%;
        position: fixed;
        top: 50%;
    }
</style>
 <script type="text/javascript">

     var row_td = null;
     var chk_id = null;
     var g_drID = null;
     var g_isChk = false;
     var MainOver = '<div id="overlay" class="overlay" style="height:100%; width:100%;">' +
                    '<div><img id="loading" src="../Icon/ajax-loader.gif"><div>' +
                    '</div>';

     function set_dificulty_chk(dif,id, objRef, id_chk, drID) {
         try {
             overloader_wait();
             row_td = objRef.parentNode;
             chk_id = id;
             g_drID = drID;
             g_isChk = id_chk;
             if (id_chk == true) {
                 PageMethods.set_difficulty(dif, id_chk, drID, OnSuccess_set_dificulty_chk);
             } else { 
                 PageMethods.set_difficulty('', id_chk, drID, OnSuccess_set_dificulty_chk);
             }
         } catch (e) { alert(e.message); }
     }

     function OnSuccess_set_dificulty_chk(res) {
         try {
             $("#overlay").remove();
             if (res.trim() == "1") {
                 var inputs = row_td.getElementsByTagName("input");

                 for (var i = 0; i < inputs.length; i++) {
                     if (inputs[i].type == "checkbox" && inputs[i].className != chk_id) {
                         inputs[i].disabled = (g_isChk);
                     }
                 }
             } else {
                 alert(res);
             }
         } catch (e) { alert(e.message); }
     }

     function overloader_wait() {
         try {
             var docHeight = $(document).height();
             $("body").append(MainOver);
             $("#overlay")
             .height(docHeight)
             .css({
                 'opacity': 0.8,
                 'position': 'absolute',
                 'background-color': 'white',
                 'width': '100%',
                 'z-index': 5000
             });
         } catch (e) {
             alert(e.message);
             $("#overlay").remove();
         }
     }
 </script>
</asp:Content>



