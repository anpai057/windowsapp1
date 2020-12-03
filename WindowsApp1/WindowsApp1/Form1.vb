Public Class Form1
    Dim r As New Random
    Dim score As Integer

    Sub randmove(p As PictureBox)
        Dim x As Integer
        Dim y As Integer
        x = r.Next(-10, 11)
        y = r.Next(-10, 11)
        MoveTo(p, x, y)
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.R
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
                Me.Refresh()
            Case Keys.Up, Keys.W
                MoveTo(PictureBox1, 0, -5)
            Case Keys.Down, Keys.S
                MoveTo(PictureBox1, 0, +5)
            Case Keys.Left, Keys.A
                MoveTo(PictureBox1, -5, 0)
            Case Keys.Right, Keys.D
                MoveTo(PictureBox1, 5, 0)
            Case Keys.Space
                bullet.Location = pictureWIN.Location
                bullet.Visible = True
            Case Keys.Space
                Timer2.Enabled = True
                bullet.Visible = True
                bullet.Location = pictureWIN.Location

        End Select
    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)
        Dim x, y As Integer
        If p.Location.X > pictureWIN.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < PictureBox1.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub



    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean
        score = score + 1
        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        If p.Name = "PictureBox1" And Collision(p, "WIN", other) Then
            Me.BackColor = Color.Green
            other.visible = True
        End If
    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub bullet_Click(sender As Object, e As EventArgs) Handles bullet.Click
    End Sub
    Dim bDir As Integer = 5
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If bullet.Location.X < 0 Then
            bDir = 5
        End If
        MoveTo(bullet, 5, 0)


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox10wall.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox6wall_Click(sender As Object, e As EventArgs) Handles PictureBox6wall.Click

    End Sub

    Private Sub PictureBox4wall_Click(sender As Object, e As EventArgs) Handles PictureBox4wall.Click

    End Sub

    Private Sub PictureBox9wall_Click(sender As Object, e As EventArgs) Handles PictureBox9wall.Click

    End Sub

    Private Sub PictureBox13wall_Click(sender As Object, e As EventArgs) Handles PictureBox13wall.Click

    End Sub

    Private Sub PictureBox14wall_Click(sender As Object, e As EventArgs) Handles PictureBox14wall.Click

    End Sub
End Class
