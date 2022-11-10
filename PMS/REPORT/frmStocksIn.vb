Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmStocksIn

    Private Sub frmStocksIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PharmacyDBDataSet.Stock' table. You can move, or remove it, as needed.
        'Me.StockTableAdapter.Fill(Me.PharmacyDBDataSet.Stock)

        'Me.ReportViewer1.RefreshReport()
        LoadReport()
    End Sub

    Public Sub LoadReport()
        Try
            sqL = "SELECT S.StockDate, P.GenericName, C.Name, S.ManufactureDate, S.ExpirationDate, S.Packing, S.StockQuantity FROM Stock AS S INNER JOIN Product AS P ON P.ProductID = S.ProductID INNER JOIN Company AS C ON C.CompanyID = S.SupplierID WHERE StockDate BETWEEN '" & frmSelectReport.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' AND '" & frmSelectReport.DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'"

            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            da = New SqlDataAdapter(cmd)

            Me.PharmacyDBDataSet.Stock.Clear()
            da.Fill(Me.PharmacyDBDataSet.Stock)

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