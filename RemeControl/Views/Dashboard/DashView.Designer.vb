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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotalCambios = New System.Windows.Forms.Label()
        Me.lblNCambios = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTotalMensual = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblOrdenReady = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
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
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblTotalCambios)
        Me.Panel2.Controls.Add(Me.lblNCambios)
        Me.Panel2.Location = New System.Drawing.Point(16, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 109)
        Me.Panel2.TabIndex = 1
        '
        'lblTotalCambios
        '
        Me.lblTotalCambios.AutoSize = True
        Me.lblTotalCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCambios.Location = New System.Drawing.Point(3, 64)
        Me.lblTotalCambios.Name = "lblTotalCambios"
        Me.lblTotalCambios.Size = New System.Drawing.Size(71, 20)
        Me.lblTotalCambios.TabIndex = 1
        Me.lblTotalCambios.Text = "Cambios"
        '
        'lblNCambios
        '
        Me.lblNCambios.AutoSize = True
        Me.lblNCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNCambios.Location = New System.Drawing.Point(3, 33)
        Me.lblNCambios.Name = "lblNCambios"
        Me.lblNCambios.Size = New System.Drawing.Size(66, 20)
        Me.lblNCambios.TabIndex = 0
        Me.lblNCambios.Text = "Clientes"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblTotalMensual)
        Me.Panel3.Location = New System.Drawing.Point(16, 202)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(205, 58)
        Me.Panel3.TabIndex = 3
        '
        'lblTotalMensual
        '
        Me.lblTotalMensual.AutoSize = True
        Me.lblTotalMensual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMensual.Location = New System.Drawing.Point(3, 33)
        Me.lblTotalMensual.Name = "lblTotalMensual"
        Me.lblTotalMensual.Size = New System.Drawing.Size(27, 20)
        Me.lblTotalMensual.TabIndex = 1
        Me.lblTotalMensual.Text = "??"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total mensual"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblOrdenReady)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(16, 260)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(205, 51)
        Me.Panel5.TabIndex = 3
        '
        'lblOrdenReady
        '
        Me.lblOrdenReady.AutoSize = True
        Me.lblOrdenReady.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdenReady.Location = New System.Drawing.Point(3, 24)
        Me.lblOrdenReady.Name = "lblOrdenReady"
        Me.lblOrdenReady.Size = New System.Drawing.Size(27, 20)
        Me.lblOrdenReady.TabIndex = 1
        Me.lblOrdenReady.Text = "??"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 24)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Numero de ordenes"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Chart1)
        Me.Panel7.Location = New System.Drawing.Point(16, 319)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(536, 213)
        Me.Panel7.TabIndex = 5
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(612, 213)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'btnHoy
        '
        Me.btnHoy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHoy.ForeColor = System.Drawing.Color.Blue
        Me.btnHoy.Location = New System.Drawing.Point(399, 14)
        Me.btnHoy.Name = "btnHoy"
        Me.btnHoy.Size = New System.Drawing.Size(77, 23)
        Me.btnHoy.TabIndex = 7
        Me.btnHoy.Text = "Hoy"
        Me.btnHoy.UseVisualStyleBackColor = True
        '
        'btnLast7
        '
        Me.btnLast7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnLast7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast7.ForeColor = System.Drawing.Color.Blue
        Me.btnLast7.Location = New System.Drawing.Point(475, 14)
        Me.btnLast7.Name = "btnLast7"
        Me.btnLast7.Size = New System.Drawing.Size(77, 23)
        Me.btnLast7.TabIndex = 8
        Me.btnLast7.Text = "Ultimos 7"
        Me.btnLast7.UseVisualStyleBackColor = True
        '
        'btnLast30
        '
        Me.btnLast30.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnLast30.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast30.ForeColor = System.Drawing.Color.Blue
        Me.btnLast30.Location = New System.Drawing.Point(551, 14)
        Me.btnLast30.Name = "btnLast30"
        Me.btnLast30.Size = New System.Drawing.Size(77, 23)
        Me.btnLast30.TabIndex = 9
        Me.btnLast30.Text = "Ultimos 30"
        Me.btnLast30.UseVisualStyleBackColor = True
        '
        'btnThisMonth
        '
        Me.btnThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThisMonth.ForeColor = System.Drawing.Color.Blue
        Me.btnThisMonth.Location = New System.Drawing.Point(627, 14)
        Me.btnThisMonth.Name = "btnThisMonth"
        Me.btnThisMonth.Size = New System.Drawing.Size(75, 23)
        Me.btnThisMonth.TabIndex = 10
        Me.btnThisMonth.Text = "Este mes"
        Me.btnThisMonth.UseVisualStyleBackColor = True
        '
        'btnCustom
        '
        Me.btnCustom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustom.ForeColor = System.Drawing.Color.Blue
        Me.btnCustom.Location = New System.Drawing.Point(323, 14)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(77, 23)
        Me.btnCustom.TabIndex = 6
        Me.btnCustom.Text = "Custom"
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'btnCustomDate
        '
        Me.btnCustomDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnCustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCustomDate.Location = New System.Drawing.Point(303, 14)
        Me.btnCustomDate.Name = "btnCustomDate"
        Me.btnCustomDate.Size = New System.Drawing.Size(20, 23)
        Me.btnCustomDate.TabIndex = 11
        Me.btnCustomDate.Text = "-"
        Me.btnCustomDate.UseVisualStyleBackColor = True
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(16, 21)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpStartDate.TabIndex = 12
        Me.dtpStartDate.Value = New Date(2023, 2, 2, 0, 0, 0, 0)
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(159, 21)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(125, 20)
        Me.dtpEndDate.TabIndex = 13
        Me.dtpEndDate.Value = New Date(2023, 2, 2, 0, 0, 0, 0)
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(13, 18)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(125, 19)
        Me.lblStartDate.TabIndex = 14
        Me.lblStartDate.Text = "Feb 01 2023"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(159, 18)
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
        Me.BackColor = System.Drawing.Color.White
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
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "DashView"
        Me.Size = New System.Drawing.Size(776, 535)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblTotalCambios As Label
    Friend WithEvents lblNCambios As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblTotalMensual As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblOrdenReady As Label
    Friend WithEvents Label6 As Label
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
