
Imports System.Data.SqlClient

Module modOrder
    Public Sub AddEditOrder(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO [Order](OrderNo, OrderDate, CompanyId, TotalQuantity,  TotalAmount, Status, EmployeeId, OrderDiscount, OrderTotalAmount, OrderComment, OrderInvoice) VALUES(@OrderNo, @OrderDate, @CompanyId, @TotalQuantity,  @TotalAmount, @Status, @EmployeeId, @OrderDiscount, @OrderTotalAmount, @OrderComment, @OrderInvoice)"
            Else
                sqL = "UPDATE [Order] SET OrderNo=@OrderNo, OrderDate=@OrderDate, CompanyId=@CompanyId, TotalQuantity=@TotalQuantity,  TotalAmount=@TotalAmount, Status=@Status, OrderDiscount=@OrderDiscount, OrderTotalAmount=@OrderTotalAmount, OrderComment=@OrderComment, OrderInvoice=@OrderInvoice WHERE OrderId=@OrderId"
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditOrder
                cmd.Parameters.AddWithValue("@OrderNo", .txtOrderNo.Text)
                cmd.Parameters.AddWithValue("@OrderDate", .dtpOrderDate.Value)
                cmd.Parameters.AddWithValue("@CompanyId", Val(.txtManufacturer.Tag))
                cmd.Parameters.AddWithValue("@TotalQuantity", Val(.txtTotalQuantity.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@TotalAmount", Val(.txtSubtotal.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@Status", .cmbStatus.Text)
                cmd.Parameters.AddWithValue("@EmployeeId", Val(.txtCreatedBy.Tag))
                cmd.Parameters.AddWithValue("@OrderDiscount", Val(.txtDiscount.Text))
                cmd.Parameters.AddWithValue("@OrderTotalAmount", Val(.txtTotalAmount.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@OrderComment", .txtComment.Text)
                cmd.Parameters.AddWithValue("@OrderInvoice", .txtOrderInvoice.Text)

                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@OrderId", Val(.txtOrderNo.Tag))
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Order Information Successfully Added", MsgBoxStyle.Information, "Adding Order")
                Else
                    MsgBox("Order Information Successfully Updated", MsgBoxStyle.Information, "Editing Order")
                End If

            Else
                MsgBox("Saving Order Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadOrderList(ByVal OrderNo As String)
        Try
            sqL = "SELECT OrderId, OrderNo, OrderInvoice, OrderDate, C.Name, TotalQuantity,  TotalAmount, Status, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as EmployeeName FROM [Order] O INNER JOIN Company C ON C.CompanyId = O.CompanyId INNER JOIN Employee E ON E.EmployeeId = O.EmployeeId WHERE OrderNo LIKE '" & OrderNo & "%' AND Status LIKE '" & frmListOrder.cmbStatus.Text & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            frmListOrder.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(Format(dr(6), "N2").ToString())
                x.SubItems.Add(dr(7).ToString())
                x.SubItems.Add(dr(8).ToString())

                frmListOrder.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub SelectLoadOrderList(ByVal OrderNo As String)
        Try
            sqL = "SELECT OrderId, OrderNo, OrderInvoice,  OrderDate, C.Name, TotalQuantity,  TotalAmount, Status, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as EmployeeName FROM [Order] O INNER JOIN Company C ON C.CompanyId = O.CompanyId INNER JOIN Employee E ON E.EmployeeId = O.EmployeeId WHERE OrderNo LIKE '" & OrderNo & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            frmLoadOrder.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(Format(dr(6), "N2").ToString())
                x.SubItems.Add(dr(7).ToString())
                x.SubItems.Add(dr(8).ToString())

                frmLoadOrder.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Public Sub LoadOrderList(ByVal DateFrom As Date, ByVal DateTo As Date)
        Try
            sqL = "SELECT OrderId, OrderNo, OrderInvoice, OrderDate, C.Name, TotalQuantity,  TotalAmount, Status, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as EmployeeName FROM [Order] O INNER JOIN Company C ON C.CompanyId = O.CompanyId INNER JOIN Employee E ON E.EmployeeId = O.EmployeeId WHERE OrderDate >= @DateFrom AND OrderDate <= @DateTo"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom)
            cmd.Parameters.AddWithValue("@DateTo", DateTo)
            dr = cmd.ExecuteReader

            frmListOrder.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(Format(dr(6), "N2").ToString())
                x.SubItems.Add(dr(7).ToString())
                x.SubItems.Add(dr(8).ToString())

                frmListOrder.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetOrderInfo(ByVal OrderId As Integer)
        Try
            sqL = "SELECT OrderId, OrderNo,  OrderDate, O.CompanyId, C.Name, TotalQuantity,  TotalAmount, Status, O.EmployeeId, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) as EmployeeName, OrderDiscount, OrderTotalAmount, OrderComment, OrderInvoice FROM [Order] O INNER JOIN Company C ON C.CompanyId = O.CompanyId INNER JOIN Employee E ON E.EmployeeId = O.EmployeeId WHERE OrderNo = '" & OrderId & "'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@OrderId", OrderId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditOrder
                    .txtOrderNo.Tag = dr(0).ToString()
                    .txtOrderNo.Text = dr(1).ToString()
                    .dtpOrderDate.Value = dr(2)
                    .txtManufacturer.Tag = dr(3).ToString()
                    .txtManufacturer.Text = dr(4).ToString()
                    .txtTotalQuantity.Text = dr(5).ToString()
                    .txtSubtotal.Text = dr(6).ToString()
                    .cmbStatus.Text = dr(7).ToString()
                    .txtCreatedBy.Tag = dr(8).ToString
                    .txtCreatedBy.Text = dr(9).ToString
                    .txtDiscount.Text = dr(10).ToString
                    .txtTotalAmount.Text = dr(11).ToString
                    .txtComment.Text = dr(12).ToString
                    .txtOrderInvoice.Text = dr(13).ToString
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    '++++++++++++++++++++++++++++++++++++ORDER PRODUCTS+++++++++++++++++++++++++++++++++++++++++++++++++++
    Public Sub AddEditOrderProduct()
        Try
            sqL = "INSERT INTO OrderLineItem(ProductId, Quantity, CostPrice, ExtendedPrice, Discount, TotalPrice) VALUES(@ProductId, @Quantity, @CostPrice, @ExtendedPrice, @Discount, @TotalPrice)"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

    End Sub

    Public Sub LoadOrderProductList(ByVal orderNo As String)
        Try
            sqL = "SELECT GenericName, TradeName,  OL.CostPrice, OL.Quantity, ExtendedPrice, TotalPrice FROM OrderLineItem OL INNER JOIN Product P ON P.ProductId = OL.ProductId WHERE OrderNo = '" & orderNo & "'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmListOrder.ListView2.Items.Clear()

            Do While dr.Read = True
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(Format(dr(2), "N2").ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(Format(dr(4), "N2").ToString())
                x.SubItems.Add(Format(dr(5), "N2").ToString())

                frmListOrder.ListView2.Items.Add(x)

            Loop
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

    End Sub

    Public Sub LoadAddEditOrderProductList(ByVal orderNo As String)
        Try
            sqL = "SELECT GenericName, TradeName, OL.Quantity, OL.CostPrice, ExtendedPrice, TotalPrice FROM OrderLineItem OL INNER JOIN Product P ON P.ProductId = OL.ProductId WHERE OrderNo = '" & orderNo & "'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmAddEditOrder.ListView1.Items.Clear()

            Do While dr.Read = True
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())

                frmAddEditOrder.ListView1.Items.Add(x)

            Loop
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            cmd.Dispose()
            conn.Close()
        End Try

    End Sub

    Public Sub AddOrderProduct(ByVal ProductID As Integer, ByVal Quantity As Integer, ByVal CostPrice As Double, ByVal ExtendedPrice As Double, ByVal TotalPrice As Double, ByVal OrderNo As String)
        Try
            sqL = "INSERT INTO OrderLineItem(ProductId, Quantity, Costprice, ExtendedPrice, TotalPrice, OrderNo) VALUES(@ProductId, @Quantity, @Costprice, @ExtendedPrice, @TotalPrice, @OrderNo)"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ProductId", ProductID)
            cmd.Parameters.AddWithValue("@Quantity", Quantity)
            cmd.Parameters.AddWithValue("@Costprice", CostPrice)
            cmd.Parameters.AddWithValue("@ExtendedPrice", ExtendedPrice)
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice)
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    '=======================================================================

    'Public Sub LoadOrderListPayment_Order(ByVal OrderNo As String)
    '    Try
    '        sqL = "SELECT OrderPaymentId, OrderNo, CompanyName, PaidDate, ReceiptNo,  PaidAmount FROM OrderPayment WHERE ORDERNo LIKE '" & OrderNo & "%'"
    '        ConnDB()
    '        cmd = New SqlCommand(sqL, conn)
    '        dr = cmd.ExecuteReader

    '        frmListOrder.ListView3.Items.Clear()
    '        Dim x As ListViewItem
    '        Do While dr.Read
    '            x = New ListViewItem(dr(0).ToString())
    '            x.SubItems.Add(dr(1).ToString())
    '            x.SubItems.Add(dr(2).ToString())
    '            x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
    '            x.SubItems.Add(dr(4).ToString())
    '            x.SubItems.Add(Format(dr(5), "N2").ToString())

    '            frmListOrder.ListView3.Items.Add(x)
    '        Loop
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        cmd.Dispose()
    '        conn.Close()
    '    End Try
    'End Sub
End Module
