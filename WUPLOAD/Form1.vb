Imports System.Net
Public Class Form1
    Dim WithEvents web As New WebClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Try
                RichTextBox1.Text += "GET Upload Time: " + Date.Now.ToString + vbCrLf
                RichTextBox1.Text += "GET Method : " + TextBox2.Text + " To " + TextBox1.Text + " Uploading..."
                web.UploadFileAsync(New Uri(TextBox1.Text), "GET", TextBox2.Text)
            Catch ex As Exception
                RichTextBox1.Text += "GET Upload Fali..."
            End Try
        ElseIf RadioButton2.Checked = True Then
            Try
                RichTextBox1.Text += "POST Upload Time: " + Date.Now.ToString + vbCrLf
                RichTextBox1.Text += "POST Method : " + TextBox2.Text + " To " + TextBox1.Text + " Uploading..."
                web.UploadFileAsync(New Uri(TextBox1.Text), "POST", TextBox2.Text)
            Catch ex As Exception
                RichTextBox1.Text += "POST Upload Fali..."
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        TextBox2.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\Log.txt"
        SaveFileDialog1.Filter = "*.txt|*.txt|*.all|*.*"
        OpenFileDialog1.Filter = "*.all|*.*"
    End Sub
    Private Sub web_UploadFileCompleted(sender As Object, e As UploadFileCompletedEventArgs) Handles web.UploadFileCompleted
    End Sub
    Private Sub web_UploadProgressChanged(sender As Object, e As UploadProgressChangedEventArgs) Handles web.UploadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label3.Text = "Upload Status: " & e.BytesSent.ToString / 1000000 & " MB / " & e.TotalBytesToSend.ToString / 1000000 & " MB" + vbCrLf
        Label4.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value = 100 Then
            If RadioButton1.Checked = True Then
                RichTextBox1.Text += "GET Upload Successfly..." + vbCrLf
            ElseIf RadioButton2.Checked = True Then
                RichTextBox1.Text += "POST Upload Successfly..." + vbCrLf
            End If
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
        TextBox3.Text = SaveFileDialog1.FileName
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RichTextBox1.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.FileSystem.WriteAllText(TextBox3.Text, RichTextBox1.Text, True)
        MessageBox.Show("Successfly Save Log File Path: " + TextBox3.Text)
    End Sub
End Class
