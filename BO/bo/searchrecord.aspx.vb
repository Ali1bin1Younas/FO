Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class FO_searchrecord
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblCompleteName.Text = Session("CompletePrefix") + "  " + Session("CompleteFirstNAme") + "   " + Session("CompleteLastName")
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Dim query As String
        Session("cint") = 0
        Session("cint1") = 0
        If Not Page.IsPostBack Then


            query = Session("searchquery")
            Dim Con As New DBTaskBO
            Dim ds As DataSet
            ds = Con.getDataSet(query)
            Dim strNOFiles As String = "Records Found: " + ds.Tables(0).Rows.Count.ToString
            lblMessage.Text = strNOFiles
            'If strNOFiles.Trim = "" Or strNOFiles.Trim = "Records Found: 0" Then
            '    btnResend.Visible = False
            'Else
            '    btnResend.Visible = True
            'End If
            Me.grdMain.DataSource = ds
            Me.grdMain.DataBind()
        End If

        'If grdMain.Rows.Count <> 0 Then

        '    Dim cbHeader As CheckBox = CType(grdMain.HeaderRow.FindControl("chkheadder"), CheckBox)

        '    'Run the ChangeCheckBoxState client-side function whenever the
        '    'header checkbox is checked/unchecked
        '    cbHeader.Attributes("onclick") = "ChangeAllCheckBoxStates(this.checked);"

        '    'Add the CheckBox's ID to the client-side CheckBoxIDs array
        '    ClientScript.RegisterArrayDeclaration("CheckBoxIDs", String.Concat("'", cbHeader.ClientID, "'"))

        '    For Each gvr As GridViewRow In grdMain.Rows
        '        'Get a programmatic reference to the CheckBox control
        '        Dim cb As CheckBox = CType(gvr.FindControl("chk1"), CheckBox)

        '        'If the checkbox is unchecked, ensure that the Header CheckBox is unchecked
        '        cb.Attributes("onclick") = "ChangeHeaderAsNeeded();"

        '        'Add the CheckBox's ID to the client-side CheckBoxIDs array
        '        ClientScript.RegisterArrayDeclaration("CheckBoxIDs", String.Concat("'", cb.ClientID, "'"))
        '    Next
        'End If

    End Sub

    Protected Function getCounter() As String
        Dim intCount As Integer = Session("cint")
        intCount += 1
        Session("cint") = intCount
        Return intCount.ToString
    End Function

    Protected Sub grdMain_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdMain.RowCommand
        Dim row As GridViewRow = grdMain.Rows(e.CommandArgument.ToString)
        Dim nowdatetime As Date
        nowdatetime = Now.Date
        nowdatetime += Now.TimeOfDay
        Dim filename As String
        Dim errmsg As String

        If e.CommandName = "View" Then
            Dim coll As Collections.Specialized.IOrderedDictionary
            coll = grdMain.DataKeys(e.CommandArgument.ToString).Values

            Session("scliID") = coll.Item(0)
            Session("ssfoid") = coll.Item(3)
            Dim transName As String = coll.Item(4)
            ' DisplayDownloadDialog("../Data/" + Session("scliID") + "/Transcriptions/" + row.Cells(2).Text)
            filename = Server.MapPath("../Data/" + Session("ssfoid") + Session("scliID").ToString + "/Transcriptions/" + transName)

            If IO.File.Exists(filename) = True Then
                Response.Write("<script language='javascript'>window.open('../Data/" + Session("ssfoid") + Session("scliID").ToString + "/Transcriptions/" + transName & "')</script>")
            Else
                errmsg = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                                                           + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                                                           + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                                                           + "<td width=60 align=center><img src='../images/error.ico' /></td><td width=390 align=left><font style='font-family:verdana; font-size:9pt;'>Following transcription File :<br/>(&nbsp; " + row.Cells(2).Text + " &nbsp;) do not exist. <br/>Please contact your Front Office Admin.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                                                           + "<tr><td height=2></td></tr></table>"

                'lblMessage.Text = errmsg
                Session("confirmationMessage") = errmsg
                Session("page") = "searchrecord.aspx"
                'Response.Redirect("filedownload.aspx")
            End If


        End If

        'If e.CommandName = "Download" Then
        '    Dim Con As New DBTask
        '    Dim Query As String = "update tbl_Transcriptions set traCliDownloadDate='" + nowdatetime + "' where traName='" + row.Cells(2).Text + "' "

        '    Con.update(Query)
        '    Dim coll As Collections.Specialized.IOrderedDictionary
        '    coll = grdMain.DataKeys(e.CommandArgument.ToString).Values

        '    Session("scliID") = coll.Item(0)

        '    DisplayDownloadDialog("../Data/" + Session("scliID").ToString + "/Transcriptions/" + row.Cells(2).Text)


        'End If


    End Sub
    Sub DisplayDownloadDialog(ByVal PathVirtual As String)
        Try
            Dim errmsg As String
            PathVirtual = Server.MapPath(PathVirtual)
            Dim fs As IO.FileStream
            Dim a As Integer
            Dim filename As String = PathVirtual.Substring(PathVirtual.LastIndexOf("\") + 1)

            If PathVirtual <> String.Empty Then
                If IO.File.Exists(PathVirtual) = True Then
                    fs = IO.File.Open(PathVirtual, IO.FileMode.Open)
                    Dim strFileName As String = PathVirtual.Substring(PathVirtual.LastIndexOf("\") + 1)

                    Dim bytBytes(fs.Length) As Byte
                    fs.Read(bytBytes, 0, fs.Length)
                    fs.Close()
                    'attachment|inline[;filename="<filename>"]

                    HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" & strFileName)
                    ' HttpContext.Current.Response.ContentType = "application/octet-stream"
                    HttpContext.Current.Response.ContentType = "message/rfc822"

                    HttpContext.Current.Response.BinaryWrite(bytBytes)

                Else
                    HttpContext.Current.Response.Clear()

                    errmsg = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
                                            + "<tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
                                            + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr><tr>" _
                                            + "<td width=60 align=center><img src='../images/error.ico' /></td><td width=390 align=left><font style='font-family:verdana; font-size:9pt;'>Following transcription File :<br/>(&nbsp; " + filename + " &nbsp;) do not exist. <br/>Please contact your Front Office Admin.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr>" _
                                            + "<tr><td height=2></td></tr></table>"

                    'lblMessage.Text = errmsg
                    Session("confirmationMessage") = errmsg
                    Session("page") = "searchrecord.aspx"
                    Response.Redirect("filedownload.aspx")
                    'lblError.Visible = True
                    'lblError.Text = "Error: The file does not exist on the specified location."
                End If
            Else
                HttpContext.Current.Response.Clear()



                'lblError.Visible = True
                'lblError.Text = "Error: The file does not exist on the specified location."
            End If



        Catch ex As Exception

        End Try

    End Sub
    Protected Sub grdMain_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMain.RowCreated
        Try

            If e.Row.RowType = DataControlRowType.DataRow Then


                'Dim addButton As ImageButton = e.Row.FindControl("ImageButtonDown")
                'addButton.CommandArgument = e.Row.RowIndex.ToString()

                Dim addButton1 As ImageButton = e.Row.FindControl("ImageButtonStatus")
                addButton1.CommandArgument = e.Row.RowIndex.ToString()

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub grdMain_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMain.RowDataBound

    End Sub

    'Protected Sub ImageButtonDownall_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDownall.Click
    '    Dim count As Integer
    '    count = 0

    '    For Each item4 As GridViewRow In grdMain.Rows
    '        Dim chk2 As CheckBox = item4.FindControl("chk1")
    '        If chk2.Checked Then

    '            Dim nowdatetime As Date
    '            Dim filename As String
    '            nowdatetime = Now.Date
    '            nowdatetime += Now.TimeOfDay
    '            ' Response.Write("ali")
    '            'Dim Con As New DBTask
    '            'Dim Query As String = "update tbl_Transcriptions set traCliDownloadDate='" + nowdatetime + "' where traName='" + item4.Cells(2).Text + "' "

    '            'Con.update(Query)
    '            Dim coll As Collections.Specialized.IOrderedDictionary
    '            coll = grdMain.DataKeys(count).Values


    '            Session("scliID") = coll.Item(0)
    '            filename = "../Data/" + Session("scliID").ToString + "/Transcriptions/" + item4.Cells(2).Text



    '            Response.Write("<script language='javascript'>window.open('" & filename & "')</script>")

    '            count = count + 1
    '        End If


    '    Next

    '    If count = 0 Then

    '        Me.Label2.Text = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
    '                + "<tr><td height=15></td></tr><tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
    '                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr>" _
    '                + "<tr><td align=center width=80><img src='../images/error.ico' /></td><td width=370 align=left><font style='font-family:verdana; font-size:8pt;'>Please select files.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=10></td></tr></table>"
    '    End If
    'End Sub

    'Protected Sub btnResend_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnResend.Click
    '    Dim count As Integer
    '    count = 0
    '    Dim filesTable As New DataTable
    '    Dim myDataRow As DataRow
    '    filesTable.Columns.Add("ID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traPatFirstName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("locName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("datDateTime", Type.GetType("System.DateTime"))
    '    filesTable.Columns.Add("TID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("DID", Type.GetType("System.String"))
    '    For Each item4 As GridViewRow In grdMain.Rows
    '        Dim chk2 As CheckBox = item4.FindControl("chk1")
    '        If chk2.Checked Then
    '            myDataRow = filesTable.NewRow()
    '            myDataRow("ID") = getCounter1()
    '            myDataRow("traName") = item4.Cells(2).Text.ToString.Trim
    '            'myDataRow("traPatFirstName") = item4.Cells(2).Text.ToString.Trim

    '            Dim lblName As System.Web.UI.DataBoundLiteralControl = CType(item4.Cells(3).Controls(0), System.Web.UI.DataBoundLiteralControl)
    '            myDataRow("traPatFirstName") = lblName.Text

    '            If item4.Cells(4).Text.ToString.Trim <> "&nbsp;" Then
    '                myDataRow("locName") = item4.Cells(4).Text.ToString.Trim
    '            Else
    '                myDataRow("locName") = ""
    '            End If

    '            Dim lblDate As Label = item4.Cells(5).Controls(1)
    '            myDataRow("datDateTime") = CDate(lblDate.Text)

    '            Dim coll As Collections.Specialized.IOrderedDictionary
    '            coll = grdMain.DataKeys(count).Values
    '            Session("scliID") = coll.Item(0)
    '            myDataRow("TID") = coll.Item(2)
    '            myDataRow("DID") = coll.Item(1)


    '            filesTable.Rows.Add(myDataRow)

    '            count = count + 1
    '        End If
    '    Next
    '    If filesTable.Rows.Count > 0 Then
    '        Session("dt") = filesTable
    '        Response.Redirect("searchresponse.aspx")
    '    Else
    '        Dim str As String
    '        str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
    '                + "<tr><td height=15></td></tr><tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
    '                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr>" _
    '                + "<tr><td align=center width=80><img src='../images/error.ico' /></td><td width=370 align=left><font style='font-family:verdana; font-size:8pt;'>Please select files.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=10></td></tr></table>"

    '        Me.Label2.Text = str
    '    End If

    'End Sub

    'Protected Sub sendmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles sendmail.Click

    '    Dim filesTable As New DataTable
    '    Dim myDataRow As DataRow
    '    filesTable.Columns.Add("ID", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traName", Type.GetType("System.String"))
    '    filesTable.Columns.Add("traPatFirstName", Type.GetType("System.String"))

    '    For Each item4 As GridViewRow In grdMain.Rows
    '        Dim chk2 As CheckBox = item4.FindControl("chk1")
    '        If chk2.Checked Then
    '            myDataRow = filesTable.NewRow()
    '            myDataRow("ID") = getCounter1()
    '            myDataRow("traName") = item4.Cells(2).Text.ToString.Trim
    '            'myDataRow("traPatFirstName") = item4.Cells(2).Text.ToString.Trim

    '            Dim lblName As System.Web.UI.DataBoundLiteralControl = CType(item4.Cells(3).Controls(0), System.Web.UI.DataBoundLiteralControl)
    '            myDataRow("traPatFirstName") = lblName.Text




    '            filesTable.Rows.Add(myDataRow)


    '        End If
    '    Next
    '    If filesTable.Rows.Count > 0 Then
    '        Session("dt") = filesTable
    '        Response.Redirect("sendmail.aspx")

    '    Else
    '        Dim str As String
    '        str = "<table width=500 border=0 cellpadding=0 cellspacing=0>" _
    '                + "<tr><td height=15></td></tr><tr><td><fieldset><legend><font style='font-family:arial; font-size:13px; text-align:left; color:#343434; letter-spacing:0.9px;'><strong>Error &nbsp;</strong></font></legend>" _
    '                + "<table width=450 align=center border=0 cellspacing=0 cellpadding=0><tr><td colspan=2 height=6></td></tr>" _
    '                + "<tr><td align=center width=80><img src='../images/error.ico' /></td><td width=370 align=left><font style='font-family:verdana; font-size:8pt;'>Please select files.</font></td></tr><tr><td colspan=2 height=6></td></tr></table></fieldset></td></tr><tr><td height=10></td></tr></table>"

    '        Me.Label2.Text = str
    '    End If


    'End Sub
    Protected Function tagImage(ByVal tag As String) As String
        If tag = True Then
            tag = "~/images/tag.gif"
        Else
            tag = "~/images/tag1.gif"
        End If


        Return tag
    End Function
    Protected Function getCounter1() As String
        Dim intCount1 As Integer = Session("cint1")
        intCount1 += 1
        Session("cint1") = intCount1
        Return intCount1.ToString
    End Function
End Class
