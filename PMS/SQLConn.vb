Imports System.Data.SqlClient
Module SQLConn
    Public ServerSql As String
    Public UserNameSql As String
    Public PwdSql As String
    Public DBNameSql As String
    Public sqL As String
    Public ds As New DataSet
    Public cmd As SqlCommand
    Public dr As SqlDataReader
    Public da As SqlDataAdapter

    Public isAddingData As Boolean

    Public conn As New SqlConnection

    Sub getData()
        Dim AppName As String = Application.ProductName

        Try
            DBNameSql = GetSetting(AppName, "DBSection", "DB_Name", "temp")
            ServerSql = GetSetting(AppName, "DBSection", "DB_IP", "temp")
            UserNameSql = GetSetting(AppName, "DBSection", "DB_User", "temp")
            PwdSql = GetSetting(AppName, "DBSection", "DB_Password", "temp")
        Catch ex As Exception
            MsgBox("System registry was not established, you can set/save " & _
            "these settings by pressing F1", MsgBoxStyle.Information)
        End Try

    End Sub

    Public Sub ConnDB()

        conn.Close()

        Try
            conn.ConnectionString = "Server = '" & ServerSql & "';  " _
                                         & "Database = '" & DBNameSql & "'; " _
                                         & "user id = '" & UserNameSql & "'; " _
                                         & "password = '" & PwdSql & "'"

            conn.Open()


        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")
        End Try

    End Sub

    Public Sub DisconnMy()

        conn.Close()
        conn.Dispose()

    End Sub

    Sub SaveData()
        Dim AppName As String = Application.ProductName

        SaveSetting(AppName, "DBSection", "DB_Name", DBNameSql)
        SaveSetting(AppName, "DBSection", "DB_IP", ServerSql)
        SaveSetting(AppName, "DBSection", "DB_User", UserNameSql)
        SaveSetting(AppName, "DBSection", "DB_Password", PwdSql)

        MsgBox("Database connection settings are saved.", MsgBoxStyle.Information)
    End Sub


    
End Module

