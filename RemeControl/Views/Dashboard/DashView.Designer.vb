<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashView
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotalCambios = New System.Windows.Forms.Label()
        Me.lblNCambios = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnHoy = New System.Windows.Forms.Button()
        Me.btnLast7 = New System.Windows.Forms.Button()
        Me.btnLast30 = New System.Windows.Forms.Button()
        Me.btnThisMonth = New System.Windows.Forms.Button()
        Me.btnCustom = New System.Windows.Forms.Button()
        Me.btnCustomDate = New System.Windows.Forms.Button()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lime
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(16, 294)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 21)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cambios"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblTotalCambios)
        Me.Panel2.Controls.Add(Me.lblNCambios)
        Me.Panel2.Location = New System.Drawing.Point(16, 315)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 93)
        Me.Panel2.TabIndex = 1
        '
        'lblTotalCambios
        '
        Me.lblTotalCambios.AutoSize = True
        Me.lblTotalCambios.Location = New System.Drawing.Point(79, 65)
        Me.lblTotalCambios.Name = "lblTotalCambios"
        Me.lblTotalCambios.Size = New System.Drawing.Size(39, 13)
        Me.lblTotalCambios.TabIndex = 1
        Me.lblTotalCambios.Text = "Label1"
        '
        'lblNCambios
        '
        Me.lblNCambios.AutoSize = True
        Me.lblNCambios.Location = New System.Drawing.Point(79, 32)
        Me.lblNCambios.Name = "lblNCambios"
        Me.lblNCambios.Size = New System.Drawing.Size(39, 13)
        Me.lblNCambios.TabIndex = 0
        Me.lblNCambios.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Location = New System.Drawing.Point(222, 315)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 93)
        Me.Panel3.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(79, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Label1"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Lime
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(222, 294)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 21)
        Me.Panel4.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Cambios"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(428, 315)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 93)
        Me.Panel5.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(79, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Label1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(79, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Label1"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Lime
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Location = New System.Drawing.Point(428, 294)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(200, 21)
        Me.Panel6.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Cambios"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Chart1)
        Me.Panel7.Location = New System.Drawing.Point(16, 75)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(612, 213)
        Me.Panel7.TabIndex = 5
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        'Series1.ChartArea = "ChartArea1"
        'Series1.Legend = "Legend1"
        'Series1.Name = "Series1"
        'Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(612, 213)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'btnHoy
        '
        Me.btnHoy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHoy.ForeColor = System.Drawing.Color.Blue
        Me.btnHoy.Location = New System.Drawing.Point(325, 14)
        Me.btnHoy.Name = "btnHoy"
        Me.btnHoy.Size = New System.Drawing.Size(77, 23)
        Me.btnHoy.TabIndex = 7
        Me.btnHoy.Text = "Hoy"
        Me.btnHoy.UseVisualStyleBackColor = True
        '
        'btnLast7
        '
        Me.btnLast7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLast7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast7.ForeColor = System.Drawing.Color.Blue
        Me.btnLast7.Location = New System.Drawing.Point(401, 14)
        Me.btnLast7.Name = "btnLast7"
        Me.btnLast7.Size = New System.Drawing.Size(77, 23)
        Me.btnLast7.TabIndex = 8
        Me.btnLast7.Text = "Ultimos 7"
        Me.btnLast7.UseVisualStyleBackColor = True
        '
        'btnLast30
        '
        Me.btnLast30.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLast30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast30.ForeColor = System.Drawing.Color.Blue
        Me.btnLast30.Location = New System.Drawing.Point(477, 14)
        Me.btnLast30.Name = "btnLast30"
        Me.btnLast30.Size = New System.Drawing.Size(77, 23)
        Me.btnLast30.TabIndex = 9
        Me.btnLast30.Text = "Ultimos 30"
        Me.btnLast30.UseVisualStyleBackColor = True
        '
        'btnThisMonth
        '
        Me.btnThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThisMonth.ForeColor = System.Drawing.Color.Blue
        Me.btnThisMonth.Location = New System.Drawing.Point(553, 14)
        Me.btnThisMonth.Name = "btnThisMonth"
        Me.btnThisMonth.Size = New System.Drawing.Size(75, 23)
        Me.btnThisMonth.TabIndex = 10
        Me.btnThisMonth.Text = "Este mes"
        Me.btnThisMonth.UseVisualStyleBackColor = True
        '
        'btnCustom
        '
        Me.btnCustom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustom.ForeColor = System.Drawing.Color.Blue
        Me.btnCustom.Location = New System.Drawing.Point(249, 14)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(77, 23)
        Me.btnCustom.TabIndex = 6
        Me.btnCustom.Text = "Custom"
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'btnCustomDate
        '
        Me.btnCustomDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCustomDate.FlatAppearance.BorderSize = 0
        Me.btnCustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCustomDate.Location = New System.Drawing.Point(229, 14)
        Me.btnCustomDate.Name = "btnCustomDate"
        Me.btnCustomDate.Size = New System.Drawing.Size(20, 23)
        Me.btnCustomDate.TabIndex = 11
        Me.btnCustomDate.Text = "-"
        Me.btnCustomDate.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(16, 45)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpStartDate.TabIndex = 12
        Me.dtpStartDate.Value = New Date(2023, 2, 2, 0, 0, 0, 0)
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(159, 45)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(125, 20)
        Me.dtpEndDate.TabIndex = 13
        Me.dtpEndDate.Value = New Date(2023, 2, 2, 0, 0, 0, 0)
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(13, 41)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(125, 19)
        Me.lblStartDate.TabIndex = 14
        Me.lblStartDate.Text = "Feb 01 2023"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(159, 41)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(125, 19)
        Me.lblEndDate.TabIndex = 15
        Me.lblEndDate.Text = "Feb 01 2023"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DashView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.btnCustomDate)
        Me.Controls.Add(Me.btnThisMonth)
        Me.Controls.Add(Me.btnLast30)
        Me.Controls.Add(Me.btnLast7)
        Me.Controls.Add(Me.btnHoy)
        Me.Controls.Add(Me.btnCustom)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "DashView"
        Me.Size = New System.Drawing.Size(648, 418)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTotalCambios As Label
    Friend WithEvents lblNCambios As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents btnHoy As Button
    Friend WithEvents btnLast7 As Button
    Friend WithEvents btnLast30 As Button
    Friend WithEvents btnThisMonth As Button
    Friend WithEvents btnCustom As Button
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents btnCustomDate As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
End Class
