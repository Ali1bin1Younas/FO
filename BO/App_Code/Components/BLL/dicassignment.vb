Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports MTBMS.BLL

Public Class dicassignment
    Inherits System.Web.UI.Page
    Private _EmployeeRoll, Qry As String
    Private _SelectedDate, _EmplyeeID, DicDate, Out_Q_DicStatus, In_Q_DicStatus, Date_Check, Status_Check As String

    Public Property EmployeeRoll() As String
        Get
            Return _EmployeeRoll
        End Get
        Set(ByVal value As String)
            _EmployeeRoll = value
        End Set
    End Property

    Public Property SelectedDate() As String
        Get
            Return _SelectedDate
        End Get
        Set(ByVal value As String)
            _SelectedDate = Format(CType(value, System.DateTime).Date, "M/d/yyyy")
        End Set
    End Property

    Public Property EmplyeeID() As String
        Get
            Return _EmplyeeID
        End Get
        Set(ByVal value As String)
            _EmplyeeID = value
        End Set
    End Property

    Public Function Generate_Query(ByVal SelectGrid As String) As String

        If SelectGrid = "Current" Then
            SelectGrid = "(boDictation.dicDate = '"
            DicDate = "(Bdic.dicDate = '"
            In_Q_DicStatus = ""
            Out_Q_DicStatus = ";"
            Date_Check = "="
            Status_Check = ""
        Else
            SelectGrid = "(boDictation.dicDate < '"
            DicDate = "(Bdic.dicDate < '"
            In_Q_DicStatus = "AND (boDictationLayers.diclStatus < 3)"
            Out_Q_DicStatus = "AND (DicL.diclStatus < 3);"
            Date_Check = "<"
            Status_Check = "And (DicL.diclStatus < 3)"
        End If
        If _EmplyeeID = "-1" Or _EmplyeeID = "All" Then
            Qry = "SELECT DISTINCT DicL.empID, boEmployee.empFirstName, boEmployee.empLastName, " _
                          & "(Select Count(boDictation.dicId)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & In_Q_DicStatus & " AND boEmployee.empId=DicL.empId) As Dictations, " _
                          & "IsNull((Select Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & In_Q_DicStatus & " AND boEmployee.empId=DicL.empId),0) As dicLength, " _
                          & "(Select Count(boDictation.dicId)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & "AND boDictationLayers.diclStatus < 3 AND boEmployee.empId=DicL.empId) As OutDictations, " _
                          & "IsNull((Select Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & "AND boDictationLayers.diclStatus < 3 AND boEmployee.empId=DicL.empId),0) As OutdicLength " _
                          & "FROM boDictation Bdic INNER JOIN boDictationLayers  DicL ON " _
                          & "Bdic.dicID = DicL.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "DicL.empID = boEmployee.empID " _
                          & "WHERE (DicL.rolID = '" & _EmployeeRoll & "') AND " _
                          & DicDate & _SelectedDate & "') " _
                          & Out_Q_DicStatus
            Qry += "SELECT   DicL.empID, bDic.foID, bDic.drID, boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName, " _
                    & "(SELECT Count(boDictation.dicId) FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') " _
                    & "AND (boDictation.dicDate" & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "AND boDictationLayers.empId=DicL.empId AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as DicTations, " _
                    & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID  " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') " _
                    & "AND (boDictation.dicDate " & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "And boDictationLayers.empId=DicL.empId AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as dicLength, " _
                    & "(SELECT Count(boDictation.dicId) FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND boDictationLayers.diclStatus < 3 " _
                    & "AND (boDictation.dicDate" & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "AND boDictationLayers.empId=DicL.empId AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as OutDicTations, " _
                    & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID  " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND boDictationLayers.diclStatus < 3 " _
                    & "AND (boDictation.dicDate " & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "And boDictationLayers.empId=DicL.empId AND boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as OutdicLength " _
                    & "FROM boDictation bDic INNER JOIN boDictationLayers DicL " _
                    & "ON bDic.dicID = DicL.dicID " _
                    & "INNER JOIN boDictator ON bDic.drID = boDictator.drID AND bDic.foID = boDictator.foID " _
                    & "WHERE (DicL.rolID = '" & _EmployeeRoll & "') AND (bDic.dicDate " & Date_Check & " '" & _SelectedDate & "') " _
                    & Status_Check & "group by dicl.empid, bDic.foID, bDic.drID,boDictator.drFirstName, " _
                    & "boDictator.drLastName, boDictator.drMiddleName;"
            Qry += "SELECT boDictationLayers.empID, boDictation.foID, boDictation.drID, " _
                   & "boDictation.dicID, boDictation.dicActualName, boDictation.dicDate, " _
                   & "boDictation.dicLength, boDictation.dicStatus FROM boDictation " _
                   & "INNER JOIN boDictationLayers ON " _
                   & "boDictation.dicID = boDictationLayers.dicID " _
                   & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                   & SelectGrid & _SelectedDate & "') " _
                   & In_Q_DicStatus & " Order By boDictation.foID, boDictation.drID, boDictation.dicDate, boDictation.dicActualName"
        Else
            Qry = "SELECT DISTINCT DicL.empID, boEmployee.empFirstName, boEmployee.empLastName, " _
                          & "(Select Count(boDictation.dicId)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & "(boDictationLayers.empID = '" + _EmplyeeID + "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & In_Q_DicStatus & " AND boEmployee.empId=DicL.empId) As Dictations, " _
                          & "IsNull((Select Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & "(boDictationLayers.empID = '" + _EmplyeeID + "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & "AND boDictationLayers.diclStatus < 3 AND boEmployee.empId=DicL.empId),0) As dicLength, " _
                          & "(Select Count(boDictation.dicId)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & "(boDictationLayers.empID = '" + _EmplyeeID + "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & "AND boDictationLayers.diclStatus < 3 AND boEmployee.empId=DicL.empId) As OutDictations, " _
                          & "IsNull((Select Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "boDictationLayers.empID = boEmployee.empID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                          & "(boDictationLayers.empID = '" + _EmplyeeID + "') AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & In_Q_DicStatus & " AND boEmployee.empId=DicL.empId),0) As OutdicLength " _
                          & "FROM boDictation Bdic INNER JOIN boDictationLayers  DicL ON " _
                          & "Bdic.dicID = DicL.dicID " _
                          & "INNER JOIN boEmployee ON " _
                          & "DicL.empID = boEmployee.empID " _
                          & "WHERE (DicL.rolID = '" & _EmployeeRoll & "') AND " _
                          & "(DicL.empID = '" + _EmplyeeID + "') AND " _
                          & DicDate & _SelectedDate & "') " _
                          & Out_Q_DicStatus

            Qry += "SELECT   DicL.empID, bDic.foID, bDic.drID, boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName, " _
                    & "(SELECT Count(boDictation.dicId) FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND (boDictationLayers.empID = '" & _EmplyeeID & "') " _
                    & "AND (boDictation.dicDate" & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as DicTations, " _
                    & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID  " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND (boDictationLayers.empID = '" & _EmplyeeID & "') " _
                    & "AND (boDictation.dicDate " & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "And boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as dicLength, " _
                    & "(SELECT Count(boDictation.dicId) FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND (boDictationLayers.empID = '" & _EmplyeeID & "') " _
                    & "AND (boDictation.dicDate" & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as OutDicTations, " _
                    & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation INNER JOIN boDictationLayers " _
                    & "ON boDictation.dicID = boDictationLayers.dicID  " _
                    & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND (boDictationLayers.empID = '" & _EmplyeeID & "') " _
                    & "AND (boDictation.dicDate " & Date_Check & " '" & _SelectedDate & "' " & In_Q_DicStatus & ") " _
                    & "And boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as OutdicLength " _
                    & "FROM boDictation bDic INNER JOIN boDictationLayers DicL " _
                    & "ON bDic.dicID = DicL.dicID " _
                    & "INNER JOIN boDictator ON bDic.drID = boDictator.drID AND bDic.foID = boDictator.foID " _
                    & "WHERE (DicL.rolID = '" & _EmployeeRoll & "') AND (DicL.empID = '" & _EmplyeeID & "') AND (bDic.dicDate " & Date_Check & " '" & _SelectedDate & "') " _
                    & Status_Check & "group by dicl.empid, bDic.foID, bDic.drID,boDictator.drFirstName, " _
                    & "boDictator.drLastName, boDictator.drMiddleName;"

            Qry += "SELECT boDictationLayers.empID, boDictation.foID, boDictation.drID as drID, " _
                   & "boDictation.dicID, boDictation.dicActualName, boDictation.dicDate, " _
                   & "boDictation.dicLength, boDictation.dicStatus FROM boDictation " _
                   & "INNER JOIN boDictationLayers ON " _
                   & "boDictation.dicID = boDictationLayers.dicID " _
                   & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') AND " _
                   & "(boDictationLayers.empID = '" & _EmplyeeID & "') AND " _
                   & SelectGrid & _SelectedDate & "') " _
                   & In_Q_DicStatus & " Order By boDictation.foID, boDictation.drID, boDictation.dicDate, boDictation.dicActualName"

        End If
                Return Qry
    End Function

    Public Function Dic_Query(ByVal sDate As String, ByVal bShowAll As Boolean) As String
        Dim sInnerDate, sOuterDate As String
        Dim sInnerShow, sOuterShow As String

        If sDate.Trim <> "01/01/0001" Then
            sInnerDate = "AND (boDictation.dicDate= '" & sDate & "')"
            sOuterDate = "AND (bDic.dicDate= '" & sDate & "')"
        End If

        If Not bShowAll Or sDate.Trim = "01/01/0001" Then
            sInnerShow = "AND bDic.dicStatus < 4 "
            sOuterShow = "AND dicStatus < 4 "
        End If

        Qry = "SELECT bDic.foID, bDic.drID, boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName, boDictator.drDifficulty, " _
                & "(SELECT Count(boDictation.dicId) FROM boDictation WHERE boDictation.dicEnable = 1 " & sInnerDate & " AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as DicTations, " _
                & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation WHERE boDictation.dicEnable = 1 " & sInnerDate & " And boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as dicLength, " _
                & "(SELECT Count(boDictation.dicId) FROM boDictation WHERE boDictation.dicEnable = 1 AND boDictation.dicStatus < 4 " & sInnerDate & " AND boDictation.drId=BDic.drId AND boDictation.foId=BDic.foID) as OutDicTations, " _
                & "IsNull((SELECT Sum(boDictation.dicLength)FROM boDictation WHERE boDictation.dicEnable = 1 AND boDictation.dicStatus < 4 " & sInnerDate & " And boDictation.drId = bDic.drId And boDictation.foId = bDic.foID),0) as OutdicLength " _
                & "FROM boDictation bDic " _
                & "INNER JOIN boDictator ON bDic.drID = boDictator.drID AND bDic.foID = boDictator.foID " _
                & "WHERE bDic.dicEnable = 1 " & sInnerShow & sOuterDate & " " _
                & "GROUP BY bDic.foID, bDic.drID,boDictator.drFirstName, boDictator.drLastName, boDictator.drMiddleName,boDictator.drDifficulty;"
        Qry &= "SELECT boDictation.foID, boDictation.drID , boDictation.dicID, boDictation.dicActualName, boDictation.dicTempName, boDictation.dicAccountName, boDictation.dicDate,boDictation.dicDuplicateCheck,boDictation.dicUrgent, " _
                & "boDictation.dicLength, boDictation.dicStatus " _
                & "FROM boDictation " _
                & "WHERE dicEnable = 1 " & sOuterShow & sInnerDate & " " _
                & "Order By boDictation.foID, boDictation.drID, boDictation.dicDate, boDictation.dicActualName"

        Return Qry
    End Function

    Public Function Dictation_Qry(ByVal SelectGrid As String) As String
        Dim Emp_Inner_Query, Emp_Quter_Query As String
        If SelectGrid = "Current" Then
            SelectGrid = "(boDictation.dicDate = '"
            DicDate = "(Bdic.dicDate = '"
            In_Q_DicStatus = ""
            Out_Q_DicStatus = ";"
            Date_Check = "="
            Status_Check = ""
        Else
            SelectGrid = "(boDictation.dicDate < '"
            DicDate = "(Bdic.dicDate < '"
            In_Q_DicStatus = "AND (boDictationLayers.diclStatus < 3)"
            Out_Q_DicStatus = "AND (DicL.diclStatus < 3);"
            Date_Check = "<"
            Status_Check = "And (DicL.diclStatus < 3)"
        End If

        If Me._EmplyeeID = "-1" Then
            Emp_Inner_Query = ""
            Emp_Quter_Query = ""
        Else
            Emp_Inner_Query = " AND (boDictationLayers.empID = '" & _EmplyeeID & "')"
            Emp_Quter_Query = " AND (DicL.rolID = '" & _EmployeeRoll & "')"
        End If
        Qry = "SELECT boDictation.foID, boDictation.drID as drID, " _
                          & "boDictation.dicID, boDictation.dicActualName, boDictation.dicDate, " _
                          & "boDictation.dicLength, boDictation.dicStatus,boDictationLayers.empID FROM boDictation " _
                          & "INNER JOIN boDictationLayers ON " _
                          & "boDictation.dicID = boDictationLayers.dicID " _
                          & "WHERE (boDictationLayers.rolID = '" & _EmployeeRoll & "') " _
                          & Emp_Inner_Query & " AND " _
                          & SelectGrid & _SelectedDate & "') " _
                          & In_Q_DicStatus & " Order By boDictation.foID, boDictation.drID, boDictation.dicDate, boDictation.dicActualName"

        Return Qry
    End Function
End Class
