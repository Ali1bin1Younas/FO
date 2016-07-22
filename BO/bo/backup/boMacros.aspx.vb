Imports MTBMS.DAL
Imports System.Data


Partial Class bo_boMacros
    Inherits System.Web.UI.Page

    Public rowCount As Integer

    Private Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_macros_grid()
        If Not Page.IsPostBack Then

        End If
    End Sub

    Private Sub load_macros_grid()
        Try
            Dim qry As String = "Select mcID, mcName, mcVersion, mcType, mcDefault from boMacros"
            Dim objDB As New DBTaskBO
            Dim ds As New DataSet

            ds = objDB.getDataSet(qry)
            If ds.Tables(0).Rows.Count > 0 Then
                gv_macros.DataSource = ds
                gv_macros.DataBind()
            End If
            lbl_error.Visible = False
        Catch ex As Exception
            lbl_error.Text = ex.Message.ToString()
            lbl_error.Visible = True
        End Try
        
    End Sub

    Private Sub gv_macros_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_macros.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            rowCount += 1
        Else
            rowCount = 0
        End If
    End Sub

    Private Sub gv_macros_DataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_macros.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dvr As DataRowView = e.Row.DataItem
            Dim img_mcDefault As HtmlImage = CType(e.Row.FindControl("img_mcDefault"), HtmlImage)
            If CType(dvr("mcDefault").ToString(), Boolean) Then
                img_mcDefault.Src = "~/Icon/Ngood.gif"
            Else
                img_mcDefault.Src = "~/Icon/cancel.gif"
            End If
        End If
    End Sub

    Private Sub btn_upload_macro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_upload_macro.Click
        Dim objDB As New DBTaskBO
        Dim if_ver_exist As Boolean = False
        Dim ver_chk As Double
        Try
            If btn_select_macro.HasFile Then
                Dim num As Integer = btn_select_macro.FileName.ToString.Split("_").Length
                If num > 1 Then
                    Dim name As String = btn_select_macro.FileName.ToString.Split("_")(btn_select_macro.FileName.ToString.Split("_").Length - 1)
                    ver_chk = CType(name.Substring(1, name.Length - 5), Double)

                    Dim qry_chk As String = "select mcID from boMacros where mcVersion = " & ver_chk.ToString.Trim()
                    If objDB.getDataSet(qry_chk).Tables(0).Rows.Count > 0 Then
                        if_ver_exist = False
                        lbl_error.Visible = True
                        lbl_error.Text = "Macro with this version already exists."
                    Else
                        if_ver_exist = True
                    End If
                Else
                    lbl_error.Visible = True
                    lbl_error.Text = "Please upload file with valid name, eg. MacroName_v1.0.dot"
                End If
            Else
                lbl_error.Visible = True
                lbl_error.Text = "Please select a file to upload."
            End If
        Catch ex As Exception
            lbl_error.Visible = True
            lbl_error.Text = "Please upload with valid name, eg. MacroName_v1.0.dot"
            if_ver_exist = False
        End Try

        Try
            If if_ver_exist Then
                If Not IO.Directory.Exists(Server.MapPath("~/data/macros")) Then
                    IO.Directory.CreateDirectory(Server.MapPath("~/data/macros"))
                End If
                btn_select_macro.SaveAs(Server.MapPath("~/data/macros/" & btn_select_macro.FileName))

                Dim qry As String = "Insert into boMacros(mcName, mcVersion, mcType, mcDefault) values('" & btn_select_macro.FileName & "', '" & ver_chk.ToString().Trim() & "','1' ,'0')"
                objDB.saveData(qry)
                lbl_error.Visible = False
                load_macros_grid()
            End If

            
        Catch ex As Exception
            lbl_error.Visible = True
            lbl_error.Text = ex.Message.ToString()
        End Try

    End Sub

    Private Sub set_default_OnClick(ByVal sender As Object, ByVal e As ImageClickEventArgs)

    End Sub
End Class
