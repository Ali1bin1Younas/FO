<%@ Page Language="VB"  MasterPageFile ="~/BO/master.master" AutoEventWireup="false" CodeFile="DeleteUtilitySettings2.aspx.vb" Inherits="DeleteUtilitySettings2" Title ="AccessTek [ Back Office - Admin ]" Theme="BOboLayout" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="js/DeleteUtilitySettings2.js"></script>
     <style type="text/css">

         #folder_structure {
             list-style-type:none;
         }
         .folder {
             padding-left:50px;
             padding-top:20px;
             list-style-type:none;
         }
        .folder img, .folder > span, .folder select, .folder > ul,.folder_chkbox[type="checkbox"] {
            float:left;
        }
        .folder ul {
             padding-bottom:20px;
        }
         .folder_img {
             padding-right:10px;
         }
        .folder_img_del {
            cursor:pointer;
        }
         .folder_sel {
             padding-left:10px;
             padding-right:10px;
             padding-top:3px;
             margin-left:10px;
         }
         .folder_sel > option {
             padding-left:10px;
             padding-right:10px;
             padding-top:3px;
             padding-bottom:5px;
         }
         .folder_sel_root {
             padding-left:10px;
             padding-right:10px;
             padding-top:3px;
             margin-left:10px;
         }
        .folder_sel_root > option {
            padding-left:10px;
            padding-right:10px;
            padding-top:3px;
            padding-bottom:5px;
        }
         .folder_chkbox {
             margin-right:10px;
             margin-bottom:10px;
         }
         .folder_lbl_sch {
            padding-left:10px;
            font-weight:bold;
         }
         .folder_sch_sel {
             padding-left:10px;
             padding-right:10px;
             padding-top:3px;
             margin-left:10px;
         }
         .folder_sch_sel > option {
             padding-left:10px;
             padding-right:10px;
             padding-top:3px;
             padding-bottom:5px;
         }
         .folder_lbl {
             float:left;
             min-width:100px;
         }
         #loading {
            left: 50%;
            position: fixed;
            top: 50%;
        }

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
    @media screen and (-webkit-min-device-pixel-ratio:0)
    {
    .tblLogs{width:475px !important;}
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
                    <div style="padding-bottom:10px;">
                        <label>Add folder Name:</label>
                        <input type="button" value="Add Folder Name" title="Add New Folder to Dropdown" onclick="show_add_folder_name_popup();"/>
                    </div>

                    <div>
                        <label>Add Root:</label>
                        <select id="folder_sel_root" class="folder_sel_root" onchange="add_folder(this,0)"></select>
                    </div>

                    <div id="folder_structure">
                    </div>
                </fieldset>
      
            </td>
        </tr> 
    </table>
    
    <div onkeydown="return (event.keyCode!=13)" id="div_add_folder_name" style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:999999999999;" class="divTbl">
        <form action="GET" id="change_minutes_form" onsubmit="return (event.keyCode!=13);">
        <table id="Table1" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Add Folder Name</h2>
                </th>
            </tr>

            <tr class="leftAlign" style="line-height:20px;font-size:14px;">
                <td colspan="2" class="leftAlignSpace" style="padding-bottom:10px;">
                    Folder Name: <input type="text" id="txtFolName" style="width:150px; height:25px;"/> 
                </td>
            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    <input type="button" onClick="btn_add_folder_name();" id="btnChangedDicMintes" value="Save" style="width:80px;"/>
                </td>
            </tr>

            <tr><td colspan="2"  style="background-color:#BAD6FF;height:10px; width:270px;"><label style="margin-top:10px;"></label></td></tr>

        </table>
    </form>
    </div>

    <div onkeydown="return (event.keyCode!=13)" id="div_set_schedule" style="width:350px; position:fixed; background-color:transparent; left:35%; top:28%; visibility:hidden; z-index:4500;" class="divTbl">
        <form action="GET" id="Form1" onsubmit="return (event.keyCode!=13);">
        <table id="Table2" class="tblLogMain" style="vertical-align:top; background-color:white; color:#1b2432; font-size:12px; height:auto; width:100%;" cellpadding="0" cellspacing="0">
            <tr>
                <th colspan="4">
                    <h2>Set Folder Schedule</h2>
                </th>
            </tr>

            <tr id="tr_time" class="leftAlign" style="line-height:20px;font-size:12px;display:none;">
                <td class="leftAlignSpace" style="padding-bottom:10px;padding-top:5px;">
                    Time: <input type="text" id="txt_schTime" style="width:100px; height:25px;"/>
                </td>
                <td>
                    Set As Default: <input type="checkbox" id="chk_schDefault" onclick="set_schedule_default(this)"/>
                </td>
            </tr>

            <tr id="tr_date" class="leftAlign" style="line-height:20px;font-size:12px;display:none;">
                <td colspan="2" class="leftAlignSpace" style="padding-bottom:10px;">
                    Date: <select id="sel_schDate_day" style="width:40px; height:25px;"></select>
                          <select id="sel_schDate_month" style="width:40px; height:25px;"></select>
                          <select id="sel_schDate_year" style="width:60px; height:25px;"></select>
                </td>
            </tr>

            <tr style="height:1px; width:100%; background-color:black;">
                <td colspan="2"></td>
            </tr>

            <tr id="tr1" class="leftAlign" style="line-height:20px;font-size:12px;">
                <td colspan="2" class="leftAlignSpace" style="padding-bottom:10px;padding-top:5px;">
                    Keep Files for <input type="text" id="txt_schKeepFiles" style="width:50px; height:25px;"/> Days.
                </td>
            </tr>

            <tr style="height:1px; width:100%; background-color:black;">
                <td colspan="2"></td>
            </tr>

            <tr style="line-height:20px;font-size:14px; text-align:center;">
                <td colspan="2" class="leftAlignSpace dic_min_last_row">
                    <input type="hidden" id="h_sch_id" value="0"/>
                    <input type="hidden" id="h_fID" value="0"/>
                    <input type="button" onClick="btn_set_folder_schedule();" id="Button1" value="Save" style="width:80px;"/>
                </td>
            </tr>


            <tr><td colspan="2"  style="background-color:#BAD6FF;height:10px; width:270px;"><label style="margin-top:10px;"></label></td></tr>

        </table>
    </form>
    </div>
    <input id="hchkboxid" type="hidden" runat="server" value="" />
 
</asp:Content>



