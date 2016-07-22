Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class fronoffice
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Try
        Call SaveRecords()

        If Session("rdSpecialty") = "specialty.aspx" Then
            Response.Redirect("client.aspx")
            Session("rdSpecialty") = ""
        Else
            Response.Redirect("frontofficemain.aspx")
            Session("rdSpecialty") = ""
        End If

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub SaveRecords()
        'Try
        Dim hash As New Hashtable
        Dim col As ColumnName = Nothing
        col = New ColumnName("foID", CInt(Me.txtfoID.Text.ToString), "str")
        hash.Add("1", col)
        col = New ColumnName("foName", Me.txtfoName.Text.ToString, "str")
        hash.Add("2", col)
        col = New ColumnName("foAddress1", Me.txtfoAddress.Text.ToString, "str")
        hash.Add("3", col)
        col = New ColumnName("foState", Me.txtfoState.Text.ToString, "str")
        hash.Add("4", col)
        col = New ColumnName("foZip", Me.txtfoZip.Text.ToString, "str")
        hash.Add("5", col)
        col = New ColumnName("foPhoneNo", Me.txtfoPhoneNo.Text.ToString, "str")
        hash.Add("6", col)
        col = New ColumnName("foFaxNo", Me.txtfoFaxNo.Text.ToString, "str")
        hash.Add("7", col)
        col = New ColumnName("foURL", Me.txtfoURL.Text.ToString, "str")
        hash.Add("8", col)
        col = New ColumnName("foEmail", Me.txtfoEmail.Text.ToString, "str")
        hash.Add("9", col)
        col = New ColumnName("foContactName", Me.txtfoContactPersonName.Text.ToString, "str")
        hash.Add("10", col)
        col = New ColumnName("foContactPhoneNo", Me.txtfoContactPersonPhoneNo.Text.ToString, "str")
        hash.Add("11", col)
        col = New ColumnName("foContactCellNo", Me.txtfoContactPersonCellNo.Text.ToString, "str")
        hash.Add("12", col)
        col = New ColumnName("foContactAddress", Me.txtfoContactPersonAddress.Text.ToString, "str")
        hash.Add("13", col)
        col = New ColumnName("foContactEmail", Me.txtfoContactPersonEmail.Text.ToString, "str")
        hash.Add("14", col)
        col = New ColumnName("foContactPagerNo", Me.txtfoContactPersonPagerNo.Text.ToString, "str")
        hash.Add("15", col)
        col = New ColumnName("foAddress2", Me.txtfoAddress2.Text.ToString, "str")
        hash.Add("16", col)
        col = New ColumnName("foCity", Me.txtfoCity.Text.ToString, "str")
        hash.Add("17", col)
        col = New ColumnName("foCountry", Me.cmbfoCountry.Text.ToString, "str")
        hash.Add("18", col)
        col = New ColumnName("foPassword", Me.txtfoPassword.Text.ToString, "str")
        hash.Add("19", col)
        col = New ColumnName("foDateTime", Me.CPFOCreated.SelectedDate, "date")
        hash.Add("20", col)

        Dim ad As New DBTaskBO
        ad.InsertDataValues(hash, "mmoFO")



        'Dim obj As New wsfo.FrontOfficeDO
        'obj.FOId = Me.txtfoID.Text
        'obj.foName = Me.txtfoName.Text
        'obj.foAddress1 = Me.txtfoAddress.Text
        'obj.foAddress2 = Me.txtfoAddress2.Text
        'obj.foCity = Me.txtfoCity.Text
        'obj.foState = Me.txtfoState.Text
        'obj.foZip = Me.txtfoZip.Text
        'obj.foCountry = Me.cmbfoCountry.Text
        'obj.foCell = "2569"
        'obj.foPhone = Me.txtfoPhoneNo.Text
        'obj.foURL = Me.txtfoURL.Text
        'obj.foEmail = Me.txtfoEmail.Text
        'obj.foContactName = Me.txtfoContactPersonName.Text
        'obj.foContactPhone = Me.txtfoContactPersonPhoneNo.Text
        'obj.foContactEmail = Me.txtfoContactPersonEmail.Text
        'obj.foContactAddress = Me.txtfoContactPersonAddress.Text
        'obj.foContactPagerNo = Me.txtfoContactPersonPagerNo.Text
        'obj.foPassword = Me.txtfoPassword.Text
        'obj.foEnable = "1"

        'Dim foSave As New wsfo.serviceupdatefodb
        'Dim i As Integer = foSave.InsertFOData(obj)

        'Catch ex As Exception
        'End Try
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Session("rdSpecialty") = "specialty.aspx" Then
            Response.Redirect("client.aspx")
            Session("rdSpecialty") = ""
        Else
            Response.Redirect("frontofficemain.aspx")
            Session("rdSpecialty") = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
    End Sub
End Class
