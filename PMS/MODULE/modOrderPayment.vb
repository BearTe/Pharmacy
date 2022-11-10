
Imports System.Data.SqlClient
Module modOrderPayment
    Dim totalOrderPayment As Double
    Dim totalOrderAmount As Double
    Dim orderBalance As Double

    Public Sub AddEditOrderPayment(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO [OrderPayment](OrderNo, CompanyName, PaidDate, ReceiptNo,  PaidAmount) VALUES(@OrderNo, @CompanyName, @PaidDate, @ReceiptNo,  @PaidAmount)"
            Else
                sqL = "UPDATE [OrderPayment] SET OrderNo = @OrderNo, CompanyName=@CompanyName, PaidDate=@PaidDate, ReceiptNo=@ReceiptNo,  PaidAmount=@PaidAmount WHERE OrderPaymentId=@OrderPaymentId"
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditOrderPayment
                cmd.Parameters.AddWithValue("@OrderNo", .txtOrderNo.Text)
                cmd.Parameters.AddWithValue("@CompanyName", .txtCompany.Text)
                cmd.Parameters.AddWithValue("@PaidDate", .dtpPaidDate.Value)
                cmd.Parameters.AddWithValue("@ReceiptNo", .txtReceiptNo.Text)
                cmd.Parameters.AddWithValue("@PaidAmount", Val(.txtPaidAmount.Text.Replace(",", "")))

                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@OrderPaymentId", Val(.txtOrderNo.Tag))
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Order Payment Information Successfully Added", MsgBoxStyle.Information, "Adding Order Payment")
                Else
                    MsgBox("Order Payment Information Successfully Updated", MsgBoxStyle.Information, "Editing Order Payment")
                End If

            Else
                MsgBox("Saving Order Payment Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadOrderListPayment(ByVal CompanyName As String)

        Try
            sqL = "SELECT OrderPaymentId, OrderNo, CompanyName, PaidDate, ReceiptNo,  PaidAmount FROM OrderPayment WHERE CompanyName LIKE '" & CompanyName & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            frmListOrderPayment.ListView1.Items.Clear()
            totalOrderPayment = 0
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(Format(dr(5), "N2").ToString())
                totalOrderPayment += dr(5)
                frmListOrderPayment.ListView1.Items.Add(x)
            Loop

            With frmListOrderPayment
                .lblTotalOrderAmount.Text = Format(GetTotalOrderAmount(CompanyName), "N2").ToString()
                .lblTotalOrderPayment.Text = Format(GetTotalOrderPayment(CompanyName), "N2").ToString()
                .lblBalance.Text = Format(GetTotalOrderAmount(CompanyName) - totalOrderPayment, "N2").ToString()
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetOrderPaymentInfo(ByVal OrderPaymentId As Integer)
        Try
            sqL = "SELECT OrderPaymentId, OrderNo, CompanyName, PaidDate, ReceiptNo,  PaidAmount FROM OrderPayment WHERE OrderPaymentId=@OrderPaymentId"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@OrderPaymentId", OrderPaymentId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditOrderPayment
                    .txtOrderNo.Tag = dr(0).ToString()
                    .txtOrderNo.Text = dr(1).ToString()
                    .txtCompany.Text = dr(2).ToString()
                    .dtpPaidDate.Value = dr(3)
                    .txtReceiptNo.Text = dr(4).ToString()
                    .txtPaidAmount.Text = Format(dr(5), "N2").ToString()

                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Public Sub LoadCompany()
        Try
            sqL = "SELECT DISTINCT [Name] FROM Company ORDER BY [Name]"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader
            frmListOrderPayment.cmbCompany.Items.Clear()
            Do While dr.Read
                frmListOrderPayment.cmbCompany.Items.Add(dr(0).ToString())
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Function GetTotalOrderAmount(ByVal CompanyName As String) As Double
        Dim retDouble As Double
        Try
            sqL = "SELECT SUM(OrderTotalAmount) as TotalOrder FROM [Order] O Inner Join Company C ON C.CompanyId = O.CompanyId  WHERE C.Name= '" & CompanyName & "' GROUP BY C.Name"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read Then
                retDouble = dr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        Return retDouble
    End Function


    Public Function GetTotalOrderPayment(ByVal CompanyName As String) As Double
        Dim retDouble As Double
        Try
            sqL = "SELECT SUM(PaidAmount) as TotalPayment FROM [OrderPayment]   WHERE CompanyName = '" & CompanyName & "' GROUP BY CompanyName"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            If dr.Read Then
                retDouble = dr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
        Return retDouble
    End Function
End Module
