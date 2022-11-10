Imports System.Data.SqlClient

Module modLoadSelect


    Public Sub LoadCompany_Select()
        Try
            sqL = "SELECT CompanyID, Name, Address, Phone FROM Company WHERE Name LIKE '" & frmLoadCompany.TextBox1.Text & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmLoadCompany.ListView1.Items.Clear()

            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1))
                x.SubItems.Add(dr(2))
                x.SubItems.Add(dr(3))

                frmLoadCompany.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadProduct_Select(ByVal fieldName As String, ByVal fieldValue As String)
        Try
            sqL = "SELECT ProductId, TradeName, GenericName, DrugType, CostPrice, Quantity, ProductCode FROM Product WHERE " & fieldName & " LIKE '" & fieldValue & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmLoadProduct.ListView1.Items.Clear()
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())
                x.SubItems.Add(dr(6).ToString())

                frmLoadProduct.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub


    Public Sub LoadEmployee_Select(ByVal lastname As String)
        Try
            sqL = "SELECT EmployeeID, Lastname, Firstname, Middlename, Gender, Age, MobileNo, EmailAddress FROM Employee WHERE Lastname LIKE '" & lastname & "%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            Dim x As ListViewItem
            frmLoadEmployee.ListView1.Items.Clear()

            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1))
                x.SubItems.Add(dr(2))
                x.SubItems.Add(dr(3))
                x.SubItems.Add(dr(4))
                x.SubItems.Add(dr(5))
                x.SubItems.Add(dr(6))
                x.SubItems.Add(dr(7))

                frmLoadEmployee.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
End Module
