<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="DeleteUtilitySettings.aspx.vb" Inherits="DeleteUtilitySettings " Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     <style type="text/css">

         .tblLogMain td table th
        {
            background-color: #D7D7D7;
            color: black;
            font-family: Verdana;
            vertical-align: middle;
            height:30px;
            font-size:13px;
            border:none;
            margin:0px;
            padding:0px;
            border-collapse: separate;
        }
         
         ctl00_ContentPlaceHolder1_CPMain_div
         {
              z-index:999999;
         }

        .tblLogMain th
        {
            text-align:left;
            font-size:10px;
            font-family: Verdana;
            font-weight: bold;
            height:50px;

            background-color: #353c47;
            border-top-left-radius: 7px;
            border-top-right-radius: 7px;
            color: white;
            padding: 10px;
        }
    .tblLogMain {
        background-color: #353c47;
        border-top-left-radius: 7px;
        border-top-right-radius: 7px;
    }



    .tblLogMain td { 
       padding-left: 10px;
    }
    .tblLogs {
    border-collapse: separate;
    border:none;
    }
    .tblLogs
        {
            display:block;
            height:auto;
            width:100%;
            background-color:white;
            padding-left: -10px;
            }
            
        .tblLogs td
        {
            background-color: #ECECEC;
            color: black;
            font-family: Verdana;
            line-height: 100%;
            vertical-align: middle;
            margin:0px;
            padding:0px;
            border:none;
        }
        @media screen and (-webkit-min-device-pixel-ratio:0)
    {
    .tblLogs{width:475px !important;}
    }
        .dic_min_last_row {
        padding-bottom:20px;
    }

    </style>  
    <script language="javascript" type="text/javascript">

        function enabledropdown(obj, is_chk) {
            var row = obj.parentNode.parentNode;
            var ddl = row.getElementsByTagName("select")[0];
            //var isDisabled = $(ddl).is(':disabled');

            if (is_chk) {
                $(ddl).removeAttr("disabled");
            } else {
                $(ddl).attr("disabled", "disabled");
            }
        };

        function onChange_ddl(obj, val) {
            try {
                //var selectedText = $(obj).find("option:selected").text();
                var selectedValue = $(obj).val();
                $('#<%=hchkboxid.ClientID%>').val("");
                $('#<%=hchkboxid.ClientID%>').val(val);
                //alert("Selected Text: " + selectedText + " Value: " + selectedValue);
                PageMethods.get_schedule(val, selectedValue, OnSuccess_get_schedule);
            } catch (e) {
                alert(e.message);
            }
        }

        function handlerFunction(chk, schVals) {
            overloader_view();
            if (chk == "1") {
                if (schVals[0] != "0") {
                    $('#ctl00_ContentPlaceHolder1_h_schID_timer1').val(schVals[1]);
                    $('#ctl00_ContentPlaceHolder1_txtdailytimer').val(schVals[5]);
                }
                $('#divtimer1').css('visibility', 'visible');
            } else if (chk == "2") {
                $('#divtimer2').css('visibility', 'visible');
            } else if (chk == "3") {
                $('#divtimer3').css('visibility', 'visible');
            } else if (chk == "4") {
                $('#divtimer4').css('visibility', 'visible');
            }
        }

        function OnSuccess_get_schedule(res) {

            if (res[2] == "1") {
                if (res[0] == "1") {
                    handlerFunction(1, res);
                } else {
                    handlerFunction(1, 0);
                }
            } else if (res[2] == "2") {
                handlerFunction(2);
            } else if (res[2] == "3") {
                handlerFunction(3);
            } else if (res[2] == "4") {
                handlerFunction(4);
            }
        }

        ////////////////////////////////////////////////////
        /////////////////////////   Overlay   /////////////
        //////////////////////////////////////////////////
        var overlay_view = '<div id="overlay" onClick="btn_hide_overylay_view();" class="overlay" style="height:100%; width:100%;">' +
                    '<div><div>' +
                    '</div>';

        function btn_hide_overylay_view() {
            $('#divtimer1').css('visibility', 'hidden');
            $('#divtimer2').css('visibility', 'hidden');
            $('#divtimer3').css('visibility', 'hidden');
            $('#divtimer4').css('visibility', 'hidden');

            $("#overlay").remove();
        }

        function overloader_view() {
            try {
                var docHeight = $(document).height();
                $(".mainBody").append(overlay_view);
                $("#overlay")
                .height(docHeight)
                .css({
                    'opacity': 0.4,
                    'position': 'absolute',
                    'background-color': 'black',
                    'width': '100%',
                    'z-index': 9999,
                    'top': 0
                });
            } catch (e) {
                alert(e.message);
                $("#overlay").remove();
            }
        }

    </script>
    <asp:ScriptManager runat="server" EnablePageMethods="true">
    </asp:ScriptManager>

 <table width="100%" border="0" cellspacing="0" cellpadding="0">
    
    <tr>
    <td align="left">
        <fieldset style="width:100%; float:left;">
                    <legend style="font:bold 8pt Verdana; color:#239CC7;">Folder Information</legend>
                    <table id="tbl_login_info" border="0" cellpadding="0" cellspacing="5" style="width:70%;" align="center">
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img20" > Data Folder  </td>
                            
                            <td style="width:15%;">
                                
                        </tr>
                        
                        <tr>
                            
                            <td style="width:15%;" align="center"><img src="../Icon/window.png" style="display:none" alt="Direction Arrow" id="img2" > Dictator Folder </td>
                            
                            <td style="width:15%;"></td>
                        </tr>
                        <tr>
                             
                            <td style="width:15%;" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img1" >
                                &nbsp;&nbsp;
                                <input id="checkbox1" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked);  />&nbsp;&nbsp;<img src="../Icon/window.png" alt="Direction Arrow" id="img4" >&nbsp;Dications Folder   </td>
                            
                            <td style="width:15%" align="left">
                                <select id="ddl1" onchange="onChange_ddl(this,4)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                        </tr>         
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img3" >
                                &nbsp;&nbsp;
                                <input id="Checkbox2" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img5" >&nbsp;Transcriptions Folder </td> 
                            <td style="width:15%">
                                <select id="Select1" onchange="onChange_ddl(this,5)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img6" >
                                &nbsp;&nbsp;
                                <input id="Checkbox3" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked);  />&nbsp;&nbsp;<img src="../Icon/window.png" alt="Direction Arrow" id="img7" >&nbsp;Comparison Folder </td>
                            
                            <td style="width:15%;">
                                <select id="Select2" onchange="onChange_ddl(this,6)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                           
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img8" >
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img9" >&nbsp;Downloads Folder </td>
                            
                            <td style="width:15%;"></td>
                            
                        </tr>
                        <tr>
                             
                            <td style="width:15%;" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img21" >
                                &nbsp;&nbsp;
                                <input id="Checkbox4" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img22" >&nbsp;Dications Folder   </td>
                            
                            <td style="width:15%">
                                <select id="Select3" onchange="onChange_ddl(this,8)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                        </tr> 

                        
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img10" >
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img11" >&nbsp;Upload Folder </td>
                            
                            <td style="width:15%;"></td>
                            
                        </tr>

                        <tr>
                             
                            <td style="width:15%;" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img23" >
                                &nbsp;&nbsp;
                                <input id="Checkbox5" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked);  />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img24" >&nbsp;Transcriptions Folder   </td>
                            
                            <td style="width:15%">
                                <select id="Select4" onchange="onChange_ddl(this,14)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>    
                            </td>
                        </tr> 
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img12" >
                                &nbsp;&nbsp;
                                <input id="Checkbox6" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img13" >&nbsp;MT Folder </td>
                            
                            <td style="width:15%;">
                                <select id="Select5" onchange="onChange_ddl(this,10)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                            
                        </tr>


                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img14" >
                                &nbsp;&nbsp;
                                <input id="Checkbox7" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img15" >&nbsp;QC Folder </td>
                           
                            <td style="width:15%;">
                                <select id="Select6" onchange="onChange_ddl(this,11)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img16" >
                                &nbsp;&nbsp;
                                <input id="Checkbox8" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img17" >&nbsp;PR Folder </td>
                            
                            <td style="width:15%;">
                                <select id="Select7" onchange="onChange_ddl(this,12)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                            
                        </tr>
                        <tr>
                            
                            <td style="width:15%;" align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../Icon/arrow.png" alt="Direction Arrow" id="img18" >
                                &nbsp;&nbsp;
                                <input id="Checkbox9" type="checkbox" runat="server" class="chk" onclick=enabledropdown(this,this.checked); />
                                &nbsp;&nbsp;
                                <img src="../Icon/window.png" alt="Direction Arrow" id="img19" >&nbsp;FR Folder </td>
                            
                            <td style="width:15%;">
                                <select id="Select8" onchange="onChange_ddl(this,13)" disabled="disabled">
                                    <option value="">Select</option>
                                    <option value="1">Daily</option>
                                    <option value="2">Weekly</option>
                                    <option value="3">FortNight</option>
                                    <option value="4">Monthly</option>
                                </select>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="width:15%;" ></td>
                            <td style="width:15%;" ></td>
                        </tr>
                    </table>
            </fieldset>
      
 </td>
</tr>
          
</table>

     <div  style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divtimer1">
        
        <table id="Table1" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2">
                    <h2>Enter Schedule Daily Time Details</h2>
                </th>
            </tr>
            
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td class="leftAlignSpace" style="padding-bottom:10px;">Time in hours:</td><td><asp:TextBox ID="txtdailytimer" runat="server"></asp:TextBox></td>
            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    <input type="hidden" id="h_schID_timer1" runat="server"/>
                    <asp:Button ID="btndailytimer" OnClick="SaveDailyTimer" runat="server" Text="Save" Width="60px" />
                </td>
            </tr>

        </table>
    
    </div>

    <div style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divtimer2">
        
        <table id="Table2" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2">
                    <h2>Enter Schedule Weekly Time Details</h2>
                </th>
            </tr>
             <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">Select Day:</td><td><asp:DropDownList runat="server" ID="ddlweekly">
                    <asp:ListItem Text="Monday" value="Monday" />
                    <asp:ListItem Text="Tuesday" value="Tuesday" />
                    <asp:ListItem Text="Wednesday" value="Wednesday" />
                    <asp:ListItem Text="Thirsday" value="Thirsday" />
                    <asp:ListItem Text="Friday" value="Firday" />
                    <asp:ListItem Text="Satruday" value="Saturday" />
                    <asp:ListItem Text="Sunday" value="Sunday" />

                </asp:DropDownList></td>
            </tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">Time:</td><td><asp:textbox ID="Textbox2" runat="server"></asp:textbox></td>
            </tr>


            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                   
                    <asp:Button ID="btnweeklytimer" OnClick="SaveweeklyTimer" runat="server" Text="Save" Width="60px" />
                </td>
            </tr>

            

        </table>
    
    </div>

    <div  style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divtimer3">
     
        <table id="Table3" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2">
                    <h2>Enter Schedule Fortnight Time Details</h2>
                </th>
            </tr>

                         <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">Select Day:</td><td><asp:DropDownList runat="server" ID="ddlfortnight">
                    <asp:ListItem Text="Monday" value="Monday" />
                    <asp:ListItem Text="Tuesday" value="Tuesday" />
                    <asp:ListItem Text="Wednesday" value="Wednesday" />
                    <asp:ListItem Text="Thirsday" value="Thirsday" />
                    <asp:ListItem Text="Friday" value="Firday" />
                    <asp:ListItem Text="Satruday" value="Saturday" />
                    <asp:ListItem Text="Sunday" value="Sunday" />

                </asp:DropDownList></td>
            </tr>

            
            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">time:</td><td><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td>

            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    
                    <asp:Button ID="btnfortnighttimer" OnClick="SavefornightTimer" runat="server" Text="Save"  Width="60px" />
                </td>
            </tr>

        </table>
    
    </div>

    <div  style="width:350px; position:fixed; background-color:transparent;left:35%; top:28%; visibility:hidden; z-index:999999;" class="divTbl" id="divtimer4">
       
        <table id="Table4" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="2">
                    <h2>Enter Schedule Monthly Time Details</h2>
                </th>
            </tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">
                    Time: 
                </td>
                <td>
                    <asp:TextBox ID="TxtBox8" runat="server"></asp:TextBox></td>
                    <%--<ew:CalendarPopup ID="CPMain" runat="server" AutoPostBack="True" SelectedDate="2006-12-13"  style="position:fixed; right:528px;" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px">
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial"  font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>--%>
                
            </tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td  class="leftAlignSpace" style="padding-bottom:10px;">
                     Date: 
                </td>
                <td>
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td>
                    <%--<ew:CalendarPopup ID="CPMain" runat="server" AutoPostBack="True" SelectedDate="2006-12-13"  style="position:fixed; right:528px;" VisibleDate="2006-12-13" CalendarLocation="Bottom" Width="103px">
                    <cleardatestyle backcolor="White" font-names="Verdana,Helvetica,Tahoma,Arial"  font-size="XX-Small" forecolor="Black" />
                </ew:CalendarPopup>--%>
                
            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    
                    <asp:Button ID="btnmonthlytimer" OnClick="SaveMonthlyTimer" runat="server" Text="Save" Width="60px" />
                </td>
            </tr>

            

        </table>
  
    </div>

    
    <input id="hchkboxid" type="hidden" runat="server" value="" />
 
</asp:Content>



