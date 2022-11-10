Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmOrderDetailReport

    Private Sub frmOrderDetailReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PharmacyDBDataSet.OrderDetail' table. You can move, or remove it, as needed.
        'Me.OrderDetailTableAdapter.Fill(Me.PharmacyDBDataSet.OrderDetail)

        'Me.ReportViewer1.RefreshReport()
        LoadReport()
    End Sub

    Public Sub LoadReport()
        Try
            sqL = "SELECT O.OrderNo, O.OrderDate, C.Name as Supplier, O.TotalQuantity, O.TotalAmount, O.Status, (E.Lastname + ', ' + E.Firstname + ' ' + E.Middlename) as CreatedBy, P.GenericName, P.TradeName, OL.CostPrice, OL.Quantity, OL.TotalPrice, O.OrderDiscount, O.OrderTotalAmount, O.OrderComment FROM [dbo].[Order]  as O INNER JOIN [dbo].[OrderLineItem] OL ON O.OrderNo = OL.OrderNo  INNER JOIN Company C On C.CompanyId= O.CompanyId INNER JOIN Employee E ON O.EmployeeID = E.EmployeeID INNER JOIN Product P On P.ProductID = OL.ProductId WHERE O.OrderNo = '" & frmListOrder.ListView1.FocusedItem.SubItems(1).Text & "'"

            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            da = New SqlDataAdapter(cmd)

            Me.PharmacyDBDataSet.OrderDetail.Clear()
            da.Fill(Me.PharmacyDBDataSet.OrderDetail)


            Dim OrderNo = New ReportParameter("OrderNo", frmListOrder.ListView1.FocusedItem.SubItems(1).Text)
            Dim HeaderParams As ReportParameter() = {OrderNo}

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