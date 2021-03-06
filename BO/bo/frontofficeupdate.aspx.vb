Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class frontofficeupdate
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Call SaveRecords()
            Response.Redirect("frontofficemain.aspx")
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub SaveRecords()

        Try
            Dim hash As New Hashtable
            Dim col As ColumnName = Nothing
            'col = New ColumnName("foID", CInt(Me.txtfoID.Text.ToString), "str")
            'hash.Add("1", col)
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
            If Me.txtfoPassword.Text <> "" Then
                col = New ColumnName("foPassword", Me.txtfoPassword.Text.ToString, "str")
                hash.Add("19", col)
            End If
            col = New ColumnName("foDateTime", Me.CPFOCreated.SelectedDate, "date")
            hash.Add("20", col)
            col = New ColumnName("foID", Session("ssfoID").ToString, "str")
            hash.Add("wheres", col)
            Dim ad As New DBTaskBO
            ad.updateDataValues(hash, "mmoFO")
            setFrontOffice()

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        Try

            If Not Page.IsPostBack Then
                Session("ssfoID") = Request.QueryString("foID")
                setFrontOffice()
            End If
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub setFrontOffice()

        Try
            Dim Con As New DBTaskBO
            Dim ssfoID As String = Session("ssfoID")
            Dim Query As String = "Select * From mmoFO where foID='" + ssfoID + "'"
            'Dim dr As SqlDataReader
            'dr = Con.getDataReader(Query)
            'While dr.Read
            '    Me.txtfoID.Text = dr("foID").ToString
            '    Me.txtfoName.Text = dr("foName").ToString
            '    Me.txtfoAddress.Text = dr("foAddress1").ToString
            '    Me.txtfoAddress2.Text = dr("foAddress2").ToString
            '    Me.txtfoCity.Text = dr("foCity").ToString
            '    Me.txtfoState.Text = dr("foState").ToString
            '    Me.txtfoZip.Text = dr("foZip").ToString
            '    Me.cmbfoCountry.SelectedValue = dr("foCountry").ToString
            '    Me.txtfoPhoneNo.Text = dr("foPhoneNo").ToString
            '    Me.txtfoFaxNo.Text = dr("foFaxNo").ToString
            '    Me.txtfoURL.Text = dr("foURL").ToString
            '    Me.txtfoPassword.Text = dr("foPassword").ToString
            '    Me.txtfoEmail.Text = dr("foEmail").ToString
            '    Me.txtfoContactPersonName.Text = dr("foContactName").ToString
            '    Me.txtfoContactPersonPhoneNo.Text = dr("foContactPhoneNo").ToString
            '    Me.txtfoContactPersonCellNo.Text = dr("foContactCellNo").ToString
            '    Me.txtfoContactPersonAddress.Text = dr("foContactAddress").ToString
            '    Me.txtfoContactPersonEmail.Text = dr("foContactEmail").ToString
            '    Me.txtfoContactPersonPagerNo.Text = dr("foContactPagerNo").ToString
            'End While

            Dim ds As DataSet
            ds = Con.getDataSet(Query)
            For Each dr As DataRow In ds.Tables(0).Rows


                Me.txtfoID.Text = dr("foID").ToString
                Me.txtfoName.Text = dr("foName").ToString
                Me.txtfoAddress.Text = dr("foAddress1").ToString
                Me.txtfoAddress2.Text = dr("foAddress2").ToString
                Me.txtfoCity.Text = dr("foCity").ToString
                Me.txtfoState.Text = dr("foState").ToString
                Me.txtfoZip.Text = dr("foZip").ToString
                Me.cmbfoCountry.SelectedValue = dr("foCountry").ToString
                Me.txtfoPhoneNo.Text = dr("foPhoneNo").ToString
                Me.txtfoFaxNo.Text = dr("foFaxNo").ToString
                Me.txtfoURL.Text = dr("foURL").ToString
                Me.txtfoPassword.Text = dr("foPassword").ToString
                Me.txtfoEmail.Text = dr("foEmail").ToString
                Me.txtfoContactPersonName.Text = dr("foContactName").ToString
                Me.txtfoContactPersonPhoneNo.Text = dr("foContactPhoneNo").ToString
                Me.txtfoContactPersonCellNo.Text = dr("foContactCellNo").ToString
                Me.txtfoContactPersonAddress.Text = dr("foContactAddress").ToString
                Me.txtfoContactPersonEmail.Text = dr("foContactEmail").ToString
                Me.txtfoContactPersonPagerNo.Text = dr("foContactPagerNo").ToString
            Next
        Catch ex As Exception

        End Try
        
    End Sub


End Class
