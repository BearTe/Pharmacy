Public Class frmListEmployee

    Public strEmpLastname As String = ""


    Private Sub frmListEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadEmployeeList(strEmpLastname)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                isAddingData = False
                frmAddEditEmployee.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        isAddingData = True
        frmAddEditEmployee.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        strEmpLastname = InputBox("Enter Employee Last Name ", "SEARCH EMPLOYEE", " ")
        If strEmpLastname = " " Then
            LoadEmployeeList(strEmpLastname.Trim)
        End If

    End Sub
End Class