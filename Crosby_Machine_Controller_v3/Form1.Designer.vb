<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Crosby_PC_Control
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Sampling_timer = New System.Windows.Forms.Timer(Me.components)
        Me.connecting_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.refreshCOM_CB_BTN = New System.Windows.Forms.Button()
        Me.Right_BTN = New System.Windows.Forms.Button()
        Me.Left_BTN = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.receivedData_head_LBL = New System.Windows.Forms.Label()
        Me.clear_BTN = New System.Windows.Forms.Button()
        Me.connect_BTN = New System.Windows.Forms.Button()
        Me.comPort_ComboBox = New System.Windows.Forms.ComboBox()
        Me.COMport_LBL = New System.Windows.Forms.Label()
        Me.Up_BTN = New System.Windows.Forms.Button()
        Me.Down_BTN = New System.Windows.Forms.Button()
        Me.Forward_BTN = New System.Windows.Forms.Button()
        Me.Back_BTN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.X_Num = New System.Windows.Forms.NumericUpDown()
        Me.Y_Num = New System.Windows.Forms.NumericUpDown()
        Me.Z_Num = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Start_Button = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.x_dir_btn = New System.Windows.Forms.Button()
        Me.y_dir_btn = New System.Windows.Forms.Button()
        Me.z_dir_btn = New System.Windows.Forms.Button()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.X_Num, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Y_Num, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Z_Num, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Sampling_timer
        '
        Me.Sampling_timer.Interval = 500
        '
        'connecting_Timer
        '
        Me.connecting_Timer.Interval = 250
        '
        'refreshCOM_CB_BTN
        '
        Me.refreshCOM_CB_BTN.Location = New System.Drawing.Point(196, 25)
        Me.refreshCOM_CB_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.refreshCOM_CB_BTN.Name = "refreshCOM_CB_BTN"
        Me.refreshCOM_CB_BTN.Size = New System.Drawing.Size(26, 25)
        Me.refreshCOM_CB_BTN.TabIndex = 102
        Me.refreshCOM_CB_BTN.TabStop = False
        Me.refreshCOM_CB_BTN.Text = "R"
        Me.refreshCOM_CB_BTN.UseVisualStyleBackColor = True
        '
        'Right_BTN
        '
        Me.Right_BTN.Location = New System.Drawing.Point(416, 318)
        Me.Right_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Right_BTN.Name = "Right_BTN"
        Me.Right_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Right_BTN.TabIndex = 110
        Me.Right_BTN.TabStop = False
        Me.Right_BTN.Text = "Right"
        Me.Right_BTN.UseVisualStyleBackColor = True
        '
        'Left_BTN
        '
        Me.Left_BTN.Location = New System.Drawing.Point(212, 318)
        Me.Left_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Left_BTN.Name = "Left_BTN"
        Me.Left_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Left_BTN.TabIndex = 107
        Me.Left_BTN.TabStop = False
        Me.Left_BTN.Text = "Left"
        Me.Left_BTN.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(24, 85)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(154, 249)
        Me.RichTextBox1.TabIndex = 109
        Me.RichTextBox1.Text = ""
        '
        'receivedData_head_LBL
        '
        Me.receivedData_head_LBL.AutoSize = True
        Me.receivedData_head_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.receivedData_head_LBL.Location = New System.Drawing.Point(50, 63)
        Me.receivedData_head_LBL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.receivedData_head_LBL.Name = "receivedData_head_LBL"
        Me.receivedData_head_LBL.Size = New System.Drawing.Size(104, 18)
        Me.receivedData_head_LBL.TabIndex = 108
        Me.receivedData_head_LBL.Text = "Received Data"
        '
        'clear_BTN
        '
        Me.clear_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clear_BTN.Location = New System.Drawing.Point(52, 349)
        Me.clear_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.clear_BTN.Name = "clear_BTN"
        Me.clear_BTN.Size = New System.Drawing.Size(74, 30)
        Me.clear_BTN.TabIndex = 104
        Me.clear_BTN.TabStop = False
        Me.clear_BTN.Text = "Clear"
        Me.clear_BTN.UseVisualStyleBackColor = True
        '
        'connect_BTN
        '
        Me.connect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connect_BTN.Location = New System.Drawing.Point(364, 22)
        Me.connect_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.connect_BTN.Name = "connect_BTN"
        Me.connect_BTN.Size = New System.Drawing.Size(120, 30)
        Me.connect_BTN.TabIndex = 103
        Me.connect_BTN.TabStop = False
        Me.connect_BTN.Text = "Connect"
        Me.connect_BTN.UseVisualStyleBackColor = True
        '
        'comPort_ComboBox
        '
        Me.comPort_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPort_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comPort_ComboBox.FormattingEnabled = True
        Me.comPort_ComboBox.Location = New System.Drawing.Point(228, 28)
        Me.comPort_ComboBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.comPort_ComboBox.Name = "comPort_ComboBox"
        Me.comPort_ComboBox.Size = New System.Drawing.Size(122, 21)
        Me.comPort_ComboBox.TabIndex = 101
        Me.comPort_ComboBox.TabStop = False
        '
        'COMport_LBL
        '
        Me.COMport_LBL.AutoSize = True
        Me.COMport_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMport_LBL.Location = New System.Drawing.Point(248, 5)
        Me.COMport_LBL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.COMport_LBL.Name = "COMport_LBL"
        Me.COMport_LBL.Size = New System.Drawing.Size(76, 18)
        Me.COMport_LBL.TabIndex = 105
        Me.COMport_LBL.Text = "COM Port"
        '
        'Up_BTN
        '
        Me.Up_BTN.Location = New System.Drawing.Point(281, 297)
        Me.Up_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Up_BTN.Name = "Up_BTN"
        Me.Up_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Up_BTN.TabIndex = 124
        Me.Up_BTN.TabStop = False
        Me.Up_BTN.Text = "Up"
        Me.Up_BTN.UseVisualStyleBackColor = True
        '
        'Down_BTN
        '
        Me.Down_BTN.Location = New System.Drawing.Point(281, 342)
        Me.Down_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Down_BTN.Name = "Down_BTN"
        Me.Down_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Down_BTN.TabIndex = 125
        Me.Down_BTN.TabStop = False
        Me.Down_BTN.Text = "Down"
        Me.Down_BTN.UseVisualStyleBackColor = True
        '
        'Forward_BTN
        '
        Me.Forward_BTN.Location = New System.Drawing.Point(349, 297)
        Me.Forward_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Forward_BTN.Name = "Forward_BTN"
        Me.Forward_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Forward_BTN.TabIndex = 126
        Me.Forward_BTN.TabStop = False
        Me.Forward_BTN.Text = "Forward"
        Me.Forward_BTN.UseVisualStyleBackColor = True
        '
        'Back_BTN
        '
        Me.Back_BTN.Location = New System.Drawing.Point(349, 342)
        Me.Back_BTN.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Back_BTN.Name = "Back_BTN"
        Me.Back_BTN.Size = New System.Drawing.Size(58, 23)
        Me.Back_BTN.TabIndex = 127
        Me.Back_BTN.TabStop = False
        Me.Back_BTN.Text = "Back"
        Me.Back_BTN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(334, 211)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Speed"
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(238, 235)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TrackBar1.Maximum = 460
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(225, 42)
        Me.TrackBar1.TabIndex = 129
        Me.TrackBar1.TabStop = False
        '
        'X_Num
        '
        Me.X_Num.Location = New System.Drawing.Point(364, 107)
        Me.X_Num.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.X_Num.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.X_Num.Name = "X_Num"
        Me.X_Num.Size = New System.Drawing.Size(62, 20)
        Me.X_Num.TabIndex = 130
        '
        'Y_Num
        '
        Me.Y_Num.Location = New System.Drawing.Point(364, 131)
        Me.Y_Num.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Y_Num.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Y_Num.Name = "Y_Num"
        Me.Y_Num.Size = New System.Drawing.Size(62, 20)
        Me.Y_Num.TabIndex = 131
        '
        'Z_Num
        '
        Me.Z_Num.Location = New System.Drawing.Point(364, 156)
        Me.Z_Num.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Z_Num.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.Z_Num.Name = "Z_Num"
        Me.Z_Num.Size = New System.Drawing.Size(62, 20)
        Me.Z_Num.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 111)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "X-Dir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 133)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Y-Dir"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 156)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Z-Dir"
        '
        'Start_Button
        '
        Me.Start_Button.Location = New System.Drawing.Point(448, 121)
        Me.Start_Button.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Start_Button.Name = "Start_Button"
        Me.Start_Button.Size = New System.Drawing.Size(66, 34)
        Me.Start_Button.TabIndex = 136
        Me.Start_Button.TabStop = False
        Me.Start_Button.Text = "Start"
        Me.Start_Button.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(278, 63)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 20)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Finite Step Control"
        '
        'x_dir_btn
        '
        Me.x_dir_btn.Location = New System.Drawing.Point(298, 107)
        Me.x_dir_btn.Name = "x_dir_btn"
        Me.x_dir_btn.Size = New System.Drawing.Size(52, 20)
        Me.x_dir_btn.TabIndex = 138
        Me.x_dir_btn.Text = "Right"
        Me.x_dir_btn.UseVisualStyleBackColor = True
        '
        'y_dir_btn
        '
        Me.y_dir_btn.Location = New System.Drawing.Point(298, 131)
        Me.y_dir_btn.Name = "y_dir_btn"
        Me.y_dir_btn.Size = New System.Drawing.Size(52, 20)
        Me.y_dir_btn.TabIndex = 139
        Me.y_dir_btn.Text = "Forward"
        Me.y_dir_btn.UseVisualStyleBackColor = True
        '
        'z_dir_btn
        '
        Me.z_dir_btn.Location = New System.Drawing.Point(298, 156)
        Me.z_dir_btn.Name = "z_dir_btn"
        Me.z_dir_btn.Size = New System.Drawing.Size(52, 20)
        Me.z_dir_btn.TabIndex = 140
        Me.z_dir_btn.Text = "Up"
        Me.z_dir_btn.UseVisualStyleBackColor = True
        '
        'Crosby_PC_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 461)
        Me.Controls.Add(Me.z_dir_btn)
        Me.Controls.Add(Me.y_dir_btn)
        Me.Controls.Add(Me.x_dir_btn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Start_Button)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Z_Num)
        Me.Controls.Add(Me.Y_Num)
        Me.Controls.Add(Me.X_Num)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Back_BTN)
        Me.Controls.Add(Me.Forward_BTN)
        Me.Controls.Add(Me.Down_BTN)
        Me.Controls.Add(Me.Up_BTN)
        Me.Controls.Add(Me.refreshCOM_CB_BTN)
        Me.Controls.Add(Me.Right_BTN)
        Me.Controls.Add(Me.Left_BTN)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.receivedData_head_LBL)
        Me.Controls.Add(Me.clear_BTN)
        Me.Controls.Add(Me.connect_BTN)
        Me.Controls.Add(Me.comPort_ComboBox)
        Me.Controls.Add(Me.COMport_LBL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Crosby_PC_Control"
        Me.Text = "Crosby PC Control"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.X_Num, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Y_Num, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Z_Num, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Sampling_timer As Timer
    Friend WithEvents connecting_Timer As Timer
    Friend WithEvents refreshCOM_CB_BTN As Button
    Friend WithEvents Right_BTN As Button
    Friend WithEvents Left_BTN As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents receivedData_head_LBL As Label
    Friend WithEvents clear_BTN As Button
    Friend WithEvents connect_BTN As Button
    Friend WithEvents comPort_ComboBox As ComboBox
    Friend WithEvents COMport_LBL As Label
    Friend WithEvents Up_BTN As Button
    Friend WithEvents Down_BTN As Button
    Friend WithEvents Forward_BTN As Button
    Friend WithEvents Back_BTN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents X_Num As NumericUpDown
    Friend WithEvents Y_Num As NumericUpDown
    Friend WithEvents Z_Num As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Start_Button As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents x_dir_btn As Button
    Friend WithEvents y_dir_btn As Button
    Friend WithEvents z_dir_btn As Button
End Class
