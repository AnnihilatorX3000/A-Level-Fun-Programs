'https://www.youtube.com/watch?v=_1IqpC_f_rA Source
Option Strict On

Imports System.Drawing

Public Class Form1
    'Create: PictureBox, 3 Buttons, 1 ComboBox, 1 ColourDialog
    Dim blnDraw As Boolean
    Dim clrDrawColour As Color = Color.Black
    Dim intDrawSize As Integer = 6

    Dim bmp As Bitmap

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'SET INITIAL BRUSH SIZE
        cmbSize.SelectedIndex = 2

        'POPULATE PictureBox Image Property
        bmp = New Bitmap(pboxPaint.Width, pboxPaint.Height)
        pboxPaint.Image = bmp

    End Sub

    Private Sub PaintBrush(X As Integer, Y As Integer)
        Using g As Graphics = Graphics.FromImage(pboxPaint.Image)
            g.FillRectangle(New SolidBrush(clrDrawColour), New Rectangle(X, Y, intDrawSize, intDrawSize))
        End Using

        pboxPaint.Refresh()
    End Sub

    Private Sub pboxPaint_MouseDown(sender As Object, e As MouseEventArgs) Handles pboxPaint.MouseDown
        blnDraw = True
        'FIRST PIXEL
        PaintBrush(e.X, e.Y)
    End Sub

    Private Sub pboxPaint_MouseMove(sender As Object, e As MouseEventArgs) Handles pboxPaint.MouseMove
        If blnDraw = True Then
            PaintBrush(e.X, e.Y)
        End If
    End Sub

    Private Sub pboxPaint_MouseUp(sender As Object, e As MouseEventArgs) Handles pboxPaint.MouseUp
        blnDraw = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        bmp = New Bitmap(pboxPaint.Width, pboxPaint.Height)
        pboxPaint.Image = bmp
    End Sub

    Private Sub cmbSize_SelectedIndesChanged(sender As Object, e As EventArgs) Handles cmbSize.SelectedIndexChanged
        intDrawSize = CInt(cmbSize.SelectedItem)
    End Sub

    Private Sub btnColour_Click(sender As Object, e As EventArgs) Handles btnColour.Click
        'If in colordialog, and select OK
        If clrDialog.ShowDialog() = DialogResult.OK Then
            clrDrawColour = clrDialog.Color
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        pboxPaint.DrawToBitmap(bmp, New Rectangle(0, 0, pboxPaint.Width, pboxPaint.Height))
        'Note: will save in DEBUG folder
        bmp.Save("Test1.bmp", Imaging.ImageFormat.Bmp)
        bmp = New Bitmap(pboxPaint.Width, pboxPaint.Height)
    End Sub
End Class
