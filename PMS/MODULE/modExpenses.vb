Imports System.Data.SqlClient

Module modExpenses

    Public Sub AddEditExpenses(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO Expenses(EmployeeId, Description, ExpensesDate, Amount) VALUES(@EmployeeId, @Description, @ExpensesDate, @Amount)"
            Else
                sqL = "UPDATE Expenses SET EmployeeId=@EmployeeId, Description=@Description, ExpensesDate=@ExpensesDate, Amount=@Amount WHERE ExpensesId = @ExpensesId "
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditExpenses
                cmd.Parameters.AddWithValue("@EmployeeId", .txtEmployee.Tag)
                cmd.Parameters.AddWithValue("@Description", .txtDescription.Text)
                cmd.Parameters.AddWithValue("@ExpensesDate", .dtpExpensesDate.Value)
                cmd.Parameters.AddWithValue("@Amount", Val(.txtAmount.Text.Replace(",", "")))
                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@ExpensesId", .txtDescription.Tag)
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Expenses Information Successfully Added", MsgBoxStyle.Information, "Adding Expenses")
                Else
                    MsgBox("Expenses Information Successfully Updated", MsgBoxStyle.Information, "Editing Expenses")
                End If

            Else
                MsgBox("Saving Expenses Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadExpensesList(ByVal Lastname As String)
        Try
            sqL = "SELECT Ex.EmployeeId, ExpensesDate, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) EmployeeName, Description,  Amount FROM Expenses Ex INNER JOIN Employee E ON Ex.EmployeeId = E.EmployeeId WHERE Lastname LIKE @Name +'%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@Name", Lastname)
            dr = cmd.ExecuteReader

            frmListExpenses.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(Format(dr(1), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3))
                x.SubItems.Add(Format(dr(4), "N2").ToString())
              
                frmListExpenses.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetExpensesInfo(ByVal ExpensesId As Integer)
        Try
            sqL = "SELECT ExpensesId, EmployeeId, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) EmployeeName, Description, ExpensesDate, Amount FROM Expenses WHERE ExpensesId=@ExpensesId"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@ExpensesId", ExpensesId)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditExpenses
                    .txtDescription.Tag = dr(0).ToString()
                    .txtEmployee.Tag = dr(1).ToString()
                    .txtEmployee.Text = dr(2).ToString()
                    .txtDescription.Text = dr(3).ToString()
                    .dtpExpensesDate.Value = dr(4)
                    .txtAmount.Text = Format(dr(5), "N2").ToString()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetListEmployee()
        Try
            sqL = "SELECT EmployeeID, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) EmployeeName FROM Employee ORDER BY Lastname, Firstname"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            dr = cmd.ExecuteReader

            frmListExpensesByEmployee.cmbEmployee.Items.Clear()
            Do While dr.Read
                frmListExpensesByEmployee.cmbEmployee.Items.Add(dr(1).ToString())
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetExpensesByEmployee(ByVal EName As String)
        Dim totExpenses As Double
        Try
            sqL = "SELECT ExpensesId,  ExpensesDate, CONCAT(Lastname, ', ', Firstname, ' ', Middlename) EmployeeName, Description,  Amount FROM Expenses E INNER JOIN Employee Em On E.EmployeeID = Em.EmployeeID WHERE CONCAT(Lastname, ', ', Firstname, ' ', Middlename) = @EName"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@EName", EName)
            dr = cmd.ExecuteReader
            totExpenses = 0
            frmListExpensesByEmployee.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                totExpenses = totExpenses + Val(dr(4))
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(Format(dr(1), "MM/dd/yyyy").ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3))
                x.SubItems.Add(Format(dr(4), "N2").ToString())

                frmListExpensesByEmployee.ListView1.Items.Add(x)
            Loop

            frmListExpensesByEmployee.lblTotalExpenses.Text = Format(totExpenses, "N2").ToString()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

End Module
