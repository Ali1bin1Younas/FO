var html = "";
var g_obj = null;
var g_html_folders_list = "";
var g_sch_sel_val = 0;
var g_root_path = "D:/";

$(document).ready(function () {

    $(window).load(function () {
        overloader_wait();
        func_get_folders_list();
        fill_date_ddls();
    });

});

function func_get_folder_structure() {
    $('#folder_structure').empty();
    PageMethods.get_folder_structure(OnSuccess_get_folder_structure);
}

function OnSuccess_get_folder_structure(res) {
    try {
        if (res[0] == "1") {
            make_folder_structure_tree(res[1]);
        } else if (res[0] == "0") {

        } else {
            alert(res[1]);
        }
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function make_folder_structure_tree(res) {
    try {

        if (window.DOMParser) {
            parser = new DOMParser();
            xmlDoc = parser.parseFromString(res, "text/xml");
        }
        else // Internet Explorer
        {
            xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
            xmlDoc.async = false;
            xmlDoc.loadXML(res);
        }

        var xml = $(xmlDoc);
        
        if (xml.find("tree")) {
            var treeXml = xml.find("tree");
            if (treeXml.length > 0) {
                html = make_folder_structure_tree_loop(treeXml, 0, "true", g_root_path);
            }
            $('#folder_structure').append(html);
            hide_overylay_wait();
        }

    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function make_folder_structure_tree_loop(treeXml, fid, chk, root_path) {
    var tree = $('<ul>');
    treeXml.each(function () {
        var temXml = $(this);
        if (fid == temXml.find("parentid").text()) {
            var actual_path = "";
            var fID = temXml.find("fid").text();
            var dis = "";
            var checked = "checked ";
            if (temXml.find("fEnable").text() == "false") { checked = "";}
            if (chk == "false") { dis = 'disabled=""'; }

            // creating base path of the folders
            if (temXml.find("foldername").text().toLowerCase() == "root") {
                actual_path = g_root_path + "/System/www_root/BO";
            } else if(temXml.find("foldername").text().toLowerCase() == "root backup"){
                actual_path = g_root_path;
            }else{
                actual_path = root_path + "/" + temXml.find("foldername").text();
            }

            var folder_html = '<input class="folder_chkbox" ' + dis + ' ' + checked + 'type="checkbox" id=chk_"' + fID + '" onclick="enable_folder(this,' + fID + ')"/>' +
                '<Lable id="img_del_' + fID + '" class="folder_img_del" onclick="view_options(this,' + fID + ',event)">Options</Lable>';
                //'<Lable id="img_del_' + fID + '" class="folder_img_del" onclick="remove_folder(this,' + fID + ')">Remove</Lable>';

            folder_html += ' ' +
                '<img id="img_' + fID + '" title="' + actual_path + '" class="folder_img" src="../icon/window.png"/>' +
                '<Label class="folder_lbl" title="' + actual_path + '">' + temXml.find("foldername").text() + '</Label>';
                //'<select class="folder_sel" ' + dis + ' id="sel_' + fID + '" onChange="add_folder(this,' + fID + ')">' + g_html_folders_list + '</select>';

            //condition to show schedule only for leaf nodes
            if (!(chk_is_parent(treeXml, fID))) {
                folder_html += '<Label class="folder_lbl_sch" title="Click to edit schedule" id="folder_sch_sel" onclick="set_folder_schedule(this,' + fID + ')" >' + temXml.find("scheduleDetail").text() + '</Label>';
            }
            //folder_html += actual_path;

            

            //if (!(chk_is_parent(treeXml, fID))) {
            //    folder_html += '<Lable class="folder_lbl_sch">'+
            //        '<select class="folder_sch_sel" id="folder_sch_sel" onChange="set_folder_schedule(this,' + fID + ')">'+
            //        '<option value="0">Set Schedule</option><option value="1">Daily</option><option value="2">Weekly</option>' +
            //        '<option value="3">Fortnight</option><option value="4">Monthly</option>' +
            //        '</select></Lable>';
            //}
            var span = $('<span style="width:100%;vertical-align:middle;" id=spn_' + fID + '>').html(folder_html).addClass("folder_span").appendTo($('<li>').appendTo(tree).addClass('folder'));
            
            var sub_tree = make_folder_structure_tree_loop(treeXml, fID, temXml.find("fEnable").text(), actual_path);
            span.after(sub_tree);
        }
    });
    return tree;
}

function view_options(objRef, fID, event) {

    var html_options = '<Lable id="img_del_' + fID + '" class="folder_img_del" onclick="remove_folder(this,' + fID + ')">Remove</Lable>' +
        '<select class="folder_sel" id="sel_' + fID + '" onClick="event.stopPropagation();" onChange="add_folder(this,' + fID + ')">' + g_html_folders_list + '</select>';

    var html = '<div class="addedDiv" style="border:1px solid #000;display:none;width:170px;float:left;margin-left:75px;background-color:#9FBEEA;position:absolute;z-index:99999;border-top-left-radius: 7px;border-top-right-radius: 7px;padding:10px;"><div style="text-align:right;"><span style="color:#fff;font-size:11px;width:161px;float:left;">' + html_options + '</span> <span onClick="javascript:this.parentNode.parentNode.style.visibility = &quot;hidden&quot;;" style="text-align:right;float:right;cursor:pointer;color:#ffffff;font-weight:bold;vertical-align:top;">X</span><div>';
    $('#' + objRef.id).after(html);
    $('div.addedDiv').slideDown("slow");

    event.stopPropagation();
}

document.onclick = function () {
    $('.addedDiv').css('visibility','hidden');
}

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Get Folder Schedule        ////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
function set_folder_schedule_window(obj, schType) {
    try {
        overloader_wait();
        g_sch_sel_val = schType;
        PageMethods.get_schedule_by_schType($('#h_fID').val(), schType, onSuccess_set_folder_schedule);
    } catch (e) {
        alert(e.message.toString());
    }
}

function set_folder_schedule(obj, fID) {
    try {
        overloader_wait();
        $('#h_fID').val(fID);
        //g_sch_sel_val = $(obj).val();
        PageMethods.get_schedule(fID, onSuccess_set_folder_schedule);
    } catch (e) {
        alert(e.message.toString());
    }
}

function onSuccess_set_folder_schedule(res) {

    alert(res);
    reset_values_schedule();

    hide_overylay_wait();
    overloader_view_back();
    if (res[0] == "1") {
        set_schedule_vals(res);
        $('#div_set_schedule').css('visibility', 'visible');
    } else {
        view_schedule(res);
        $('#div_set_schedule').css('visibility', 'visible');
        $('#folder_sch_sel').val(0);
    } 
}

function set_schedule_vals(res) {
    $('#btn_sch' + res[2]).addClass("class_selected_sch");
    $('#h_sch_id').val(res[1]);
    $('#h_fID').val(res[6]);
    $('#txt_schTime').val(res[5]);
    $('#txt_schKeepFiles').val(res[8]);

    if (res[7] == "1") {
        $('#chk_schDefault').prop('checked', true);
        $("#chk_schDefault").prop('disabled', true);
    } else {
        $('#chk_schDefault').prop('checked', false);
    }
    if (res[2] == "1") {
        $('#tr_time').css('display', 'block');
        $('#tr_date').css('display', 'none');
    } else {
        var sch_date = res[4].substring(0, 10).toString().trim();

        $('#sel_schDate_day').val(sch_date.split("/")[1].trim());
        $('#sel_schDate_month').val(sch_date.split("/")[0].trim());
        $('#sel_schDate_year').val(parseInt(sch_date.split("/")[2].trim().toString()));
        $('#tr_time').css('display', 'block');
        $('#tr_date').css('display', 'block');
    }
}

function view_schedule(res) {

    $('#btn_sch' + res[2]).addClass("class_selected_sch");

    $('#h_sch_id').val(0);

    if (g_sch_sel_val == 0) {
        g_sch_sel_val = 1;
        $('#btn_sch1').addClass("class_selected_sch");
    } else {
        $('#btn_sch' + g_sch_sel_val).addClass("class_selected_sch");
    }

    if (g_sch_sel_val == 1) {
        $('#tr_time').css('display', 'block');
        $('#tr_date').css('display', 'none');
    } else {
        $('#tr_time').css('display', 'block');
        $('#tr_date').css('display', 'block');
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Set Folder Schedule        ////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

function btn_set_folder_schedule() {
    if ($('#txt_schTime').val() != "") {
        overloader_wait();

        var sch_date;
        if ($('#folder_sch_sel').val() == "1") {
            sch_date = "01/01/1999";
        } else {
            sch_date = $('#sel_schDate_month').val() + "/" + $('#sel_schDate_day').val() + "/" + $('#sel_schDate_year').val();
        }
        PageMethods.save_schedule($('#h_sch_id').val(), $('#txt_schTime').val(), sch_date, g_sch_sel_val, $('#h_fID').val(), $('#txt_schKeepFiles').val(), onSuccess_btn_set_folder_schedule);
    }
}

function onSuccess_btn_set_folder_schedule(res) {
    hide_overylay_wait();
    if (res == "1") {
        btn_hide_overylay_View_back();
    } else if (res == "0") {
        alert("Could not update, please try again later.");
    } else {
        alert(res);
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Set Default Schedule        ///////////////////
///////////////////////////////////////////////////////////////////////////////////////////
function set_schedule_default(obj) {
    try {
        var tbl_sch_main = obj.parentNode.parentNode.parentNode.parentNode;
        var row = tbl_sch_main.getElementsByTagName("tr")[tbl_sch_main.getElementsByTagName("tr").length - 1];
        var inputs = row.getElementsByTagName("input");
        var schID = inputs[0].value;
        var fID = inputs[1].value;
        if (schID != "" && schID != 0) {
            overloader_wait();
            PageMethods.set_schedule_default(schID, obj.checked, fID, onSuccess_Set_schedule_default(obj.checked));
        } else {
            alert("No schedule have been set yet.");
            $('#chk_schDefault').prop('checked', false);
        }
    } catch (e) {
        alert(e.message);
    }
}

function onSuccess_Set_schedule_default(is_chk) {
    return function (res) {
        
        hide_overylay_wait();
        if (res == "1") {
            if (is_chk) {
                $("#chk_schDefault").prop('disabled', true);
            }
        } else if (res == "0") {
            alert("Unexpected error while setting Default, please try again");
        } else {
            alert(res);
        }
        func_get_folder_structure();
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Folder List        ////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
function func_get_folders_list() {
    try {
        PageMethods.get_folders_list(OnSuccess_get_folders_list);
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function OnSuccess_get_folders_list(res) {
    if (res[0] == "1") {
        g_html_folders_list = "";
        $('#folder_sel_root').empty();
        set_g_html_folders_list(res);
        $('#folder_sel_root').append(g_html_folders_list);
        func_get_folder_structure(); // gets folder structure and forms the tree
        hide_overylay_wait();
    }else if(res[0] == "0"){
        hide_overylay_wait();
    }
}

function set_g_html_folders_list(res) {
    g_html_folders_list = '<option>Add Folder</option>';
    for (var i = 1; i < res.length; i++) {
        g_html_folders_list = g_html_folders_list+'<option>' + res[i] + '</option>';
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Add Folder        /////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

function add_folder(obj, parentID) {
    try {
        if ($(obj).val() == "Add Folder") {
            return;
        }
        overloader_wait();
        g_obj = obj;
        var chkbox = true;

        if (parentID != 0) {
            var inputs = g_obj.parentNode.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].className == "folder_chkbox") {
                    chkbox = inputs[i].checked;
                }
            }
        }
        
        PageMethods.add_folder($(obj).val(), parentID, chkbox, OnSuccess_add_folder);
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function OnSuccess_add_folder(res) {
    if (res.trim() == "1") {
        func_get_folder_structure();
    } else if(res == "2") {
        alert("Folder already exists");
    }
    hide_overylay_wait();
}


/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Enable Disable Folders        /////////////////
///////////////////////////////////////////////////////////////////////////////////////////
function enable_folder(obj, fID) {
    try {
        overloader_wait();
        g_obj = obj;
        var ids = get_folders_ids(g_obj);
        if (ids != "") {
            PageMethods.enable_folder(ids, obj.checked, OnSuccess_enable_folder);
        }
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function OnSuccess_enable_folder(res) {
    try {
        if (res == "1") {
            enable_disable_folders();
            hide_overylay_wait();
        } else if (res == "0") {

        } else {
        }
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function enable_disable_folders() {
    var selected_folder = g_obj.parentNode.parentNode;
    var ddls = selected_folder.getElementsByTagName("select");
    var inputs = selected_folder.getElementsByTagName("input");

    for (var i = 1; i < ddls.length; i++) {
        if (ddls.className = "folder_sel") {
            ddls[i].disabled = !(g_obj.checked);
        }
    }
    for (var j = 1; j < inputs.length; j++) {
        if (inputs[j].className = "folder_chkbox") {
            inputs[j].disabled = !(g_obj.checked);
            inputs[j].checked = g_obj.checked;
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Remove Folders        /////////////////
///////////////////////////////////////////////////////////////////////////////////////////
function remove_folder(obj, fID) {
    try {
        var r = confirm("Are you sure you want to delete this folder and all its sub-folders?");
        if (!r) { return; }

        overloader_wait();
        g_obj = obj;
        var ids = get_folders_ids(g_obj);
        if (ids != "") {
            PageMethods.remove_folder(ids, OnSuccess_remove_folder);
        }
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function OnSuccess_remove_folder(res) {
    hide_overylay_wait();
    try {
        if (res == "1") {
            func_get_folder_structure();
        } else if (res == "0") {

        } else {
            alert(res);
        }
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Add Folder Name to DropDown        ////////////
///////////////////////////////////////////////////////////////////////////////////////////

function show_add_folder_name_popup() {
    try {
        overloader_view_back();
        $('#div_add_folder_name').css("visibility", "visible");
    } catch (e) {
        alert(e.message.toString());
    }
}

function btn_add_folder_name() {
    try {
        overloader_wait();
        var folName = $('#txtFolName').val();
        
        PageMethods.add_folder_name(folName, OnSuccess_btn_add_folder_name);
    } catch (e) {
        alert(e.message.toString());
        hide_overylay_wait();
    }
}

function OnSuccess_btn_add_folder_name(res) {
    hide_overylay_wait();
    if (res == "1") {
        func_get_folders_list();
    } else if (res == "2") {
        alert("Folder name already exists.");
    } else {
        alert(res);
    }
    btn_hide_overylay_View_back();
}
/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Reseting Values        ////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////

function reset_values_schedule() {
    g_sch_sel_val = 0;

    $('#txt_schTime').val("");
    $('#txt_schKeepFiles').val("");
    $('#chk_schDefault').prop('checked', false);
    $("#chk_schDefault").prop('disabled', false);

    $('#sel_schDate_day').val(0);
    $('#sel_schDate_month').val(0);
    $('#sel_schDate_year').val(0);

    $('#btn_sch1').removeClass("class_selected_sch");
    $('#btn_sch2').removeClass("class_selected_sch");
    $('#btn_sch3').removeClass("class_selected_sch");
    $('#btn_sch4').removeClass("class_selected_sch");

    $('.folder_sch_sel').val(0);
}

/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////        Helping Functions        //////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
var MainOver = '<div id="overlay" class="overlay" style="height:100%; width:100%;">' +
                    '<div><img id="loading" src="../Icon/ajax-loader.gif"><div>' +
                    '</div>';
var overlay_view_back = '<div id="overlay_view_back" onClick="btn_hide_overylay_View_back();" class="overlay_view_back" style="height:100%; width:100%;">' +
                    '<div><div>' +
                    '</div>';

function overloader_view_back() {
    try {
        var docHeight = $(document).height();
        $("body").append(overlay_view_back);
        $("#overlay_view_back")
        .height(docHeight)
        .css({
            'opacity': 0.4,
            'position': 'absolute',
            'background-color': 'black',
            'width': '100%',
            'z-index': 4000,
            'top':0
        });
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
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
            'z-index': 5000,
            'top':0
        });
    } catch (e) {
        alert(e.message);
        $("#overlay").remove();
    }
}

function hide_overylay_wait() {
    $("#overlay").remove();
}

function btn_hide_overylay_View_back() {
    $('#div_add_folder_name').css("visibility", "hidden");
    $('#div_set_schedule').css("visibility", "hidden");
    
    $('#tr_time').css('display', 'none');
    $('#tr_date').css('display', 'none');

    $('#txtFolName').val("");

    reset_values_schedule();

    $("#overlay_view_back").remove();

    $('#h_fID').val(0);
    $('#h_sch_id').val(0);
}


function get_folders_ids(obj) {
    try {
        var folder_ids = "";
        var selected_folder = g_obj.parentNode.parentNode.parentNode.parentNode.parentNode;
        var ddls = selected_folder.getElementsByTagName("span");

        for (var i = 0; i < ddls.length; i++) {
            if (ddls[i].className == "folder_span") {
                var id = ddls[i].id.split("_");
                if (folder_ids == "") {
                    folder_ids = "'" + id[1] + "'";
                } else {
                    folder_ids = folder_ids + ",'" + id[1] + "'";
                }
            }
        }
        return folder_ids;
    } catch (e) {
        alert(e.message.toString());
    }
}

function chk_is_parent(treeXml, fid) {
    var chk = 0;
    treeXml.each(function () {
        var temXml = $(this);
        if (temXml.find("parentid").text() == fid) {
            chk = 1;
        }
    });
    if (chk == 0) {
        return false;
    } else {
        return true;
    }
}

function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

function fill_date_ddls() {
    //fill days
    var d = new Date();
    var day_html = "";
    for (var i = 1; i < daysInMonth(d.getMonth(), d.getYear()) ; i++) {
        day_html += '<option value="' + i + '">' + i + '</option>';
    }
    $('#sel_schDate_day').append(day_html);
    day_html = '';
    //fill months
    for (var i = 1; i < 13 ; i++) {
        day_html += '<option value="' + i + '">' + i + '</option>';
    }
    $('#sel_schDate_month').append(day_html);
    day_html = '';

    //fill years
    day_html += '<option value="' + d.getFullYear() + '">' + d.getFullYear() + '</option><option value="' + (d.getFullYear() + 1) + '">' + (d.getFullYear() + 1) + '</option>';
    $('#sel_schDate_year').append(day_html);
    day_html = '';
}