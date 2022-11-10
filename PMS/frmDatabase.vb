Public Class frmDatabase
    Private TstServerSql As String
    Private TstPortSql As String
    Private TstUserNameSql As String
    Private TstPwdSql As String
    Private TstDBNameSql As String
    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        'Test database connection

        TstServerSql = txtServerHost.Text
        TstUserNameSql = txtUserName.Text
        TstPwdSql = txtPassword.Text
        TstDBNameSql = txtDatabase.Text


        Try
            conn.ConnectionString = "Server = '" & TstServerSql & "';  " _
                                         & "Database = '" & TstDBNameSql & "'; " _
                                         & "user id = '" & TstUserNameSql & "'; " _
                                         & "password = '" & TstPwdSql & "'"


            conn.Open()
            MsgBox("Test connection successful", MsgBoxStyle.Information, "Database Settings")

        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")

        End Try
        Call DisconnMy()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        TstServerSql = txtServerHost.Text
        TstPortSql = txtPort.Text
        TstUserNameSql = txtUserName.Text
        TstPwdSql = txtPassword.Text
        TstDBNameSql = txtDatabase.Text

        Try
            conn.ConnectionString = "Server = '" & TstServerSql & "';  " _
                                         & "Database = '" & TstDBNameSql & "'; " _
                                         & "user id = '" & TstUserNameSql & "'; " _
                                         & "password = '" & TstPwdSql & "'"
            conn.Open()

            DBNameSql = txtDatabase.Text
            ServerSql = txtServerHost.Text
            UserNameSql = txtUserName.Text
            PwdSql = txtPassword.Text

            Call SaveData()
            Me.Close()
        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")
        End Try
        Call DisconnMy()
        'save database
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Location = New Point(166, 122)
        txtServerHost.Text = ServerSql
        txtUserName.Text = UserNameSql
        txtPassword.Text = PwdSql
        txtDatabase.Text = DBNameSql
    End Sub
End Class