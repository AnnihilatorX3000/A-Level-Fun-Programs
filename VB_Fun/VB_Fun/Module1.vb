Imports System.IO
Module Module1
    Dim strName As String = ""
    Dim strAge As String = "" 'Age as string to prevent crashing
    Dim strGender As String = ""
    Dim strAntiCrasher As String = ""
    Dim strYesNo As String = ""
    Dim blnLooper As Boolean = True
    Dim intTimer As Integer = 0
    Sub Main()
        'Full Resolution Windowed
        Console.WindowHeight = Console.LargestWindowHeight
        Console.WindowWidth = Console.LargestWindowWidth
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight)
        Console.SetWindowPosition(0, 0)



        Console.Write("???: Welcome Adventurer! I shall be your super duper awesome guide for today!" & vbCrLf & "???: You can call me Mr. Mister! What is your name? ")

        strName = Console.ReadLine()

        Console.Clear()
        Console.Write("Mr. Mister: Hello " & strName & "! How old are ya? ")

        strAge = Console.ReadLine()
        If IsNumeric(strAge) = False Then
            Console.Write(vbCrLf & "Mr. Mister: Never heard of the number " & strAge & " before. You must be special! ")
        ElseIf CInt(strAge) < 0 Then
            Console.Write(vbCrLf & "Mr. Mister: You ain't even born yet? Wow that's cool! ")
        ElseIf CInt(strAge) = 0 Then
            Console.Write(vbCrLf & "Mr. Mister: Just popped into the world eh? ")
        ElseIf CInt(strAge) > 100 Then
            Console.Write(vbCrLf & "Mr. Mister: Aren't you a little too old to be alive? Ah well... ")
        Else
            Console.Write(vbCrLf & "Mr. Mister: Hey! I'm " & strAge & " years old too! ")
        End If

        Console.ReadLine()

        Console.Clear()
        Console.WriteLine("Mr. Mister: Now, are you a boy or a girl?" & vbCrLf & "<B/G>" & vbCrLf)

        strGender = Console.ReadLine()
        If UCase(strGender) = "B" Then
            Console.Write(vbCrLf & "Mr. Mister: A boy? We'll...if that's what you think then alright! ")
            strGender = "boy"
        ElseIf UCase(strGender) = "G" Then
            Console.Write(vbCrLf & "Mr. Mister: A girl? You sure don't look like one... ")
            strGender = "girl"
        Else
            Console.Write(vbCrLf & "Mr. Mister: You're a " & strGender & "? Wow you really are a special person! ")
        End If

        Console.ReadLine()

        Console.Clear()
        Console.WriteLine("Mr. Mister: Well then it's real nice to meet you " & strName & "!")
        Console.ReadLine()
        Console.WriteLine("Mr. Mister: It's a real pleasure to see another living soul out here!" & vbCrLf & "Mr. Mister: Especially one who's a " & StrConv(strGender, vbProperCase) & " and " & strAge & " years old! ")
        Console.ReadLine()

        Console.WriteLine("Mr. Mister: Well! There isn't really much to do around here so... " & vbCrLf & "Mr. Mister: How about a little fun fact?")
        Console.ReadLine()

        While blnLooper = True
            Console.Write(vbCrLf & "<Y/N>? ")
            strAntiCrasher = Console.ReadLine
            Console.Clear()
            If UCase(strAntiCrasher) = "Y" Then
                blnLooper = False
                Console.WriteLine("Mr. Mister: Alrighty then lets start!")
            ElseIf UCase(strAntiCrasher) = "N" Then
                Console.Write("Mr. Mister: Aww come on pretty please?")
            Else
                Console.Write("Mr. Mister: Sorry what did you say? I didn't quite get ya!")
            End If
        End While
        blnLooper = True

        Console.ReadLine()

        Randomize()
        Dim dblPizza As Integer = (10 * Rnd()) + 2
        Dim tempPizza1 As Double
        Dim temppizza2 As Double
        Dim intCounter As Integer = 0
        tempPizza1 = dblPizza / 2

        Console.Clear()
        Console.WriteLine("Mr. Mister: Did you know that if you started with " & dblPizza & " pizzas..." & vbCrLf & "Mr. Mister: And you ate half of it, you'd end up with " & tempPizza1 & " pizzas?")
        Console.ReadLine()

        While intCounter < (3 * Rnd()) + 2
            temppizza2 = tempPizza1 / 2
            Console.WriteLine("Mr. Mister: And if you ate half of that, you'd end up with " & temppizza2 & " pizzas...")
            Console.ReadLine()
            tempPizza1 = temppizza2 / 2
            Console.WriteLine("Mr. Mister: And if you ate half of that, you'd end up with " & tempPizza1 & " pizzas...")
            Console.ReadLine()
            intCounter += 1
        End While

        Console.WriteLine(vbCrLf & "Mr. Mister: Agh!")
        Console.ReadLine()
        Console.WriteLine(vbCrLf & "Mr. Mister has died of dysentry")
        Console.ReadLine()

        Call RealGame()

    End Sub
    Sub LoadingScreen()

        Dim aTimer As New System.Timers.Timer
        aTimer.AutoReset = True
        aTimer.Interval = 100 'Goes to a designated procedure every tenth of a second
        AddHandler aTimer.Elapsed, AddressOf TIMER 'Which procedure to pull out data from
        aTimer.Start()
        Console.ReadKey()

        Dim x As Integer

        While blnLooper = True
            Randomize()
            x = 10 * Rnd()
            Console.Write(x)
            If intTimer >= 15 Then '>= instead of = in case stupid computer "misses"
                intTimer = 0 'NOTE: For some reason, the longer you spend in "RealGame()", the shorter the loading screen time
                Call RealGame2()
            End If
        End While

    End Sub
    Sub TIMER(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        intTimer += 1
    End Sub
    Sub RealGame()

        Console.WriteLine(vbCrLf & "??? : Great, now that he's out of the way, we can start the actual game")
        Console.ReadLine()

        Console.Clear()

        Console.WriteLine("________      _____ __________ ____  __.     _________________   ____ ___.____       _________")
        Console.WriteLine("\______ \    /  _  \\______   \    |/ _|    /   _____/\_____  \ |    |   \    |     /   _____/")
        Console.WriteLine(" |    |  \  /  /_\  \|       _/      <      \_____  \  /   |   \|    |   /    |     \_____  \ ")
        Console.WriteLine(" |    `   \/    |    \    |   \    |  \     /        \/    |    \    |  /|    |___  /        \")
        Console.WriteLine("/_______  /\____|__  /____|_  /____|__ \   /_______  /\_______  /______/ |_______ \/_______  /")
        Console.WriteLine("        \/         \/       \/        \/           \/         \/                 \/        \/     2.0")

        Console.WriteLine("SELECT YOUR DIFFICULTY" & vbCrLf & "Easy/Normal/Hard/Expert")
        Console.ReadLine()

        Console.WriteLine(vbCrLf & "'Expert' DIFFICULTY SELECTED" & vbCrLf & "<Press ENTER to continue>" & vbCrLf)

        Call LoadingScreen()

    End Sub
    Sub RealGame2()
        Console.Clear()
        Dim intEmpty As Integer = 0

        Console.WriteLine("YOUR DETAILS:")
        If LTrim(RTrim(strName)) = "" Then
            Console.WriteLine("Your name: YOU HAVE NOT ENTERED ANYTHING")
            intEmpty += 1
        Else
            Console.WriteLine("Your name: " & strName)
        End If

        If LTrim(RTrim(strAge)) = "" Then
            Console.WriteLine("Your age: YOU HAVE NOT ENTERED ANYTHING")
            intEmpty += 1
        Else
            Console.WriteLine("Your age: " & strAge)
        End If

        If LTrim(RTrim(strGender)) = "" Then
            Console.WriteLine("Your gender: YOU HAVE NOT ENTERED ANYTHING")
            intEmpty += 1
        Else
            Console.WriteLine("Your gender: " & strGender & vbCrLf)
        End If

        If intEmpty = 3 Then
            Call NewCharacter()
        End If

        Console.WriteLine("Change your details? <Y/N>")

        While blnLooper = True
            strYesNo = Console.ReadLine
            If UCase(strYesNo) = "Y" Then
                Call NewCharacter()
            ElseIf UCase(strYesNo) = "N" Then
                Call RealGame3()
            Else
                Console.WriteLine("ERROR: Enter 'Y' or 'N' only")
            End If
        End While

    End Sub
    Sub NewCharacter()
        Console.Clear()


        Console.ReadLine()

    End Sub
    Sub RealGame3()
        Console.Clear()



        Console.WriteLine("RealGame3")
        Console.ReadLine()

    End Sub
End Module
