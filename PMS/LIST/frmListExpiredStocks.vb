Public Class frmListExpiredStocks

    'Dim i As Integer

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        UpdateIsViewed()
        Me.Close()
    End Sub

    Public Sub UpdateIsViewed()
        For i = 0 To ListView1.Items.Count - 1
            IsViewedSetToYes(ListView1.Items(i).SubItems(0).Text)
        Next
    End Sub

    Private Sub frmListExpiredStocks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadListofExpiredProducts()
    End Sub

    Private Sub frmListExpiredStocks_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        UpdateIsViewed()
    End Sub
End Class