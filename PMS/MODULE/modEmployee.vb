Imports System.Data.SqlClient

Module modEmployee

    Public Sub AddEditEmployee(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO Employee(Lastname, Firstname, Middlename, ContactPerson, Gender, Age, Address, MobileNo, EmailAddress, Salary, HireDate, Comment) VALUES(@Lastname, @Firstname, @Middlename, @ContactPerson, @Gender, @Age, @Address, @MobileNo, @EmailAddress, @Salary, @HireDate, @Comment)"
            Else
                sqL = "UPDATE Employee SET Lastname=@Lastname, Firstname=@Firstname, Middlename=@Middlename, ContactPerson=@ContactPerson, Gender=@Gender, Age=@Age, Address=@Address, MobileNo=@MobileNo, EmailAddress=@EmailAddress, Salary=@Salary, HireDate=@HireDate, Comment=@Comment WHERE EmployeeID=@EmployeeID "
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditEmployee
                cmd.Parameters.AddWithValue("@Lastname", .txtLastname.Text)
                cmd.Parameters.AddWithValue("@Firstname", .txtFirstName.Text)
                cmd.Parameters.AddWithValue("@MiddleName", .txtMiddleName.Text)
                cmd.Parameters.AddWithValue("@ContactPerson", .txtContactPerson.Text)
                cmd.Parameters.AddWithValue("@Gender", .cmbGender.Text)
                cmd.Parameters.AddWithValue("@Age", .txtAge.Text)
                cmd.Parameters.AddWithValue("@Address", .txtAddress.Text)
                cmd.Parameters.AddWithValue("@MobileNo", .txtMobileNo.Text)
                cmd.Parameters.AddWithValue("@EmailAddress", .txtEmailAddress.Text)
                cmd.Parameters.AddWithValue("@Salary", .txtSalary.Text)
                cmd.Parameters.AddWithValue("@HireDate", .txtHireDate.Text)
                cmd.Parameters.AddWithValue("@Comment", .txtComment.Text)
                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@EmployeeID", .txtLastname.Tag)
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Employee Information Successfully Added", MsgBoxStyle.Information, "Adding Employee")
                Else
                    MsgBox("Employee Information Successfully Updated", MsgBoxStyle.Information, "Editing Employee")
                End If

            Else
                MsgBox("Saving Employee Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadEmployeeList(ByVal lastname As String)
        Try
            sqL = "SELECT EmployeeID, Lastname, Firstname, Middlename, Gender, Age, MobileNo, EmailAddress, Salary, HireDate, ContactPerson FROM Employee WHERE Lastname LIKE @Lastname + '%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@Lastname", lastname)
            dr = cmd.ExecuteReader

            frmListEmployee.ListView1.Items.Clear()
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
                x.SubItems.Add(dr(8).ToString())
                x.SubItems.Add(Format(dr(9), "MM/dd/yyyy"))
                x.SubItems.Add(dr(10).ToString())

                frmListEmployee.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetEmployeeInfo(ByVal EmployeeID As Integer)
        Try
            sqL = "SELECT EmployeeID, Lastname, Firstname, Middlename, Gender, Age, MobileNo, EmailAddress, Salary, HireDate, ContactPerson, Comment FROM Employee WHERE EmployeeID=@EmployeeID"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditEmployee
                    .txtLastname.Tag = dr(0)
                    .txtLastname.Text = dr(1)
                    .txtFirstName.Text = dr(2)
                    .txtMiddleName.Text = dr(3)
                    .cmbGender.Text = dr(4)
                    .txtAge.Text = dr(5)
                    .txtMobileNo.Text = dr(6)
                    .txtEmailAddress.Text = dr(7)
                    .txtSalary.Text = dr(8)
                    .txtHireDate.Text = Format(dr(9), "MM/dd/yyyy")
                    .txtContactPerson.Text = dr(10)
                    .txtComment.Text = dr(11)
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
