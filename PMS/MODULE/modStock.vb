Imports System.Data.SqlClient

Module modStock

    Public Sub AddEditStock(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO Stock(ProductID, StockQuantity, StockDate, ManufactureDate, ExpirationDate, SupplierID, Packing) VALUES(@ProductID, @StockQuantity, @StockDate, @ManufacturerDate, @ExpirationDate, @SupplierID, @Packing)"
            Else
                sqL = "UPDATE Stock SET ProductID=@ProductID, StockQuantity=@StockQuantity, StockDate=@StockDate, ManufactureDate=@ManufacturerDate, ExpirationDate=@ExpirationDate, SupplierID=@SupplierID, Packing=@Packing WHERE StockId=@StockId"
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditStock
                cmd.Parameters.AddWithValue("@ProductID", frmListProduct.productID)
                cmd.Parameters.AddWithValue("@StockQuantity", .txtStockQuantity.Text)
                cmd.Parameters.AddWithValue("@StockDate", .dtpStockDate.Value)
                cmd.Parameters.AddWithValue("@ManufacturerDate", .dtpManufacture.Value)
                cmd.Parameters.AddWithValue("@ExpirationDate", .dtpExpiration.Value)
                cmd.Parameters.AddWithValue("@SupplierID", .txtManufacturer.Tag)
                cmd.Parameters.AddWithValue("@Packing", .txtPacking.Text)
                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@StockId", .txtMedicine.Tag)
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Stock Information Successfully Added", MsgBoxStyle.Information, "Adding Stock")
                Else
                    MsgBox("Stock Information Successfully Updated", MsgBoxStyle.Information, "Editing Stock")
                End If

            Else
                MsgBox("Saving Stock Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadStockList(ByVal productID As Integer)
        Try
            sqL = "SELECT StockId, StockDate, Name as Manufacturer, ManufactureDate, ExpirationDate, Packing,  StockQuantity FROM Stock S INNER JOIN Company C ON S.SupplierID = C.CompanyID WHERE ProductID=@ProductID"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ProductID", productID)
            dr = cmd.ExecuteReader

            frmListProduct.ListView2.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(Format(dr(1), "MM/dd/yyyy"))
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy"))
                x.SubItems.Add(Format(dr(4), "MM/dd/yyyy"))
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(dr(6).ToString())

                frmListProduct.ListView2.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadStockList(ByVal productID As Integer, ByVal DateFrom As Date, ByVal DateTo As Date)
        Try
            sqL = "SELECT StockId, StockDate, Name as Manufacturer, ManufactureDate, ExpirationDate, Packing,  StockQuantity FROM Stock S INNER JOIN Company C ON S.SupplierID = C.CompanyID WHERE ProductID=@ProductID AND StockDate BETWEEN @DateFrom AND @DateTo"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ProductID", productID)
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom)
            cmd.Parameters.AddWithValue("@DateTo", DateTo)
            dr = cmd.ExecuteReader

            frmListProduct.ListView2.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(Format(dr(1), "MM/dd/yyyy"))
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy"))
                x.SubItems.Add(Format(dr(4), "MM/dd/yyyy"))
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(dr(6).ToString())

                frmListProduct.ListView2.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetStockInfo(ByVal StockId As Integer)
        Try
            sqL = "SELECT StockId, Tradename, StockDate, SupplierId, Name as Manufacturer, ManufactureDate, ExpirationDate,S.Packing,  StockQuantity FROM Stock S INNER JOIN Company C ON S.SupplierID = C.CompanyID INNER JOIN Product P ON P.ProductId = S.ProductId  WHERE StockId=@StockId"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@StockId", StockId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditStock
                    .txtMedicine.Tag = dr(0).ToString()
                    .txtMedicine.Text = dr(1).ToString()
                    .dtpStockDate.Value = dr(2)
                    .txtManufacturer.Tag = dr(3)
                    .txtManufacturer.Text = dr(4)
                    .dtpManufacture.Value = dr(5)
                    .dtpExpiration.Value = dr(6)
                    .txtPacking.Text = dr(7).ToString
                    .txtStockQuantity.Text = dr(8)
                    frmAddEditStock.oldStockNo = dr(8)
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub UpdateProductStock_Increasing(ByVal productID As Integer, ByVal stockQuantity As Integer)
        Try
            sqL = "UPDATE Product Set Quantity = ISNULL(Quantity,0) + " & stockQuantity & " WHERE ProductId= " & productID & ""
            ConnDB()
            cmd = New SqlCommand(sqL, conn)

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                Dim strtest As String = "Test"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub UpdateProductStock_Descreasing(ByVal productID As Integer, ByVal stockQuantity As Integer)
        Try
            sqL = "UPDATE Product Set Quantity = Quantity - " & stockQuantity & " WHERE ProductId=@ProductId"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ProductId", productID)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

End Module
