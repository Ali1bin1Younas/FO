Imports System.Data
Imports System.io
Imports System.Data.SqlClient
Imports MTBMS.BLL
Imports MTBMS.DAL

Partial Public Class _master
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Ajax.Utility.RegisterTypeForAjax(GetType(_master))

        Dim sURL As String = HttpContext.Current.Request.Url.AbsolutePath
        If sURL.Contains("dailyworkload.aspx") Then
            lblPageHeading.Text = "Daily Workload"
        ElseIf sURL.Contains("dailyworkload_new.aspx") Then
            lblPageHeading.Text = "Daily Workload"
        ElseIf sURL.Contains("dictatorassignment.aspx") Then
            lblPageHeading.Text = "Assign Team to Dictator"
        ElseIf sURL.Contains("dictationassignmentsimple.aspx") Then
            lblPageHeading.Text = "Dictations Assignment - Simple"
        ElseIf sURL.Contains("dictationassignmentsimplenew2.aspx") Then
            lblPageHeading.Text = "Dictations Assignment"
        ElseIf sURL.Contains("dictationassignment.aspx") Then
            lblPageHeading.Text = "Dictations Assignment - Standard"
        ElseIf sURL.Contains("employeemain.aspx") Then
            lblPageHeading.Text = "Employees"
        ElseIf sURL.Contains("employeeview.aspx") Then
            lblPageHeading.Text = "Employee Details"
        ElseIf sURL.Contains("employee.aspx") Then
            lblPageHeading.Text = "Add new Employee"
        ElseIf sURL.Contains("employeeupdate.aspx") Then
            lblPageHeading.Text = "Update Employee"
        ElseIf sURL.Contains("employeeroles.aspx") Then
            lblPageHeading.Text = "Assign Roles to Employee"
        ElseIf sURL.Contains("employeechangepassword.aspx") Then
            lblPageHeading.Text = "Change Employee Password"
        ElseIf sURL.Contains("dictatormain.aspx") Then
            lblPageHeading.Text = "Dictators"
        ElseIf sURL.Contains("dictatorview.aspx") Then
            lblPageHeading.Text = "Dictator Details"
        ElseIf sURL.Contains("dictationtools.aspx") Then
            lblPageHeading.Text = "Dictation Tools"
        ElseIf sURL.Contains("dictationtoolsnew.aspx") Then
            lblPageHeading.Text = "Dictation Tools"
        ElseIf sURL.Contains("dictationtoolsnew.aspx") Then
            lblPageHeading.Text = "Dictation Tools"
        ElseIf sURL.Contains("transcriptiontools.aspx") Then
            lblPageHeading.Text = "Transcription Tools"
        ElseIf sURL.Contains("transcriptiontools2.aspx") Then
            lblPageHeading.Text = "Transcription Tools"
        ElseIf sURL.Contains("changepassword.aspx") Then
            lblPageHeading.Text = "Change Password"
        ElseIf sURL.Contains("progressreport.aspx") Then
            lblPageHeading.Text = "Progress Report"
        ElseIf sURL.Contains("dictatorsworkload.aspx") Then
            lblPageHeading.Text = "Dictators Workload"
        ElseIf sURL.Contains("employeesworkload.aspx") Then
            lblPageHeading.Text = "Employees Workload"
        ElseIf sURL.Contains("employeesworkloadFull.aspx") Then
            lblPageHeading.Text = "Employee Workload"
        ElseIf sURL.Contains("dictatorworkhistory.aspx") Then
            lblPageHeading.Text = "Dictator Work History"
        ElseIf sURL.Contains("employeeworkhistory.aspx") Then
            lblPageHeading.Text = "Employee Work History"
        ElseIf sURL.Contains("dictatorslinecount.aspx") Then
            lblPageHeading.Text = "Dictators Line Count"
        ElseIf sURL.Contains("employeeslinecount.aspx") Then
            lblPageHeading.Text = "Employees Line Count"
        ElseIf sURL.Contains("datelinecount.aspx") Then
            lblPageHeading.Text = "Line Count by Date"
        ElseIf sURL.Contains("companymain.aspx") Then
            lblPageHeading.Text = "Companies"
        ElseIf sURL.Contains("companyview.aspx") Then
            lblPageHeading.Text = "Company Details"
        ElseIf sURL.Contains("company.aspx") Then
            lblPageHeading.Text = "Add new Company"
        ElseIf sURL.Contains("companyupdate.aspx") Then
            lblPageHeading.Text = "Update company"
        ElseIf sURL.Contains("assignmentdics.aspx") Then
            lblPageHeading.Text = "Dictations Assignment"
        End If

    End Sub
End Class
