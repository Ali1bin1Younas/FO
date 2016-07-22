Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL


Partial Class frontofficeview
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Session("ssefoID") = Request.QueryString("foID").ToString
            Dim Con As New DBTaskBO
            'Dim dr As SqlDataReader
            'dr = Con.getDataReader("procViewFrontOffice '" & Session("ssefoID") & "'")
            'dvFrontOffice.DataSource = dr
            'dvFrontOffice.DataBind()

            Dim ds As DataSet
            ds = Con.getDataSet("procViewFrontOffice '" & Session("ssefoID") & "'")
            dvFrontOffice.DataSource = ds
            dvFrontOffice.DataBind()
            ds.Dispose()
            ds = Nothing

            Con.objConnection.Close()
            Con = Nothing
        End If
    End Sub
End Class

