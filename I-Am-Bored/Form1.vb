Imports System.IO

Public Class Form1
    Dim sfxController As Boolean = True
    Dim Desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Dim objWriter As New System.IO.StreamWriter(Desktop & "save.txt", False)
    Private Sub sfx()
        If sfxController = True Then
            My.Computer.Audio.Play(My.Resources.kaching, AudioPlayMode.Background)
        End If

        If sfxController = False Then
            sfxController = False
        Else
            sfxController = True
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        System.Diagnostics.Process.Start("http://patreon.com/SlipSerum")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Static hits As Integer = 0
        hits += 1

        Label1.Text = hits.ToString("n0")
        sfx()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim Desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        objWriter.WriteLine(Label1.Text)
        objWriter.Close()
        If My.Computer.FileSystem.FileExists(Desktop & "\save.txt") Then
            MsgBox("Saved.")
        Else
            MsgBox("Save Unsuccessful. Please send error code 503 to the issues section on github.com/SlipSerum/I-Am-Bored")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim Desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim oFS As StreamReader = File.OpenText(Desktop & "\save.txt")
        Label1.Text = oFS.ReadLine
        If My.Computer.FileSystem.FileExists(Desktop & "\save.txt") Then
            readSave()
            MsgBox("Save imported.")
        Else
            MsgBox("Save not found. Please send error code 502 to the issues section on github.com/SlipSerum/I-Am-Bored")
        End If

    End Sub

    Private Sub readSave()
        Label1.Text = File.OpenText(Desktop & "\save.txt").ReadLine
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Visible = False
        Button5.Visible = True
        sfxController = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Visible = False
        Button6.Visible = True
        sfxController = True
    End Sub

End Class
