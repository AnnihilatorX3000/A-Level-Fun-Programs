Public Class clsAnt
    Public xPos As Integer
    Public yPos As Integer
    Public intDir As Integer

    Public Sub CREATEANT(ByVal mousMapX As Integer, ByVal mousMapY As Integer, ByVal dir As Integer)
        xPos = mousMapX
        yPos = mousMapY
        intDir = dir
    End Sub

End Class
