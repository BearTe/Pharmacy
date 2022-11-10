Public Class frmListExpenses

    Public strEmpLastname As String = ""


    Private Sub ToolStripButton3_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                isAddingData = False
                frmAddEditExpenses.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        strEmpLastname = InputBox("Enter lastname of the Employee.", "Search Expenses By Employee", " ")

        If strEmpLastname = " " Then
            LoadExpensesList(strEmpLastname.Trim)
        End If


    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        isAddingData = True
        frmAddEditExpenses.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
End Class