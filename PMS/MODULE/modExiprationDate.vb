
Imports System.Data.SqlClient
Module modExiprationDate

    Dim ctrExpired As Integer


    Public Sub LoadExpiredProduct()
        Try
            sqL = "SELECT DISTINCT StockId FROM Stock S INNER JOIN Product P ON S.ProductId = P.ProductId WHERE ExpirationDate <= '" & Date.Now.ToString("yyyy-MM-dd") & "' AND (IsViewed = '' OR IsViewed is null)"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader
            ctrExpired = 0
            If dr.HasRows Then
                Do While dr.Read
                    ctrExpired = ctrExpired + 1
                Loop

                If MsgBox(ctrExpired & " Expired Products. Do you want to view?", MsgBoxStyle.YesNo, "Expired Products") = MsgBoxResult.Yes Then
                    frmListExpiredStocks.ShowDialog()
                End If
            End If
          

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadListofExpiredProducts()
        Try
            sqL = "SELECT StockId, GenericName, TradeName, ExpirationDate, StockDate  FROM Stock S INNER JOIN Product P ON S.ProductId = P.ProductId WHERE ExpirationDate <= '" & Date.Now.ToString("yyyy-MM-dd") & "'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader
            Dim x As ListViewItem
            frmListExpiredStocks.ListView1.Items.Clear()

            Do While dr.Read
                x = New ListViewItem(dr(0).ToString)
                x.SubItems.Add(dr(1).ToString)
                x.SubItems.Add(dr(2).ToString)
                x.SubItems.Add(Format(dr(3), "MM/dd/yyyy").ToString())
                x.SubItems.Add(Format(dr(4), "MM/dd/yyyy").ToString())
                frmListExpiredStocks.ListView1.Items.Add(x)
            Loop


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub IsViewedSetToYes(ByVal StockId As Integer)
        Try
            sqL = "Update STOCK set IsViewed = 'YES' WHERE StockId = " & StockId & ""
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.ExecuteNonQuery()
           

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

End Module
