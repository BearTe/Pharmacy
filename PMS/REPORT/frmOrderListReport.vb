Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmOrderListReport

    Private Sub frmOrderListReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PharmacyDBDataSet.Order' table. You can move, or remove it, as needed.
        ' Me.OrderTableAdapter.Fill(Me.PharmacyDBDataSet.Order)

        ' Me.ReportViewer1.RefreshReport()
        LoadReport()
    End Sub

    Public Sub LoadReport()
        Try
            sqL = "SELECT O.OrderNo, O.OrderDate, C.Name as Supplier, O.TotalQuantity, O.TotalAmount, O.Status, (E.Lastname + ', ' + E.Firstname + ' ' + E.Middlename) as CreatedBy  FROM [dbo].[Order]  as O  INNER JOIN Company C On C.CompanyId= O.CompanyId INNER JOIN Employee E ON O.EmployeeID = E.EmployeeID WHERE ORDERDate BETWEEN '" & frmSelectReport.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' AND '" & frmSelectReport.DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'"

            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            da = New SqlDataAdapter(cmd)

            Me.PharmacyDBDataSet.Order.Clear()
            da.Fill(Me.PharmacyDBDataSet.Order)

            Dim startDate = New ReportParameter("StartDate", frmSelectReport.DateTimePicker1.Value)
            Dim endDate = New ReportParameter("EndDate", frmSelectReport.DateTimePicker2.Value)
            Dim HeaderParams As ReportParameter() = {startDate, endDate}

            For Each param As ReportParameter In HeaderParams
                ReportViewer1.LocalReport.SetParameters(param)
            Next

            Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            Me.ReportViewer1.ZoomPercent = 90
            Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class