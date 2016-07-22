<%@ Control Language="VB" AutoEventWireup="false" CodeFile="employeeworkloaddetail.ascx.vb" Inherits="BO_employeedictator" %>
<script type="text/javascript">
        
   function onClick_btnViewTem(btnID, drID, foID, ddlselected){
        
            
    var row = btnID.parentNode.parentNode;
    var GridView = row.parentNode;
    var inputList = GridView.getElementsByTagName("select")
    
//  var dropdowns = new Array(); //Create array to hold all the dropdown lists.   
//  var gridview = document.getElementById('<%=gvDictator.ClientID %>'); //GridView1 is the id of ur gridview.   
//  dropdowns = gridview.getElementsByTagName('select'); //Get all dropdown lists contained in GridView1.   
        
    var ids = inputList[ddlselected - 1].value.split(",");
    var temID = ids[0];
    var drIdChk = ids[1];
        
    if(temID != ""){
        window.open("viewTemplate.aspx?temid=" + temID + "&drID=" + drID + "&foID=" + foID, "_blank");
        ddlTemp.selectedIndex = 0;
    }else{
        alert("Please select a Template first.....");
    }
        
    
   }
</script>

<table border ="0" width="100%" cellpadding="0" cellspacing="0">

<tr><td style="width:20px; height: 100%;" ></td><td align="right" style=" vertical-align:top; height:100%; width:100%;">
<asp:GridView ID="gvDictator" runat="server" AutoGenerateColumns="False" SkinId="gridviewSkinSmall" ShowHeader="False">
    <Columns>
        <asp:TemplateField HeaderText="#">
            <ItemTemplate>
                <%#iCounter %>
            </ItemTemplate>
            <ItemStyle Width="68px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="68px" CssClass="gridHeadingCenter" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Dr. ID">
            <ItemTemplate>
                <%#Eval("foID")%>-<%#Eval("drID") %>
            </ItemTemplate>
            <ItemStyle Width="70px" CssClass="tdspacingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
            <HeaderStyle Width="70px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <%#Eval("drLastName") %>, <%#Eval("drFirstName") %> <%#Eval("drMiddleName") %>
            </ItemTemplate>
            <ItemStyle Width="168px" CssClass="tdspacingLeft" HorizontalAlign="Left" />
            <HeaderStyle Width="168px" CssClass="gridHeadingLeft" HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Total">
            <ItemTemplate>
                <%#GF.GetMin(Eval("dicLength")) %>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DicTations"), "000") %>]
            </ItemTemplate>
            <ItemStyle Width="129px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="129px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Done">
            <ItemTemplate>
                <%#GF.GetMin(Eval("DonedicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("DoneDictations"), "000") %>]
            </ItemTemplate>
            <ItemStyle Width="129px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="129px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Done">
            <ItemTemplate>
                <%#GF.GetMin(Eval("availdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("availDictations"), "000")%>]
            </ItemTemplate>
            <ItemStyle Width="129px" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle Width="129px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"/>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Outstanding">
            <ItemTemplate>
                <%#GF.GetMin(Eval("OutdicLength"))%>&nbsp;&nbsp;&nbsp;&nbsp;[<%#Format(Eval("OutDicTations"),"000") %>]
            </ItemTemplate>
            <HeaderStyle Width="129px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Width="129px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
                <asp:DropDownList CssClass="select-style" ID="ddlTem" runat="server" onchange="IndexChange(this);" Width="170px">
                </asp:DropDownList>
                
                <a href="#" style="width:50px; background-color:#BAD6FF; color:Black; text-decoration:none; padding: 0 7px 0 6px; border: 0.5px solid black;" onclick="onClick_btnViewTem(this, <%#Eval("drID") %>, <%#Eval("foID") %>, <%#iCounter %>)">View</a>
            </ItemTemplate>
            <HeaderStyle Width="235px" CssClass="gridHeadingCenter" Font-Bold="True" HorizontalAlign="center" VerticalAlign="Middle" />
            <ItemStyle Width="235px" HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
</td></tr></table>
