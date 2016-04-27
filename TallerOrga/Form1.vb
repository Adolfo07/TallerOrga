Public Class Form1

    Private Sub TextBox_Enviado_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Enviado.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim envio = TextBox_Enviado.Text.ElementAt(0)
            EnviarPorPuertoSerial(envio)
        End If
    End Sub

    Private Sub EnviarPorPuertoSerial(ByVal caracter As Char)
        Dim numero = Convert.ToInt16(caracter)
        MessageBox.Show("Se envió: " & caracter & vbCrLf & "Código ASCII: " & numero)
        Dim binario = MostrarBinario(numero)
        Dim i As Int16
        For i = 1 To 8
            Dim bit = binario.ElementAt(i)
            If bit = "1" Then
                CType(Me.Controls.Find("PictureBox" & i, True).First(), PictureBox).Image = ImageList1.Images(1)
            ElseIf bit = "0" Then
                CType(Me.Controls.Find("PictureBox" & i, True).First(), PictureBox).Image = ImageList1.Images(0)
            End If
        Next
        'SerialPort1.Open()
        'SerialPort1.Write(caracter)
        'SerialPort1.Close()
    End Sub

    Private Function MostrarBinario(ByVal numero As Int32) As String
        Dim binario As String = ""
        Do While numero >= 2
            binario = (numero Mod 2) & binario
            numero = Int(numero / 2)
        Loop
        binario = numero & binario
        For i = binario.Length To 8
            binario = "0" & binario
        Next
        Return binario
    End Function

End Class
