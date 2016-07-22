Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL
Partial Class faxmain
    Inherits System.Web.UI.Page
    Protected iCounter As Int16

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        iCounter = 0
        If Not Page.IsPostBack Then
            loadDictator()
        End If
        loadGrid()

    End Sub

    Private Sub loadDictator()

        'Dim Con As New DBTaskBO
        'Dim Query As String = "Select * From boDictator"

        'Dim dr As SqlDataReader
        'dr = Con.getDataReader(Query)

        'While dr.Read
        '    Me.cmbDictator.Items.Add(dr("drFirstName"))
        'End While

        Dim Con As New DBTaskBO
        Dim Query As String = "Select * From boDictator"

        'Dim dr As SqlDataReader
        'dr = Con.getDataReader(Query)

        'While dr.Read
        '    Dim str As String = dr("drID").ToString + "-" + dr("foID").ToString + "-" + dr("drLastName").ToString + ", " + dr("drFirstName").ToString
        '    Me.cmbDictator.Items.Add(str)
        'End While
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim str As String = dr("drID").ToString + "-" + dr("foID").ToString + "-" + dr("drLastName").ToString + ", " + dr("drFirstName").ToString
            Me.cmbDictator.Items.Add(str)
        Next

    End Sub

    Private Sub loadGrid()

        Dim Query As String
        Dim Con As New DBTaskBO
        'Dim Query As String = "Select * From boTemplates where drID='" & GetDictatorID(Me.cmbDictator.Text.Trim) & "'"

        Dim strWholeName As String = Me.cmbDictator.Text.ToString
        Dim strdrID As String = strWholeName.Substring(0, 4)
        Dim strfoID As String = strWholeName.Substring(5, 4)

        If Me.cmbDictator.Text <> "All Faxes..." Then
            Query = "Select * From boFax where drID='" & strdrID & "' and foID='" & strfoID & "' "
        Else
            Query = "Select * From boFax"
        End If
        Dim ds As DataSet
        ds = Con.getDataSet(Query)
        Me.grdTemplates.DataSource = ds
        Me.grdTemplates.DataBind()
    End Sub

    Private Function GetDictatorID(ByVal did As String) As String
        Dim Con As New DBTaskBO
        Dim strdrID As String = Nothing
        Dim Query As String = "Select drID From boDictator Where drFirstName='" & did & "'"
        'Dim dr As SqlDataReader
        Dim ds As DataSet
        'dr = Con.getDataReader(Query)
        ds = Con.getDataSet(Query)
        'If dr.Read Then
        If ds.tables(0).rows.count > 0 Then
            'strdrID = dr("drID")
            strdrID = ds.tables(0).rows(0).item("drID")
        End If
        Return strdrID

    End Function

    Protected Sub grdTemplates_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTemplates.RowCreated
        If e.Row.RowIndex > 0 Then iCounter += 1
    End Sub
End Class
