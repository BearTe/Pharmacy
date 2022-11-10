Public Class frmListOrder
    Public orderNo As String = ""
    Public selectedOrderNo As String

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        isAddingData = True
        frmAddEditOrder.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)
        orderNo = InputBox("ENTER ORDER NO ", "Search Order by Order Number")
        LoadOrderList(orderNo)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            selectedOrderNo = ListView1.FocusedItem.SubItems(1).Text
            LoadOrderProductList(selectedOrderNo)
            'LoadOrderListPayment_Order(selectedOrderNo)
        Catch ex As Exception

        End Try

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
                frmAddEditOrder.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmListOrder_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadOrderList(dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub dtpTo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadOrderList(dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        LoadOrderList("")
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        If ListView1.Items.Count = 0 Then
            MsgBox("Please select record to update", MsgBoxStyle.Exclamation, "Update")
            Exit Sub
        End If
        Try
            If ListView1.FocusedItem.Text = "" Then

            Else
                frmOrderDetailReport.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class