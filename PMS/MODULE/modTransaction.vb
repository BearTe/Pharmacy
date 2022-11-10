
Imports System.Data.SqlClient

Module modTransaction
    Public Sub LoadTransactionList(ByVal InvoiceNo As String)
        Try
            sqL = "Select TransactionDate, T.InvoiceNo, T.TotalAmount, P.PaidAmount, P.Balance, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as Cashier, ISNULL(P.DiscountAmount,0), ISNULL(P.ProfitAmount,0) FROM [Transaction] T INNER JOIN TransactionPayment P ON T.InvoiceNo = P.InvoiceNo INNER JOIN Employee E ON T.EmployeeID =  E.EmployeeID WHERE T.InvoiceNo=@InvoiceNo"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmListTransactions.ListView1.Items.Clear()

            Do While dr.Read = True
                x = New ListViewItem(Format(dr(0), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(Format(dr(2), "N2"))
                x.SubItems.Add(Format(dr(3), "N2"))
                x.SubItems.Add(Format(dr(4), "N2"))
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(Format(dr(6), "N2"))
                x.SubItems.Add(Format(dr(7), "N2"))
                frmListTransactions.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Public Sub LoadTransactionList(ByVal DateFrom As Date, ByVal DateTo As Date)
        Dim totalAmount As Double
        Dim totalProfit As Double
        Dim totalDiscount As Double
        Dim totalAdditionalProfit As Double

        Try
            sqL = "Select TransactionDate, T.InvoiceNo, T.TotalAmount,  PCost.TotalCostPrice , (T.TotalAmount - PCost.TotalCostPrice) as TProfit, P.PaidAmount, P.Balance, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as Cashier,  ISNULL(P.DiscountAmount,0), ISNULL(P.ProfitAmount,0), CustomerInfo FROM [Transaction] T INNER JOIN TransactionPayment P ON T.InvoiceNo = P.InvoiceNo INNER JOIN Employee E ON T.EmployeeID =  E.EmployeeID LEFT OUTER JOIN (SELECT  SUM(p.CostPrice) as TotalCostPrice, tl.InvoiceNo FROM Product p INNER JOIN TransactionLineItem   tl ON p.ProductID = tl.ProductID INNER JOIN [Transaction] T ON T.InvoiceNo = tl.InvoiceNo WHERE TransactionDate >= @DateFrom AND TransactionDate <= @DateTo GROUP BY tl.InvoiceNo) as PCost ON PCost.InvoiceNo = T.InvoiceNo WHERE TransactionDate >= @DateFrom AND TransactionDate <= @DateTo"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom)
            cmd.Parameters.AddWithValue("@DateTo", DateTo)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmListTransactions.ListView1.Items.Clear()
            totalAmount = 0
            totalProfit = 0
            totalDiscount = 0
            totalAdditionalProfit = 0
            Do While dr.Read = True
                totalAmount = totalAmount + dr(2)
                totalProfit = totalProfit + dr(4)
                totalDiscount = totalDiscount + dr(8)
                totalAdditionalProfit = totalAdditionalProfit + dr(9)

                x = New ListViewItem(Format(dr(0), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(Format(dr(2), "N2"))
                x.SubItems.Add(Format(dr(3), "N2"))
                x.SubItems.Add(Format(dr(4), "N2"))
                x.SubItems.Add(Format(dr(5), "N2"))
                x.SubItems.Add(Format(dr(6), "N2"))
                x.SubItems.Add(dr(7).ToString())
                x.SubItems.Add(Format(dr(8), "N2"))
                x.SubItems.Add(Format(dr(9), "N2"))
                x.SubItems.Add(dr(10).ToString())
                frmListTransactions.ListView1.Items.Add(x)
            Loop

            With frmListTransactions
                .lblTotalAmount.Text = Format(totalAmount, "N2").ToString()
                .lblTotalProfit.Text = Format(totalProfit, "N2").ToString()
                .lblTotalDiscount.Text = Format(totalDiscount, "N2").ToString()
                .lblAdditionalProfit.Text = Format(totalAdditionalProfit, "N2").ToString()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadTransactionLineItem(ByVal InvoiceNo As String)
        Try
            sqL = "SELECT GenericName, TradeName, ItemPrice, TL.Quantity, TL.ExtendedPrice, TL.Discount, TL.TotalAmount FROM TransactionLineItem TL INNER JOIN Product P ON TL.ProductId = P.ProductId Where InvoiceNo =@InvoiceNo"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmListTransactions.ListView2.Items.Clear()

            Do While dr.Read = True
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(Format(dr(2), "N2").ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(Format(dr(4), "N2").ToString())
                x.SubItems.Add(Format(dr(5), "N2").ToString())
                x.SubItems.Add(Format(dr(6), "N2").ToString())

                frmListTransactions.ListView2.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
End Module
