Imports System.Data.SqlClient
Module modProduct

    Public Sub AddEditProduct(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO Product(ProductCode, Tradename, GenericName, DrugType,  Unit, UnitValue, CostPrice, ProfitPercent, SellingPrice, Instruction, Packing) Values(@ProductCode, @Tradename, @GenericName, @DrugType, @Unit, @UnitValue, @CostPrice, @ProfitPercent, @SellingPrice, @Instruction, @Packing)"
            Else
                sqL = "UPDATE Product SET ProductCode=@ProductCode, Tradename=@Tradename, GenericName=@GenericName, DrugType=@DrugType, Unit=@Unit, UnitValue=@UnitValue, CostPrice=@CostPrice, ProfitPercent=@ProfitPercent, SellingPrice=@SellingPrice, Instruction=@Instruction, Packing=@Packing WHERE ProductId=@ProductId"
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditProduct
                cmd.Parameters.AddWithValue("@ProductCode", .txtMedicineCode.Text)
                cmd.Parameters.AddWithValue("@Tradename", .txtTradeName.Text)
                cmd.Parameters.AddWithValue("@GenericName", .txtGenericName.Text)
                cmd.Parameters.AddWithValue("@DrugType", .cmbDrugType.Text)
                cmd.Parameters.AddWithValue("@Unit", .txtUnit.Text)
                cmd.Parameters.AddWithValue("@UnitValue", .txtUnitvalue.Text)
                cmd.Parameters.AddWithValue("@CostPrice", Val(.txtCostPrice.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@ProfitPercent", .txtProfitPercent.Text)
                cmd.Parameters.AddWithValue("@SellingPrice", Val(.txtSellingPrice.Text.Replace(",", "")))
                cmd.Parameters.AddWithValue("@Instruction", .txtInstruction.Text)
                cmd.Parameters.AddWithValue("@Packing", .txtPacking.Text)
                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@ProductId", .txtMedicineCode.Tag)
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Product Information Successfully Added", MsgBoxStyle.Information, "Adding Product")
                Else
                    MsgBox("Product Information Successfully Updated", MsgBoxStyle.Information, "Editing Product")
                End If

            Else
                MsgBox("Saving Product Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub DeleteProduct(ByVal productID As Integer)
        Try
            sqL = "DELETE FROM Product WHERE ProductID = " & productID & ""
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            Dim i As Integer
            i = cmd.ExecuteNonQuery

            If i > 0 Then
                MsgBox("Product successfully deleted.", MsgBoxStyle.Information, "Delete Product")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadProductList(ByVal fieldName As String, ByVal fieldValue As String)
        Try
            sqL = "SELECT ProductId, ProductCode, Tradename, GenericName, DrugType, Unit, Unitvalue, Quantity, CostPrice, ProfitPercent, SellingPrice, Instruction FROM Product WHERE " & fieldName & " LIKE '" & fieldValue & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            frmListProduct.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(dr(6).ToString())
                x.SubItems.Add(dr(7).ToString())
                x.SubItems.Add(FormatNumber(dr(8)).ToString())
                x.SubItems.Add(dr(9).ToString())
                x.SubItems.Add(FormatNumber(dr(10)).ToString())
                x.SubItems.Add(dr(11).ToString())

                frmListProduct.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetProductInfo(ByVal ProductId As Integer)
        Try
            sqL = "SELECT ProductId, ProductCode, Tradename, GenericName, DrugType, Unit, Unitvalue, Quantity, CostPrice, ProfitPercent, SellingPrice, Instruction FROM Product WHERE ProductId = @ProductId"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ProductId", ProductId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditProduct
                    .txtMedicineCode.Tag = dr(0).ToString
                    .txtMedicineCode.Text = dr(1).ToString
                    .txtTradeName.Text = dr(2).ToString
                    .txtGenericName.Text = dr(3).ToString
                    .cmbDrugType.Text = dr(4).ToString
                    .txtUnit.Text = dr(5).ToString
                    .txtUnitvalue.Text = dr(6).ToString
                    .txtQuantity.Text = dr(7).ToString
                    .txtCostPrice.Text = FormatNumber(dr(8)).ToString
                    .txtProfitPercent.Text = dr(9).ToString
                    .txtSellingPrice.Text = FormatNumber(dr(10)).ToString
                    .txtInstruction.Text = dr(11).ToString
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

End Module
