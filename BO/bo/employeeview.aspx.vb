Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.DAL
Imports MTBMS.BLL


Partial Class employeeview
    Inherits System.Web.UI.Page
    Dim intCheckValue As Integer
    Dim strHospitalName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        If Session("empId") = "" Then Response.Redirect(GF.Home)
        If Not Page.IsPostBack Then
            Session("sseEmpID") = Request.QueryString("empID").ToString
            ViewEmployee()
        End If
        'Catch ex As Exception

        'End Try
        
    End Sub
    Private Sub ViewEmployee()
        Dim Con As New DBTaskBO

        Dim Query As String = "Select * From boEmployee WHERE empID = '" & Session("sseEmpID") & "'"
        Dim ds As DataSet
        ds = Con.getDataSet(Query)

        Dim Query2 As String = "Select comName From boCompany WHERE comID = '" & ds.Tables(0).Rows(0)("comID") & "'"
        Dim ds2 As DataSet
        ds2 = Con.getDataSet(Query2)

        Dim Query3 As String = "Select depName From boDepartment WHERE depID = '" & ds.Tables(0).Rows(0)("depID") & "'"
        Dim ds3 As DataSet
        ds3 = Con.getDataSet(Query3)

        Dim Query4 As String = "Select etpName From boEmployeeTypes WHERE etpID = '" & ds.Tables(0).Rows(0)("etpID") & "'"
        Dim ds4 As DataSet
        ds4 = Con.getDataSet(Query4)

        empID.Text = ds.Tables(0).Rows(0)("empID")
        empLoginID.Text = ds.Tables(0).Rows(0)("empLoginID")
        depName.Text = ds3.Tables(0).Rows(0)("depName")
        comName.Text = ds2.Tables(0).Rows(0)("comName")
        etpName.Text = ds4.Tables(0).Rows(0)("etpName")

        empPassword.Text = ds.Tables(0).Rows(0)("empPassword")
        empPrefix.Text = ds.Tables(0).Rows(0)("empPrefix")
        empFirstName.Text = ds.Tables(0).Rows(0)("empFirstName")
        empLastName.Text = ds.Tables(0).Rows(0)("empLastName")
        empGender.Text = ds.Tables(0).Rows(0)("empGender")
        empDOB.Text = ds.Tables(0).Rows(0)("empDOB")

        empNIC.Text = ds.Tables(0).Rows(0)("empNIC")
        empPhone.Text = ds.Tables(0).Rows(0)("empPhone")
        empCell.Text = ds.Tables(0).Rows(0)("empCell")
        empEMail.Text = ds.Tables(0).Rows(0)("empEMail")

        empAddress.Text = ds.Tables(0).Rows(0)("empAddress1")
        empAddress2.Text = ds.Tables(0).Rows(0)("empAddress2")
        empCity.Text = ds.Tables(0).Rows(0)("empCity")
        empState.Text = ds.Tables(0).Rows(0)("empState")
        empZip.Text = ds.Tables(0).Rows(0)("empZip")
        empCountry.Text = ds.Tables(0).Rows(0)("empCountry")

        empJoiningDate.Text = ds.Tables(0).Rows(0)("empJoiningDate")
        If Not IsDBNull(ds.Tables(0).Rows(0)("empDesignation")) Then empDesignation.Text = ds.Tables(0).Rows(0)("empDesignation")
        empEnable.Text = ds.Tables(0).Rows(0)("empEnable")

        ds.Dispose()
        ds = Nothing

        Con.objConnection.Close()
        Con = Nothing
    End Sub
End Class

