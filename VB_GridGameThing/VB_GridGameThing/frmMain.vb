Option Strict On
'Imports System.Drawing 'Allows drawing to screen and graphics (May be unnecessary)

Public Class frmMain
#Region "DECLARATIONS OF INDEPENDENCES"
    'GRAPHICS VARIABLES - Info on Buffering: http://www.anandtech.com/show/2794/2 
    Dim G As Graphics       'Graphics object
    Dim BB As Bitmap        'Backbuffer bitmap
    Dim rect As Rectangle   'For drawing grid tiles
    Dim bmpAnt As Bitmap   'Ant bitmap image

    'FPS COUNTER
    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim MaxTicks As Integer = 0

    'FOR GRID
    Dim intTileSize As Integer
    Dim intNoOfTiles As Integer = 50    'from 1
    Const dblHeightRatio As Double = 0.8     '(gridlength)/(me.height)

    'MOUSE LOCATIONS
    Dim mousGridX As Integer           'GRID XY COORDINATES OF PART OF MAP SHOWN ON SCREEN
    Dim mousGridY As Integer
    Dim mousMapX As Integer            'MAP XY IS ON ACTUAL MAP
    Dim mousMapY As Integer
    Dim mousX As Integer               'GENERAL MOUSE LOCATION
    Dim mousY As Integer

    'MAP VARIABLES - Let map coordinate start on (0 , 0) so end coordinate is (Reslength - 1, Reslength - 1)
    Dim ResLength As Integer = CInt(Screen.PrimaryScreen.Bounds.Height)
    Dim Map(ResLength - 1, ResLength - 1, 1) As Integer       'ENTIRE MAP GRID (MapX,MapY,Property {0 = Colour, 1 = Ant on/off})
    Dim MapX As Integer = CInt(ResLength - 1 - intNoOfTiles)
    'Dim MapX As Integer = CInt(ResLength / 4) - 1     'WHICH PART OF MAP TO DISPLAY ON TOP LEFT SCREEN - CENTERING MAP (Note: -1 as Map's from 0 to ResLength -1)
    Dim MapY As Integer = MapX

    'PAINTBRUSH
    Dim intPaintLocation As Integer = intNoOfTiles + 1
    Dim paintBrush As Integer = 0
    Dim yPaintTop As Integer = CInt(intNoOfTiles / 2)
    Dim yPaintBtm As Integer = CInt(intNoOfTiles / 2) + 3

    'FOR ANTS
    Dim blnPlaceAnt As Boolean = False
    Dim arrAnts(10000) As clsAnt        'If Map(X,Y,1) <> 0, then it = index of arrAnts, which = direction of ant (0,1,2,3 => w,a,s,d (ANTICLOCKWISE)).    Starts at 1
    Dim intLastAnt As Integer = 0
    Dim intLastColour As Integer = 1

    'ARRAY OF COLOURS WITH DIRECTION TURN? -1D. HOW TO DO WITH COLOUR PICKER? 255R255G255B255 FOR WHITE, SOLID?


    'FOR KEY DETECTION
    Dim KeyPushed As Short = 0
    Dim MoveDir As Short = 0
    Dim LastDir As Short = 2
    Dim MoveSpeed As Integer = 30

    'ALLOWS RETRIEVING KEYSTATE (True/False when doing GetAsyncKeyState(key))
    Private Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal vKey As Integer) As Integer

    'FOR DRAGGING
    Dim M1Held As Boolean = False
    Dim mousHoldX As Integer = 0
    Dim mousHoldY As Integer = 0

#End Region

    'IDEAS:------------------------------------------------------------------------------------------------------
    'ON PROGRAM START UP (With empty grid and stuff) PUT DOWN MESSAGE INFORMING USER OF RULES OF LANGTON'S ANT AND WHAT IT IS ABOUT ON TOP OF GRID + "START" button

    'FULLSCREEN CAPABILITIES + ASPECT RATIOS?
    'On FULLSCREEN, REMAINING WIDTH (Call it OPTIONS BAR) WILL BE USED FOR COLOUR PICKER AND TURNING AND STUFF
    'MINIMUM WINDOW SIZE? - Taking into consideration how things will be displayed on the OPTIONS BAR

    'DRAGGING GRID ALONG MAP CABPABILITIES - ALSO CHANGE MOUSE CURSOR ICON
    'ABILITY TO DRAG OPTIONS BAR - INCREASE/DECREASE FOR ABSOLUTE FULLSCREEN. LOCK RIGHT SIDE OF GRID TO LEFT SIDE OF OPTIONS BAR SO NO ISSUES WHEN DRAGGING

    'FOR MOST EFFECTIVE USE OF MAP, WHEN FIRST ANT IS PLACED ON GRID, REPOSITION ENTIRE MAP TO MAKE THAT ANT ON THE CENTRE OF GRID
    '(Also prevents Yuki from dragging all the way to the left and then placing ant on the extreme left)

    'FOR ZOOMING IN/OUT GRID:
    'MIN. TILESIZE = 1 PIXEL (So same size as tilesize for MAP)
    'MAX. TILESIZE = GRID MAXLENGTH (Can remove this limitation if you're a Yuki and wants to zoom in beyond 1 tile)
    'DISPLAYING MORE "PIXELS" THAN WHAT MONITOR CAN SUPPORT? - AVG. MAP COORDINATES (E.g. If 4 tiles per pixel) BEFORE OUTPUTTING RESULT

    'DRAG AND DROP ANT? - Drag from bottom of options bar? Or have Ant Placing Mode button?

    'BY DEFAULT: (GRID MAXLENGTH = MAXHEIGHT OF MONITOR RES. = MAXLENGTH OF MAP)
    'IF ANT HIT END OF MAP, THEN STOP BUT HAVE OPTION OF CONTINUING BY RESIZE (or just MAYBE, continue on from other side, for experimental value)
    'TO INCREASE SIZE DURING RUNTIME (When ant hit end of map):
    'MAKE COPY Of CURRENT MAP
    'CREATE NEW MAP WITH NEW RESOLUTION (With custom length / increased by some multiple)
    '[NOTE: ASSUMING MONITOR HEIGHTS ARE ALL EVEN, THEN ANY INT. MULTIPLE OF IT WILL BE EVEN]
    'SLAP COPY OF MAP INTO CENTRE OF NEW MAP - IT WILL BE CENTERABLE
    'CHANGE REQUIRED VALUES TO FIT NEW MAP COORDINATES
    '[NOTE: GRID DISPLAY DOES NOT CHANGE, IT'S JUST THE MAP THAT CHANGES. USERS MAY EXPERIENCE VISIBLE LAG]

    '[NOTE TWO DIFFERENT TYPES OF RESIZE - GRID RESIZE, WINDOW RESIZE]

    'CONTENTS OF OPTION BAR
    'TWO TABS: OPTIONS TAB, STEPS TAKEN  [ALL SCROLLABLE]

    'IN OPTIONS TAB:
    'Slider for speed (=timer tick interval) + textbox to add upper + lower limits, and custom time into it (+editing limits based on that val.)
    'Import existing config. / Export current config.
    'Enable/Disable ant image
    'Grid ON/OFF (Best off for large no.ofsquares per row/column)
    'Advanced options? - Things like custom ant image (+colour to make transparent for best effect), custom tile colour, etc...
    '

    'IN STEPS TAKEN TAB:
    'Textbox? Console-style output? -May look cooler ☺  (idk about max. no. of lines)

    'WHEN TILESIZE GETS SMALLER, ANT STARTS TO DISAPPEAR. THRESHOLD? - WHEN TO STOP OUTPUTTING ANT IMAGE

    'ALLOW CUSTOM INITIAL MAP COLOUR CONFIGURATION? - E.g. Checkerboard, Random Colours (Within those chosen), etc...

    'ON EXPORT, SHOW LOG AND INFORMATION OF ANT PATTERN: RLLR, RLLRLLRLLRR, LLRLRLRLRLRLLRLLLLL, ETC...

    '☺


    'MAY CHANGE GRAPHICS DRAWING METHOD TO PICTUREBOX - IS PERSISTENT, WILL REMAIN ON SCREEN. THEN ONLY CHANGE PART OF THE BITMAP AND (INVALIDATE)? FOR EFFICIENCY
    'http://stackoverflow.com/questions/13334210/drawing-graphics-disappear-in-vb-net

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        'FORM SIZES
        Me.Size = New Size(CInt(ResLength * 0.8), CInt(ResLength * 0.8))
        'Me.MinimumSize = New Size(CInt(ResLength * 0.24), CInt(ResLength * 0.24))      'FORM SIZES
        'Me.MaximumSize = New Size(CInt(Screen.PrimaryScreen.Bounds.Width), CInt(Screen.PrimaryScreen.Bounds.Height))

        'GRID SIZES
        intTileSize = CInt((dblHeightRatio * Me.Height) / intNoOfTiles)

        'START AT MIDDLE OF MAP, CREATE NEW MAP RESOLUTION, RESIZE MAP?


        'SMOOTH RESIZE?

        'ONLY DISPLAY ODD NO. OF SQUARES (PER ROW/COLUMN) SO CENTRE SQUARE AVAILABLE

        'INITIALISE GRAPHICS OBJECTS
        G = Me.CreateGraphics
        BB = New Bitmap(ResLength, ResLength)
        bmpAnt = New Bitmap(frmGFX.pboxAnt.Image)
        bmpAnt.MakeTransparent(Color.Fuchsia)

        'STARTS SIMULATION
        TMR.Enabled = True

    End Sub

    Private Sub TMR_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TMR.Tick
        '1) Check User Input
        SetMoveDir()
        MoveGrid(MoveDir)
        '2) Run AI
        '3) Update Object Data (Object Positions, Status, etc...)
        UPDATEANTS()
        'Create array to store current locations of ants on map for much faster searching? - What if multiple ants? Oh just do first ant to move]
        '4) Check Triggers and Conditions
        '5) Draw Graphics
        DrawGraphics()
        '6) Play Sound Effects and Music

        'UPDATE TICK COUNTER
        TickCounter()
    End Sub

    Private Sub TickCounter()
        If tSec = TimeOfDay.Second Then    'Keep +1 to ticks in the same second (keeping in mind that loops more than once per sec) [ticks/sec]
            tTicks += 1
        Else
            MaxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
    End Sub

    Private Sub CREATENEWANT()
        intLastAnt += 1
        Map(mousMapX, mousMapY, 1) = intLastAnt

        arrAnts(intLastAnt) = New clsAnt
        arrAnts(intLastAnt).CREATEANT(mousMapX, mousMapY, 0)     'Create and initialise new ant (xPos, yPos, Dir)

    End Sub

    Private Sub UPDATEANTS()
        Dim intTileClr As Integer

        For i = 1 To intLastAnt
            'LOOK AT CURRENT TILE COLOUR
            intTileClr = Map(arrAnts(i).xPos, arrAnts(i).yPos, 0)

            TURNANT(intTileClr, i)

            'CHANGE TILE COLOUR
            If intTileClr = intLastColour Then      '@ Last colour
                intTileClr = 0          'Reset
            Else
                intTileClr += 1
            End If
            Map(arrAnts(i).xPos, arrAnts(i).yPos, 0) = intTileClr

            'DELETE MAP ANT NUMBERS     - ONLY IF ALLOWED TO MOVE - UPDATE LATER
            Map(arrAnts(i).xPos, arrAnts(i).yPos, 1) = 0

            'MOVE ANT FORWARDS
            Select Case arrAnts(i).intDir
                Case 0      'W
                    If arrAnts(i).yPos = 0 Then     'If going out of grid, loop back to other end - Torus shaped map
                        arrAnts(i).yPos = ResLength - 1
                    Else
                        arrAnts(i).yPos -= 1
                    End If
                Case 1      'A
                    If arrAnts(i).xPos = 0 Then
                        arrAnts(i).xPos = ResLength - 1
                    Else
                        arrAnts(i).xPos -= 1
                    End If
                Case 2      'S
                    If arrAnts(i).yPos = ResLength - 1 Then
                        arrAnts(i).yPos = 0
                    Else
                        arrAnts(i).yPos += 1
                    End If
                Case 3      'D
                    If arrAnts(i).xPos = ResLength - 1 Then
                        arrAnts(i).xPos = 0
                    Else
                        arrAnts(i).xPos += 1
                    End If
            End Select

            'UPDATE MAP ANT NUMBERS
            Map(arrAnts(i).xPos, arrAnts(i).yPos, 1) = i
        Next
    End Sub

    Private Sub TURNANT(ByVal intTileClr As Integer, ByVal i As Integer)
        Dim intAntDir As Integer = arrAnts(i).intDir

        'For i = 0 To intLastColour



        'Next

        'LRRR

        If intTileClr = 0 Then      'If = 1st colour    
            TURNLEFT(intAntDir)

        ElseIf intTileClr = 1 Then
            TURNRIGHT(intAntDir)

            'ElseIf intTileClr = 2 Then  
            '    TURNLEFT(intAntDir)

            'ElseIf intTileClr = 3 Then
            '    TURNRIGHT(intAntDir)
        End If

        arrAnts(i).intDir = intAntDir

    End Sub

    Private Sub TURNLEFT(ByRef intAntDir As Integer)
        intAntDir += 1
        If intAntDir = 4 Then       'At end of dir no.s
            intAntDir = 0           'Loop back
        End If
    End Sub

    Private Sub TURNRIGHT(ByRef intAntDir As Integer)
        intAntDir -= 1
        If intAntDir = -1 Then      'At end of dir no.s
            intAntDir = 3           'Loop back
        End If
    End Sub

    Private Sub CHANGETILECLR()

    End Sub

#Region "Draw Graphics"
    Private Sub DrawGraphics()
        '(SEE https://www.youtube.com/watch?v=nQIhfXi_8dY)

        G = Graphics.FromImage(BB)      'DRAW TO BITMAP
        G.Clear(Color.Wheat)    'Fill with colour after clearing. Fixes overdraw

        'BEGIN DRAWING
        DRAWGRID()
        DRAWGRIDINFO()
        DRAWPAINTPALETTE()
        MOUSEHOVERGRID()
        'DRAWDRAGLINE()


        'END DRAWING

        'DRAW BITMAP TO SCREEN
        Me.CreateGraphics.DrawImage(BB, 0, 0, ResLength, ResLength)
    End Sub

    Private Sub DRAWGRID()
        For X = 0 To (intNoOfTiles - 1)
            For Y = 0 To (intNoOfTiles - 1)
                rect = New Rectangle(intTileSize * X, intTileSize * Y, intTileSize, intTileSize)

                'DECIDE COLOUR OF SQUARE AND DRAW
                Select Case Map(MapX + X, MapY + Y, 0)
                    Case 0
                        G.FillRectangle(Brushes.BurlyWood, rect)
                    Case 1
                        G.FillRectangle(Brushes.Red, rect)
                    Case 2
                        G.FillRectangle(Brushes.Blue, rect)
                    Case 3
                        G.FillRectangle(Brushes.Yellow, rect)
                End Select

                'DRAW ANT IF ON
                If Map(MapX + X, MapY + Y, 1) <> 0 Then
                    G.DrawImage(bmpAnt, rect)
                End If


                'SQUARE BORDER
                'G.DrawRectangle(Pens.Black, rect)
            Next
        Next
    End Sub

    Private Sub DRAWGRIDINFO()
        'Write TICKS and MOUSE LOCATION
        G.DrawString(("Ticks: " & tTicks & vbCrLf & "TPS: " & MaxTicks & vbCrLf &
                     "Tile Size: " & intTileSize & vbCrLf & "No. of Tiles: " & intNoOfTiles & vbCrLf &
                     "Top Left Coordinate: " & "(" & MapX & " , " & MapY & ")" & vbCrLf &
                     "mousGridX: " & mousGridX & vbCrLf & "mousGridY: " & mousGridY & vbCrLf &
                     "mousMapX: " & mousMapX & vbCrLf & "mousMapY: " & mousMapY & vbCrLf &
                     "mousX: " & mousX & vbCrLf & "mousY: " & mousY & vbCrLf &
                     "mousHoldX: " & mousHoldX & vbCrLf & "mousHoldY: " & mousHoldY & vbCrLf &
                     "PaintBrush: " & paintBrush & vbCrLf &
                     "Ant placing mode: " & If(blnPlaceAnt = True, "ON", "OFF") & vbCrLf &
                     "No. of ants: " & intLastAnt),
                     Me.Font, Brushes.Black, (intTileSize * intNoOfTiles + 5), 0)

    End Sub

    Private Sub DRAWPAINTPALETTE()
        'Can replace with for loop, or with colour picker later on
        G.FillRectangle(Brushes.BurlyWood, (intTileSize * intPaintLocation), (intTileSize * yPaintTop), intTileSize, intTileSize)
        G.FillRectangle(Brushes.Red, (intTileSize * intPaintLocation), (intTileSize * (yPaintTop + 1)), intTileSize, intTileSize)
        G.FillRectangle(Brushes.Blue, (intTileSize * intPaintLocation), (intTileSize * (yPaintTop + 2)), intTileSize, intTileSize)

        'BORDER
        For i = yPaintTop To yPaintBtm
            If i = yPaintBtm And blnPlaceAnt = True Then    'HIGHLIGHTING ANT PLACEMENT MODE
                G.FillRectangle(Brushes.Yellow, (intTileSize * intPaintLocation), (intTileSize * i), intTileSize, intTileSize)
            End If
            G.DrawRectangle(Pens.Black, (intTileSize * intPaintLocation), (intTileSize * i), intTileSize, intTileSize)
        Next

        'Draw ant last
        G.DrawImage(bmpAnt, (intTileSize * intPaintLocation), (intTileSize * yPaintBtm), intTileSize, intTileSize)
    End Sub

    Private Sub MOUSEHOVERGRID()
        'Only if on designated squares
        If mousGridX <> -1 Then
            G.DrawRectangle(Pens.Red, intTileSize * mousGridX, intTileSize * mousGridY, intTileSize, intTileSize)
        End If
    End Sub

    Private Sub DRAWDRAGLINE()
        If M1Held Then
            'DRAW LINE FROM HELD POINT TO CURRENT CURSOR POINT
            G.DrawLine(New Pen(Color.Black, 2), New Point(mousHoldX, mousHoldY), New Point(mousX, mousY))
        End If
    End Sub

#End Region

#Region "Mouse Events"
    Private Sub frmMain_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseClick
        'CLICKING ON PALETTE
        If mousGridX <> -1 And mousMapX = -1 Then
            PALETTESELECT()
        End If

        'CLICKING ON GRID
        If mousMapX <> -1 Then
            'SET TILE PROPERTIES ON MAP
            Map(mousMapX, mousMapY, 0) = paintBrush
            If CInt(blnPlaceAnt) = -1 Then          'Note: -1 = TRUE, 0 = FALSE
                CREATENEWANT()
            End If
        End If
    End Sub

    Private Sub PALETTESELECT()
        If mousGridY = yPaintTop Then
            'SELECT ORIGINAL PAINTBRUSH 
            paintBrush = 0

        ElseIf mousGridY = (yPaintTop + 1) Then
            'SELECT RED PAINTBRUSH 
            paintBrush = 1

        ElseIf mousGridY = (yPaintTop + 2) Then
            'SELECT BLUE PAINTBRUSH
            paintBrush = 2

        ElseIf mousGridY = (yPaintTop + 3) Then
            'ANT
            If blnPlaceAnt = False Then
                blnPlaceAnt = True
            Else
                blnPlaceAnt = False
            End If
        End If
    End Sub

    Private Sub frmMain_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDoubleClick
        'ADD ANT IN GRID ON DOUBLE CLICK
        If mousMapX <> -1 Then
            CREATENEWANT()
        End If
    End Sub

    Private Sub frmMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left And mousMapX <> -1 Then
            M1Held = True
            mousHoldX = e.X
            mousHoldY = e.Y
        End If
    End Sub

    Private Sub frmMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            M1Held = False
            mousHoldX = 0
            mousHoldY = 0
        End If
    End Sub

    Private Sub frmMain_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        'General mouse location
        mousX = e.X
        mousY = e.Y

        If M1Held Then
            MOUSEDRAG()
        End If

        UPDATEMOUSELOCATIONS()
    End Sub

    Private Sub MOUSEDRAG()
        Dim xMousDisp As Double = ((mousX - mousHoldX) / intTileSize)           'Tiles moved from held
        Dim yMousDisp As Double = ((mousY - mousHoldY) / intTileSize)

        'GRID DRAG / TICK
        '[NOTE: FOR DRAGGING, DIRECTIONS ARE REVERSED, SO THE +Move => -Move]
        'X MOVE     - BASED ON TOP LEFT TILE
        If MapX - xMousDisp <= 0 Then       'TOO MUCH LEFT
            MapX = 0
        ElseIf MapX - xMousDisp >= ResLength - intNoOfTiles Then        'TOO MUCH RIGHT
            MapX = ResLength - intNoOfTiles
        ElseIf Math.Abs(xMousDisp) >= 1 Then            'Only update if moved greater than 1 tile
            MapX -= CInt(xMousDisp)
            mousHoldX = mousX                           'New hold to prevent continuously moving
        End If

        'Y MOVE
        If MapY - yMousDisp <= 0 Then
            MapY = 0
        ElseIf MapY - yMousDisp >= ResLength - intNoOfTiles Then
            MapY = ResLength - intNoOfTiles
        ElseIf Math.Abs(yMousDisp) >= 1 Then
            MapY -= CInt(yMousDisp)
            mousHoldY = mousY
        End If
    End Sub

    Private Sub UPDATEMOUSELOCATIONS()
        Dim tempX As Double = Math.Floor(mousX / intTileSize)
        Dim tempY As Double = Math.Floor(mousY / intTileSize)

        If (mousX < (intTileSize * intNoOfTiles) And mousY < (intTileSize * intNoOfTiles)) Then
            'IF IN GRID
            mousGridX = CInt(tempX)
            mousGridY = CInt(tempY)
            mousMapX = MapX + mousGridX
            mousMapY = MapY + mousGridY

        ElseIf (tempX = intPaintLocation And tempY >= yPaintTop And tempY <= yPaintBtm) Then

            'IF IN PALETTE
            mousGridX = CInt(tempX)
            mousGridY = CInt(tempY)
            mousMapX = -1
            mousMapY = -1

        Else
            mousGridX = -1
            mousGridY = -1
            mousMapX = -1
            mousMapY = -1
        End If
    End Sub
#End Region

#Region "Grid Movement"
    Private Function GetKeyState(ByVal KeyCheck As Integer) As Boolean
        Dim KeyState As Integer
        KeyState = GetAsyncKeyState(KeyCheck)
        'Checks if key has been pressed or not
        If KeyState = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub SetMoveDir()
        'If one of keys held down
        If GetKeyState(Keys.W) Or GetKeyState(Keys.Up) Then MoveDir = 1
        If GetKeyState(Keys.S) Or GetKeyState(Keys.Down) Then MoveDir = 2
        If GetKeyState(Keys.A) Or GetKeyState(Keys.Left) Then MoveDir = 3
        If GetKeyState(Keys.D) Or GetKeyState(Keys.Right) Then MoveDir = 4

        'Multiple keys held down
        If (GetKeyState(Keys.W) And GetKeyState(Keys.A)) Or (GetKeyState(Keys.Up) And GetKeyState(Keys.Left)) Then MoveDir = 5
        If (GetKeyState(Keys.W) And GetKeyState(Keys.D)) Or (GetKeyState(Keys.Up) And GetKeyState(Keys.Right)) Then MoveDir = 6
        If (GetKeyState(Keys.S) And GetKeyState(Keys.A)) Or (GetKeyState(Keys.Down) And GetKeyState(Keys.Left)) Then MoveDir = 7
        If (GetKeyState(Keys.S) And GetKeyState(Keys.D)) Or (GetKeyState(Keys.Down) And GetKeyState(Keys.Right)) Then MoveDir = 8

        'If none of keys held down
        If GetKeyState(Keys.W) = False And GetKeyState(Keys.Up) = False And
           GetKeyState(Keys.S) = False And GetKeyState(Keys.Down) = False And
           GetKeyState(Keys.A) = False And GetKeyState(Keys.Left) = False And
           GetKeyState(Keys.D) = False And GetKeyState(Keys.Right) = False _
       Then
            MoveDir = 0
        End If
    End Sub

    Private Sub MoveGrid(ByVal MoveDir As Short)
        Static XResist As Integer = 0
        Static YResist As Integer = 0
        'Idea is that the resistors have to be filled up equal or greater than their capacity for grid to move by one - So hold key for long enough time to move
        '+ve in one direction, -ve in other for each axis

        Debug.Print(MoveDir & " , " & LastDir & " , " & XResist & " , " & YResist)
        Select Case MoveDir
            Case 0      'No Movement
                XResist = 0
                YResist = 0
            Case 1      'W
                MoveGridUp(YResist)
            Case 2      'S
                MoveGridDown(YResist)
            Case 3      'A
                MoveGridLeft(XResist)
            Case 4      'D
                MoveGridRight(XResist)
            Case 5      'W + A
                MoveGridUp(YResist)
                MoveGridLeft(XResist)
            Case 6      'W + D
                MoveGridUp(YResist)
                MoveGridRight(XResist)
            Case 7      'S + A
                MoveGridDown(YResist)
                MoveGridLeft(XResist)
            Case 8      'S + D
                MoveGridDown(YResist)
                MoveGridRight(XResist)
        End Select

        If MoveDir <> 0 Then LastDir = MoveDir
        UPDATEMOUSELOCATIONS()
    End Sub



    'FOR MOVE GRIDS:
    'LastDir <> a AND MoveDir = a - Currently Chosen as condition to make reset (X|Y)Resist
    'IF: LastDir = a AND MoveDir = a THEN, Single-Key, Continue moving in same dir. DON'T RESET RESIST.
    'IF: LastDir <> a AND MoveDir = a THEN, NOT a to a => From single-key, change to a. RESET RESIST. From multi-key, change to a, 
    'IF: LastDir = a AND MoveDir <> a THEN, Going from dir a to Other key / Multi-Key that includes/doesn't include a
    'IF: LastDir <> a AND MoveDir <> a THEN, Going from NOT a to NOT a - Could be other key to Multi-Key inc. a?

    Private Sub MoveGridUp(ByRef YResist As Integer)
        If LastDir <> 1 And MoveDir = 1 Then
            YResist = 0
        End If
        YResist += MoveSpeed
        If YResist >= intTileSize Then
            If MapY > 0 Then
                MapY -= 1
            End If
            YResist = 0
        End If
    End Sub

    Private Sub MoveGridDown(ByRef YResist As Integer)
        If LastDir <> 2 And MoveDir = 2 Then
            YResist = 0
        End If
        YResist -= MoveSpeed
        If YResist <= intTileSize * -1 Then
            If MapY + intNoOfTiles < ResLength Then
                MapY += 1
            End If
            YResist = 0
        End If
    End Sub

    Private Sub MoveGridLeft(ByRef XResist As Integer)
        If LastDir <> 3 And MoveDir = 3 Then
            XResist = 0
        End If
        XResist -= MoveSpeed
        If XResist <= intTileSize * -1 Then
            If MapX > 0 Then
                MapX -= 1
            End If
            XResist = 0
        End If

    End Sub

    Private Sub MoveGridRight(ByRef XResist As Integer)
        If LastDir <> 4 And MoveDir = 4 Then
            XResist = 0
        End If
        XResist += MoveSpeed
        If XResist >= intTileSize Then
            If MapX + intNoOfTiles < ResLength Then
                MapX += 1
            End If
            XResist = 0
        End If
    End Sub




#End Region

    'Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    'SET NEW RESOLUTIONS - NEEDS FIXING
    'If IsRunning = True Then
    '    BB = New Bitmap(Me.Width, Me.Height)
    '    intTileSize = CInt(Math.Floor((dblHeightRatio * Me.Height) / intNoOfTiles))

    '    DrawGraphics()      'Keep this so no empty spacing on resize
    'End If

    'End Sub


    'Private Sub frmMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    '    'MOVING ENTIRE GRID
    '    Select Case e.KeyChar
    '        Case CChar("w")
    '            If MapY > 0 Then
    '                MapY -= 1
    '            End If
    '        Case CChar("a")
    '            If MapX > 0 Then
    '                MapX -= 1
    '            End If
    '        Case CChar("s")
    '            If MapY + intNoOfTiles < ResLength Then
    '                MapY += 1
    '            End If
    '        Case CChar("d")
    '            If MapX + intNoOfTiles < ResLength Then
    '                MapX += 1
    '            End If
    '    End Select
    '    UPDATEMOUSELOCATIONS()
    'End Sub
End Class
'CONTINUE: https://www.youtube.com/watch?v=69QrAV9ZWug
