Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL


Partial Class dictatorview
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Session("ssedrID") = Request.QueryString("drID").ToString
            Session("ssefoID") = Request.QueryString("foID").ToString
            Dim Con As New DBTaskBO

            'Dim dr As SqlDataReader
            'dr = Con.getDataReader("procViewDictator '" & Session("ssedrID") & "','" & Session("ssefoID") & "'")
            'dvEmployee.DataSource = dr
            'dvEmployee.DataBind()
            Dim ds As DataSet
            'ds = Con.getDataSet("procViewDictator '" & Session("ssedrID") & "','" & Session("ssefoID") & "'")
            Dim qry As String = "SELECT     drID AS [Dictator ID], foID AS [Front Office ID], drFirstName AS [First Name], drLastName AS [Last Name], drMiddleName AS [Middle Name], " _
                                & "drGender AS Gender, drSpecialty AS Specialty " _
                                & "FROM boDictator " _
                                & "where drID='" & Session("ssedrID") & "' and foID= '" & Session("ssefoID") & "'"
            ds = Con.getDataSet(qry)
            dvEmployee.DataSource = ds
            dvEmployee.DataBind()
        End If
        'Catch ex As Exception

        'End Try

    End Sub
End Class

