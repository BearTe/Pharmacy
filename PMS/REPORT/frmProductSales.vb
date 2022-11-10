Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmProductSales

    Private Sub frmProductSales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PharmacyDBDataSet.ProductSales' table. You can move, or remove it, as needed.
        ' Me.ProductSalesTableAdapter.Fill(Me.PharmacyDBDataSet.ProductSales)

        'Me.ReportViewer1.RefreshReport()
        LoadReport()
    End Sub

    Public Sub LoadReport()
        Try
            sqL = "SELECT T.TransactionDate,  P.GenericName, P.TradeName, ItemPrice, SUM(TL.Quantity) as Quantity,SUM(TL.Discount) as Discount ,SUM(ExtendedPrice) as ExtendedPrice , SUM(TL.TotalAmount) as TotalAmount FROM dbo.TransactionLineItem TL  INNER JOIN Product P ON P.ProductId = TL.ProductId INNER JOIN [Transaction] T ON T.InvoiceNo = Tl.InvoiceNo WHERE T.TransactionDate BETWEEN '" & frmSelectReport.DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' AND '" & frmSelectReport.DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' GROUP BY T.TransactionDate,  P.GenericName, P.TradeName, ItemPrice"

            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            da = New SqlDataAdapter(cmd)

            Me.PharmacyDBDataSet.ProductSales.Clear()
            da.Fill(Me.PharmacyDBDataSet.ProductSales)

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