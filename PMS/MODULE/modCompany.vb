Imports System.Data.SqlClient
Module modCompany

    Public Sub AddEditCompany(ByVal isAdding As Boolean)
        Try
            If isAdding = True Then
                sqL = "INSERT INTO Company(Name, Address, Phone, ContactPerson, ContactPersonNo) VALUES(@Name, @Address, @Phone, @ContactPerson, @ContactPersonNo)"
            Else
                sqL = "UPDATE Company SET Name=@Name, Address=@Address, Phone=@Phone, ContactPerson=@ContactPerson, ContactPersonNo=@ContactPersonNo WHERE CompanyID=@CompanyID "
            End If
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            With frmAddEditCompany
                cmd.Parameters.AddWithValue("@Name", .txtCompanyName.Text)
                cmd.Parameters.AddWithValue("@Address", .txtAddress.Text)
                cmd.Parameters.AddWithValue("@Phone", .txtPhoneNo.Text)
                cmd.Parameters.AddWithValue("@ContactPerson", .txtContactPerson.Text)
                cmd.Parameters.AddWithValue("@ContactPersonNo", .txtContactNo.Text)
                If isAdding = False Then
                    cmd.Parameters.AddWithValue("@CompanyID", .txtCompanyName.Tag)
                End If
            End With

            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                If isAdding = True Then
                    MsgBox("Company Information Successfully Added", MsgBoxStyle.Information, "Adding Company")
                Else
                    MsgBox("Company Information Successfully Updated", MsgBoxStyle.Information, "Editing Company")
                End If

            Else
                MsgBox("Saving Company Information Failed", MsgBoxStyle.Exclamation, "Failed")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub LoadCompanyList(ByVal companyName As String)
        Try
            sqL = "SELECT CompanyID, Name, Address, Phone, ContactPerson, ContactPersonNo FROM Company WHERE Name LIKE @Name +'%'"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@Name", companyName)
            dr = cmd.ExecuteReader

            frmListCompany.ListView1.Items.Clear()
            Dim x As ListViewItem
            Do While dr.Read
                x = New ListViewItem(dr(0).ToString())
                x.SubItems.Add(dr(1).ToString())
                x.SubItems.Add(dr(2).ToString())
                x.SubItems.Add(dr(3).ToString())
                x.SubItems.Add(dr(4).ToString())
                x.SubItems.Add(dr(5).ToString())

                frmListCompany.ListView1.Items.Add(x)
            Loop
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Public Sub GetCompanyInfo(ByVal CompanyID As Integer)
        Try
            sqL = "SELECT CompanyID, Name, Address, Phone, ContactPerson, ContactPersonNo FROM Company WHERE CompanyID = @CompanyID"
            ConnDB()
            cmd = New SqlCommand(sqL, conn)
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID)
            dr = cmd.ExecuteReader

            If dr.Read Then
                With frmAddEditCompany
                    .txtCompanyName.Tag = dr(0)
                    .txtCompanyName.Text = dr(1)
                    .txtAddress.Text = dr(2)
                    .txtPhoneNo.Text = dr(3)
                    .txtContactPerson.Text = dr(4)
                    .txtContactNo.Text = dr(5)
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
