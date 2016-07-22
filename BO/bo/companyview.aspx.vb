Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL


Partial Class companyview
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Session("ssecomID") = Request.QueryString("comID").ToString
            ViewEmployee()
        End If
        'Catch ex As Exception

        'End Try

    End Sub
    Private Sub ViewEmployee()
        Dim Con As New DBTaskBO

        Dim Query As String = "Select * From boCompany WHERE comID = '" & Session("ssecomID") & "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        comID.Text = ds.Tables(0).Rows(0)("comID")
        comName.Text = ds.Tables(0).Rows(0)("comName")
        comEnable.Text = ds.Tables(0).Rows(0)("comEnable")

        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub
End Class

