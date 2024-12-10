'Developed from the work of martyncurrey.com
'Developed from the work of martyncurrey.com
'Developed from the work of martyncurrey.com
'
'Arduino Wiring Assumption -
'
'D0,D1 - Not used.  Reserved for communications
'A0,A1 - Implemented analog inputs
'D2,D4,D9 - Digital outputs
'D10,D11,D12,D13 - Digital inputs
'D7,D8 - Reserved for Adafruit Ultimate GPS Logger Shield use
'D3,D5 - PWM analog outputs
'D6 - Servo output
'
'

Imports System
Imports System.IO.Ports

Public Class Crosby_PC_Control
    ' Global variables
    Dim comPORT As String
    Dim receivedData As String = ""
    Dim connected As Boolean = False
    Dim count = 0
    Dim File_Opened As Integer

    Dim hor_step As Boolean = False



    Dim Digital_out_D2 As String = " "
    Dim Digital_out_D4 As String = " "
    Dim Digital_out_D7 As String = " "
    Dim Digital_out_D8 As String = " "
    Dim Digital_out_D12 As String = " "
    Dim Digital_out_D13 As String = " "
    Dim Analog_out_D3 As String = " "
    Dim Analog_out_D5 As String = " "
    Dim Analog_out_D6 As String = " "

    Dim Filename As String = " "
    Dim start_time As Double
    Dim current_time As Double


    ' When the program starts; make sure the timer is off (not really needed) and add the available COM ports to the COMport drop down list
    Private Sub Crosby_PC_Control_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Sampling_timer.Enabled = False
        File_Opened = 0
        start_time = (DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds 'unix time

        Me.Text = "Test Bench Controller"

        Me.KeyPreview = True
        populateCOMport()
    End Sub

    'The refresh button updates the COMport list
    Private Sub refreshCOM_BTN_Click(sender As Object, e As EventArgs) Handles refreshCOM_CB_BTN.Click
        SerialPort1.Close()
        populateCOMport()
    End Sub

    Private Sub populateCOMport()
        comPORT = ""
        comPort_ComboBox.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            comPort_ComboBox.Items.Add(sp)
        Next
    End Sub

    Private Sub comPort_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPort_ComboBox.SelectedIndexChanged
        If (comPort_ComboBox.SelectedItem <> "") Then
            comPORT = comPort_ComboBox.SelectedItem
        End If
    End Sub

    ' When the Connect button is clicked; if a COM port has been selected, connect and send out a HELLO message.
    ' Then wait for the Arduino to respond with its own HELLO.
    ' When the HELLO is received we are connected; change the button text to Dis-connect.
    Private Sub connect_BTN_Click(sender As Object, e As EventArgs) Handles connect_BTN.Click
        comPORT = comPort_ComboBox.SelectedItem
        If (connect_BTN.Text = "Connect") Then
            If (comPORT <> "") Then
                SerialPort1.Close()
                SerialPort1.PortName = comPORT
                SerialPort1.BaudRate = 9600
                SerialPort1.DataBits = 8
                SerialPort1.Parity = Parity.None
                SerialPort1.StopBits = StopBits.One
                SerialPort1.Handshake = Handshake.None
                SerialPort1.Encoding = System.Text.Encoding.Default
                SerialPort1.ReadTimeout = 10000

                SerialPort1.Open()

                'See if the Arduino is there
                count = 0
                SerialPort1.WriteLine("<HELLO>")
                connect_BTN.Text = "Connecting..."
                connecting_Timer.Enabled = True
            Else
                MsgBox("Select a COM port first")
            End If
        Else
            'connect_BTN.Text = "Dis-connect"
            'close the connection a reset the button and timer label
            Sampling_timer.Enabled = False
            SerialPort1.Close()
            connected = False
            connect_BTN.Text = "Connect"
            populateCOMport()
        End If


    End Sub

    'The connecting_Timer waits for the Arduino to say HELLO.
    ' If HELLO is not received in 2 seconds display an error message.
    ' The connecting_Timer is only used for connecting

    Private Sub connecting_Timer_Tick(sender As Object, e As EventArgs) Handles connecting_Timer.Tick
        connecting_Timer.Enabled = False
        count = count + 1

        If (count <= 8) Then
            receivedData = receivedData & ReceiveSerialData()

            If (Microsoft.VisualBasic.Left(receivedData, 5) = "HELLO") Then
                'if we get an HELLO from the Arduino then we are connected
                connected = True
                connect_BTN.Text = "Dis-connect"
                Sampling_timer.Enabled = False
                receivedData = ReceiveSerialData()
                receivedData = ""
                SerialPort1.WriteLine("<START>")

            Else
                'start the timer again and keep waiting for a signal from the Arduino
                connecting_Timer.Enabled = True
            End If


        Else
            'time out (8 * 250 = 2 seconds)
            RichTextBox1.Text &= vbCrLf & "ERROR" & vbCrLf & "Can not connect" & vbCrLf
            connect_BTN.Text = "Connect"
            populateCOMport()
        End If



    End Sub



    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                Return "nothing" & vbCrLf
            Else
                Return Incoming
            End If
        Catch ex As TimeoutException
            Return "Error: Serial Port read timed out."
        End Try

    End Function


    'Clear the RecievedDtaa test box
    Private Sub clear_BTN_Click(sender As Object, e As EventArgs) Handles clear_BTN.Click
        RichTextBox1.Text = ""
    End Sub


    Private Sub Right_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Right_BTN.MouseDown
        SerialPort1.WriteLine("<P002ON>")
        SerialPort1.WriteLine("<P004OF>")
    End Sub

    Private Sub Right_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Right_BTN.MouseUp
        SerialPort1.WriteLine("<P004ON>")
    End Sub

    Private Sub Left_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Left_BTN.MouseDown
        SerialPort1.WriteLine("<P002OF>")
        SerialPort1.WriteLine("<P004OF>")
    End Sub

    Private Sub Left_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Left_BTN.MouseUp
        SerialPort1.WriteLine("<P004ON>")
    End Sub

    Private Sub Up_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Up_BTN.MouseDown
        SerialPort1.WriteLine("<P007OF>")
        SerialPort1.WriteLine("<P008OF>")
    End Sub

    Private Sub Up_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Up_BTN.MouseUp
        SerialPort1.WriteLine("<P008ON>")
    End Sub

    Private Sub Down_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Down_BTN.MouseDown
        SerialPort1.WriteLine("<P007ON>")
        SerialPort1.WriteLine("<P008OF>")
    End Sub

    Private Sub Down_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Down_BTN.MouseUp
        SerialPort1.WriteLine("<P008ON>")
    End Sub

    Private Sub Forward_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Forward_BTN.MouseDown
        SerialPort1.WriteLine("<P012OF>")
        SerialPort1.WriteLine("<P013OF>")
    End Sub

    Private Sub Forward_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Forward_BTN.MouseUp
        SerialPort1.WriteLine("<P013ON>")
    End Sub

    Private Sub Back_BTN_MouseDown(sender As Object, e As MouseEventArgs) Handles Back_BTN.MouseDown
        SerialPort1.WriteLine("<P012ON>")
        SerialPort1.WriteLine("<P013OF>")
    End Sub

    Private Sub Back_BTN_MouseUp(sender As Object, e As MouseEventArgs) Handles Back_BTN.MouseUp
        SerialPort1.WriteLine("<P013ON>")
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim tmp As String = ""
        tmp = "<I" + (500 - TrackBar1.Value).ToString("D3") + ">"
        Console.WriteLine(tmp)
        SerialPort1.WriteLine(tmp)
    End Sub

    Private Sub Crosby_PC_Control_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        System.Diagnostics.Debug.WriteLine(e.KeyValue)


        Select Case e.KeyValue
            Case 39
                SerialPort1.WriteLine("<P002ON>")
                SerialPort1.WriteLine("<P004OF>")
            Case 37
                SerialPort1.WriteLine("<P002OF>")
                SerialPort1.WriteLine("<P004OF>")
            Case 38
                SerialPort1.WriteLine("<P007OF>")
                SerialPort1.WriteLine("<P008OF>")
            Case 40
                SerialPort1.WriteLine("<P007ON>")
                SerialPort1.WriteLine("<P008OF>")
        End Select

    End Sub

    Private Sub Crosby_PC_Control_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyValue
            Case 39
                SerialPort1.WriteLine("<P004ON>")
            Case 37
                SerialPort1.WriteLine("<P004ON>")
            Case 38
                SerialPort1.WriteLine("<P008ON>")
            Case 40
                SerialPort1.WriteLine("<P008ON>")
        End Select
    End Sub

    Private Sub Start_Button_Click(sender As Object, e As EventArgs) Handles Start_Button.Click
        Dim x As String = X_Num.Value.ToString("000")
        Dim y As String = Y_Num.Value.ToString("000")
        Dim z As String = Z_Num.Value.ToString("000")

        Dim x_dir As String = x_dir_btn.Text.Substring(0, 1)
        Dim y_dir As String = y_dir_btn.Text.Substring(0, 1)
        Dim z_dir As String = z_dir_btn.Text.Substring(0, 1)


        SerialPort1.WriteLine("<F" + x_dir + x + y_dir + y + z_dir + z + ">")
        System.Console.WriteLine("<F" + x_dir + x + y_dir + y + z_dir + z + ">")
    End Sub

    Private Sub x_dir_btn_Click(sender As Object, e As EventArgs) Handles x_dir_btn.Click
        If (x_dir_btn.Text.Equals("Right")) Then
            x_dir_btn.Text = "Left"
        Else
            x_dir_btn.Text = "Right"
        End If
    End Sub

    Private Sub y_dir_btn_Click(sender As Object, e As EventArgs) Handles y_dir_btn.Click
        If (y_dir_btn.Text.Equals("Forward")) Then
            y_dir_btn.Text = "Back"
        Else
            y_dir_btn.Text = "Forward"
        End If
    End Sub

    Private Sub z_dir_btn_Click(sender As Object, e As EventArgs) Handles z_dir_btn.Click
        If (z_dir_btn.Text.Equals("Up")) Then
            z_dir_btn.Text = "Down"
        Else
            z_dir_btn.Text = "Up"
        End If
    End Sub
End Class