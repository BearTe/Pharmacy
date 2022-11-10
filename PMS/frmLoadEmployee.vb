Public Class frmLoadEmployee

    Private Sub frmLoadEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadEmployee_Select(TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        LoadEmployee_Select(TextBox1.Text)
    End Sub

    Private Sub ListView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If frmAddEditExpenses.isAddExpenses = True Then
            frmAddEditExpenses.txtEmployee.Tag = ListView1.FocusedItem.Text
            frmAddEditExpenses.txtEmployee.Text = ListView1.FocusedItem.SubItems(1).Text & ", " & ListView1.FocusedItem.SubItems(2).Text & " " & ListView1.FocusedItem.SubItems(3).Text
            frmAddEditExpenses.isAddExpenses = False
        End If

        If frmUser.isUserEmployee = True Then
            frmUser.txtEmployee.Tag = ListView1.FocusedItem.Text
            frmUser.txtEmployee.Text = ListView1.FocusedItem.SubItems(1).Text & ", " & ListView1.FocusedItem.SubItems(2).Text & " " & ListView1.FocusedItem.SubItems(3).Text
            frmUser.isUserEmployee = False
        End If
        Me.Close()
    End Sub
End Class