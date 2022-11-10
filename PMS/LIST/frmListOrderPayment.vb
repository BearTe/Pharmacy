Public Class frmListOrderPayment

    Dim strOrderNo As String

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                isAddingData = False
                frmAddEditOrderPayment.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        isAddingData = True
        frmAddEditOrderPayment.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        strOrderNo = InputBox("Enter Order Number ", "SEARCH ORDER", " ")
        If strOrderNo = " " Then
            LoadOrderListPayment(strOrderNo.Trim)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub frmListOrderPayment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCompany()
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        LoadOrderListPayment(cmbCompany.Text)
    End Sub
End Class